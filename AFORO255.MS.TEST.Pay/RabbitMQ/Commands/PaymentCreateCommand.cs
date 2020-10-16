using System;

namespace AFORO255.MS.TEST.Pay.RabbitMQ.Commands
{
    public class PaymentCreateCommand : PaymentCommand
    {
        public PaymentCreateCommand(int transactionId, int invoiceId, decimal amount, DateTime date)
        {
            TransactionId = transactionId;
            InvoiceId = invoiceId;
            Amount = amount;
            Date = date;           
        }      
    }
}
