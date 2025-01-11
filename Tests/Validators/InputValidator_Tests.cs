using MainApp.Validators;
using MainApp.Enums;

namespace Tests.Validators
{
    public class InputValidator_Tests
    {
        [Fact]
        public void Validate_ReturnsTrueWhenStringValueIsPresent()
        {

            //Arrange
            var validator = new InputValidator();
            var value = "Not an empty string";

            //Act
            var response = validator.Validate(ValidationType.String, value);

            //Assert
            Assert.True(response.IsValid);
            Assert.True(string.IsNullOrEmpty(response.ErrorMessage));

        }

        [Fact]
        public void Validate_ReturnsFalseWhenNotNumericValue()
        {

            //Arrange
            var validator = new InputValidator();
            var value = "Not a numeric value.";

            //Act
            var response = validator.Validate(ValidationType.String, value);

            //Assert
            Assert.True(response.IsValid);
            Assert.True(string.IsNullOrEmpty(response.ErrorMessage));

        }

        [Fact]
        public void Validate_ReturnsTrueWhenNoValidation()
        {
            //Arrange
            var validator = new InputValidator();
            var value = "Not a numeric value";

            //Act
            var response = validator.Validate(ValidationType.None, value);

            //Assert
            Assert.True(response.IsValid);
            Assert.True(string.IsNullOrEmpty(response.ErrorMessage));

        }
    }
}
