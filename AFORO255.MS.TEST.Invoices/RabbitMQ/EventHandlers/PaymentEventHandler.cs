using AFORO255.MS.TEST.Invoices.RabbitMQ.Events;
using AFORO255.MS.TEST.Invoices.Service;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Invoices.RabbitMQ.EventHandlers
{
    public class PaymentEventHandler : IEventHandler<PaymentCreatedEvent>
    {
        private readonly IInvoiceService _service;

        public PaymentEventHandler(
            IInvoiceService service
            )
        {
            _service = service;
        }
        public Task Handle(PaymentCreatedEvent @event)
        {
            _service.ChangeState(new Model.Invoice()
            {
                Amount = @event.Amount,
                InvoiceId = @event.InvoiceId,
                State = 2
            });

            return Task.CompletedTask;
        }
    }
}
