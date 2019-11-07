using BobManager.Dto.DtoModels;
using BobManager.Dto.DtoResults;
using System.Threading.Tasks;

namespace BobManager.Domain.Services.Abstraction
{
    public interface IWalletService
    {
        Task<CollectionResultDto<SpendingDto>> GetSpendigs();
        Task AddSpending(SpendingDto spending);
        Task<CollectionResultDto<SpendingCategoryDto>> GetSpendingCategory();
        Task<int> GetSpendigsCount();
        Task<CollectionResultDto<SpendingDto>> GetSpendingForPage(int pageIndex);
    }
}