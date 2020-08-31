//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.TeamBuilding.Impl
// FileName : TeamBuildingService
//
// Created by : Will.Wu at 2020/8/19 15:24:42
//
//
//========================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
using EMR.ToolKits.Base;

namespace EMR.Application.TeamBuilding.Impl
{
    public partial class TeamBuildingService
    {
        public async Task<ServiceResult<IEnumerable<TeamExpendDto>>> QueryTeamExpendByTeamAsync(Guid id)
        {
            var result = new ServiceResult<IEnumerable<TeamExpendDto>>();
            var list = (from pe in await _teamexpendRepository.GetListAsync()
                        join t in await _teamRepository.GetListAsync()

                        on pe.TeamId equals t.Id

                        where t.Id == id
                        orderby pe.CreateTime ascending
                        select new TeamExpendDto
                        {
                            Expend = pe.Expend,
                            Comment = pe.Comment,
                            CreateTime = pe.CreateTime,
                            SerialNumber = pe.SerialNumber,
                            TeamName = t.TeamName
                        });
            result.IsSuccess(list);
            return result;
        }
    }
}