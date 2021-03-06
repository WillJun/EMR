﻿// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="TeamBuildingService.User.cs" company="EMR.Application">
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
using EMR.ToolKits.Extensions;

using static EMR.Domain.Shared.EMRConsts;

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
        /// Gets the user detail asynchronous.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>Task&lt;ServiceResult&lt;UserDetailDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult<UserDetailDto>> GetUserDetailAsync(string account)
        {
            var result = new ServiceResult<UserDetailDto>();
            var user = await _userRepository.FindAsync(x => x.Account.Equals(account));
            if (null == user)
            {
                result.IsFailed(ResponseText.WHAT_NOT_EXIST.FormatWith("Account", account));
                return result;
            }
            var teaminfo = await _teamRepository.GetAsync(user.TeamId);

            var personalrecharges = from pr in await _personalrechargeRepository.GetListAsync()
                                    join team in await _teamRepository.GetListAsync()
                                    on pr.SourceId equals team.Id
                                    where pr.UserId == user.Id
                                    orderby pr.CreateTime descending
                                    select new PersonalRechargeDto
                                    {
                                        Amount = pr.Amount,
                                        Comment = pr.Comment,
                                        CreateTime = pr.CreateTime,
                                        SerialNumber = pr.SerialNumber,
                                        SourceName = team.TeamName
                                    };

            var personalexpenditures = from pe in await _personalexpenditureRepository.GetListAsync()
                                       join team in await _teamRepository.GetListAsync()
                                       on pe.ExpenditureTeamId equals team.Id
                                       where pe.UserId == user.Id
                                       orderby pe.CreateTime descending
                                       select new PersonalExpenditureDto
                                       {
                                           Comment = pe.Comment,
                                           CreateTime = pe.CreateTime,
                                           Expend = pe.Expend,
                                           ExpenditureName = team.TeamName,
                                           SerialNumber = pe.SerialNumber
                                       };

            var userDetail = new UserDetailDto
            {
                Id = user.Id,
                Account = user.Account,
                Balance = user.Balance,
                Dept = user.Dept,
                Email = user.Email,
                IsLeader = user.IsLeader,
                IsOverspend = user.IsOverspend,
                UserEnName = user.UserEnName,
                UserName = user.UserName,
                TeamInfo = new TeamDto
                {
                    Id = teaminfo.Id,
                    TeamName = teaminfo.TeamName,
                    CreateTime = teaminfo.CreateTime,
                    IsOrganiser = teaminfo.IsOrganiser,
                    TeamLeader = teaminfo.TeamLeader,
                    Logo = teaminfo.Logo
                },
                PersonalExpenditures = personalexpenditures,
                PersonalRecharges = personalrecharges
            };
            result.IsSuccess(userDetail);
            return result;
        }

        /// <summary>
        /// Queries the users by team asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;QueryUserDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult<IEnumerable<QueryUserDto>>> QueryUsersByTeamAsync(Guid
            id)
        {
            var result = new ServiceResult<IEnumerable<QueryUserDto>>();
            var list = (from u in await _userRepository.GetListAsync()
                        join t in await _teamRepository.GetListAsync()
                        on u.TeamId equals t.Id
                        where t.Id == id
                        select new QueryUserDto
                        {
                            Id = u.Id,
                            Account = u.Account,
                            IsLeader = u.IsLeader,
                            Balance = u.Balance,
                            Dept = u.Dept,
                            Email = u.Email,
                            IsOverspend = u.IsOverspend,
                            UserEnName = u.UserEnName,
                            UserName = u.UserName
                        }).OrderByDescending(p => p.IsLeader).ThenBy(p => p.UserEnName).ToList();
            result.IsSuccess(list);
            return result;
        }

        /// <summary>
        /// user bulk insert as an asynchronous operation.
        /// </summary>
        /// <param name="users">The users.</param>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task UserBulkInsertAsync(IEnumerable<User> users)
        {
            await _userRepository.BulkInsertAsync(users);
        }
    }
}