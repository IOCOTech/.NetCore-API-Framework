using APIFramework.Models.Errors;
using FluentValidation.Results;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace APIFramework.Models.ExtensionMethods
{
    public static class FluentValidation
    {
        public static IEnumerable<string> ErrorsAsString(this ValidationResult results)
        {
            return results.Errors.Select(e => $"{e.PropertyName}:  {e.ErrorMessage}");
        }
        public static string ErrorsAsJson(this ValidationResult results)
        {
            return JsonConvert.SerializeObject(results.Errors.Select(e => new ValidationError() { PropertyName = e.PropertyName, ErrorDescription = e.ErrorMessage }));
        }
    }
}
