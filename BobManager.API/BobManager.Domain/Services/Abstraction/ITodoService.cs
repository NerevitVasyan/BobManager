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
        Task<CollectionResultDto<ToDoDto>> GetTodos();
    }
}
