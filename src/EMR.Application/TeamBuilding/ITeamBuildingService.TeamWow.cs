//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.TeamBuilding
// FileName : ITeamBuildingService
//
// Created by : Will.Wu at 2020/8/19 15:38:56
//
//
//========================================================================
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
using EMR.ToolKits.Base;

namespace EMR.Application.TeamBuilding
{
    public partial interface ITeamBuildingService
    {
        Task<ServiceResult<TeamWowCountDto>> QueryTeamWowCountsByTeamAsync(Guid id);

        Task<ServiceResult<UserWowCountDto>> QueryUserWowCountsByUserAsync(Guid id);

        Task<ServiceResult<IEnumerable<TeamWowCountDto>>> QueryTeamWowCountsAsync();
    }
}