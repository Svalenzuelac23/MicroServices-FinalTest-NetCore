using MS.AFORO255.Cross.RabbitMQ.Src.Events;

namespace AFORO255.MS.TEST.Invoices.RabbitMQ.Events
{
    public class PaymentCreatedEvent : Event
    {
        public PaymentCreatedEvent(int invoiceId, decimal amount, int state)
        {
            InvoiceId = invoiceId;
            Amount = amount;
            State = state;
        }
        
        public int InvoiceId { get; set; }       
        public decimal Amount { get; set; }       
        public int State { get; set; }
    }
}
