//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.TeamBuilding
// FileName : ITeamBuildingService
//
// Created by : Will.Wu at 2020/8/19 13:05:11
//
//
//========================================================================
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
using EMR.Domain.TeamBuilding;
using EMR.ToolKits.Base;

namespace EMR.Application.TeamBuilding
{
    public partial interface ITeamBuildingService
    {
        /// <summary>
        /// Gets the user detail asynchronous.
        /// </summary>
        /// <param name="account"> The account. </param>
        /// <returns> </returns>
        Task<ServiceResult<UserDetailDto>> GetUserDetailAsync(string account);

        /// <summary>
        /// Queries the users by team asynchronous.
        /// </summary>
        /// <param name="teamname"> The teamname. </param>
        /// <returns> </returns>
        Task<ServiceResult<IEnumerable<QueryUserDto>>> QueryUsersByTeamAsync(Guid id);

        Task UserBulkInsertAsync(IEnumerable<User> users);
    }
}