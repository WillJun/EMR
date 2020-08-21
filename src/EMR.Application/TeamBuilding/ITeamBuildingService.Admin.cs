//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.TeamBuilding
// FileName : ITeamBuildingService
//
// Created by : Will.Wu at 2020/8/21 16:17:20
//
//
//========================================================================

using System;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding.Input;
using EMR.ToolKits.Base;

namespace EMR.Application.TeamBuilding
{
    public partial interface ITeamBuildingService
    {
        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="input"> </param>
        /// <returns> </returns>
        Task<ServiceResult> InsertWowAsync(EditTeamWowInput input);

        /// <summary>
        /// 取消赞
        /// </summary>
        /// <param name="id"> </param>
        /// <returns> </returns>
        Task<ServiceResult> DeleteWowAsync(Guid id);
    }
}