//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.EntityFrameworkCore.Repositories.TeamBuilding
// FileName : TeamDiscountRepository
//
// Created by : Will.Wu at 2020/8/19 11:42:52
//
//
//========================================================================
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EMR.Domain.TeamBuilding;
using EMR.Domain.TeamBuilding.Repositories;

using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EMR.EntityFrameworkCore.Repositories.TeamBuilding
{
    public class TeamDiscountRepository : EfCoreRepository<EMRDbContext, TeamDiscount, Guid>, ITeamDiscountRepository
    {
        public TeamDiscountRepository(IDbContextProvider<EMRDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task BulkInsertAsync(IEnumerable<TeamDiscount> teamdiscounts)
        {
            await DbContext.Set<TeamDiscount>().AddRangeAsync(teamdiscounts);
            await DbContext.SaveChangesAsync();
        }
    }
}