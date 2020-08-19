//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Domain.TeamBuilding.Repositories
// FileName : ISalesQuotaRepository
//
// Created by : Will.Wu at 2020/8/19 11:34:52
//
//
//========================================================================
using System;
using Volo.Abp.Domain.Repositories;

namespace EMR.Domain.TeamBuilding.Repositories
{
    public interface ISalesQuotaRepository : IRepository<SalesQuota, Guid>
    {
    }
}