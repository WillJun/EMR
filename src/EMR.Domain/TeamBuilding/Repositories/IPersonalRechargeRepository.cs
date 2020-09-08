// ***********************************************************************
// Assembly         : EMR.Domain
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="IPersonalRechargeRepository.cs" company="EMR.Domain">
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
    /// Interface IPersonalRechargeRepository
    /// Implements the <see cref="Volo.Abp.Domain.Repositories.IRepository{EMR.Domain.TeamBuilding.PersonalRecharge, System.Guid}" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Repositories.IRepository{EMR.Domain.TeamBuilding.PersonalRecharge, System.Guid}" />
    /// <remarks>Will Wu</remarks>
    public interface IPersonalRechargeRepository : IRepository<PersonalRecharge, Guid>
    {
        /// <summary>
        /// Bulks the insert asynchronous.
        /// </summary>
        /// <param name="personalRecharges">The personal recharges.</param>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        Task BulkInsertAsync(IEnumerable<PersonalRecharge> personalRecharges);
    }
}