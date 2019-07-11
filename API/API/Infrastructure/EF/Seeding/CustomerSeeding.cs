using API.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Infrastructure.EF;

namespace API.Infrastructure.EF.Seeding
{
    public static class CustomerSeeding
    {
        public static void Seed(AssignmentDbContext context)
        {
            var customer1 = new Customer()
            {
                Name = "Customer1",
                ContactEmail = "customer1@customer.com",
                MobileNo = "(+66)1150",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var customer2 = new Customer()
            {
                Name = "Customer2",
                ContactEmail = "customer2@customer.com",
                MobileNo = "(+66)1112",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            context.Add(customer1);
            context.Add(customer2);
            context.SaveChanges();
        }
    }
}
