using API.Core.DomainModels.Base;
using API.Core.DomainModels.Transections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Core.DomainModels
{
    public class Transection : EntityBase
    {
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public Decimal Amount { get; set; }
        public Status Status { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
    }
}
