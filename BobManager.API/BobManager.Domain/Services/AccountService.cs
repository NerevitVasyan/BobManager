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
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
            return _clientErrorManager.MapErrorIDToResultDto(2);
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



       


        public async Task<ResultDto> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user!=null)
            {
                //Password generator
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[16];
                var random = new Random();
                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                var finalString = new string(stringChars);
                Console.WriteLine(stringChars);
                string NewPassword = new string(stringChars);
                //Send password to user Gmail
                    string htmlMessage = $@"<html>
                         <body>
                         <img src='cid:BobManager' />
                         </br>
                         <h3>Hello! Your new password: {NewPassword}
                         </body>
                         </html>";
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                                                  htmlMessage,
                                                  Encoding.UTF8,
                                                  MediaTypeNames.Text.Html);
                    AlternateView plainView = AlternateView.CreateAlternateViewFromString(
                                                                Regex.Replace(htmlMessage,
                                                                              "<[^>]+?>",
                                                                              string.Empty),
                                                                Encoding.UTF8,
                                                                MediaTypeNames.Text.Plain);
                    string mediaType = MediaTypeNames.Image.Jpeg;
                    LinkedResource img = new LinkedResource(@"C:\Users\MK\Desktop\BobManagerPNG`s\mini-logo.png", mediaType);
                    img.ContentId = "BobManager";
                    img.ContentType.MediaType = mediaType;
                    img.TransferEncoding = TransferEncoding.Base64;
                    img.ContentType.Name = img.ContentId;
                    img.ContentLink = new Uri("cid:" + img.ContentId);
                    htmlView.LinkedResources.Add(img);
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("dimka05023test@gmail.com");
                    mail.To.Add(email);
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("dimka05023test@gmail.com", "0502327941");
                    SmtpServer.EnableSsl = true;
                    mail.AlternateViews.Add(plainView);
                    mail.AlternateViews.Add(htmlView);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Forgot Password";
                    SmtpServer.Send(mail);
                await _userManager.ResetPasswordAsync(user, "", NewPassword);
                if (IdentityResult.Success.Succeeded)
                {
                    return new SingleResultDto<string> { IsSuccessful = true, Message = "Password reseted" };
                }
                else
                    return new SingleResultDto<string> { IsSuccessful = false, Message = "Password reseted failed" };
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
