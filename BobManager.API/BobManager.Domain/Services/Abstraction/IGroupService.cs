using BobManager.DataAccess.Entities;
using BobManager.Dto.DtoModels;
using BobManager.Dto.DtoResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.Domain.Services.Abstraction
{
    public interface IGroupService
    {
        Task<ResultDto> AddGroup(AddGroupDto entity, User curUser);
        Task<ResultDto> RemoveGroup(int ID, User curUser);
        Task<ResultDto> ExitFromGroup(int ID, User curUser);
        Task<ResultDto> AddUsers(AddUsersToGroupDto entity, User curUser);
        Task<ResultDto> RemoveUsers(RemoveUsersFromGroupDto entity, User curUser);
        Task<ResultDto> Get(GetGroupsDto entity, User curUser);
    }
}
