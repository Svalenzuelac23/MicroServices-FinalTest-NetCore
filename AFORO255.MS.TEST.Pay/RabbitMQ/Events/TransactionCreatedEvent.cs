using MS.AFORO255.Cross.RabbitMQ.Src.Events;
using System;

namespace AFORO255.MS.TEST.Pay.RabbitMQ.Events
{
    public class TransactionCreatedEvent : Event
    {
        public TransactionCreatedEvent(int transactionId, int invoiceId, decimal amount, DateTime date)
        {
            TransactionId = transactionId;
            InvoiceId = invoiceId;
            Amount = amount;
            Date = date;
        }
        public int TransactionId { get; set; }
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }

}

