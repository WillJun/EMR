// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="TeamBuildingService.TeamWow.cs" company="EMR.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
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
        /// query team wow counts as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;TeamWowCountDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult<IEnumerable<TeamWowCountDto>>> QueryTeamWowCountsAsync()
        {
            var result = new ServiceResult<IEnumerable<TeamWowCountDto>>();
            var list = (from u in await _teamRepository.GetListAsync()
                        join s in await _teamwowRepository.GetListAsync()

                        on u.Id equals s.TeamId into lj
                        from ls in lj.DefaultIfEmpty()
                        where u.IsOrganiser == false
                        group (ls, u) by new { u.TeamName, u.Id } into g
                        select new TeamWowCountDto
                        {
                            Count = g.Where(p => p.ls != null).Count(),
                            TeamName = g.Key.TeamName,
                            Id = g.Key.Id,
                            LastDateTime = g.Where(p => p.ls != null).Count() == 0 ? DateTime.Now : g.Max(p => p.ls.WowTime)
                        }).OrderByDescending(p => p.Count).ThenBy(p => p.LastDateTime).ToList(); ;
            result.IsSuccess(list);
            return result;
        }

        /// <summary>
        /// query team wow counts by team as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;TeamWowCountDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult<TeamWowCountDto>> QueryTeamWowCountsByTeamAsync(Guid id)
        {
            var result = new ServiceResult<TeamWowCountDto>();
            var data = (from u in await _teamRepository.GetListAsync()
                        join s in await _teamwowRepository.GetListAsync()

                        on u.Id equals s.TeamId into lj
                        from ls in lj.DefaultIfEmpty()
                        where u.Id == id
                        group (ls, u) by new { u.TeamName, u.Id } into g
                        select new TeamWowCountDto
                        {
                            Count = g.Where(p => p.ls != null).Count(),
                            TeamName = g.Key.TeamName,
                            Id = g.Key.Id,
                            LastDateTime = g.Where(p => p.ls != null).Count() == 0 ? DateTime.Now : g.Max(p => p.ls.WowTime)
                        }).FirstOrDefault();
            result.IsSuccess(data);
            return result;
        }

        /// <summary>
        /// query user wow counts by user as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;UserWowCountDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult<UserWowCountDto>> QueryUserWowCountsByUserAsync(Guid id)
        {
            var result = new ServiceResult<UserWowCountDto>();
            var data = (from u in await _userRepository.GetListAsync()
                        join s in await _teamwowRepository.GetListAsync()

                        on u.Id equals s.UserId into lj
                        from ls in lj.DefaultIfEmpty()
                        where u.Id == id
                        group (ls, u) by u.Account into g
                        select new UserWowCountDto
                        {
                            Count = g.Where(p => p.ls != null).Count(),
                            Account = g.Key
                        }).FirstOrDefault();

            var wows = (from tw in await _teamwowRepository.GetListAsync()
                        where tw.UserId == id
                        select new TeamWowDto
                        {
                            Id = tw.Id,
                            TeamId = tw.TeamId,
                            UserId = tw.UserId,
                            IsWow = tw.IsWow,
                            WowTime = tw.WowTime
                        }
                        ).ToList();
            data.Wows = wows;
            result.IsSuccess(data);
            return result;
        }
    }
}