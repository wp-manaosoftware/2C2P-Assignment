using API.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure.EF.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetById(int customerId);
        Task<Customer> GetByEmailAddress(string emailAddr);
        Task<Customer> GetByEmailAddressAndId(string emailAddr, int customerId);
    }
}
