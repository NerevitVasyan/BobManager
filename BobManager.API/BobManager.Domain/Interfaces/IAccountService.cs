using BobManager.Dto.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<object> Register(RegisterDto entity);
        Task<object> Login(LoginDto entity);
        Task<object> LogOut();
    }
}
