using System;

namespace AFORO255.MS.TEST.Transaction.DTO
{
    public class TransactionResponse
    {
        public int TransactionId { get; set; }
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
