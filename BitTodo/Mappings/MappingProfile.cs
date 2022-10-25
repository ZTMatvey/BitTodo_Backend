using AutoMapper;
using BitTodo.Domain.DTOs.Request;
using BitTodo.Domain.DTOs.Response;
using BitTodo.Domain.Models;

namespace BitTodo.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Group, GroupDTO>();
            CreateMap<AddTaskDTO, Domain.Models.Task>()
                .ForMember(dest => dest.GroupId,
                opt => opt.MapFrom(x => Guid.Parse(x.GroupId)));
            CreateMap<Domain.Models.Task, TaskDTO>();
        }
    }
}
