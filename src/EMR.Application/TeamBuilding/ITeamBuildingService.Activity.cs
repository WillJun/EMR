// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="ITeamBuildingService.Activity.cs" company="EMR.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
        /// Gets the activity asynchronous.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&lt;ActivityDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult<ActivityDto>> GetActivityAsync();


    }
}