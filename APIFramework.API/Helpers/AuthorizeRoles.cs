using APIFramework.Models.Enums;
using APIFramework.Models.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;

namespace APIFramework.API.Helpers
{
    // TODO: Test functionality
    public sealed class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRoles[] AuthorizedRoles { get; } = new AuthorizeRoles[0];
        public AuthorizeRolesAttribute(params AuthorizeRoles[] authorizedRoles) => 
            Roles = string.Join(", ", authorizedRoles.Select(x => x.GetDescription()).ToArray());
    }
}
