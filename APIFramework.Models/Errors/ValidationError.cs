using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Models.Errors
{
    public class ValidationError
    {
        public string PropertyName { get; set; } = string.Empty;
        public string ErrorDescription { get; set; } = string.Empty;
    }
}