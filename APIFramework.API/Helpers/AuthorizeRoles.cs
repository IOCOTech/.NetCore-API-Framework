using APIFramework.Models.Enums;
using APIFramework.Models.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace APIFramework.API.Helpers
{
    public sealed class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRoles[] AuthorizedRoles { get; }
        public AuthorizeRolesAttribute(params AuthorizeRoles[] authorizedRoles) => Roles = string.Join(", ", authorizedRoles.Select(x => x.GetDescription()).ToArray());
    }
}
