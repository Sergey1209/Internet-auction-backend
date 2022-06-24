using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Business.Validation;
using Data.Entities;
using Data.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IOptions<AuthOptions> _authOptions;
        private readonly IUnitOfWorkAuth _unitOfWork;
        private readonly IPersonAuthRepository _authRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public AuthService(IOptions<AuthOptions> authOptions, IUnitOfWorkAuth unitOfWorkAuth, IMapper mapper )
        {
            _mapper = mapper;
            _authOptions = authOptions;
            _unitOfWork = unitOfWorkAuth;
            _personRepository = unitOfWorkAuth.PersonRepository;
            _authRepository = unitOfWorkAuth.PersonAuthRepository;
        }

        public async Task<string> LoginAsync(LoginModel login)
        {
            var identity = await _authRepository.GetByLoginAsync(login: login.Email);
            if (identity == null || identity.Password != login.Password)
                throw new LoginException();

            var token = GenerateJWT(login: identity.Email, personId: identity.PersonId, role: identity.Role);

            return token;
        }

        public async Task RegistrationAsync(RegistrationModel registration)
        {
            var identity = await _authRepository.GetByLoginAsync(login: registration.Email);
            if (identity != null)
                throw new RegistrationException();

            var person = _mapper.Map<Person>(registration);
            
            var auth = _mapper.Map<PersonAuth>(registration);
            auth.Person = person;

            await _personRepository.AddAsync(person);
            await _authRepository.AddAsync(auth);

            await _unitOfWork.SaveAsync();
        }

        private string GenerateJWT(string login, int personId, Role role)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var now = DateTime.UtcNow;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, login),
                new Claim(JwtRegisteredClaimNames.Sub, personId.ToString()),
                new Claim("role", role.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: authParams.Issuer,
                audience: authParams.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task DeleteAsync(string modelId)
        {
            await _authRepository.DeleteByLoginAsync(modelId);
        }

        public async Task UpdateAsyc(PersonAuthModel personAuthModel)
        {
            personAuthModel.Validate();

            _personRepository.Update(_mapper.Map<Person>(personAuthModel));
            _authRepository.Update(_mapper.Map<PersonAuth>(personAuthModel));
            
            await _unitOfWork.SaveAsync();
        }
    }
}
