using FluentValidation.Results;

namespace APIFramework.Models.Interfaces
{
    public interface IModelValidation
    {
        /// <summary>
        /// Method to validate model
        /// </summary>
        /// <param name="throwValidationException">Indicates if the method shoud throw a error when validation falis.  If false validation will fail silently and return ValidationResult</param>
        /// <returns>Fluent validation validation result</returns>
        public ValidationResult Validate(bool throwValidationException = true);
        // ------------------- EXAMPLE OF IMPLEMENTATION ----------------------------------------
        //{
        //    ValidationResult result = this.Validate(this);
        //    if (!result.IsValid && throwValidationException)
        //    {
        //        throw new ValidationException(result.ErrorsAsJson());
        //    }
        //    return result;
        //}
    }
}
