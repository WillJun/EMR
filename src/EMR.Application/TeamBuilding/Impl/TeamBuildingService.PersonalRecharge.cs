// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="TeamBuildingService.PersonalRecharge.cs" company="EMR.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
using EMR.Domain.TeamBuilding;
using EMR.ToolKits.Base;

/// <summary>
/// The Impl namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Application.TeamBuilding.Impl
{
    /// <summary>
    /// Class TeamBuildingService.
    /// Implements the <see cref="EMR.Application.ServiceBase" />
    /// Implements the <see cref="EMR.Application.TeamBuilding.ITeamBuildingService" />
    /// </summary>
    /// <seealso cref="EMR.Application.ServiceBase" />
    /// <seealso cref="EMR.Application.TeamBuilding.ITeamBuildingService" />
    /// <remarks>Will Wu</remarks>
    public partial class TeamBuildingService
    {
        /// <summary>
        /// query personal recharges by user as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;PersonalRechargeDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult<IEnumerable<PersonalRechargeDto>>> QueryPersonalRechargesByUserAsync(Guid id)
        {
            var result = new ServiceResult<IEnumerable<PersonalRechargeDto>>();
            var list = (from pr in await _personalrechargeRepository.GetListAsync()
                        join t in await _teamRepository.GetListAsync()

                        on pr.SourceId equals t.Id
                        join u in await _userRepository.GetListAsync()
                        on pr.UserId equals u.Id

                        where u.Id == id
                        orderby pr.CreateTime ascending
                        select new PersonalRechargeDto
                        {
                            Amount = pr.Amount,
                            Comment = pr.Comment,
                            CreateTime = pr.CreateTime,
                            SerialNumber = pr.SerialNumber,
                            SourceName = t.TeamName
                        }).OrderByDescending(p => p.CreateTime).ToList();
            result.IsSuccess(list);
            return result;
        }

        /// <summary>
        /// personal recharge bulk insert as an asynchronous operation.
        /// </summary>
        /// <param name="personalRecharges">The personal recharges.</param>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task PersonalRechargeBulkInsertAsync(IEnumerable<PersonalRecharge> personalRecharges)
        {
            await _personalrechargeRepository.BulkInsertAsync(personalRecharges);
        }
    }
}