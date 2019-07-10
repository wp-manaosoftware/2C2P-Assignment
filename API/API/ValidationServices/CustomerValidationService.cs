using System;
using System.Net.Mail;

namespace API.ValidationServices
{
    public class CustomerValidationService: ICustomerValidationService
    {
        const string invalidIdErrorMsg = "Invalid Customer ID";
        const string invalidEmailAddrErrorMsg = "Invalid Email";
        const string noInquiryErrorMsg = "No inquiry criteria";

        public ValidationResult ValidateId(int Id)
        {
            if (Id < 1)
                return new ValidationResult(false, "Id", invalidIdErrorMsg);

            return new ValidationResult();
        }

        public ValidationResult ValidateEmailAddress(string emailAddr)
        {
            var invalidEmailErrorMsg = invalidEmailAddrErrorMsg;

            if (string.IsNullOrEmpty(emailAddr) || !IsValidEmail(emailAddr))
                return new ValidationResult(false, "Id", invalidEmailErrorMsg);

            return new ValidationResult();
        }

        public ValidationResult ValidateEmailAddressAndId(string emailAddr, int id)
        {
            var idResult = ValidateId(id);

            if (!idResult.Success)
                return idResult;

            var emailResult = ValidateEmailAddress(emailAddr);
            if (!emailResult.Success)
                return emailResult;

            return new ValidationResult();
        }

        public ValidationResult ValidateEmailAddressAndIdBothEmpty(string emailAddr, int customerId)
        {
            if (string.IsNullOrEmpty(emailAddr) && customerId == 0)
                return new ValidationResult(false, "Id", noInquiryErrorMsg);

            return new ValidationResult();
        }

        private bool IsValidEmail(string emailAddr)
        {
            try
            {
                MailAddress m = new MailAddress(emailAddr);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
