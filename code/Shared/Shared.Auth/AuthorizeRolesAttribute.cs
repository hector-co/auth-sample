using Microsoft.AspNetCore.Authorization;

namespace Shared.Auth
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles) : base()
        {
            if (roles != null && roles.Length > 0)
                Roles = string.Join(",", roles);
        }
    }
}
