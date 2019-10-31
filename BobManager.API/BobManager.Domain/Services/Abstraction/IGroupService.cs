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
        Task<ResultDto> AddGroup(GroupDto entity);
        Task<ResultDto> RemoveGroup(int ID);
    }
}
