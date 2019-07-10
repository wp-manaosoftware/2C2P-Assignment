using System;
using System.Net.Mail;

namespace API.ValidationServices
{
    public class CustomerValidationService: ICustomerValidationService
    {
        public ValidationResult ValidateId(int Id)
        {
            if (Id < 1)
                return new ValidationResult(false, "Id", "Invalid Customer ID");

            return new ValidationResult();
        }

        public ValidationResult ValidateEmailAddress(string emailAddr)
        {
            var invalidEmailErrorMsg = "Invalid Email"; 

            if (string.IsNullOrEmpty(emailAddr) || !IsValidEmail(emailAddr))
                return new ValidationResult(false, "Id", invalidEmailErrorMsg);

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
