using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AFORO255.MS.TEST.Transaction.Model
{
    public class Transaction
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int TransactionId { get; set; }
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
