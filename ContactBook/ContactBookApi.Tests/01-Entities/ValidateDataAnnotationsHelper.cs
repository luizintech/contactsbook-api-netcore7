using System.ComponentModel.DataAnnotations;

namespace ContactBookApi.Tests._01_Entities
{
    public static class ValidateDataAnnotationsHelper
    {

        //I decided to generalize this method to use this in more points inside my code.
        //Look the commits history on GitHub.
        public static bool Validate<TType>(TType type)
            where TType : class
        {
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(type,
                new ValidationContext(type),
                validationResults,
                validateAllProperties: true);
            return actual;
        }

    }
}
