using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Core.DomainModels;
using API.Infrastructure.EF.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService customerService { get; }
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        
        [HttpGet("{customerId}")]
        public async Task<ActionResult<Customer>> GetById(int customerId)
        {
            return await customerService.GetById(customerId);
        }
    }
}
