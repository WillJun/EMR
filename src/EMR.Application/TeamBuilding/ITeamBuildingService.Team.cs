// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="ITeamBuildingService.Team.cs" company="EMR.Application">
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
/// The TeamBuilding namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Application.TeamBuilding
{
    /// <summary>
    /// Interface ITeamBuildingService
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public partial interface ITeamBuildingService
    {
        /// <summary>
        /// Queries the teams asynchronous.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;TeamDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult<IEnumerable<TeamDto>>> QueryTeamsAsync();
        /// <summary>
        /// Teams the bulk insert asynchronous.
        /// </summary>
        /// <param name="teams">The teams.</param>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        Task TeamBulkInsertAsync(IEnumerable<Team> teams);
    }
}