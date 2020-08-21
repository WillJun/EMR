//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.TeamBuilding.Impl
// FileName : TeamBuildingService
//
// Created by : Will.Wu at 2020/8/19 15:03:01
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
        public async Task<ServiceResult<IEnumerable<SalesQuotaDto>>> QuerySalesQuotasByTeamAsync(Guid id)
        {
            var result = new ServiceResult<IEnumerable<SalesQuotaDto>>();
            var list = (from s in await _salesquotaRepository.GetListAsync()
                        join t in await _teamRepository.GetListAsync()

                        on s.TeamId equals t.Id
                        join u in await _userRepository.GetListAsync()
                        on s.Operator equals u.Id

                        where t.Id == id
                        orderby s.CreateTime ascending
                        select new SalesQuotaDto
                        {
                            Comment = s.Comment,
                            Operator = u.UserEnName,
                            CreateTime = s.CreateTime,
                            Income = s.Income,
                            SerialNumber = s.SerialNumber,
                            TeamName = t.TeamName
                        });
            result.IsSuccess(list);
            return result;
        }

        public async Task<ServiceResult<IEnumerable<SalesQuotaDto>>> QuerySalesQuotasByUserAsync(Guid id)
        {
            var result = new ServiceResult<IEnumerable<SalesQuotaDto>>();
            var list = (from s in await _salesquotaRepository.GetListAsync()
                        join t in await _teamRepository.GetListAsync()

                        on s.TeamId equals t.Id
                        join u in await _userRepository.GetListAsync()
                        on s.Operator equals u.Id

                        where u.Id == id
                        orderby s.CreateTime ascending
                        select new SalesQuotaDto
                        {
                            Comment = s.Comment,
                            Operator = u.UserEnName,
                            CreateTime = s.CreateTime,
                            Income = s.Income,
                            SerialNumber = s.SerialNumber,
                            TeamName = t.TeamName
                        });
            result.IsSuccess(list);
            return result;
        }

        public async Task<ServiceResult<IEnumerable<TeamSalesQuotaTotalDto>>> QueryTeamSalesQuotasAsync()
        {
            var result = new ServiceResult<IEnumerable<TeamSalesQuotaTotalDto>>();
            var list = (from t in await _teamRepository.GetListAsync()
                        join s in await _salesquotaRepository.GetListAsync()

                        on t.Id equals s.TeamId into lj
                        from ls in lj.DefaultIfEmpty(new Domain.TeamBuilding.SalesQuota())
                        where t.IsOrganiser == false
                        group (ls, t) by t.TeamName into g
                        select new TeamSalesQuotaTotalDto
                        {
                            TotalIncome = g.Where(p => p.ls != null).Count() == 0 ? 0 : g.Sum(p => p.ls.Income),
                            TeamName = g.Key
                        });
            result.IsSuccess(list);
            return result;
        }

        public async Task<ServiceResult<TeamSalesQuotaTotalDto>> QueryTeamSalesQuotasByTeamAsync(Guid id)
        {
            var result = new ServiceResult<TeamSalesQuotaTotalDto>();
            var data = (from t in await _teamRepository.GetListAsync()
                        join s in await _salesquotaRepository.GetListAsync()

                        on t.Id equals s.TeamId into lj
                        from ls in lj.DefaultIfEmpty(new Domain.TeamBuilding.SalesQuota())
                        where t.Id == id
                        group (ls, t) by t.TeamName into g
                        select new TeamSalesQuotaTotalDto
                        {
                            TotalIncome = g.Where(p => p.ls != null).Count() == 0 ? 0 : g.Sum(p => p.ls.Income),
                            TeamName = g.Key
                        }).FirstOrDefault();
            result.IsSuccess(data);
            return result;
        }

        public async Task<ServiceResult<UserSalesQuotaTotalDto>> QueryUserSalesQuotasByUserAsync(Guid id)
        {
            var result = new ServiceResult<UserSalesQuotaTotalDto>();
            var data = (from u in await _userRepository.GetListAsync()
                        join s in await _salesquotaRepository.GetListAsync()
                        on u.Id equals s.Operator into lj
                        from ls in lj.DefaultIfEmpty(new Domain.TeamBuilding.SalesQuota())
                        where u.Id == id
                        group (ls, u) by u.Account into g
                        select new UserSalesQuotaTotalDto
                        {
                            TotalIncome = g.Where(p => p.ls != null).Count() == 0 ? 0 : g.Sum(p => p.ls.Income),
                            Account = g.Key
                        }).FirstOrDefault();
            result.IsSuccess(data);
            return result;
        }
    }
}