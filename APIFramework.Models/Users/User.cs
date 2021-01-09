using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIFramework.Models.Users
{
    public class User
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("surname")]
        public string Surname { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("phonenumber")]
        public string Phonenumber { get; set; }
        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; } = new List<string>();
    }
}
