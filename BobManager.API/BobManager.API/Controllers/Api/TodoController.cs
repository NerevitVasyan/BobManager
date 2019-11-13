using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BobManager.Domain.Services.Abstraction;
using BobManager.Dto.DtoModels;
using BobManager.Dto.DtoResults;
using Microsoft.AspNetCore.Mvc;

namespace BobManager.API.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public Task<CollectionResultDto<ToDoDto>> todos()
        {
            return _todoService.GetTodos();
        }

    }
}