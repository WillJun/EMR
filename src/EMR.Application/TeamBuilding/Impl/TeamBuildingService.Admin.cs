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
using EMR.ToolKits.Helper;

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

            var countReult = await QueryUserWowCountsByUserAsync(input.UserId);
            if (countReult.Result.Count >= 3)
            {
                result.IsFailed(ResponseText.WOW_TIMES_LIMIT);
                return result;
            }

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
            result.IsSuccess(ResponseText.UPDATE_SUCCESS);
            return result;
        }

        /// <summary>
        /// 更新折扣状态
        /// </summary>
        /// <param name="id"> </param>
        /// <returns> </returns>
        public async Task<ServiceResult> UpdateTeamDiscountAsync(EditTeamDiscountInput input)
        {
            var result = new ServiceResult();

            var tw = await _teamdiscountRepository.FindAsync(input.Id);
            if (null == tw)
            {
                result.IsFailed(ResponseText.WHAT_NOT_EXIST.FormatWith("Id", input.Id));
                return result;
            }

            tw.IsDisable = input.IsDisable;
            tw.Discount = input.Discount;
            tw.FullAmount = input.FullAmount;
            tw.Discription = input.Discription;

            await _teamdiscountRepository.UpdateAsync(tw, true);
            result.IsSuccess(ResponseText.UPDATE_SUCCESS);
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

            //if (userResult.Result.IsOverspend)
            //{
            //    result.IsFailed(ResponseText.BALANCE_IS_NONE);
            //    return result;
            //}

            double cost = 0;
            var result1 = userResult.Result.PersonalExpenditures;
            var result2 = userResult.Result.PersonalRecharges;
            double Balance = result2.Sum(p => p.Amount);
            if (result1 != null)
            {
                cost = result1.Sum(p => p.Expend);
                if (Balance - cost < input.Amount)
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
            if (count == 6 && !ui.IsOverspend)
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
                ui.IsOverspend = true;
            }

            await UpdateUserAsync(ui);

            result.IsSuccess(ResponseText.INSERT_SUCCESS);
            return result;
        }

        public async Task<ServiceResult> TeamExpendToUserAsync(EditTeamExpendInput input)
        {
            var result = new ServiceResult();

            var obj = await QueryTeamSalesQuotasByTeamAsync(input.TeamId);
            double totalincome = obj.Result.TotalIncome;
            if (totalincome < input.Expend)
            {
                result.IsFailed(ResponseText.BALANCE_IS_NONE);
                return result;
            }

            var userresult = await QueryUsersByTeamAsync(input.TeamId);

            var users = userresult.Result;

            var opuser = users.Where(p => p.Id == input.UserId).FirstOrDefault();
            if (opuser == null)
            {
                result.IsFailed(ResponseText.USER_ERROR);
                return result;
            }
            if (!opuser.IsLeader)
            {
                result.IsFailed(ResponseText.RIGHT_LIMIT);
                return result;
            }
            Random rd = new Random();
            DateTime time = DateTime.Now;
            var SerialNumber = time.ToString("yyyyMMddHHmmss") + rd.Next(0, 9999).ToString("0000");

            input.SerialNumber = SerialNumber;
            input.Comment = "团队分钱";
            input.CreateTime = DateTime.Now;
            double amount = input.Expend / users.Count();
            foreach (var item in users)
            {
                EditUserInput ui = new EditUserInput();
                ui.Id = item.Id;
                ui.Balance = item.Balance;

                EditPersonalRechargeInput editPersonalRechargeInput = new EditPersonalRechargeInput();
                editPersonalRechargeInput.Amount = amount;
                editPersonalRechargeInput.SerialNumber = SerialNumber;
                editPersonalRechargeInput.Comment = "团队分钱";
                editPersonalRechargeInput.CreateTime = time;
                editPersonalRechargeInput.UserId = item.Id;

                editPersonalRechargeInput.SourceId = input.TeamId;
                var pr = ObjectMapper.Map<EditPersonalRechargeInput, PersonalRecharge>(editPersonalRechargeInput);
                await _personalrechargeRepository.InsertAsync(pr);
                ui.Balance += amount;
                await UpdateUserAsync(ui);
            }

            var te = ObjectMapper.Map<EditTeamExpendInput, TeamExpend>(input);
            await _teamexpendRepository.InsertAsync(te);

            result.IsSuccess(ResponseText.INSERT_SUCCESS);
            return result;
        }

        /// <summary>
        /// 发改委给团队发钱
        /// </summary>
        /// <param name="input"> </param>
        /// <returns> </returns>
        public async Task<ServiceResult> InsertFGWMoneyAsync(EditFGWMoneyInput input)
        {
            var result = new ServiceResult();

            var allteams = await QueryTeamsAsync();

            var sourceteam = allteams.Result.Where(p => p.Id == input.SourceId).FirstOrDefault();

            if (sourceteam == null)
            {
                result.IsFailed(ResponseText.RIGHT_LIMIT);
                return result;
            }
            if (sourceteam.TeamName != "发改委")
            {
                result.IsFailed(ResponseText.RIGHT_LIMIT);
                return result;
            }

            Random rd = new Random();
            DateTime time = DateTime.Now;

            foreach (string str in input.TeamIds.Split(','))
            {
                Guid TeamId = Guid.Parse(str);

                var team = allteams.Result.Where(p => p.Id == TeamId).FirstOrDefault();
                if (team != null)
                {
                    var alluser = await QueryUsersByTeamAsync(team.Id);
                    var leader = alluser.Result.Where(p => p.IsLeader).FirstOrDefault();
                    if (leader != null)
                    {
                        var SerialNumber = time.ToString("yyyyMMddHHmmss") + rd.Next(0, 9999).ToString("0000");
                        EditSalesQuotaInput editSalesQuotaInput = new EditSalesQuotaInput()
                        {
                            Comment = "发改委奖励团队",
                            CreateTime = time,
                            Income = input.Amount,
                            Operator = leader.Id,
                            SerialNumber = SerialNumber,
                            TeamId = TeamId
                        };
                        var sq = ObjectMapper.Map<EditSalesQuotaInput, SalesQuota>(editSalesQuotaInput);

                        await _salesquotaRepository.InsertAsync(sq, true);
                    }
                }
            }

            result.IsSuccess(ResponseText.INSERT_SUCCESS);
            return result;
        }

        /// <summary>
        /// 客户线上支付
        /// </summary>
        /// <param name="input"> </param>
        /// <returns> </returns>
        public async Task<ServiceResult> InsertCustomPaymentAsync(EditCustomPaymentInput input)
        {
            var result = new ServiceResult();
            var userResult = await GetUserDetailAsync(input.Account);

            if (userResult.Result.TeamInfo.Id == input.TeamId)
            {
                result.IsFailed(ResponseText.DONOT_COST_IN_OWNER_SHOP);
                return result;
            }
            var alluser = await QueryUsersByTeamAsync(input.TeamId);
            var leader = alluser.Result.Where(p => p.IsLeader).FirstOrDefault();
            //if (userResult.Result.IsOverspend)
            //{
            //    result.IsFailed(ResponseText.BALANCE_IS_NONE);
            //    return result;
            //}

            double cost = 0;
            var result1 = userResult.Result.PersonalExpenditures;
            var result2 = userResult.Result.PersonalRecharges;
            double Balance = result2.Sum(p => p.Amount);
            if (result1 != null)
            {
                cost = result1.Sum(p => p.Expend);
                if (Balance - cost < input.Amount)
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
            editPersonalExpenditureInput.UserId = input.UserId;
            editPersonalExpenditureInput.SerialNumber = SerialNumber;
            editPersonalExpenditureInput.CreateTime = time;

            EditSalesQuotaInput editSalesQuotaInput = new EditSalesQuotaInput();
            editSalesQuotaInput.Income = input.Amount;
            editSalesQuotaInput.TeamId = input.TeamId;
            editSalesQuotaInput.Operator = leader.Id;
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
            if (count == 6 && !ui.IsOverspend)
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
                ui.IsOverspend = true;
            }

            await UpdateUserAsync(ui);

            result.IsSuccess(ResponseText.INSERT_SUCCESS);
            return result;
        }

        /// <summary>
        /// GenerateQRCode
        /// </summary>
        /// <param name="input"> </param>
        /// <returns> </returns>
        public async Task<ServiceResult> GenerateQRCodeAsync(Guid id)
        {
            var result = new ServiceResult();

            string url = "https://localhost:44303/Business/CustomQR?targetId=" + id;
            string qrcode = QRHelper.GetQRCode(url);

            result.IsSuccess(qrcode);
            return result;
        }
    }
}