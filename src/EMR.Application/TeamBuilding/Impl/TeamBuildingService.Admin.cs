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
using System.Linq;
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
        /// 更新个人状态
        /// </summary>
        /// <param name="id"> </param>
        /// <returns> </returns>
        public async Task<ServiceResult> UpdateUserAsync(EditUserInput input)
        {
            var result = new ServiceResult();

            var tw = await _userRepository.FindAsync(input.Id);
            if (null == tw)
            {
                result.IsFailed(ResponseText.WHAT_NOT_EXIST.FormatWith("Id", input.Id));
                return result;
            }

            tw.Balance = input.Balance;
            tw.IsOverspend = input.IsOverspend;
            await _userRepository.UpdateAsync(tw, true);
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

        /// <summary>
        /// 新增消费记录
        /// </summary>
        /// <param name="input"> </param>
        /// <returns> </returns>
        public async Task<ServiceResult> InsertCostAsync(EditCostInput input)
        {
            var result = new ServiceResult();

            var userResult = await GetUserDetailAsync(input.Account);

            if (userResult.Result.TeamInfo.Id == input.TeamId)
            {
                result.IsFailed(ResponseText.DONOT_COST_IN_OWNER_SHOP);
                return result;
            }

            if (userResult.Result.IsOverspend)
            {
                result.IsFailed(ResponseText.BALANCE_IS_NONE);
                return result;
            }

            double cost = 0;
            var result1 = userResult.Result.PersonalExpenditures;
            if (result1 != null)
            {
                cost = result1.Sum(p => p.Expend);
                if (userResult.Result.Balance - cost < input.Amount)
                {
                    result.IsFailed(ResponseText.BALANCE_IS_NONE);
                    return result;
                }
            }

            Random rd = new Random();
            DateTime time = DateTime.Now;
            var SerialNumber = time.ToString("yyyyMMddHHmmss") + rd.Next(0, 9999).ToString("0000");

            EditPersonalExpenditureInput editPersonalExpenditureInput = new EditPersonalExpenditureInput();

            editPersonalExpenditureInput.ExpenditureTeamId = input.TeamId;
            editPersonalExpenditureInput.Expend = input.Amount;
            editPersonalExpenditureInput.UserId = userResult.Result.Id;
            editPersonalExpenditureInput.SerialNumber = SerialNumber;
            editPersonalExpenditureInput.CreateTime = time;

            EditSalesQuotaInput editSalesQuotaInput = new EditSalesQuotaInput();
            editSalesQuotaInput.Income = input.Amount;
            editSalesQuotaInput.TeamId = input.TeamId;
            editSalesQuotaInput.Operator = input.OperatorId;
            editSalesQuotaInput.SerialNumber = SerialNumber;
            editSalesQuotaInput.CreateTime = time;
            editSalesQuotaInput.Income = input.Amount;

            var pe = ObjectMapper.Map<EditPersonalExpenditureInput, PersonalExpenditure>(editPersonalExpenditureInput);

            await _personalexpenditureRepository.InsertAsync(pe, true);

            var sq = ObjectMapper.Map<EditSalesQuotaInput, SalesQuota>(editSalesQuotaInput);

            await _salesquotaRepository.InsertAsync(sq, true);

            var peResult = await QueryPersonalExpendituresByUserAsync(userResult.Result.Id);

            int count = peResult.Result.Select(p => p.ExpenditureName).Distinct().Count();

            EditUserInput ui = new EditUserInput();
            ui.Id = userResult.Result.Id;
            ui.Balance = userResult.Result.Balance;
            if (count == 6 && userResult.Result.Balance == 280)
            {
                EditPersonalRechargeInput editPersonalRechargeInput = new EditPersonalRechargeInput();
                editPersonalRechargeInput.Amount = 50;
                editPersonalRechargeInput.SerialNumber = time.ToString("yyyyMMddHHmmss") + rd.Next(0, 9999).ToString("0000");
                editPersonalRechargeInput.Comment = "满6家店消费，发改委额外充值50元";
                editPersonalRechargeInput.CreateTime = time;
                editPersonalRechargeInput.UserId = userResult.Result.Id;
                var fgw = await _teamRepository.GetAsync(p => p.TeamName == "发改委");
                editPersonalRechargeInput.SourceId = fgw.Id;
                var pr = ObjectMapper.Map<EditPersonalRechargeInput, PersonalRecharge>(editPersonalRechargeInput);
                await _personalrechargeRepository.InsertAsync(pr);
                ui.Balance += 50;
            }

            if (ui.Balance - cost - input.Amount <= 0)
            {
                ui.IsOverspend = true;
            }

            await UpdateUserAsync(ui);

            result.IsSuccess(ResponseText.INSERT_SUCCESS);
            return result;
        }
    }
}