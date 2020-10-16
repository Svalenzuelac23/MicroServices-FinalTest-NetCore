using MS.AFORO255.Cross.RabbitMQ.Src.Commands;
using System;

namespace AFORO255.MS.TEST.Pay.RabbitMQ.Commands
{
    public class PaymentCommand : Command
    {       
        public int TransactionId { get; set; }       
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
