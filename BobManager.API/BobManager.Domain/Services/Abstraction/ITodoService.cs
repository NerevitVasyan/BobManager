using BobManager.DataAccess.Entities;
using BobManager.Dto.DtoModels;
using BobManager.Dto.DtoResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.Domain.Services.Abstraction
{
    public interface ITodoService
    {
        Task CreateTodo(ToDoDto toDoDto);
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<ToDo>> GetTodos();
        Task<ToDo> GetTodo(int id);

    }
}
