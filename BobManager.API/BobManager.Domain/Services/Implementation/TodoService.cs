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

        public TodoService(ApplicationContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
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
