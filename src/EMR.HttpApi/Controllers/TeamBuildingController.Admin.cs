// ***********************************************************************
// Assembly         : EMR.HttpApi
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="TeamBuildingController.Admin.cs" company="EMR.HttpApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding.Input;
using EMR.ToolKits.Base;

using Microsoft.AspNetCore.Mvc;

using Volo.Abp.AspNetCore.Mvc;

using static EMR.Domain.Shared.EMRConsts;

/// <summary>
/// The Controllers namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.HttpApi.Controllers
{
    /// <summary>
    /// Class TeamBuildingController.
    /// Implements the <see cref="Volo.Abp.AspNetCore.Mvc.AbpController" />
    /// </summary>
    /// <seealso cref="Volo.Abp.AspNetCore.Mvc.AbpController" />
    /// <remarks>Will Wu</remarks>
    public partial class TeamBuildingController : AbpController
    {
        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpPost]
        [Route("teamwow/add")]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
        public async Task<ServiceResult> InsertWowAsync([FromBody] EditTeamWowInput input)
        {
            return await _tbService.InsertWowAsync(input);
        }

        /// <summary>
        /// 取消点赞
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpPost]
        [Route("teamwow/remove")]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
        public async Task<ServiceResult> DeleteWowAsync([Required] Guid id)
        {
            return await _tbService.DeleteWowAsync(id);
        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpPost]
        [Route("personalrecharge/add")]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
        public async Task<ServiceResult> InsertPersonalRechargeAsync([FromBody] EditPersonalRechargeInput input)
        {
            return await _tbService.InsertPersonalRechargeAsync(input);
        }

        /// <summary>
        /// 新增消费
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpPost]
        [Route("personalexpend/add")]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
        public async Task<ServiceResult> InsertPersonalExpenditureAsync([FromBody] EditPersonalExpenditureInput input)
        {
            return await _tbService.InsertPersonalExpenditureAsync(input);
        }

        /// <summary>
        /// 新增店铺流水
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpPost]
        [Route("salesquota/add")]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
        public async Task<ServiceResult> InsertSalesQuotaAsync([FromBody] EditSalesQuotaInput input)
        {
            return await _tbService.InsertSalesQuotaAsync(input);
        }

        /// <summary>
        /// 新增交易
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpPost]
        [Route("cost")]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
        public async Task<ServiceResult> InsertCostAsync([FromBody] EditCostInput input)
        {
            return await _tbService.InsertCostAsync(input);
        }

        /// <summary>
        /// 分钱
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpPost]
        [Route("team/expend")]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
        public async Task<ServiceResult> TeamExpendToUserAsync([FromBody] EditTeamExpendInput input)
        {
            return await _tbService.TeamExpendToUserAsync(input);
        }

        /// <summary>
        /// 发改委发钱
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpPost]
        [Route("fgw/bill")]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
        public async Task<ServiceResult> InsertFGWMoneyAsync([FromBody] EditFGWMoneyInput input)
        {
            return await _tbService.InsertFGWMoneyAsync(input);
        }

        /// <summary>
        /// 客户自助在线支付
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpPost]
        [Route("custom/pay")]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
        public async Task<ServiceResult> InsertCustomPaymentAsync([FromBody] EditCustomPaymentInput input)
        {
            return await _tbService.InsertCustomPaymentAsync(input);
        }

        /// <summary>
        /// 折扣
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpPost]
        [Route("team/discount")]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
        public async Task<ServiceResult> UpdateTeamDiscountAsync([FromBody] EditTeamDiscountInput input)
        {
            return await _tbService.UpdateTeamDiscountAsync(input);
        }


        /// <summary>
        /// Init Activity
        /// </summary>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpPost]
        [Route("activity/init")]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
        public async Task<ServiceResult> InitActivityAsync()
        {
            return await _tbService.InitActivityAsync();
        }

        /// <summary>
        /// Start Activity
        /// </summary>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpPost]
        [Route("activity/start")]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
        public async Task<ServiceResult> StartActivityAsync()
        {
            return await _tbService.StartActivityAsync();
        }


        /// <summary>
        /// Stop Activity
        /// </summary>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpPost]
        [Route("activity/stop")]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
        public async Task<ServiceResult> StopActivityAsync()
        {
            return await _tbService.StopActivityAsync();
        }

    }
}