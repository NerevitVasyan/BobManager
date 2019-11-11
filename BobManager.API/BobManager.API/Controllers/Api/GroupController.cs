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
    [ApiController]
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
        public async Task<ResultDto> Add([FromBody] AddGroupDto entity)
        {
            if (!signInManager.Context.User.Identity.IsAuthenticated)
                return clientErrorManager.MapErrorIDToResultDto(3);

            return await groupService.AddGroup(entity, await signInManager.UserManager.GetUserAsync(signInManager.Context.User));
        }

        [HttpPost]
        public async Task<ResultDto> Remove([FromBody] int ID)
        {
            if (!signInManager.Context.User.Identity.IsAuthenticated)
                return clientErrorManager.MapErrorIDToResultDto(3);

            return await groupService.RemoveGroup(ID, await signInManager.UserManager.GetUserAsync(signInManager.Context.User));
        }

        [HttpPost]
        public async Task<ResultDto> Exit([FromBody] int ID)
        {
            if (!signInManager.Context.User.Identity.IsAuthenticated)
                return clientErrorManager.MapErrorIDToResultDto(3);

            return await groupService.ExitFromGroup(ID, await signInManager.UserManager.GetUserAsync(signInManager.Context.User));
        }

    }
}