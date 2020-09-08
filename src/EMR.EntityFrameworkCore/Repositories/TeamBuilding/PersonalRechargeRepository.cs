// ***********************************************************************
// Assembly         : EMR.EntityFrameworkCore
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="PersonalRechargeRepository.cs" company="EMR.EntityFrameworkCore">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EMR.Domain.TeamBuilding;
using EMR.Domain.TeamBuilding.Repositories;

using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

/// <summary>
/// The TeamBuilding namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.EntityFrameworkCore.Repositories.TeamBuilding
{
    /// <summary>
    /// Class PersonalRechargeRepository.
    /// Implements the <see cref="Volo.Abp.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{EMR.EntityFrameworkCore.EMRDbContext, EMR.Domain.TeamBuilding.PersonalRecharge, System.Guid}" />
    /// Implements the <see cref="EMR.Domain.TeamBuilding.Repositories.IPersonalRechargeRepository" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{EMR.EntityFrameworkCore.EMRDbContext, EMR.Domain.TeamBuilding.PersonalRecharge, System.Guid}" />
    /// <seealso cref="EMR.Domain.TeamBuilding.Repositories.IPersonalRechargeRepository" />
    /// <remarks>Will Wu</remarks>
    public class PersonalRechargeRepository : EfCoreRepository<EMRDbContext, PersonalRecharge, Guid>, IPersonalRechargeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalRechargeRepository"/> class.
        /// </summary>
        /// <param name="dbContextProvider">The database context provider.</param>
        /// <remarks>Will Wu</remarks>
        public PersonalRechargeRepository(IDbContextProvider<EMRDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        /// bulk insert as an asynchronous operation.
        /// </summary>
        /// <param name="personalRecharges">The personal recharges.</param>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task BulkInsertAsync(IEnumerable<PersonalRecharge> personalRecharges)
        {
            await DbContext.Set<PersonalRecharge>().AddRangeAsync(personalRecharges);
            await DbContext.SaveChangesAsync();
        }
    }
}