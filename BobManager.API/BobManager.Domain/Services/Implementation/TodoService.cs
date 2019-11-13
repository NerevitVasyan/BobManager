using AutoMapper;
using BobManager.DataAccess.Entities;
using BobManager.DataAccess.Interfaces;
using BobManager.Domain.Services.Abstraction;
using BobManager.Dto.DtoModels;
using BobManager.Dto.DtoResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.Domain.Services.Implementation
{
    public class TodoService : ITodoService
    {
        private readonly IGenericRepository<ToDo> _repository;
        private readonly IMapper _mapper;

        public TodoService(IGenericRepository<ToDo> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CollectionResultDto<ToDoDto>> GetTodos()
        {
            var spending = await _repository.GetAllInclude(x => x.ToDoCategory);
            var mapped = _mapper.Map<IEnumerable<ToDo>, ICollection<ToDoDto>>(spending);
            return new CollectionResultDto<ToDoDto>
            {
                Data = mapped,
                IsSuccessful = true,
                Count = mapped.Count
            };
        }
    }
}
