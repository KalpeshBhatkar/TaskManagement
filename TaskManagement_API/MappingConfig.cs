using AutoMapper;
using TaskManagement_API.Models;
using TaskManagement_API.Models.DTO;

namespace TaskManagement_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Team, TeamDTO>().ReverseMap();
        }
    }
}
