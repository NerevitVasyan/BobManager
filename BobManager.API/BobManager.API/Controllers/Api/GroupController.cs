using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BobManager.DataAccess.Entities;
using BobManager.Domain.Services.Abstraction;
using BobManager.Dto.DtoModels;
using BobManager.Dto.DtoResults;
using BobManager.Helpers.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BobManager.API.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService groupService;
        private readonly SignInManager<User> signInManager;
        private readonly ClientErrorManager clientErrorManager;

        public GroupController(IGroupService groupService,
                                SignInManager<User> signInManager,
                                ClientErrorManager clientErrorManager)
        {
            this.groupService = groupService;
            this.signInManager = signInManager;
            this.clientErrorManager = clientErrorManager;
        }

        [HttpPost]
        [ActionName("")]
        public async Task<ResultDto> Get([FromBody]GetGroupsDto entity = null)
        {
            User curUser = await signInManager.UserManager.GetUserAsync(signInManager.Context.User);
            if (curUser == null)
                return clientErrorManager.MapErrorIDToResultDto(3);

            return await groupService.Get(entity, curUser);
        }

        [HttpPost]
        public async Task<ResultDto> Add([FromBody] AddGroupDto entity)
        {
            if (entity == null)
                return clientErrorManager.MapErrorIDToResultDto(18);

            User curUser = await signInManager.UserManager.GetUserAsync(signInManager.Context.User);
            if (curUser == null)
                return clientErrorManager.MapErrorIDToResultDto(3);

            return await groupService.AddGroup(entity, curUser);
        }

        [HttpGet("{ID}")]
        public async Task<ResultDto> Remove(int ID)
        {

            User curUser = await signInManager.UserManager.GetUserAsync(signInManager.Context.User);
            if (curUser == null)
                return clientErrorManager.MapErrorIDToResultDto(3);

            return await groupService.RemoveGroup(ID, curUser);
        }

        [HttpPost]
        [ActionName("users/add")]
        public async Task<ResultDto> AddUsers([FromBody] AddUsersToGroupDto entity)
        {
            if (entity == null)
                return clientErrorManager.MapErrorIDToResultDto(18);

            User curUser = await signInManager.UserManager.GetUserAsync(signInManager.Context.User);
            if (curUser == null)
                return clientErrorManager.MapErrorIDToResultDto(3);

            return await groupService.AddUsers(entity, curUser);
        }

        [HttpPost]
        [ActionName("users/remove")]
        public async Task<ResultDto> RemoveUsers([FromBody] RemoveUsersFromGroupDto entity)
        {
            if (entity == null)
                return clientErrorManager.MapErrorIDToResultDto(18);

            User curUser = await signInManager.UserManager.GetUserAsync(signInManager.Context.User);
            if (curUser == null)
                return clientErrorManager.MapErrorIDToResultDto(3);

            return await groupService.RemoveUsers(entity, curUser);
        }

        [HttpGet("{ID}")]
        public async Task<ResultDto> Exit(int ID)
        {
            User curUser = await signInManager.UserManager.GetUserAsync(signInManager.Context.User);
            if (curUser == null)
                return clientErrorManager.MapErrorIDToResultDto(3);

            return await groupService.ExitFromGroup(ID, curUser);
        }

    }
}