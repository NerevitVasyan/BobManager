using AutoMapper;
using BobManager.DataAccess.Entities;
using BobManager.Dto.DtoModels;

namespace BobManager.Domain.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Spending, SpendingDto>();
            CreateMap<SpendingCategory, SpendingCategoryDto>();
            CreateMap<User, UserDto>();
            CreateMap<Group, GroupDto>();
        }
    }
}