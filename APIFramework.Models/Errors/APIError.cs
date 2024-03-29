using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Models.Errors
{
    public class APIError
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = String.Empty;

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
