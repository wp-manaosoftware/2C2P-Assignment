namespace API.ValidationServices
{
    public interface ICustomerValidationService
    {
        ValidationResult ValidateId(int customerId);
        ValidationResult ValidateEmailAddress(string emailAddr);
        ValidationResult ValidateEmailAddressAndId(string emailAddr, int customerId);
        ValidationResult ValidateEmailAddressAndIdBothEmpty(string emailAddr, int customerId);
    }
}
