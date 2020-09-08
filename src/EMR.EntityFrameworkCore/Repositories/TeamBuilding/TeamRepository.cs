// ***********************************************************************
// Assembly         : EMR.EntityFrameworkCore
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="TeamRepository.cs" company="EMR.EntityFrameworkCore">
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
    /// Class TeamRepository.
    /// Implements the <see cref="Volo.Abp.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{EMR.EntityFrameworkCore.EMRDbContext, EMR.Domain.TeamBuilding.Team, System.Guid}" />
    /// Implements the <see cref="EMR.Domain.TeamBuilding.Repositories.ITeamRepository" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{EMR.EntityFrameworkCore.EMRDbContext, EMR.Domain.TeamBuilding.Team, System.Guid}" />
    /// <seealso cref="EMR.Domain.TeamBuilding.Repositories.ITeamRepository" />
    /// <remarks>Will Wu</remarks>
    public class TeamRepository : EfCoreRepository<EMRDbContext, Team, Guid>, ITeamRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamRepository"/> class.
        /// </summary>
        /// <param name="dbContextProvider">The database context provider.</param>
        /// <remarks>Will Wu</remarks>
        public TeamRepository(IDbContextProvider<EMRDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        /// bulk insert as an asynchronous operation.
        /// </summary>
        /// <param name="teams">The teams.</param>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task BulkInsertAsync(IEnumerable<Team> teams)
        {
            await DbContext.Set<Team>().AddRangeAsync(teams);
            await DbContext.SaveChangesAsync();
        }
    }
}