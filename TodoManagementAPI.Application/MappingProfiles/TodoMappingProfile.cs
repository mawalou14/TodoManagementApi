using AutoMapper;
using TodoManagementAPI.Domain.DTOs.User;
using TodoManagementAPI.Domain.Entities;

namespace TodoManagementAPI.Application.MappingProfiles
{
    public class TodoMappingProfile: Profile
    {
        public TodoMappingProfile()
        {
            CreateMap<User, UserProfile>().ReverseMap();
            CreateMap<Register, User>();
            CreateMap<Login, User>();
        }
    }
}
