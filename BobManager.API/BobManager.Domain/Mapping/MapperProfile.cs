using AutoMapper;
using BobManager.DataAccess.Entities;
using BobManager.Dto.DtoModels;

namespace BobManager.Domain.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ToDo, ToDoDto>();
            CreateMap<ToDoCategory, ToDoCategoryDto>();
            CreateMap<SpendingDto, Spending>().ReverseMap();
            CreateMap<SpendingCategoryDto, SpendingCategory>().ReverseMap();
            CreateMap<User, UserDto>();
            CreateMap<UsersGroup, UsersGroupDto>();
            CreateMap<Group, GroupDto>();
        }
    }
}