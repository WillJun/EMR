// ***********************************************************************
// Assembly         : EMR.EntityFrameworkCore
// Author           : WuJun
// Created          : 09-08-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="ActivityRepository.cs" company="EMR.EntityFrameworkCore">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
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
    /// Class ActivityRepository.
    /// Implements the <see cref="Volo.Abp.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{EMR.EntityFrameworkCore.EMRDbContext, EMR.Domain.TeamBuilding.Activity, System.Guid}" />
    /// Implements the <see cref="EMR.Domain.TeamBuilding.Repositories.IActivityRepository" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{EMR.EntityFrameworkCore.EMRDbContext, EMR.Domain.TeamBuilding.Activity, System.Guid}" />
    /// <seealso cref="EMR.Domain.TeamBuilding.Repositories.IActivityRepository" />
    /// <remarks>Will Wu</remarks>
    public class ActivityRepository : EfCoreRepository<EMRDbContext, Activity, Guid>, IActivityRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityRepository"/> class.
        /// </summary>
        /// <param name="dbContextProvider">The database context provider.</param>
        /// <remarks>Will Wu</remarks>
        public ActivityRepository(IDbContextProvider<EMRDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        /// insert as an asynchronous operation.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task InsertAsync(Activity activity)
        {
            await DbContext.Set<Activity>().AddRangeAsync(activity);
            await DbContext.SaveChangesAsync();
        }
    }
}