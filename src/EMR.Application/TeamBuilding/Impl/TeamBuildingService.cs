// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="TeamBuildingService.cs" company="EMR.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading.Tasks;

using EMR.Domain.TeamBuilding.Repositories;
using EMR.ToolKits.Base;

using Microsoft.EntityFrameworkCore;

using Volo.Abp.Guids;

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
    public partial class TeamBuildingService : ServiceBase, ITeamBuildingService
    {
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// The team repository
        /// </summary>
        private readonly ITeamRepository _teamRepository;
        /// <summary>
        /// The salesquota repository
        /// </summary>
        private readonly ISalesQuotaRepository _salesquotaRepository;
        /// <summary>
        /// The personalrecharge repository
        /// </summary>
        private readonly IPersonalRechargeRepository _personalrechargeRepository;
        /// <summary>
        /// The personalexpenditure repository
        /// </summary>
        private readonly IPersonalExpenditureRepository _personalexpenditureRepository;

        /// <summary>
        /// The teamwow repository
        /// </summary>
        private readonly ITeamWowRepository _teamwowRepository;

        /// <summary>
        /// The teamexpend repository
        /// </summary>
        private readonly ITeamExpendRepository _teamexpendRepository;

        /// <summary>
        /// The teamdiscount repository
        /// </summary>
        private readonly ITeamDiscountRepository _teamdiscountRepository;


        /// <summary>
        /// The teamdiscount repository
        /// </summary>
        private readonly IActivityRepository _activityRepository;
        /// <summary>
        /// The unique identifier generator
        /// </summary>
        private readonly IGuidGenerator _guidGenerator;
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamBuildingService" /> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="teamRepository">The team repository.</param>
        /// <param name="salesquotaRepository">The salesquota repository.</param>
        /// <param name="personalrechargeRepository">The personalrecharge repository.</param>
        /// <param name="personalexpenditureRepository">The personalexpenditure repository.</param>
        /// <param name="teamwowRepository">The teamwow repository.</param>
        /// <param name="teamexpendRepository">The teamexpend repository.</param>
        /// <param name="teamdiscountRepository">The teamdiscount repository.</param>
        /// <param name="activityRepository">The activity repository.</param>
        /// <param name="guidGenerator">The unique identifier generator.</param>
        /// <remarks>Will Wu</remarks>
        public TeamBuildingService(IUserRepository userRepository, ITeamRepository teamRepository, ISalesQuotaRepository salesquotaRepository, IPersonalRechargeRepository personalrechargeRepository, IPersonalExpenditureRepository personalexpenditureRepository, ITeamWowRepository teamwowRepository, ITeamExpendRepository teamexpendRepository, ITeamDiscountRepository teamdiscountRepository, IActivityRepository activityRepository, IGuidGenerator guidGenerator)
        {
            _guidGenerator = guidGenerator;
            _userRepository = userRepository;
            _teamRepository = teamRepository;
            _salesquotaRepository = salesquotaRepository;
            _personalrechargeRepository = personalrechargeRepository;
            _personalexpenditureRepository = personalexpenditureRepository;
            _teamwowRepository = teamwowRepository;
            _teamexpendRepository = teamexpendRepository;
            _teamdiscountRepository = teamdiscountRepository;
            _activityRepository = activityRepository;
        }

        /// <summary>
        /// Checks the state of the activity.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        private async Task<ServiceResult> CheckActivityState()
        {
            var result = new ServiceResult();

            var current = await _activityRepository.FirstOrDefaultAsync(p => p.IsStart == true);
            if (current == null)
            {
                result.IsFailed("活动未开始");
                return result;
            }
            else
            {
                if (current.Start_Time <= DateTime.Now && DateTime.Now <= current.Finish_Time)
                {
                    result.IsSuccess();
                    return result;
                }
                else
                {
                    result.IsFailed("当前时间为非有效活动时间");
                    return result;
                }
            }



        }
    }
}