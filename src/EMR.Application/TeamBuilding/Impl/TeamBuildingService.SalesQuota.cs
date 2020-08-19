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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMR.Application.Contracts.TeamBuilding;
using EMR.ToolKits.Base;

namespace EMR.Application.TeamBuilding.Impl
{
    public partial class TeamBuildingService
    {
        public async Task<ServiceResult<IEnumerable<SalesQuotaDto>>> QuerySalesQuotasByTeamAsync(string teamname)
        {
            var result = new ServiceResult<IEnumerable<SalesQuotaDto>>();
            var list = (from s in await _salesquotaRepository.GetListAsync()
                        join t in await _teamRepository.GetListAsync()

                        on s.TeamId equals t.Id
                        join u in await _userRepository.GetListAsync()
                        on s.Operator equals u.Id

                        where t.TeamName == teamname
                        orderby s.CreateTime ascending
                        select new SalesQuotaDto
                        {
                            Comment = s.Comment,
                            Operator = u.UserName,
                            CreateTime = s.CreateTime,
                            Income = s.Income,
                            SerialNumber = s.SerialNumber,
                            TeamName = t.TeamName
                        });
            result.IsSuccess(list);
            return result;
        }

        public async Task<ServiceResult<IEnumerable<SalesQuotaDto>>> QuerySalesQuotasByUserAsync(string account)
        {
            var result = new ServiceResult<IEnumerable<SalesQuotaDto>>();
            var list = (from s in await _salesquotaRepository.GetListAsync()
                        join t in await _teamRepository.GetListAsync()

                        on s.TeamId equals t.Id
                        join u in await _userRepository.GetListAsync()
                        on s.Operator equals u.Id

                        where u.Account == account
                        orderby s.CreateTime ascending
                        select new SalesQuotaDto
                        {
                            Comment = s.Comment,
                            Operator = u.UserName,
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
            var list = (from s in await _salesquotaRepository.GetListAsync()
                        join t in await _teamRepository.GetListAsync()

                        on s.TeamId equals t.Id
                        where t.IsOrganiser == false
                        group (s, t) by t.TeamName into g
                        select new TeamSalesQuotaTotalDto
                        {
                            TotalIncome = g.Sum(p => p.s.Income),
                            TeamName = g.Key
                        });
            result.IsSuccess(list);
            return result;
        }

        public async Task<ServiceResult<TeamSalesQuotaTotalDto>> QueryTeamSalesQuotasByTeamAsync(string teamname)
        {
            var result = new ServiceResult<TeamSalesQuotaTotalDto>();
            var data = (from s in await _salesquotaRepository.GetListAsync()
                        join t in await _teamRepository.GetListAsync()

                        on s.TeamId equals t.Id

                        where t.TeamName == teamname
                        group (s, t) by t.TeamName into g
                        select new TeamSalesQuotaTotalDto
                        {
                            TotalIncome = g.Sum(p => p.s.Income),
                            TeamName = g.Key
                        }).FirstOrDefault();
            result.IsSuccess(data);
            return result;
        }

        public async Task<ServiceResult<UserSalesQuotaTotalDto>> QueryUserSalesQuotasByUserAsync(string account)
        {
            var result = new ServiceResult<UserSalesQuotaTotalDto>();
            var data = (from s in await _salesquotaRepository.GetListAsync()
                        join u in await _userRepository.GetListAsync()
                        on s.Operator equals u.Id
                        where u.Account == account
                        group (s, u) by u.UserName into g
                        select new UserSalesQuotaTotalDto
                        {
                            TotalIncome = g.Sum(p => p.s.Income),
                            UserName = g.Key
                        }).FirstOrDefault();
            result.IsSuccess(data);
            return result;
        }
    }
}