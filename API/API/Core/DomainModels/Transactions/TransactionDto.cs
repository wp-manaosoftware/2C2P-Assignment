using API.Core.DomainModels.Base;
using API.Core.DomainModels.Transactions;
using System;

namespace API.Core.DomainModels
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public Decimal Amount
        {
            get { return Math.Round(_amount, 2); }
            set { _amount = value; }
        }
        public Status Status { get; set; }
        public string FormattedTransactionDate => GetFormattedTransactionDate();
        public DateTimeOffset TransactionDate { get; set; }
        private string GetFormattedTransactionDate()
        {
            return TransactionDate.ToString("dd/MM/yyyy HH:MM");
        }
        private Decimal _amount { get; set; }
}
}
