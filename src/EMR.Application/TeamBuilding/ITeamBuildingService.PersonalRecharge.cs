//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.TeamBuilding
// FileName : ITeamBuilding
//
// Created by : Will.Wu at 2020/8/19 15:17:16
//
//
//========================================================================
using System.Collections.Generic;
using System.Threading.Tasks;
using EMR.Application.Contracts.TeamBuilding;
using EMR.Domain.TeamBuilding;
using EMR.ToolKits.Base;

namespace EMR.Application.TeamBuilding
{
    public partial interface ITeamBuildingService
    {
        Task<ServiceResult<IEnumerable<PersonalRechargeDto>>> QueryPersonalRechargesByUserAsync(string account);

        Task PersonalRechargeBulkInsertAsync(IEnumerable<PersonalRecharge> personalRecharges);
    }
}