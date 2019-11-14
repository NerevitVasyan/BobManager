using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BobManager.DataAccess;
using BobManager.DataAccess.Entities;
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
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;
        public TodoController(ITodoService todoService, IMapper mapper, ApplicationContext context)
        {
            _todoService = todoService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var users = await _todoService.GetTodos();
            var usersToReturn = _mapper.Map<IEnumerable<ToDoDto>>(users);

            return Ok(usersToReturn);
        }


        [HttpPost]
        [Route("CreateTodo")]
        public IActionResult CreateTodo([FromBody] ToDoDto model)
        {
            try
            {
                this._context.ToDos.Add(new ToDo()
                {
                    User = this._context.Users.FirstOrDefault(x => x.Id == model.UserId),
                    Description = model.Description,
                    Deadline = model.Deadline,
                    Status = model.Status,
                    Priority = model.Priority,
                    GroupId = model.GroupId,
                    UserId = model.UserId,
                    ToDoCategoryId = model.ToDoCategoryDto.Id,
                });
                this._context.SaveChanges();
                return Ok("Created!");
            }
            catch
            {
                return BadRequest("INVALID!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteTodo(int id)
        {
            var recipe = _context.ToDos.FirstOrDefault(x => x.Id == id);

            if (recipe != null)
            {
                _context.ToDos.Remove(recipe);
                _context.SaveChanges();
            }
            return Ok(recipe);
        }


        
    }
}