//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.TeamBuilding.Impl
// FileName : TeamBuildingService
//
// Created by : Will.Wu at 2020/8/19 15:45:35
//
//
//========================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
using EMR.ToolKits.Base;

namespace EMR.Application.TeamBuilding.Impl
{
    public partial class TeamBuildingService
    {
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