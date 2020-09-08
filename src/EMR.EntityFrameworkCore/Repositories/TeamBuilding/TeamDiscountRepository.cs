// ***********************************************************************
// Assembly         : EMR.EntityFrameworkCore
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="TeamDiscountRepository.cs" company="EMR.EntityFrameworkCore">
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
    /// Class TeamDiscountRepository.
    /// Implements the <see cref="Volo.Abp.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{EMR.EntityFrameworkCore.EMRDbContext, EMR.Domain.TeamBuilding.TeamDiscount, System.Guid}" />
    /// Implements the <see cref="EMR.Domain.TeamBuilding.Repositories.ITeamDiscountRepository" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{EMR.EntityFrameworkCore.EMRDbContext, EMR.Domain.TeamBuilding.TeamDiscount, System.Guid}" />
    /// <seealso cref="EMR.Domain.TeamBuilding.Repositories.ITeamDiscountRepository" />
    /// <remarks>Will Wu</remarks>
    public class TeamDiscountRepository : EfCoreRepository<EMRDbContext, TeamDiscount, Guid>, ITeamDiscountRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamDiscountRepository"/> class.
        /// </summary>
        /// <param name="dbContextProvider">The database context provider.</param>
        /// <remarks>Will Wu</remarks>
        public TeamDiscountRepository(IDbContextProvider<EMRDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        /// bulk insert as an asynchronous operation.
        /// </summary>
        /// <param name="teamdiscounts">The teamdiscounts.</param>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task BulkInsertAsync(IEnumerable<TeamDiscount> teamdiscounts)
        {
            await DbContext.Set<TeamDiscount>().AddRangeAsync(teamdiscounts);
            await DbContext.SaveChangesAsync();
        }
    }
}