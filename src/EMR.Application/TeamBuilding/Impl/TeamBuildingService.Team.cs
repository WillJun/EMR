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
using System.Collections.Generic;
using System.Threading.Tasks;
using EMR.Application.Contracts.TeamBuilding;
using EMR.Domain.TeamBuilding;
using EMR.ToolKits.Base;

namespace EMR.Application.TeamBuilding.Impl
{
    public partial class TeamBuildingService
    {
        public async Task<ServiceResult<IEnumerable<TeamDto>>> QueryTeamsAsync()
        {
            var result = new ServiceResult<IEnumerable<TeamDto>>();
            var lists = await _teamRepository.GetListAsync();
            var teams = ObjectMapper.Map<IEnumerable<Team>, IEnumerable<TeamDto>>(lists);
            result.IsSuccess(teams);
            return result;
        }
    }
}