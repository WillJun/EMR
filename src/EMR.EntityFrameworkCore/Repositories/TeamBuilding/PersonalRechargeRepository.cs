//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.EntityFrameworkCore.Repositories.TeamBuilding
// FileName : PersonalRechargeRepository
//
// Created by : Will.Wu at 2020/8/19 11:45:21
//
//
//========================================================================
using System;
using EMR.Domain.TeamBuilding;
using EMR.Domain.TeamBuilding.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EMR.EntityFrameworkCore.Repositories.TeamBuilding
{
    public class PersonalRechargeRepository : EfCoreRepository<EMRDbContext, PersonalRecharge, Guid>, IPersonalRechargeRepository
    {
        public PersonalRechargeRepository(IDbContextProvider<EMRDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}