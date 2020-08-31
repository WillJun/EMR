//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.TeamBuilding.Impl
// FileName : TeamBuildingService
//
// Created by : Will.Wu at 2020/8/19 14:46:40
//
//
//========================================================================
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
using EMR.Domain.TeamBuilding;
using EMR.ToolKits.Base;

namespace EMR.Application.TeamBuilding.Impl
{
    public partial class TeamBuildingService
    {
        public async Task<ServiceResult<IEnumerable<TeamDiscountDto>>> QueryTeamDiscountByTeamAsync(Guid id)
        {
            var result = new ServiceResult<IEnumerable<TeamDiscountDto>>();
            var lists = await _teamdiscountRepository.GetListAsync();
            var teams = ObjectMapper.Map<IEnumerable<TeamDiscount>, IEnumerable<TeamDiscountDto>>(lists);
            result.IsSuccess(teams);
            return result;
        }
    }
}