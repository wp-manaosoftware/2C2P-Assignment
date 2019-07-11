using API.Core.DomainModels;
using API.Infrastructure.EF.Repositories;
using API.Infrastructure.EF.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class CustomerServiceTest
    {
        [Fact]
        public async Task GetDataUsingId_Should_Success()
        {
            var customer = new Customer();
            var id = 1;

            var mockCr = new Mock<ICustomerRepository>();
            mockCr.Setup(_ => _.GetById(It.IsAny<int>())).ReturnsAsync(customer);
            var cs = new CustomerService(mockCr.Object);
            var result = await cs.GetById(id);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetDataUsingIdAndEmailAddr_Should_RrturnUpto5Transactions()
        {
            var transaction = new Transaction();
            var maxTransactionNumber = 5;
            var emailAddr = "valid@email";
            var id = 2;
            var customer = new Customer()
            {
                Name = "name",
                Transactions = new List<Transaction>()
                { transaction, transaction, transaction, transaction, transaction, transaction }
            };

            var mockCr = new Mock<ICustomerRepository>();
            mockCr.Setup(_ => _.GetByEmailAddressAndId(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(customer);

            var cs = new CustomerService(mockCr.Object);
            var result = await cs.GetByEmailAddressAndId(emailAddr, id);

            Assert.Equal(maxTransactionNumber, result.Transactions.Count);
        }

        [Fact]
        public async Task GetDataUsingEmailAddr_Should_RrturnUpto5Transactions()
        {
            var transaction = new Transaction();
            var maxTransactionNumber = 5;
            var customer2TransactionNumber = 4;
            var emailAddr1 = "valid@email1";
            var emailAddr2 = "valid@email2";
            var customer1 = new Customer()
            {
                ContactEmail = emailAddr1,
                Transactions = new List<Transaction>()
                { transaction, transaction, transaction, transaction, transaction, transaction }
            };
            var customer2 = new Customer()
            {
                ContactEmail = emailAddr2,
                Transactions = new List<Transaction>()
                { transaction, transaction, transaction, transaction }
            };

            var mockCr = new Mock<ICustomerRepository>();
            mockCr.Setup(_ => _.GetByEmailAddress(emailAddr1)).ReturnsAsync(customer1);
            mockCr.Setup(_ => _.GetByEmailAddress(emailAddr2)).ReturnsAsync(customer2);

            var cs = new CustomerService(mockCr.Object);
            var result1 = await cs.GetByEmailAddress(emailAddr1);
            var result2 = await cs.GetByEmailAddress(emailAddr2);

            Assert.Equal(maxTransactionNumber, result1.Transactions.Count);
            Assert.Equal(customer2TransactionNumber, result2.Transactions.Count);
        }

    }
}
