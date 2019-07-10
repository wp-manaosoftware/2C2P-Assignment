
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Core.DomainModels.Customers;
using API.Core.Models.Results;
using API.Infrastructure.EF.Services;
using API.ValidationServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService customerService { get; }
        private ICustomerValidationService customerValidation { get; }
        public CustomerController(ICustomerService customerService, ICustomerValidationService customerValidation)
        {
            this.customerService = customerService;
            this.customerValidation = customerValidation;
        }
        
        [HttpGet("{customerId}")]
        public async Task<ActionResult<Result<CustomerDTO>>> GetById(int customerId)
        {
            var validateResult = customerValidation.ValidateId(customerId);
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

        [HttpGet("GetByEmailAddress")]
        public async Task<ActionResult<Result<CustomerDTO>>> GetByEmailAddress([FromQuery]string emailAddr)
        {
            var validateResult = customerValidation.ValidateEmailAddress(emailAddr);
            if (!validateResult.Success)
            {
                var errorResult = Result<CustomerDTO>.MakeFail(validateResult);
                return BadRequest(errorResult);
            }

            var customer = await customerService.GetByEmailAddress(emailAddr);
            if (customer != null)
            {
                var dto = customer.ToDTO();
                var result = Result<CustomerDTO>.MakeSuccess(dto);
                return result;
            }

            return NotFound();
        }

        [HttpGet("GetByEmailAddressAndId")]
        public async Task<ActionResult<Result<CustomerDTO>>> GetByEmailAddressAndId([FromQuery]string emailAddr, int customerId)
        {
            var validateBothEmptyResult = customerValidation.ValidateEmailAddressAndIdBothEmpty(emailAddr, customerId);
            if (!validateBothEmptyResult.Success)
            {
                var errorResult = Result<CustomerDTO>.MakeFail(validateBothEmptyResult);
                return BadRequest(errorResult);
            }

            var validateResult = customerValidation.ValidateEmailAddressAndId(emailAddr, customerId);
            if (!validateResult.Success)
            {
                var errorResult = Result<CustomerDTO>.MakeFail(validateResult);
                return BadRequest(errorResult);
            }

            var customer = await customerService.GetByEmailAddressAndId(emailAddr, customerId);
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
