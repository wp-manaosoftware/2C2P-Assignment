using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Core.DomainModels.Customers
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public string MobileNo { get; set; }
        public List<TransactionDTO> Transactions { get; set; }
    }
}
