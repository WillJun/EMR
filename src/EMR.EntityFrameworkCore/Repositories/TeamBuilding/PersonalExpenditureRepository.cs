//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.EntityFrameworkCore.Repositories.TeamBuilding
// FileName : PersonalExpenditureRepository
//
// Created by : Will.Wu at 2020/8/19 11:46:11
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
    public class PersonalExpenditureRepository : EfCoreRepository<EMRDbContext, PersonalExpenditure, Guid>, IPersonalExpenditureRepository
    {
        public PersonalExpenditureRepository(IDbContextProvider<EMRDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}