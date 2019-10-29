using BobManager.Dto.DtoModels;
using BobManager.Dto.DtoResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<SingleResultDto<string>> Register(RegisterDto entity);
        Task<SingleResultDto<string>> Login(LoginDto entity);
    }
}
