using API.Core.DomainModels.Base;
using API.Core.DomainModels.Transactions;
using System;

namespace API.Core.DomainModels
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public Decimal Amount { get; set; }
        public Status Status { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
    }
}
