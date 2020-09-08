// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 09-02-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="TeamBuildingService.TeamExpend.cs" company="EMR.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
using EMR.ToolKits.Base;

/// <summary>
/// The Impl namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Application.TeamBuilding.Impl
{
    /// <summary>
    /// Class TeamBuildingService.
    /// Implements the <see cref="EMR.Application.ServiceBase" />
    /// Implements the <see cref="EMR.Application.TeamBuilding.ITeamBuildingService" />
    /// </summary>
    /// <seealso cref="EMR.Application.ServiceBase" />
    /// <seealso cref="EMR.Application.TeamBuilding.ITeamBuildingService" />
    /// <remarks>Will Wu</remarks>
    public partial class TeamBuildingService
    {
        /// <summary>
        /// query team expend by team as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;TeamExpendDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
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