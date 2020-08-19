//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Domain.TeamBuilding.Repositories
// FileName : IPersonalRechargeRepository
//
// Created by : Will.Wu at 2020/8/19 11:35:45
//
//
//========================================================================
using System;
using Volo.Abp.Domain.Repositories;

namespace EMR.Domain.TeamBuilding.Repositories
{
    public interface IPersonalRechargeRepository : IRepository<PersonalRecharge, Guid>
    {
    }
}