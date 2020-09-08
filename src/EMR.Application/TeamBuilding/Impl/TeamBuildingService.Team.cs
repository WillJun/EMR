// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="TeamBuildingService.Team.cs" company="EMR.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
using EMR.Domain.TeamBuilding;
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
        /// query teams as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;TeamDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult<IEnumerable<TeamDto>>> QueryTeamsAsync()
        {
            var result = new ServiceResult<IEnumerable<TeamDto>>();
            var lists = await _teamRepository.GetListAsync();
            var teams = ObjectMapper.Map<IEnumerable<Team>, IEnumerable<TeamDto>>(lists);
            result.IsSuccess(teams);
            return result;
        }

        /// <summary>
        /// team bulk insert as an asynchronous operation.
        /// </summary>
        /// <param name="teams">The teams.</param>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task TeamBulkInsertAsync(IEnumerable<Team> teams)
        {
            await _teamRepository.BulkInsertAsync(teams);
        }
    }
}