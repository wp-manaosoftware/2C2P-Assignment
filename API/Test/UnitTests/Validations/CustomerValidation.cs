using API.Core.DomainModels;
using API.Infrastructure.EF.Repositories;
using API.Infrastructure.EF.Services;
using API.ValidationServices;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class CustomerValidation
    {
        [Fact]
        public void GetDataUsingId_ShouldAllow_PositiveInteger()
        {
            var id = 5;
            var validate = new CustomerValidationService();
            var result = validate.ValidateId(id);

            Assert.True(result.Success);
        }

        [Fact]
        public void GetDataUsingId_ShouldNotAllow_Zero()
        {
            var id = 0;
            var validate = new CustomerValidationService();
            var result = validate.ValidateId(id);

            Assert.False(result.Success);
        }

        [Fact]
        public void GetDataUsingId_ShouldNotAllow_NegativeInteger()
        {
            var id = -2;
            var validate = new CustomerValidationService();
            var result = validate.ValidateId(id);

            Assert.False(result.Success);
        }

        [Fact]
        public void GetDataUsingEmailAddr_ShouldAllow_ValidEmailAddr()
        {
            var emailAddr1 = "valid@email";
            var emailAddr2 = "valid@email.com";
            var validate = new CustomerValidationService();

            var result1 = validate.ValidateEmailAddress(emailAddr1);
            var result2 = validate.ValidateEmailAddress(emailAddr2);

            Assert.True(result1.Success);
            Assert.True(result2.Success);
        }

        [Fact]
        public void GetDataUsingEmailAddr_ShouldNotAllow_EmptyString()
        {
            var emailAddr = string.Empty;
            var validate = new CustomerValidationService();
            var result = validate.ValidateEmailAddress(emailAddr);

            Assert.False(result.Success);
        }

        [Fact]
        public void GetDataUsingEmailAddr_ShouldNotAllow_InvalidEmailAddr()
        {
            var emailAddr = "1e12";
            var validate = new CustomerValidationService();
            var result = validate.ValidateEmailAddress(emailAddr);

            Assert.False(result.Success);
        }

        [Fact]
        public void GetDataUsingEmailAddrAndId_ShouldAllow_ValidIdAndEmailAddr()
        {
            var emailAddr = "valid@email.com";
            var id = 33;

            var validate = new CustomerValidationService();
            var result = validate.ValidateEmailAddressAndId(emailAddr, id);

            Assert.True(result.Success);
        }


        [Fact]
        public void GetDataUsingEmailAddrAndId_ShouldNotAllow_InvalidIdAnValiddEmailAddr()
        {
            var emailAddr = "valid@email.com";
            var id = -9;

            var validate = new CustomerValidationService();
            var result = validate.ValidateEmailAddressAndId(emailAddr, id);

            Assert.False(result.Success);
        }

        [Fact]
        public void GetDataUsingEmailAddrAndId_ShouldNotAllow_ValidIdAnInvaliddEmailAddr()
        {
            var emailAddr = "invalid email addr";
            var id = 52;

            var validate = new CustomerValidationService();
            var result = validate.ValidateEmailAddressAndId(emailAddr, id);

            Assert.False(result.Success);
        }

        [Fact]
        public void GetDataUsingEmailAddrAndId_ShouldNotAllow_EmptyIdAnEmptyEmailAddr()
        {
            var emailAddr = default(string);
            int id = default(int);
            var noInquiryErrorMsg = "No inquiry criteria";

            var validate = new CustomerValidationService();
            var result = validate.ValidateEmailAddressAndIdBothEmpty(emailAddr, id);

            Assert.False(result.Success);
            Assert.Equal(noInquiryErrorMsg, result.Message);
        }
    }
}
