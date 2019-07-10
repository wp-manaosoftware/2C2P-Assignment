using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Core.DomainModels.Customers
{
    public static class CustomerExtension
    {
        public static CustomerDTO ToDTO(this Customer customer)
        {
            var transactions = new List<TransactionDTO>();
            foreach (var t in customer.Transactions)
            {
                var dto = Transaction.Cast(t);
                transactions.Add(dto);
            }

            return new CustomerDTO()
            {
                Id = customer.Id,
                Name = customer.Name,
                MobileNo = customer.MobileNo,
                ContactEmail = customer.ContactEmail,
                Transactions = transactions
            };
        }
    }
}
