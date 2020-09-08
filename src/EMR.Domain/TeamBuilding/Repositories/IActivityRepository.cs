// ***********************************************************************
// Assembly         : EMR.Domain
// Author           : WuJun
// Created          : 09-08-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="IActivityRepository.cs" company="EMR.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading.Tasks;

using Volo.Abp.Domain.Repositories;

/// <summary>
/// The Repositories namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Domain.TeamBuilding.Repositories
{
    /// <summary>
    /// Interface IActivityRepository
    /// Implements the <see cref="Volo.Abp.Domain.Repositories.IRepository{EMR.Domain.TeamBuilding.Activity, System.Guid}" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Repositories.IRepository{EMR.Domain.TeamBuilding.Activity, System.Guid}" />
    /// <remarks>Will Wu</remarks>
    public interface IActivityRepository : IRepository<Activity, Guid>
    {
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        Task InsertAsync(Activity activity);
    }
}