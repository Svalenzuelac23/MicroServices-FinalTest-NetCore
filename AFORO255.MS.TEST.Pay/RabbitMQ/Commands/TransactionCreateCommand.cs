using System;

namespace AFORO255.MS.TEST.Pay.RabbitMQ.Commands
{
    public class TransactionCreateCommand : TransactionCommand
    {
        public TransactionCreateCommand(int transactionId, int invoiceId, decimal amount, DateTime date)
        {
            TransactionId = transactionId;
            InvoiceId = invoiceId;
            Amount = amount;
            Date = date;           
        }      
    }
}
