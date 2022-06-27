using Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Business.Helpers
{
    public class TokenHelper
    {
        public int GetPersonId(HttpContext httpContext)
        {
            var token = httpContext.GetTokenAsync("access_token").Result;
            var securityTokenHandler = new JwtSecurityTokenHandler();
            var id = 0;
            if (securityTokenHandler.CanReadToken(token))
            {
                var decriptedToken = securityTokenHandler.ReadJwtToken(token);
                var claims = decriptedToken.Claims;
                int.TryParse(claims.Where(c => c.Type == "sub").FirstOrDefault().Value, out id);
            }
            return id;
        }

        public Role GetRole(HttpContext httpContext)
        {
            var token = httpContext.GetTokenAsync("access_token").Result;
            var securityTokenHandler = new JwtSecurityTokenHandler();
            var role = Role.UnRegisteredUser;
            if (securityTokenHandler.CanReadToken(token))
            {
                var decriptedToken = securityTokenHandler.ReadJwtToken(token);
                var claims = decriptedToken.Claims;
                Enum.TryParse<Role>(claims.Where(c => c.Type == "role").FirstOrDefault().Value, out role);
            }
            return role;
        }
    }
}
