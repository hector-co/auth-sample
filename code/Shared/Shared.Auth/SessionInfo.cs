using Microsoft.AspNetCore.Http;
using OpenIddict.Abstractions;

namespace Shared.Auth
{
    public class SessionInfo : ISessionInfo
    {
        private IEnumerable<string> _roles = new List<string>();

        public string UserId { get; private set; }
        public string UserName { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public IEnumerable<string> Roles => _roles.ToList();
        public bool IsAuthenticated => string.IsNullOrEmpty(UserId);

        public string FullName => $"{LastName} {Name}".Trim();

        public bool HasRole(string role)
        {
            return _roles.Contains(role);
        }

        public bool HasAdministratorRole()
        {
            return HasRole(AuthConstants.Roles.Administrator);
        }

        internal void SetData(HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated) return;

            _roles = GetClaimValues(context, OpenIddictConstants.Claims.Role).ToList();
            UserId = GetClaimValues(context, OpenIddictConstants.Claims.Subject).First();
            UserName = GetClaimValues(context, OpenIddictConstants.Claims.Name).First();
            Name = GetClaimValues(context, OpenIddictConstants.Claims.GivenName).First();
            LastName = GetClaimValues(context, OpenIddictConstants.Claims.FamilyName).First();
            Email = GetClaimValues(context, OpenIddictConstants.Claims.Email).First();
        }

        private static IEnumerable<string> GetClaimValues(HttpContext context, string claimType)
        {
            var claims = context.User.Claims.Where(c => c.Type == claimType);

            if (!claims.Any())
                yield return "";

            foreach (var claim in claims)
                yield return claim.Value ?? "";
        }
    }
}
