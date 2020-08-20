using AutoMapper;

using EMR.Application.Contracts.TeamBuilding;
using EMR.Domain.TeamBuilding;

namespace EMR.Application
{
    public class EMRAutoMapperProfile : Profile
    {
        public EMRAutoMapperProfile()
        {
            CreateMap<Team, TeamDto>();
        }
    }
}