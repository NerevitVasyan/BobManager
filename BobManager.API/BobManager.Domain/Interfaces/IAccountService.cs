using BobManager.Dto.DtoModels;
using BobManager.Dto.DtoResults;
using System.Threading.Tasks;

namespace BobManager.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<ResultDto> Register(RegisterDto entity);
        Task<ResultDto> Login(LoginDto entity);
        Task<ResultDto> ForgotPassword(string email);


    }
}
