﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using WebAPI.Infrastructure.EF;

namespace API.Infrastructure.EF.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public AssignmentDbContext context { get; set; }

        public CustomerRepository(AssignmentDbContext context)
        {
            this.context = context;
        }

        public async Task<Customer> GetById(int customerId)
        {
            return await context.Customers.SingleOrDefaultAsync(_ => _.Id == customerId);
        }

        public async Task<Customer> GetByEmailAddress(string emailAddr)
        {
            return await context.Customers.Include(_ => _.Transactions).SingleOrDefaultAsync(_ => _.ContactEmail == emailAddr);
        }
    }
}
