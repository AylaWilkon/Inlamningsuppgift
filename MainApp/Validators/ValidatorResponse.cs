using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
