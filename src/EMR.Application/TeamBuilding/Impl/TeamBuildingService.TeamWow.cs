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

                        on u.Id equals s.UserId into lj
                        from ls in lj.DefaultIfEmpty()
                        group (ls, u) by u.TeamName into g
                        select new TeamWowCountDto
                        {
                            Count = g.Count(),
                            TeamName = g.Key,
                            LastDateTime = g?.Max(p => p.ls.WowTime)
                        });
            result.IsSuccess(list);
            return result;
        }

        public async Task<ServiceResult<TeamWowCountDto>> QueryTeamWowCountsByTeamAsync(string teamname)
        {
            var result = new ServiceResult<TeamWowCountDto>();
            var data = (from u in await _teamRepository.GetListAsync()
                        join s in await _teamwowRepository.GetListAsync()

                        on u.Id equals s.UserId into lj
                        from ls in lj.DefaultIfEmpty()
                        where u.TeamName == teamname
                        group (ls, u) by u.TeamName into g
                        select new TeamWowCountDto
                        {
                            Count = g.Count(),
                            TeamName = g.Key,
                            LastDateTime = g?.Max(p => p.ls.WowTime)
                        }).FirstOrDefault();
            result.IsSuccess(data);
            return result;
        }

        public async Task<ServiceResult<UserWowCountDto>> QueryUserWowCountsByUserAsync(string account)
        {
            var result = new ServiceResult<UserWowCountDto>();
            var data = (from u in await _userRepository.GetListAsync()
                        join s in await _teamwowRepository.GetListAsync()

                        on u.Id equals s.UserId into lj
                        from ls in lj.DefaultIfEmpty()
                        where u.Account == account
                        group (ls, u) by u.Account into g
                        select new UserWowCountDto
                        {
                            Count = g.Count(),
                            Account = g.Key
                        }).FirstOrDefault();
            result.IsSuccess(data);
            return result;
        }
    }
}