using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Models.AppSettings
{
    public  class Authentication
    {
        public string Authority { get; set; } = string.Empty;
        public string AudienceIdToken { get; set; } = string.Empty;
        public string AudienceAccessToken { get; set; } = string.Empty;
        public string AzureB2CClientId { get; set; } = string.Empty;
    }
}
