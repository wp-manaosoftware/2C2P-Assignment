using API.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure.EF.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(int id);
        Task<Customer> GetByEmailAddress(string emailAddr);
    }
}
