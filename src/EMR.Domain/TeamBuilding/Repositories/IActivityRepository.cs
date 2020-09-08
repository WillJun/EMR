//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Domain.TeamBuilding.Repositories
// FileName : IActivityRepository
//
// Created by : Will.Wu at 2020/9/8 16:14:12
//
//
//========================================================================
using System;
using System.Threading.Tasks;

using Volo.Abp.Domain.Repositories;

namespace EMR.Domain.TeamBuilding.Repositories
{
    public interface IActivityRepository : IRepository<Activity, Guid>
    {
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="activity"> </param>
        /// <returns> </returns>
        Task InsertAsync(Activity activity);
    }
}