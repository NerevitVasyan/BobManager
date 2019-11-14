using AutoMapper;
using BobManager.DataAccess;
using BobManager.DataAccess.Entities;
using BobManager.DataAccess.Interfaces;
using BobManager.Domain.Services.Abstraction;
using BobManager.Dto.DtoModels;
using BobManager.Dto.DtoResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.Domain.Services.Implementation
{
    public class TodoService : ITodoService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ToDoCategory> _categoryrepository;
        private readonly IGenericRepository<ToDo> _repository;


        public TodoService(ApplicationContext context, IMapper mapper, IGenericRepository<ToDoCategory> categoryrepository,
            IGenericRepository<ToDo> repository)
        {
            _context = context;
            _mapper = mapper;
            _categoryrepository = categoryrepository;
            _repository = repository;
        }

        public async Task CreateTodo(ToDoDto toDoDto)
        {
            try
            {
                var mapped = _mapper.Map<ToDoDto, ToDo>(toDoDto);
                mapped.ToDoCategory = await _categoryrepository.Find(mapped.ToDoCategoryId);
                await _repository.Create(mapped);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Task<ToDo> GetTodo(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ToDo>> GetTodos()
        {
            var users = await _context.ToDos.Include(p => p.ToDoCategory).ToListAsync();
            return users;
        }

        public Task<bool> SaveAll()
        {
            throw new NotImplementedException();
        }

        //public async Task<CollectionResultDto<ToDoDto>> GetTodos()
        //{
        //    var todo = await _repository.GetAllInclude(x => x.ToDoCategory);
        //    var mapped = _mapper.Map<IEnumerable<ToDo>, ICollection<ToDoDto>>(todo);
        //    return new CollectionResultDto<ToDoDto>
        //    {
        //        Data = mapped,
        //        IsSuccessful = true,
        //        Count = mapped.Count
        //    };
        //}
    }
}
