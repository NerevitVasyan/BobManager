using AutoMapper;
using BobManager.DataAccess.Entities;
using BobManager.DataAccess.Interfaces;
using BobManager.Domain.Services.Abstraction;
using BobManager.Dto.DtoModels;
using BobManager.Dto.DtoResults;
using BobManager.Helpers.Managers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.Domain.Services.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly SignInManager<User> signInManager;
        private readonly ClientErrorManager clientErrorManager;
        private readonly IGenericRepository<Group> grpRep;
        private readonly IGenericRepository<UsersGroup> usrsGroupRep;
        private readonly IGenericRepository<GroupRole> rolesRep;
        private readonly IMapper mapper;

        public GroupService(SignInManager<User> signInManager,
                            ClientErrorManager clientErrorManager,
                            IGenericRepository<Group> grpRep,
                            IGenericRepository<UsersGroup> usrsGroupRep ,
                            IGenericRepository<GroupRole> rolesRep,
                            IMapper mapper)
        {
            this.signInManager = signInManager;
            this.clientErrorManager = clientErrorManager;
            this.grpRep = grpRep;
            this.usrsGroupRep = usrsGroupRep;
            this.mapper = mapper;
            this.rolesRep = rolesRep;
        }

        public async Task<ResultDto> AddGroup(GroupDto entity)
        {
            if (!signInManager.IsSignedIn(signInManager.Context.User)) return clientErrorManager.MapErrorIDToResultDto(3);
            else if ((entity.Name ?? "").Length < 1) return clientErrorManager.MapErrorIDToResultDto(4);

            User curUser = await signInManager.UserManager.GetUserAsync(signInManager.Context.User);
            IEnumerable<GroupRole> roles = await rolesRep.GetAll();
            GroupRole aRole = roles.GetEnumerator().Current;
            
            await usrsGroupRep.Create(
                new UsersGroup
                {
                    Group = mapper.Map<GroupDto, Group>(entity),
                    User = curUser,
                    GroupRole = aRole
                });

            return new ResultDto();
        }

        public Task<ResultDto> RemoveGroup(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
