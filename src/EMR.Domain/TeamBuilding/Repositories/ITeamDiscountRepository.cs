//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Domain.TeamBuilding.Repositories
// FileName : ITeamDiscountRepository
//
// Created by : Will.Wu at 2020/8/19 11:34:00
//
//
//========================================================================
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Volo.Abp.Domain.Repositories;

namespace EMR.Domain.TeamBuilding.Repositories
{
    public interface ITeamDiscountRepository : IRepository<TeamDiscount, Guid>
    {
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="teams"> </param>
        /// <returns> </returns>
        Task BulkInsertAsync(IEnumerable<TeamDiscount> teamdiscounts);
    }
}