using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Pay.Model
{
    public class Pay
    {
        [Key]
        [Column("id_operation")]
        public int TransactionId { get; set; }
        [Column("id_invoice")]
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
