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
            CreateMap<TeamWow, TeamWowDto>();

            CreateMap<EditTeamWowInput, TeamWow>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<EditPersonalExpenditureInput, PersonalExpenditure>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<EditPersonalRechargeInput, PersonalRecharge>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<EditSalesQuotaInput, SalesQuota>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}