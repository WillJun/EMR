// ***********************************************************************
// Assembly         : EMR.Domain
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-02-2020
// ***********************************************************************
// <copyright file="ITeamDiscountRepository.cs" company="EMR.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Volo.Abp.Domain.Repositories;

/// <summary>
/// The Repositories namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Domain.TeamBuilding.Repositories
{
    /// <summary>
    /// Interface ITeamDiscountRepository
    /// Implements the <see cref="Volo.Abp.Domain.Repositories.IRepository{EMR.Domain.TeamBuilding.TeamDiscount, System.Guid}" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Repositories.IRepository{EMR.Domain.TeamBuilding.TeamDiscount, System.Guid}" />
    /// <remarks>Will Wu</remarks>
    public interface ITeamDiscountRepository : IRepository<TeamDiscount, Guid>
    {
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="teamdiscounts">The teamdiscounts.</param>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        Task BulkInsertAsync(IEnumerable<TeamDiscount> teamdiscounts);
    }
}