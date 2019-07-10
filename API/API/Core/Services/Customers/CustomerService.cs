using API.Core.DomainModels;
using API.Infrastructure.EF.Repositories;
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
    }
}
