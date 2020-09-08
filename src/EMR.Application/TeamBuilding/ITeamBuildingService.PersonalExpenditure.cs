// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="ITeamBuildingService.PersonalExpenditure.cs" company="EMR.Application">
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
        /// Queries the personal expenditures by user asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;PersonalExpenditureDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult<IEnumerable<PersonalExpenditureDto>>> QueryPersonalExpendituresByUserAsync(Guid id);

        /// <summary>
        /// Queries the team expenditures asynchronous.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;TeamExpenditureTotalDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult<IEnumerable<TeamExpenditureTotalDto>>> QueryTeamExpendituresAsync();
    }
}