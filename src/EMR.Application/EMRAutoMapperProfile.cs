// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="EMRAutoMapperProfile.cs" company="EMR.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using AutoMapper;

using EMR.Application.Contracts.TeamBuilding;
using EMR.Application.Contracts.TeamBuilding.Input;
using EMR.Domain.TeamBuilding;

/// <summary>
/// The Application namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Application
{
    /// <summary>
    /// Class EMRAutoMapperProfile.
    /// Implements the <see cref="AutoMapper.Profile" />
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    /// <remarks>Will Wu</remarks>
    public class EMRAutoMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EMRAutoMapperProfile" /> class.
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public EMRAutoMapperProfile()
        {
            CreateMap<Team, TeamDto>();
            CreateMap<TeamWow, TeamWowDto>();

            CreateMap<EditTeamWowInput, TeamWow>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<EditPersonalExpenditureInput, PersonalExpenditure>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<EditPersonalRechargeInput, PersonalRecharge>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<EditSalesQuotaInput, SalesQuota>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<EditTeamExpendInput, TeamExpend>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}