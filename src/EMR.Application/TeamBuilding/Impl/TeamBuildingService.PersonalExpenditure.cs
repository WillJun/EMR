//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.TeamBuilding.Impl
// FileName : TeamBuildingService
//
// Created by : Will.Wu at 2020/8/19 15:24:42
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
        public async Task<ServiceResult<IEnumerable<PersonalExpenditureDto>>> QueryPersonalExpendituresByUserAsync(string account)
        {
            var result = new ServiceResult<IEnumerable<PersonalExpenditureDto>>();
            var list = (from pe in await _personalexpenditureRepository.GetListAsync()
                        join t in await _teamRepository.GetListAsync()

                        on pe.ExpenditureTeamId equals t.Id
                        join u in await _userRepository.GetListAsync()
                        on pe.UserId equals u.Id

                        where u.Account == account
                        orderby pe.CreateTime ascending
                        select new PersonalExpenditureDto
                        {
                            Expend = pe.Expend,
                            Comment = pe.Comment,
                            CreateTime = pe.CreateTime,
                            SerialNumber = pe.SerialNumber,
                            ExpenditureName = t.TeamName
                        });
            result.IsSuccess(list);
            return result;
        }
    }
}