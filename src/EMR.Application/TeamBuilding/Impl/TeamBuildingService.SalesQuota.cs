// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="TeamBuildingService.SalesQuota.cs" company="EMR.Application">
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
        /// query sales quotas by team as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;SalesQuotaWithUserDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult<IEnumerable<SalesQuotaWithUserDto>>> QuerySalesQuotasByTeamAsync(Guid id)
        {
            var result = new ServiceResult<IEnumerable<SalesQuotaWithUserDto>>();
            var list = (from s in await _salesquotaRepository.GetListAsync()
                        join t in await _teamRepository.GetListAsync()

                        on s.TeamId equals t.Id
                        join u in await _userRepository.GetListAsync()
                        on s.Operator equals u.Id

                        join pr in await _personalexpenditureRepository.GetListAsync()
                      on new { s.SerialNumber, s.TeamId } equals new { pr.SerialNumber, TeamId = pr.ExpenditureTeamId }
                        join u2 in await _userRepository.GetListAsync()
                        on pr.UserId equals u2.Id

                        where t.Id == id
                        orderby s.CreateTime ascending
                        select new SalesQuotaWithUserDto
                        {
                            Comment = s.Comment,
                            Operator = u.UserEnName,
                            CreateTime = s.CreateTime,
                            Income = s.Income,
                            SerialNumber = s.SerialNumber,
                            TeamName = t.TeamName,
                            UserName = u2.UserName,
                            UserAccount = u2.Account
                        }).OrderByDescending(p => p.CreateTime).ToList();
            result.IsSuccess(list);
            return result;
        }

        /// <summary>
        /// query sales quotas by user as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;SalesQuotaWithUserDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult<IEnumerable<SalesQuotaWithUserDto>>> QuerySalesQuotasByUserAsync(Guid id)
        {
            var result = new ServiceResult<IEnumerable<SalesQuotaWithUserDto>>();
            var list = (from s in await _salesquotaRepository.GetListAsync()
                        join t in await _teamRepository.GetListAsync()

                        on s.TeamId equals t.Id
                        join u in await _userRepository.GetListAsync()
                        on s.Operator equals u.Id

                        join pr in await _personalexpenditureRepository.GetListAsync()
                     on new { s.SerialNumber, s.TeamId } equals new { pr.SerialNumber, TeamId = pr.ExpenditureTeamId }
                        join u2 in await _userRepository.GetListAsync()
                        on pr.UserId equals u2.Id

                        where u.Id == id
                        orderby s.CreateTime ascending
                        select new SalesQuotaWithUserDto
                        {
                            Comment = s.Comment,
                            Operator = u.UserEnName,
                            CreateTime = s.CreateTime,
                            Income = s.Income,
                            SerialNumber = s.SerialNumber,
                            TeamName = t.TeamName,
                            UserName = u2.UserName,
                            UserAccount = u2.Account
                        });
            result.IsSuccess(list);
            return result;
        }

        /// <summary>
        /// query team sales quotas as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;TeamSalesQuotaTotalDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
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
                        }).ToList();

            var list2 = (from t in await _teamRepository.GetListAsync()
                         join s in await _teamexpendRepository.GetListAsync()

                         on t.Id equals s.TeamId

                         group (s, t) by t.TeamName into g
                         select new TeamExpendTotalDto
                         {
                             TotalExpend = g.Sum(p => p.s.Expend),
                             TeamName = g.Key
                         }).ToList();

            foreach (var item in list2)
            {
                var obj = list.Where(p => p.TeamName == item.TeamName).FirstOrDefault();
                if (obj != null)
                {
                    obj.TotalIncome -= item.TotalExpend;
                }
            }
            list = list.OrderByDescending(p => p.TotalIncome).ToList();
            result.IsSuccess(list);
            return result;
        }

        /// <summary>
        /// query team sales quotas by team as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;TeamSalesQuotaTotalDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
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

            var obj = (from t in await _teamRepository.GetListAsync()
                       join s in await _teamexpendRepository.GetListAsync()

                       on t.Id equals s.TeamId

                       where t.Id == id
                       group (s, t) by t.TeamName into g
                       select new TeamExpendTotalDto
                       {
                           TotalExpend = g.Sum(p => p.s.Expend),
                           TeamName = g.Key
                       }).FirstOrDefault();
            if (obj != null)
            {
                data.TotalIncome -= obj.TotalExpend;
            }

            result.IsSuccess(data);
            return result;
        }

        /// <summary>
        /// query user sales quotas by user as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;UserSalesQuotaTotalDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
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