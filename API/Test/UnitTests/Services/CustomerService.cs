using API.Core.DomainModels;
using API.Infrastructure.EF.Repositories;
using API.Infrastructure.EF.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class CustomerServiceTest
    {
        [Fact]
        public async Task GetDataUsingId_Should_Success()
        {
            var customer = new Customer()
            {
                Name = "name"
            };

            var mockCr = new Mock<ICustomerRepository>();
            mockCr.Setup(_ => _.GetById(1)).ReturnsAsync(customer);
            var cs = new CustomerService(mockCr.Object);
            var result = await cs.GetById(1);

            Assert.NotNull(result);
        }

    }
}
