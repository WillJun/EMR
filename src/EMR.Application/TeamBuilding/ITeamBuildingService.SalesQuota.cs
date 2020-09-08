// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="ITeamBuildingService.SalesQuota.cs" company="EMR.Application">
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
        /// Queries the sales quotas by team asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;SalesQuotaWithUserDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult<IEnumerable<SalesQuotaWithUserDto>>> QuerySalesQuotasByTeamAsync(Guid id);

        /// <summary>
        /// Queries the sales quotas by user asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;SalesQuotaWithUserDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult<IEnumerable<SalesQuotaWithUserDto>>> QuerySalesQuotasByUserAsync(Guid id);

        /// <summary>
        /// Queries the team sales quotas by team asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;TeamSalesQuotaTotalDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult<TeamSalesQuotaTotalDto>> QueryTeamSalesQuotasByTeamAsync(Guid id);

        /// <summary>
        /// Queries the user sales quotas by user asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;UserSalesQuotaTotalDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult<UserSalesQuotaTotalDto>> QueryUserSalesQuotasByUserAsync(Guid id);

        /// <summary>
        /// Queries the team sales quotas asynchronous.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;TeamSalesQuotaTotalDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult<IEnumerable<TeamSalesQuotaTotalDto>>> QueryTeamSalesQuotasAsync();
    }
}