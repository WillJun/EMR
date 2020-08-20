//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.TeamBuilding.Impl
// FileName : TeamBuildingService
//
// Created by : Will.Wu at 2020/8/19 15:19:11
//
//
//========================================================================
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
using EMR.Domain.TeamBuilding;
using EMR.ToolKits.Base;

namespace EMR.Application.TeamBuilding.Impl
{
    public partial class TeamBuildingService
    {
        public async Task<ServiceResult<IEnumerable<PersonalRechargeDto>>> QueryPersonalRechargesByUserAsync(string account)
        {
            var result = new ServiceResult<IEnumerable<PersonalRechargeDto>>();
            var list = (from pr in await _personalrechargeRepository.GetListAsync()
                        join t in await _teamRepository.GetListAsync()

                        on pr.SourceId equals t.Id
                        join u in await _userRepository.GetListAsync()
                        on pr.UserId equals u.Id

                        where u.Account == account
                        orderby pr.CreateTime ascending
                        select new PersonalRechargeDto
                        {
                            Amount = pr.Amount,
                            Comment = pr.Comment,
                            CreateTime = pr.CreateTime,
                            SerialNumber = pr.SerialNumber,
                            SourceName = t.TeamName
                        });
            result.IsSuccess(list);
            return result;
        }

        public async Task PersonalRechargeBulkInsertAsync(IEnumerable<PersonalRecharge> personalRecharges)
        {
            await _personalrechargeRepository.BulkInsertAsync(personalRecharges);
        }
    }
}