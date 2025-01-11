using MainApp.Enums;

namespace MainApp.Validators
{
    public class InputValidator
    {
        public string RequestUserInput(string question, ValidationType validationType)
        {

            string input = string.Empty;
            bool isValid = false;
            var errorMessage = "";

            while (!isValid)
            {
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    Console.WriteLine(errorMessage);
                    Console.ReadLine();
                }

                Console.Clear();
                Console.WriteLine(question);
                input = Console.ReadLine()!;

                var validateResponse = Validate(validationType, input);

                isValid = validateResponse.IsValid;
                errorMessage = validateResponse.ErrorMessage;
            }
            return input;
        }

        //Använder en Tuple för att minimera storleken av consol appen. Annars skapar man eventuellt ett response objekt.
        public ValidatorResponse Validate(ValidationType validationType, string input)
        {
            const string noValueProvided = "Inget värde angivet.";
            const string notANumericValueProvided = $"Angivna värdet är inte ett numeriskt värde";
            bool isValid = false;

            switch (validationType)
            {
                case ValidationType.None:
                    
                    isValid = true;
                    break;
                case ValidationType.String:
                    
                    if (string.IsNullOrWhiteSpace(input))
                    {                      
                        return new ValidatorResponse(false, noValueProvided);
                    }
                    isValid = true;
                    break;

                case ValidationType.Int:
                    
                    if (string.IsNullOrWhiteSpace(input))
                    {                       
                        return new ValidatorResponse(false, noValueProvided);
                    }
                    if (!int.TryParse(input, out int number))
                    {
                        
                        return new ValidatorResponse(false, notANumericValueProvided);
                        
                    }
                    isValid = true;
                    break;
            }

            return new ValidatorResponse(true, string.Empty);
        }
    }
}
