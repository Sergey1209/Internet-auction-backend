using Data.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Business.Helpers
{
    /// <summary>
    /// Represents the tools for getting claims data from a token.
    /// </summary>
    public class TokenHelper
    {
        /// <summary>
        /// Returns person id 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Returns the role of a person
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
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
