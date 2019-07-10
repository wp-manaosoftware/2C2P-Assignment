namespace API.Validations
{
    public static class CustomerValidationService
    {
        public static ValidationResult ValidateId(int Id)
        {
            if (Id < 1)
                return new ValidationResult(false, "Id", "Invalid Customer ID");

            return new ValidationResult();
        }
    }
}
