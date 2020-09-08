//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.EntityFrameworkCore.Repositories.TeamBuilding
// FileName : ActivityRepository
//
// Created by : Will.Wu at 2020/9/8 16:25:31
//
//
//========================================================================
using System;
using System.Threading.Tasks;

using EMR.Domain.TeamBuilding;
using EMR.Domain.TeamBuilding.Repositories;

using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EMR.EntityFrameworkCore.Repositories.TeamBuilding
{
    public class ActivityRepository : EfCoreRepository<EMRDbContext, Activity, Guid>, IActivityRepository
    {
        public ActivityRepository(IDbContextProvider<EMRDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task InsertAsync(Activity activity)
        {
            await DbContext.Set<Activity>().AddRangeAsync(activity);
            await DbContext.SaveChangesAsync();
        }
    }
}