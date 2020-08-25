//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.TeamBuilding
// FileName : ITeamBuildingService
//
// Created by : Will.Wu at 2020/8/19 14:54:58
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
        Task<ServiceResult<IEnumerable<SalesQuotaWithUserDto>>> QuerySalesQuotasByTeamAsync(Guid id);

        Task<ServiceResult<IEnumerable<SalesQuotaWithUserDto>>> QuerySalesQuotasByUserAsync(Guid id);

        Task<ServiceResult<TeamSalesQuotaTotalDto>> QueryTeamSalesQuotasByTeamAsync(Guid id);

        Task<ServiceResult<UserSalesQuotaTotalDto>> QueryUserSalesQuotasByUserAsync(Guid id);

        Task<ServiceResult<IEnumerable<TeamSalesQuotaTotalDto>>> QueryTeamSalesQuotasAsync();
    }
}