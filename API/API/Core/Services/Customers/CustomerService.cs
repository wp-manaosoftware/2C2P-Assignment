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
            {
                var latestTransection = customer.Transactions.OrderByDescending(_ => _.TransactionDate).FirstOrDefault();

                customer.Transactions = new Collection<Transaction>();
                customer.Transactions.Add(latestTransection);
            }

            return customer;
        }
    }
}
