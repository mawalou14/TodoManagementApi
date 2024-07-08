using AutoMapper;
using TodoManagementAPI.Domain.DTOs.Todo;
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
            CreateMap<UpdateTodoDto, Todo>().ReverseMap();
            CreateMap<CreateTodoDto, Todo>();
            CreateMap<Todo, TodoDto>().ReverseMap();
            CreateMap<Todo, GetTodoDto>().ReverseMap();
            CreateMap<UpdateTodoStatusDto, Todo>();
            CreateMap<UpdateTodoPriorityDto, Todo>();
        }
    }
}
