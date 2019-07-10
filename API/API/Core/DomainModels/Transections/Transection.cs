using API.Core.DomainModels.Transections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Core.DomainModels
{
    public class Transection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public Status Status { get; set; }
    }
}
