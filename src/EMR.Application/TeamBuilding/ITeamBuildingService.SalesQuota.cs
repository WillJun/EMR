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
using System.Collections.Generic;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
using EMR.ToolKits.Base;

namespace EMR.Application.TeamBuilding
{
    public partial interface ITeamBuildingService
    {
        Task<ServiceResult<IEnumerable<SalesQuotaDto>>> QuerySalesQuotasByTeamAsync(string teamname);

        Task<ServiceResult<IEnumerable<SalesQuotaDto>>> QuerySalesQuotasByUserAsync(string account);

        Task<ServiceResult<TeamSalesQuotaTotalDto>> QueryTeamSalesQuotasByTeamAsync(string teamname);

        Task<ServiceResult<UserSalesQuotaTotalDto>> QueryUserSalesQuotasByUserAsync(string account);

        Task<ServiceResult<IEnumerable<TeamSalesQuotaTotalDto>>> QueryTeamSalesQuotasAsync();
    }
}