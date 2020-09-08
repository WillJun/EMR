// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 09-02-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="TeamBuildingService.TeamDiscount.cs" company="EMR.Application">
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
        /// query team discount by team as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;TeamDiscountDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
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