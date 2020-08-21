using AutoMapper;

using EMR.Application.Contracts.TeamBuilding;
using EMR.Application.Contracts.TeamBuilding.Input;
using EMR.Domain.TeamBuilding;

namespace EMR.Application
{
    public class EMRAutoMapperProfile : Profile
    {
        public EMRAutoMapperProfile()
        {
            CreateMap<Team, TeamDto>();

            CreateMap<EditTeamWowInput, TeamWow>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}