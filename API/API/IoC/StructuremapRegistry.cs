using API.Infrastructure.EF.Repositories;
using API.Infrastructure.EF.Services;
using API.ValidationServices;
using StructureMap;

namespace API.IoC
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            For<ICustomerRepository>().Use<CustomerRepository>();
            For<ICustomerService>().Use<CustomerService>();
            For<ICustomerValidationService>().Use<CustomerValidationService>();
        }        
    }
}
