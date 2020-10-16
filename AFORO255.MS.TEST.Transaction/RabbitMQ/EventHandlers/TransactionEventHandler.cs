using AFORO255.MS.TEST.Transaction.RabbitMQ.Events;
using AFORO255.MS.TEST.Transaction.Service;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using System.Threading.Tasks;

namespace AFORO255.MS.TEST.Transaction.RabbitMQ.EventHandlers
{
    public class TransactionEventHandler : IEventHandler<TransactionCreatedEvent>
    {
        private readonly ITransactionService _service;

        public TransactionEventHandler(
            ITransactionService service
            )
        {
            _service = service;
        }
        public Task Handle(TransactionCreatedEvent @event)
        {
            _service.Add(new Model.Transaction()
            {
                TransactionId = @event.TransactionId,
                InvoiceId = @event.InvoiceId,
                Amount = @event.Amount,
                Date = @event.Date
            }) ;


            return Task.CompletedTask;
        }
    }
}
