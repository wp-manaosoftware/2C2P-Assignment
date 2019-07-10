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
    }
}
