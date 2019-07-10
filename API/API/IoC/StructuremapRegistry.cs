using API.Infrastructure.EF.Repositories;
using API.Infrastructure.EF.Services;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.IoC
{
    public class StructuremapRegistry : Registry
    {
        public StructuremapRegistry()
        {
            For<ICustomerRepository>().Use<CustomerRepository>();
            For<ICustomerService>().Use<CustomerService>();
        }

        
    }
}
