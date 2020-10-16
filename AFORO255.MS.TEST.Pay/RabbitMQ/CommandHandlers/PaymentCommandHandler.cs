using AFORO255.MS.TEST.Pay.RabbitMQ.Commands;
using AFORO255.MS.TEST.Pay.RabbitMQ.Events;
using MediatR;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Pay.RabbitMQ.CommandHandlers
{
    public class PaymentCommandHandler : IRequestHandler<PaymentCreateCommand, bool>
    {
        private readonly IEventBus _bus;

        public PaymentCommandHandler(
            IEventBus bus
            )
        {
            _bus = bus;
        }

        public Task<bool> Handle(PaymentCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new PaymentCreatedEvent(
                request.TransactionId,
                request.InvoiceId,
                request.Amount,
                request.Date
                ));

            return Task.FromResult(true);
        }
    }
}
