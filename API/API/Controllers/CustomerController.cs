
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Core.DomainModels.Customers;
using API.Core.Models.Results;
using API.Infrastructure.EF.Services;
using API.Validations;
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
        public async Task<ActionResult<Result<CustomerDTO>>> GetById(int customerId)
        {
            var validateResult = CustomerValidationService.ValidateId(customerId);
            if (!validateResult.Success)
            {
                var errorResult = Result<CustomerDTO>.MakeFail(validateResult);
                return BadRequest(errorResult);
            }

            var customer =  await customerService.GetById(customerId);
            if (customer != null)
            {
                var dto = customer.ToDTO();
                var result = Result<CustomerDTO>.MakeSuccess(dto);
                return result;
            }

            return NotFound();
        }
    }
}
