using Business.Interfaces;
using Business.Models;
using InternetAuction.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InternetAuction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Exceptions]
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
        public async Task Update([FromBody] PersonModel registration)
        {
            await _service.UpdateAsyc(registration);
        }

    }
}
