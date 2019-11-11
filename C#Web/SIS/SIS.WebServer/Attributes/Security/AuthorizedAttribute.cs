using System;
using SIS.WebServer.Identity;

namespace SIS.WebServer.Attributes
{
    public class AuthorizedAttribute:Attribute
    {
        public AuthorizedAttribute(string authority="authorized")
        {
            this.authority = authority;
        }
        private readonly string authority;

        private bool IsLoggedIn(Principal principal)
        {
            return principal != null;
        }

        public bool IsInAuthority(Principal principal)
        {
            if (!this.IsLoggedIn(principal))
            {
                return this.authority == "anonymous";
            }

            return this.authority == "authorized"
                   || principal.Roles.Contains(this.authority.ToLower());
        }
    }
}