using AFORO255.MS.TEST.Pay.RabbitMQ.Commands;
using AFORO255.MS.TEST.Pay.RabbitMQ.Events;
using MediatR;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Pay.RabbitMQ.CommandHandlers
{
    public class TransactionCommandHandler : IRequestHandler<TransactionCreateCommand, bool>
    {
        private readonly IEventBus _bus;

        public TransactionCommandHandler(
            IEventBus bus
            )
        {
            _bus = bus;
        }

        public Task<bool> Handle(TransactionCreateCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new TransactionCreatedEvent(
                request.TransactionId,
                request.InvoiceId,
                request.Amount,
                request.Date
                ));

            return Task.FromResult(true);
        }
    }
}
