using BobManager.DataAccess.Entities;
using BobManager.Domain.Interfaces;
using BobManager.Dto.DtoModels;
using BobManager.Dto.DtoResults;
using BobManager.Helpers.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ClientErrorManager _clientErrorManager;
        public AccountService(UserManager<User> userManager,
                                 SignInManager<User> signInManager,
                                 IConfiguration configuration,
                                 ClientErrorManager clientErrorManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _clientErrorManager = clientErrorManager;
        }

        public async Task<ResultDto> Register(RegisterDto entity)
        {
            var user = new User
            {
                Email = entity.Email,
                UserName = entity.Email
            };
            var result = await _userManager.CreateAsync(user, entity.Password);
            if (result.Succeeded)
            {
               return  await Login(new LoginDto { Email = entity.Email, IsRemember = false, Password = entity.Password});
            }
            return _clientErrorManager.MapErrorIDToResultDto(2); ;
        }

        public async Task<ResultDto> Login(LoginDto entity)
        {
            var result = await _signInManager.PasswordSignInAsync(entity.Email, entity.Password, entity.IsRemember, false);
            if (result.Succeeded)
            {
                var user = _userManager.Users.SingleOrDefault(r => r.Email == entity.Email);
                var token = await GenerateJwtToken(entity.Email, user);
                return new SingleResultDto<string> { Data = token.ToString(), IsSuccessful = true, Message = "" };
            }
            return _clientErrorManager.MapErrorIDToResultDto(1);
        }

        private async Task<object> GenerateJwtToken(string email, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));
            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
