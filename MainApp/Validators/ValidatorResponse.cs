namespace MainApp.Validators
{
    public class ValidatorResponse
    {
        public ValidatorResponse(bool isValid, string errorMessage)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public bool IsValid { get; set; }

        public string ErrorMessage { get; set; } = null!;
    }
}
