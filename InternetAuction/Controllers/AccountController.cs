using Business.Interfaces;
using Business.Models;
using Business.Services;
using Data.Data;
using Data.Entities;
using InternetAuction.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InternetAuction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModelState]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<object> Login([FromBody] LoginModel login)
        {
            var res = await _service.LoginAsync(login);
            return res;
        }

        [HttpPost("registration")]
        public async Task<object> Registration([FromBody] RegistrationModel registration)
        {
            await _service.RegistrationAsync(registration);
            return await _service.LoginAsync(registration);
        }

        [Authorize(Roles = "Administrator, RegisteredUser")]
        [HttpPost("update")]
        public async Task Update([FromBody] PersonAuthModel registration)
        {
            await _service.UpdateAsyc(registration);
        }

    }
}
