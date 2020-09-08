// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="TeamBuildingService.Activity.cs" company="EMR.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
using EMR.ToolKits.Base;
using EMR.ToolKits.Extensions;

using Microsoft.EntityFrameworkCore;

using static EMR.Domain.Shared.EMRConsts;

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
        /// Gets the user detail asynchronous.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&lt;UserDetailDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult<ActivityDto>> GetActivityAsync()
        {
            var result = new ServiceResult<ActivityDto>();
            var activity = await _activityRepository.FirstOrDefaultAsync();
            if (null == activity)
            {
                result.IsFailed(ResponseText.WHAT_NOT_EXIST.FormatWith("activity", "activity"));
                return result;
            }
            ActivityDto activityDto = new ActivityDto()
            {
                ActivityName = activity.ActivityName,
                Finish_Time = activity.Finish_Time,
                IsStart = activity.IsStart,
                Start_Time = activity.Start_Time
            };
            result.IsSuccess(activityDto);
            return result;
        }

    }
}