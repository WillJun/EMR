// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="TeamBuildingService.PersonalExpenditure.cs" company="EMR.Application">
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
        /// query personal expenditures by user as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;PersonalExpenditureDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult<IEnumerable<PersonalExpenditureDto>>> QueryPersonalExpendituresByUserAsync(Guid id)
        {
            var result = new ServiceResult<IEnumerable<PersonalExpenditureDto>>();
            var list = (from pe in await _personalexpenditureRepository.GetListAsync()
                        join t in await _teamRepository.GetListAsync()

                        on pe.ExpenditureTeamId equals t.Id
                        join u in await _userRepository.GetListAsync()
                        on pe.UserId equals u.Id

                        where u.Id == id
                        orderby pe.CreateTime ascending
                        select new PersonalExpenditureDto
                        {
                            Expend = pe.Expend,
                            Comment = pe.Comment,
                            CreateTime = pe.CreateTime,
                            SerialNumber = pe.SerialNumber,
                            ExpenditureName = t.TeamName
                        }).OrderByDescending(p => p.CreateTime).ToList();
            result.IsSuccess(list);
            return result;
        }

        /// <summary>
        /// query team expenditures as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;TeamExpenditureTotalDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult<IEnumerable<TeamExpenditureTotalDto>>> QueryTeamExpendituresAsync()
        {
            var result = new ServiceResult<IEnumerable<TeamExpenditureTotalDto>>();

            var list = (from team in await _teamRepository.GetListAsync()
                        join user in await _userRepository.GetListAsync()
                        on team.Id equals user.TeamId

                        join pe in await _personalexpenditureRepository.GetListAsync()

                        on user.Id equals pe.UserId
                        into lj
                        from ls in lj.DefaultIfEmpty(new Domain.TeamBuilding.PersonalExpenditure())
                        where team.IsOrganiser == false
                        group (ls, team) by new { team.TeamName } into g

                        select new TeamExpenditureTotalDto
                        {
                            TeamName = g.Key.TeamName,
                            TotalExpend = g.Where(p => p.ls != null).Count() == 0 ? 0 : g.Sum(p => p.ls.Expend)
                        }).OrderByDescending(p => p.TotalExpend).ToList();

            result.IsSuccess(list);

            return result;
        }
    }
}