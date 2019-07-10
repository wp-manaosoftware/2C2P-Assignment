namespace API.ValidationServices
{
    public interface ICustomerValidationService
    {
        ValidationResult ValidateId(int Id);
    }
}
