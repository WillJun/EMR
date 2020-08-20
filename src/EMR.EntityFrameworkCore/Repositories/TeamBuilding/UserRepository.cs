//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.EntityFrameworkCore.Repositories.TeamBuilding
// FileName : UserRepository
//
// Created by : Will.Wu at 2020/8/19 11:40:18
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
    public class UserRepository : EfCoreRepository<EMRDbContext, User, Guid>, IUserRepository
    {
        public UserRepository(IDbContextProvider<EMRDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task BulkInsertAsync(IEnumerable<User> users)
        {
            await DbContext.Set<User>().AddRangeAsync(users);
            await DbContext.SaveChangesAsync();
        }
    }
}