using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using APIFramework.Models.ExtensionMethods;
using APIFramework.Models.Interfaces;

namespace APIFramework.Models.Users
{
    public class User : IModelValidation
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("surname")]
        public string Surname { get; set; } = string.Empty;
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
        [JsonPropertyName("phonenumber")]
        public string Phonenumber { get; set; } = string.Empty;
        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; } = new List<string>();
        [JsonIgnore]
        private readonly AbstractValidator<User> validator;

        public User()
        {
            validator = new UserValidator();
        }
        public ValidationResult Validate(bool throwValidationException = true)
        {
            ValidationResult result = validator.Validate(this);
            if (!result.IsValid && throwValidationException)
            {
                throw new ValidationException(result.ErrorsAsJson());
            }
            return result;
        }
    }

    internal class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Id).NotEmpty().WithMessage("Id cannot be null");
        }
    }
}