using AutoMapper;
using BobManager.DataAccess.Entities;
using BobManager.DataAccess.Interfaces;
using BobManager.Domain.Services.Abstraction;
using BobManager.Dto.DtoModels;
using BobManager.Dto.DtoResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BobManager.Domain.Services.Implementation
{
    public class WalletService : IWalletService
    {
        private readonly IGenericRepository<Spending> repository;
        private readonly IGenericRepository<SpendingCategory> categoryRepository;
        private readonly IMapper mapper;

        public WalletService(IGenericRepository<Spending> _repository, IGenericRepository<SpendingCategory> _categoryRepository,
            IMapper _mapper)
        {
            repository = _repository;
            categoryRepository = _categoryRepository;
            mapper = _mapper;
        }

        public async Task AddSpending(SpendingDto spending)
        {
            try
            {
                var mapped = mapper.Map<SpendingDto, Spending>(spending);
                mapped.SpendingCategory = await categoryRepository.Find(mapped.SpendingCategoryId);

                await repository.Create(mapped);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<CollectionResultDto<SpendingDto>> GetSpendigs()
        {
            var spending = await repository.GetAllInclude(x => x.SpendingCategory);
            var mapped = mapper.Map<IEnumerable<Spending>, ICollection<SpendingDto>>(spending);
            return new CollectionResultDto<SpendingDto>
            {
                Data = mapped,
                IsSuccessful = true,
                Count = mapped.Count
            };
        }

        public async Task<int> GetSpendigsCount()
        {
            var spending = await repository.GetAll();
            var mapped = mapper.Map<IEnumerable<Spending>, ICollection<SpendingDto>>(spending);
            var count = mapped.Count;
            return count;
        }

        public async Task<CollectionResultDto<SpendingCategoryDto>> GetSpendingCategory()
        {
            var spendingCategory = await categoryRepository.GetAll();
            var mapped = mapper.Map<IEnumerable<SpendingCategory>, ICollection<SpendingCategoryDto>>(spendingCategory);
            return new CollectionResultDto<SpendingCategoryDto>
            {
                Data = mapped,
                IsSuccessful = true,
                Count = mapped.Count
            };
        }

        public Task<CollectionResultDto<SpendingDto>> GetSpendingForPage(int pageIndex)
        {
            throw new System.NotImplementedException();
        }
    }
}