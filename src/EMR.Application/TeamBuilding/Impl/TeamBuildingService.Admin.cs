//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.TeamBuilding.Impl
// FileName : TeamBuildingService
//
// Created by : Will.Wu at 2020/8/21 16:29:24
//
//
//========================================================================
using System;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding.Input;
using EMR.Domain.TeamBuilding;
using EMR.ToolKits.Base;
using EMR.ToolKits.Extensions;

using static EMR.Domain.Shared.EMRConsts;

namespace EMR.Application.TeamBuilding.Impl
{
    public partial class TeamBuildingService
    {
        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="input"> </param>
        /// <returns> </returns>
        public async Task<ServiceResult> InsertWowAsync(EditTeamWowInput input)
        {
            var result = new ServiceResult();

            var post = ObjectMapper.Map<EditTeamWowInput, TeamWow>(input);

            await _teamwowRepository.InsertAsync(post, true);

            result.IsSuccess(ResponseText.INSERT_SUCCESS);
            return result;
        }

        /// <summary>
        /// 取消赞
        /// </summary>
        /// <param name="id"> </param>
        /// <returns> </returns>
        public async Task<ServiceResult> DeleteWowAsync(Guid id)
        {
            var result = new ServiceResult();

            var post = await _teamwowRepository.FindAsync(id);
            if (null == post)
            {
                result.IsFailed(ResponseText.WHAT_NOT_EXIST.FormatWith("Id", id));
                return result;
            }

            await _teamwowRepository.DeleteAsync(id);

            result.IsSuccess(ResponseText.DELETE_SUCCESS);
            return result;
        }
    }
}