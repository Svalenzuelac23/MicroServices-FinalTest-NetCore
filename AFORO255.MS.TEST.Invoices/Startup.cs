using AFORO255.MS.TEST.Invoices.RabbitMQ.EventHandlers;
using AFORO255.MS.TEST.Invoices.RabbitMQ.Events;
using AFORO255.MS.TEST.Invoices.Repository;
using AFORO255.MS.TEST.Invoices.Repository.Data;
using AFORO255.MS.TEST.Invoices.Service;
using Consul;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.AFORO255.Cross.Consul.Consul;
using MS.AFORO255.Cross.Consul.Mvc;
using MS.AFORO255.Cross.RabbitMQ.Src;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;

namespace AFORO255.MS.TEST.Invoices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ContextDatabase>(opt =>
            {
                opt.UseNpgsql(Configuration["cnpostgres"]);
            });
            services.AddScoped<IContextDatabase, ContextDatabase>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceService, InvoiceService>();

            //RabbitMQ
            services.AddMediatR(typeof(Startup));
            services.AddRabbitMQ();
            services.AddTransient<PaymentEventHandler>();
            services.AddTransient<IEventHandler<PaymentCreatedEvent>, PaymentEventHandler>();
            //RabbitMQ

            //Consul
            services.AddSingleton<IServiceId, ServiceId>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddConsul();
            //Consul

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env
            , IHostApplicationLifetime hostApplicationLifetime, IConsulClient consultClient
            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Consul
            var serviceId = app.UseConsul();
            hostApplicationLifetime.ApplicationStopped.Register(() =>
            {
                consultClient.Agent.ServiceDeregister(serviceId);
            });
            //Consul

            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<PaymentCreatedEvent, PaymentEventHandler>();
        }
    }
}
