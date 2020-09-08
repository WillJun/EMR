// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="TeamBuildingService.Admin.cs" company="EMR.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding.Input;
using EMR.Domain.Configurations;
using EMR.Domain.TeamBuilding;
using EMR.ToolKits.Base;
using EMR.ToolKits.Extensions;
using EMR.ToolKits.Helper;

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
        /// 点赞
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult> InsertWowAsync(EditTeamWowInput input)
        {
            var r = await CheckActivityState();
            if (!r.Success)
            {
                return r;
            }
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
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult> DeleteWowAsync(Guid id)
        {

            var r = await CheckActivityState();
            if (!r.Success)
            {
                return r;
            }
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
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
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
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
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
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
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
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
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
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult> InsertSalesQuotaAsync(EditSalesQuotaInput input)
        {
            var r = await CheckActivityState();
            if (!r.Success)
            {
                return r;
            }

            var result = new ServiceResult();

            var sq = ObjectMapper.Map<EditSalesQuotaInput, SalesQuota>(input);

            await _salesquotaRepository.InsertAsync(sq, true);

            result.IsSuccess(ResponseText.INSERT_SUCCESS);
            return result;
        }

        /// <summary>
        /// 新增消费记录
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult> InsertCostAsync(EditCostInput input)
        {
            var r = await CheckActivityState();
            if (!r.Success)
            {
                return r;
            }
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

            EditPersonalExpenditureInput editPersonalExpenditureInput = new EditPersonalExpenditureInput
            {
                ExpenditureTeamId = input.TeamId,
                Expend = input.Amount,
                UserId = userResult.Result.Id,
                SerialNumber = SerialNumber,
                CreateTime = time
            };

            EditSalesQuotaInput editSalesQuotaInput = new EditSalesQuotaInput
            {
                Income = input.Amount,
                TeamId = input.TeamId,
                Operator = input.OperatorId,
                SerialNumber = SerialNumber,
                CreateTime = time
            };
            editSalesQuotaInput.Income = input.Amount;

            var pe = ObjectMapper.Map<EditPersonalExpenditureInput, PersonalExpenditure>(editPersonalExpenditureInput);

            await _personalexpenditureRepository.InsertAsync(pe, true);

            var sq = ObjectMapper.Map<EditSalesQuotaInput, SalesQuota>(editSalesQuotaInput);

            await _salesquotaRepository.InsertAsync(sq, true);

            var peResult = await QueryPersonalExpendituresByUserAsync(userResult.Result.Id);

            int count = peResult.Result.Select(p => p.ExpenditureName).Distinct().Count();

            EditUserInput ui = new EditUserInput
            {
                Id = userResult.Result.Id,
                Balance = userResult.Result.Balance
            };
            if (count == 6 && !ui.IsOverspend)
            {
                EditPersonalRechargeInput editPersonalRechargeInput = new EditPersonalRechargeInput
                {
                    Amount = 50,
                    SerialNumber = time.ToString("yyyyMMddHHmmss") + rd.Next(0, 9999).ToString("0000"),
                    Comment = "满6家店消费，发改委额外充值50元",
                    CreateTime = time,
                    UserId = userResult.Result.Id
                };
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
        /// team expend to user as an asynchronous operation.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult> TeamExpendToUserAsync(EditTeamExpendInput input)
        {
            var r = await CheckActivityState();
            if (!r.Success)
            {
                return r;
            }
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

            input.Comment = "团队分钱";
            foreach (string str in input.ids.Split(','))
            {
                var SerialNumber = time.ToString("yyyyMMddHHmmss") + rd.Next(0, 9999).ToString("0000");

                Guid userId = Guid.Parse(str);
                var user = users.Where(p => p.Id == userId).FirstOrDefault();
                if (user != null)
                {
                    EditUserInput ui = new EditUserInput
                    {
                        Id = user.Id,
                        Balance = user.Balance
                    };
                    EditPersonalRechargeInput editPersonalRechargeInput = new EditPersonalRechargeInput
                    {
                        Amount = input.Expend,
                        SerialNumber = SerialNumber,
                        Comment = "团队分钱",
                        CreateTime = time,
                        UserId = user.Id,
                        SourceId = input.TeamId
                    };
                    var pr = ObjectMapper.Map<EditPersonalRechargeInput, PersonalRecharge>(editPersonalRechargeInput);
                    await _personalrechargeRepository.InsertAsync(pr);
                    ui.Balance += input.Expend;
                    await UpdateUserAsync(ui);

                    TeamExpend teamExpend = new TeamExpend(_guidGenerator.Create())
                    {
                        Comment = input.Comment,
                        SerialNumber = SerialNumber,
                        Expend = input.Expend,
                        CreateTime = time,
                        TeamId = input.TeamId,
                        UserId = input.UserId
                    };
                    await _teamexpendRepository.InsertAsync(teamExpend);

                }

            }
            //double amount = input.Expend / users.Count();
            //foreach (var item in users)
            //{
            //    EditUserInput ui = new EditUserInput
            //    {
            //        Id = item.Id,
            //        Balance = item.Balance
            //    };

            //    EditPersonalRechargeInput editPersonalRechargeInput = new EditPersonalRechargeInput
            //    {
            //        Amount = amount,
            //        SerialNumber = SerialNumber,
            //        Comment = "团队分钱",
            //        CreateTime = time,
            //        UserId = item.Id,

            //        SourceId = input.TeamId
            //    };
            //    var pr = ObjectMapper.Map<EditPersonalRechargeInput, PersonalRecharge>(editPersonalRechargeInput);
            //    await _personalrechargeRepository.InsertAsync(pr);
            //    ui.Balance += amount;
            //    await UpdateUserAsync(ui);
            //}

            //var te = ObjectMapper.Map<EditTeamExpendInput, TeamExpend>(input);
            //await _teamexpendRepository.InsertAsync(te);

            result.IsSuccess(ResponseText.INSERT_SUCCESS);
            return result;
        }

        /// <summary>
        /// 发改委给团队发钱
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult> InsertFGWMoneyAsync(EditFGWMoneyInput input)
        {
            var r = await CheckActivityState();
            if (!r.Success)
            {
                return r;
            }
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
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult> InsertCustomPaymentAsync(EditCustomPaymentInput input)
        {
            var r = await CheckActivityState();
            if (!r.Success)
            {
                return r;
            }
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

            EditPersonalExpenditureInput editPersonalExpenditureInput = new EditPersonalExpenditureInput
            {
                ExpenditureTeamId = input.TeamId,
                Expend = input.Amount,
                UserId = input.UserId,
                SerialNumber = SerialNumber,
                CreateTime = time
            };

            EditSalesQuotaInput editSalesQuotaInput = new EditSalesQuotaInput
            {
                Income = input.Amount,
                TeamId = input.TeamId,
                Operator = leader.Id,
                SerialNumber = SerialNumber,
                CreateTime = time
            };
            editSalesQuotaInput.Income = input.Amount;

            var pe = ObjectMapper.Map<EditPersonalExpenditureInput, PersonalExpenditure>(editPersonalExpenditureInput);

            await _personalexpenditureRepository.InsertAsync(pe, true);

            var sq = ObjectMapper.Map<EditSalesQuotaInput, SalesQuota>(editSalesQuotaInput);

            await _salesquotaRepository.InsertAsync(sq, true);

            var peResult = await QueryPersonalExpendituresByUserAsync(userResult.Result.Id);

            int count = peResult.Result.Select(p => p.ExpenditureName).Distinct().Count();

            EditUserInput ui = new EditUserInput
            {
                Id = userResult.Result.Id,
                Balance = userResult.Result.Balance
            };
            if (count == 6 && !ui.IsOverspend)
            {
                EditPersonalRechargeInput editPersonalRechargeInput = new EditPersonalRechargeInput
                {
                    Amount = 50,
                    SerialNumber = time.ToString("yyyyMMddHHmmss") + rd.Next(0, 9999).ToString("0000"),
                    Comment = "满6家店消费，发改委额外充值50元",
                    CreateTime = time,
                    UserId = userResult.Result.Id
                };
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
        /// <param name="id">The identifier.</param>
        /// <param name="logourl">The logourl.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult> GenerateQRCodeAsync(Guid id, string logourl = "")
        {
            var result = new ServiceResult();

            string url = AppSettings.WebHost + "/Business/CustomQR?targetId=" + id;
            string qrcode = QRHelper.GetQRCode(url, logourl);
            result.IsSuccess(qrcode);
            return result;
        }





        /// <summary>
        /// GenerateQRCode
        /// </summary>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult> InitActivityAsync()
        {
            var result = new ServiceResult();

            var list = await _activityRepository.GetListAsync();
            foreach (var item in list)
                await _activityRepository.DeleteAsync(item.Id);

            Activity activity = new Activity(_guidGenerator.Create()) { ActivityName = "Team Building", IsStart = false };
            await _activityRepository.InsertAsync(activity);
            return result;

        }
        /// <summary>
        /// Starts the activity asynchronous.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult> StartActivityAsync()
        {
            var result = new ServiceResult();
            var obj = await _activityRepository.FirstOrDefaultAsync(p => p.IsStart == false);

            if (obj == null)
            {
                result.IsFailed("当前无待开始活动");
                return result;
            }
            obj.Start_Time = DateTime.Now;
            obj.Finish_Time = DateTime.Now.AddHours(3);
            obj.IsStart = true;
            await _activityRepository.UpdateAsync(obj);
            result.IsSuccess("活动开始");
            return result;
        }
        /// <summary>
        /// Stops the activity asynchronous.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task<ServiceResult> StopActivityAsync()
        {
            var result = new ServiceResult();
            var obj = await _activityRepository.FirstOrDefaultAsync(p => p.IsStart == true);

            if (obj == null)
            {
                result.IsFailed("当前无待结束活动");
                return result;
            }
            obj.Finish_Time = DateTime.Now;
            obj.IsStart = false;
            await _activityRepository.UpdateAsync(obj);
            result.IsSuccess("活动结束");


            return result;
        }
    }
}