// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="ITeamBuildingService.User.cs" company="EMR.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
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
        /// Gets the user detail asynchronous.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>Task&lt;ServiceResult&lt;UserDetailDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult<UserDetailDto>> GetUserDetailAsync(string account);

        /// <summary>
        /// Queries the users by team asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;QueryUserDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult<IEnumerable<QueryUserDto>>> QueryUsersByTeamAsync(Guid id);

        /// <summary>
        /// Users the bulk insert asynchronous.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        Task UserBulkInsertAsync(IEnumerable<User> users);
    }
}