using BobManager.DataAccess.Entities;
using BobManager.Domain.Interfaces;
using BobManager.Dto.DtoModels;
using BobManager.Dto.DtoResults;
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

        public AccountService(UserManager<User> userManager,
                                 SignInManager<User> signInManager,
                                 IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<SingleResultDto<string>> Register(RegisterDto entity)
        {
            var user = new User
            {
                UserName = entity.Email,
                Email = entity.Email
            };
            var result = await _userManager.CreateAsync(user, entity.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                var token = await GenerateJwtToken(entity.Email, user);
                return new SingleResultDto<string> { Data = token.ToString(), IsSuccessful = true, Message = "" };
            }
            return new SingleResultDto<string> { Data = "", IsSuccessful = false, Message = "INVALID_REGISTER" };
        }

        public async Task<SingleResultDto<string>> Login(LoginDto entity)
        {
            var result = await _signInManager.PasswordSignInAsync(entity.Email, entity.Password, entity.IsRemember, false);
            if (result.Succeeded)
            {
                var user = _userManager.Users.SingleOrDefault(r => r.Email == entity.Email);
                var token = await GenerateJwtToken(entity.Email, user);
                return new SingleResultDto<string> { Data = token.ToString(), IsSuccessful = true, Message = "" };
            }
            return new SingleResultDto<string> { Data = "", IsSuccessful = false, Message = "INVALID_LOGIN" };
        }

        public Task<object> LogOut()
        {
            throw new NotImplementedException();
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
