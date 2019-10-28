using System;
using System.Threading.Tasks;
using BobManager.Domain.Interfaces;
using BobManager.Dto.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace BobManager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            accountService = _accountService;
        }

        [HttpPost]
        public async Task<object> Register([FromBody] RegisterDto model)
        {
            try
            {
                return await _accountService.Register(model);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto model)
        {
            try
            {
                return await _accountService.Login(model);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}