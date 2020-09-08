// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="ITeamBuildingService.TeamWow.cs" company="EMR.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
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
        /// Queries the team wow counts by team asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;TeamWowCountDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult<TeamWowCountDto>> QueryTeamWowCountsByTeamAsync(Guid id);

        /// <summary>
        /// Queries the user wow counts by user asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;UserWowCountDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult<UserWowCountDto>> QueryUserWowCountsByUserAsync(Guid id);

        /// <summary>
        /// Queries the team wow counts asynchronous.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;TeamWowCountDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult<IEnumerable<TeamWowCountDto>>> QueryTeamWowCountsAsync();
    }
}