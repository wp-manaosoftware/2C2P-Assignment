using API.Core.DomainModels;
using API.Infrastructure.EF.Repositories;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure.EF.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository customerRepository { get; }
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<Customer> GetById(int customerId)
        {
            return await customerRepository.GetById(customerId);
        }

        public async Task<Customer> GetByEmailAddress(string emailAddr)
        {
            var customer = await customerRepository.GetByEmailAddress(emailAddr);
            if (customer != null)
                customer.Transactions = customer.Transactions.OrderByDescending(_ => _.TransactionDate).Take(5).ToList();

            return customer;
        }

        public async Task<Customer> GetByEmailAddressAndId(string emailAddr, int customerId)
        {
            var customer = await customerRepository.GetByEmailAddressAndId(emailAddr, customerId);
            if (customer != null)
                customer.Transactions = customer.Transactions.OrderByDescending(_ => _.Id).Take(5).ToList();

            return customer;
        }
    }
}
