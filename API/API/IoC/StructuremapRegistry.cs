using API.Infrastructure.EF.Repositories;
using API.Infrastructure.EF.Services;
using API.Validations;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.IoC
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            For<ICustomerRepository>().Use<CustomerRepository>();
            For<ICustomerService>().Use<CustomerService>();
            For<ICustomerValidationService>.Use<CustomerValidationService>();
        }

        
    }
}
