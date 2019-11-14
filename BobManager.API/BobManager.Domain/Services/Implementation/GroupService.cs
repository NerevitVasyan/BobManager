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
using System.Linq;

namespace BobManager.Domain.Services.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly ClientErrorManager clientErrorManager;

        private readonly UserManager<User> userManager;

        private readonly IGenericRepository<Group> grpRep;
        private readonly IGenericRepository<GroupRole> rolesRep;
        private readonly IGenericRepository<UsersGroup> userGrpRep;
        private readonly IMapper mapper;
        
        public GroupService(ClientErrorManager clientErrorManager,
                            UserManager<User> userManager,
                            IGenericRepository<Group> grpRep,
                            IGenericRepository<GroupRole> rolesRep,
                            IGenericRepository<UsersGroup> userGrpRep,
                            IMapper mapper)
        {
            this.clientErrorManager = clientErrorManager;
            this.userManager = userManager;
            this.grpRep = grpRep;
            this.userGrpRep = userGrpRep;
            this.rolesRep = rolesRep;
            this.mapper = mapper;
        }

        private async Task<GroupRole> GetFirstRoleAsync() {
            return new List<GroupRole>(await rolesRep.GetAll())[0];
        }

        private async Task<Group> IsIssetUserInGroupAsync(int ID, string userID) {
            List<Group> grps = new List<Group>(await grpRep.GetAllInclude((x) => x.Id == ID, (s) => s.Users));

            if (grps.Count < 1 || grps[0].Users.FirstOrDefault((x) => x.UserId == userID) == null) 
                return null;

            return grps[0];
        }

        private async Task<List<Group>> GetGroups(string ID) {
            return new List<Group>(await grpRep.GetAllInclude((x) => x.Users.FirstOrDefault((m) => m.UserId == ID) != null, (s) => s.Users));
        }

        public async Task<ResultDto> AddGroup(AddGroupDto entity, User curUser)
        {
            if ((entity.Name ?? "").Length < 1) return clientErrorManager.MapErrorIDToResultDto(4);
            else if (entity.Name.Length > 50) return clientErrorManager.MapErrorIDToResultDto(5);

            List<UsersGroup> addUsers = new List<UsersGroup>();

            User temp;
            List<GroupRole> roles = new List<GroupRole>(await rolesRep.GetAll());

            if (entity.Users != null) {
                foreach (var item in entity.Users)
                {
                    if (item.Key == null)
                        clientErrorManager.MapErrorIDToResultDto(6, item);

                    temp = await userManager.FindByIdAsync(item.Key);

                    if (temp == null)
                        return clientErrorManager.MapErrorIDToResultDto(7, item);
                    else if (temp.Id == curUser.Id)
                        return clientErrorManager.MapErrorIDToResultDto(8, item);

                    if (roles.FirstOrDefault((x) => x.Id == item.Value) == null)
                        return clientErrorManager.MapErrorIDToResultDto(9, item);
                    else if (item.Value < roles[0].Id)
                        return clientErrorManager.MapErrorIDToResultDto(10, item);

                    addUsers.Add(new UsersGroup { UserId = temp.Id, GroupRoleId = item.Value });
                }
            }

            addUsers.Add(new UsersGroup { UserId = curUser.Id, GroupRoleId = roles[0].Id });

            return new SingleResultDto<GroupDto>{
                IsSuccessful = true,
                Message = "Successful add group!",
                Data = mapper.Map<Group, GroupDto>(
                    await grpRep.Create(new Group {
                                        Name = entity.Name,
                                        Users = addUsers
                    }))
            };
        }

        public async Task<ResultDto> ExitFromGroup(int ID, User curUser) {
            Group grp = await IsIssetUserInGroupAsync(ID, curUser.Id);

            if (grp == null)
                return clientErrorManager.MapErrorIDToResultDto(11);

            GroupRole aRole = await GetFirstRoleAsync();
            UsersGroup usrGrp = grp.Users.FirstOrDefault((x) => x.UserId == curUser.Id);

            if (usrGrp.GroupRoleId == aRole.Id)
                return clientErrorManager.MapErrorIDToResultDto(13);

            await userGrpRep.Delete(usrGrp);

            return new ResultDto { IsSuccessful = true, Message = "Succesful exited from group!" };
        }

        public async Task<ResultDto> AddUsers(AddUsersToGroupDto entity, User curUser) {
            Group grp = await IsIssetUserInGroupAsync(entity.ID, curUser.Id);

            if (grp == null)
                return clientErrorManager.MapErrorIDToResultDto(11);

            if (entity.Users == null || entity.Users.Count == 0)
                return clientErrorManager.MapErrorIDToResultDto(15);

            List<UsersGroup> addUsers = new List<UsersGroup>();

            User temp;
            List<GroupRole> roles = new List<GroupRole>( await rolesRep.GetAll());

            foreach (var item in entity.Users)
            {
                if (item.Key == null)
                    clientErrorManager.MapErrorIDToResultDto(6, item);

                temp = await userManager.FindByIdAsync(item.Key);

                if (temp == null)
                    return clientErrorManager.MapErrorIDToResultDto(7, item);
                else if (temp.Id == curUser.Id)
                    return clientErrorManager.MapErrorIDToResultDto(8, item);
                else if (grp.Users.FirstOrDefault((x) => x.UserId == temp.Id) != null)
                    return clientErrorManager.MapErrorIDToResultDto(14, item);

                if (roles.FirstOrDefault((x) => x.Id == item.Value) == null)
                    return clientErrorManager.MapErrorIDToResultDto(9, item);
                else if (item.Value < roles[0].Id)
                    return clientErrorManager.MapErrorIDToResultDto(10, item);

                addUsers.Add(new UsersGroup { GroupId = entity.ID, UserId = temp.Id, GroupRoleId = item.Value });
            }

            return new SingleResultDto<IEnumerable<UsersGroupDto>>
            {
                IsSuccessful = true,
                Data = mapper.Map<IEnumerable<UsersGroup>, IEnumerable<UsersGroupDto>>(await userGrpRep.Create(addUsers)),
                Message = "Succesful added users!"
            };
        }

        public async Task<ResultDto> RemoveUsers(RemoveUsersFromGroupDto entity, User curUser)
        {
            Group grp = await IsIssetUserInGroupAsync(entity.ID, curUser.Id);

            if (grp == null)
                return clientErrorManager.MapErrorIDToResultDto(11);

            List<GroupRole> roles = new List<GroupRole>(await rolesRep.GetAll());

            if (grp.Users.FirstOrDefault((x) => x.UserId == curUser.Id && x.GroupRoleId == roles[0].Id) == null)
                clientErrorManager.MapErrorIDToResultDto(16);

            if (entity.Users == null || entity.Users.Count == 0)
                return clientErrorManager.MapErrorIDToResultDto(15);

            List<UsersGroup> removeUsers = new List<UsersGroup>();
            UsersGroup tempUserGrp;

            foreach (var item in entity.Users)
            {
                tempUserGrp = grp.Users.FirstOrDefault((x) => x.UserId == item);

                if (tempUserGrp == null)
                    return clientErrorManager.MapErrorIDToResultDto(17, item);
                else if (tempUserGrp.GroupRoleId == roles[0].Id || tempUserGrp.UserId == item)
                    return clientErrorManager.MapErrorIDToResultDto(13, item);

                removeUsers.Add(tempUserGrp);
            }

            await userGrpRep.Delete(removeUsers);

            return new ResultDto
            {
                IsSuccessful = true,
                Message = "Succesful removed users!"
            };
        }

        public async Task<ResultDto> RemoveGroup(int ID, User curUser)
        {
            GroupRole aRole = await GetFirstRoleAsync();
            Group grp = await IsIssetUserInGroupAsync(ID, curUser.Id);

            if (grp == null)
                return clientErrorManager.MapErrorIDToResultDto(11);

            if (grp.Users.FirstOrDefault((x) => x.UserId == curUser.Id && x.GroupRoleId == aRole.Id) == null)
                return clientErrorManager.MapErrorIDToResultDto(12);

            await grpRep.Delete(grp);

            return new ResultDto { IsSuccessful = true, Message = "Succesful group removed!" };
        }

        public async Task<ResultDto> Get(GetGroupsDto entity, User curUser) {
            List<GroupDto> groups = new List<GroupDto>();

            List<Group> grps = await GetGroups(curUser.Id);

            Dictionary<string, int> temp = new Dictionary<string, int>();
            foreach (var item in grps) {
                temp.Clear();

                foreach (var s in item.Users)
                    temp.Add(s.UserId, s.GroupRoleId);

                groups.Add(new GroupDto { Id = item.Id, Name = item.Name, Users = temp });
            }

            if (entity != null)
            {
                if (entity.Offset != null)
                {
                    if (entity.Offset > -1 && entity.Offset <= groups.Count)
                        groups = groups.Skip(entity.Offset.Value).ToList();
                    else return clientErrorManager.MapErrorIDToResultDto(20);
                }

                if (entity.Count != null) {
                    if (entity.Count > -1 && entity.Count <= groups.Count)
                        groups = groups.Take(entity.Count.Value).ToList();
                    else return clientErrorManager.MapErrorIDToResultDto(19);
                }   
            }

            return new SingleResultDto<IEnumerable<GroupDto>> {
                IsSuccessful = true,
                Message = "Succesful get groups!",
                Data = groups
            };
        }
    }
}
