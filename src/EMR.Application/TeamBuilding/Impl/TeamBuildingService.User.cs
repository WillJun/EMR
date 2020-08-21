//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.TeamBuilding.Impl
// FileName : TeamBuildingService
//
// Created by : Will.Wu at 2020/8/19 13:57:28
//
//
//========================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
using EMR.Domain.TeamBuilding;
using EMR.ToolKits.Base;
using EMR.ToolKits.Extensions;

using static EMR.Domain.Shared.EMRConsts;

namespace EMR.Application.TeamBuilding.Impl
{
    public partial class TeamBuildingService
    {
        /// <summary>
        /// Gets the user detail asynchronous.
        /// </summary>
        /// <param name="account"> The account. </param>
        /// <returns> </returns>
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
                    TeamName = teaminfo.TeamName,
                    CreateTime = teaminfo.CreateTime,
                    IsOrganiser = teaminfo.IsOrganiser,
                    TeamLeader = teaminfo.TeamLeader
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
        /// <param name="teamname"> The teamname. </param>
        /// <returns> </returns>
        public async Task<ServiceResult<IEnumerable<QueryUserDto>>> QueryUsersByTeamAsync(Guid
            id)
        {
            var result = new ServiceResult<IEnumerable<QueryUserDto>>();
            var list = (from u in await _userRepository.GetListAsync()
                        join t in await _teamRepository.GetListAsync()
                        on u.TeamId equals t.Id
                        where t.Id == id
                        orderby u.IsLeader ascending
                        select new QueryUserDto
                        {
                            Account = u.Account,
                            IsLeader = u.IsLeader,
                            Balance = u.Balance,
                            Dept = u.Dept,
                            Email = u.Email,
                            IsOverspend = u.IsOverspend,
                            UserEnName = u.UserEnName,
                            UserName = u.UserName
                        });
            result.IsSuccess(list);
            return result;
        }

        public async Task UserBulkInsertAsync(IEnumerable<User> users)
        {
            await _userRepository.BulkInsertAsync(users);
        }
    }
}