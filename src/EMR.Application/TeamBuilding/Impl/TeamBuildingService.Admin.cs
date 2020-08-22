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

            var tw = ObjectMapper.Map<EditTeamWowInput, TeamWow>(input);

            await _teamwowRepository.InsertAsync(tw, true);

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

            var tw = await _teamwowRepository.FindAsync(id);
            if (null == tw)
            {
                result.IsFailed(ResponseText.WHAT_NOT_EXIST.FormatWith("Id", id));
                return result;
            }

            await _teamwowRepository.DeleteAsync(id);

            result.IsSuccess(ResponseText.DELETE_SUCCESS);
            return result;
        }

        /// <summary>
        /// 新增个人充值
        /// </summary>
        /// <param name="input"> </param>
        /// <returns> </returns>
        public async Task<ServiceResult> InsertPersonalRechargeAsync(EditPersonalRechargeInput input)
        {
            var result = new ServiceResult();

            var pr = ObjectMapper.Map<EditPersonalRechargeInput, PersonalRecharge>(input);

            await _personalrechargeRepository.InsertAsync(pr, true);

            result.IsSuccess(ResponseText.INSERT_SUCCESS);
            return result;
        }

        /// <summary>
        /// 新增个人账单
        /// </summary>
        /// <param name="input"> </param>
        /// <returns> </returns>
        public async Task<ServiceResult> InsertPersonalExpenditureAsync(EditPersonalExpenditureInput input)
        {
            var result = new ServiceResult();

            var pe = ObjectMapper.Map<EditPersonalExpenditureInput, PersonalExpenditure>(input);

            await _personalexpenditureRepository.InsertAsync(pe, true);

            result.IsSuccess(ResponseText.INSERT_SUCCESS);
            return result;
        }

        /// <summary>
        /// 新增流水
        /// </summary>
        /// <param name="input"> </param>
        /// <returns> </returns>
        public async Task<ServiceResult> InsertSalesQuotaAsync(EditSalesQuotaInput input)
        {
            var result = new ServiceResult();

            var sq = ObjectMapper.Map<EditSalesQuotaInput, SalesQuota>(input);

            await _salesquotaRepository.InsertAsync(sq, true);

            result.IsSuccess(ResponseText.INSERT_SUCCESS);
            return result;
        }
    }
}