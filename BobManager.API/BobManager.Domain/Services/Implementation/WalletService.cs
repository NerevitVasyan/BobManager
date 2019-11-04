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
        private readonly IMapper mapper;

        public WalletService(IGenericRepository<Spending> _repository,
            IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public async Task<CollectionResultDto<SpendingDto>> GetSpendigs()
        {
            var spending = await repository.GetAllInclude(x=>x.SpendingCategory);
            var mapped = mapper.Map<IEnumerable<Spending>, ICollection<SpendingDto>>(spending);
            return new CollectionResultDto<SpendingDto>
            {
                Data = mapped,
                IsSuccessful = true,
                Count = mapped.Count
            };
        }
    }
}