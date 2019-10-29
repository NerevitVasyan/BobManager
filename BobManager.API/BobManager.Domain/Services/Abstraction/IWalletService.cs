using BobManager.Dto.DtoModels;
using BobManager.Dto.DtoResults;
using System.Threading.Tasks;

namespace BobManager.Domain.Services.Abstraction
{
    public interface IWalletService
    {
        Task<CollectionResultDto<SpendingDto>> GetSpendigs();
    }
}