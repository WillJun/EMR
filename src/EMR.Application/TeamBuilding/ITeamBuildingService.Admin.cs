// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="ITeamBuildingService.Admin.cs" company="EMR.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding.Input;
using EMR.ToolKits.Base;

/// <summary>
/// The TeamBuilding namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Application.TeamBuilding
{
    /// <summary>
    /// Interface ITeamBuildingService
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public partial interface ITeamBuildingService
    {
        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult> InsertWowAsync(EditTeamWowInput input);

        /// <summary>
        /// 取消赞
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult> DeleteWowAsync(Guid id);

        /// <summary>
        /// 新增个人充值
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult> InsertPersonalRechargeAsync(EditPersonalRechargeInput input);

        /// <summary>
        /// 新增个人账单
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult> InsertPersonalExpenditureAsync(EditPersonalExpenditureInput input);

        /// <summary>
        /// 新增流水
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult> InsertSalesQuotaAsync(EditSalesQuotaInput input);

        /// <summary>
        /// 新增消费记录
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult> InsertCostAsync(EditCostInput input);

        /// <summary>
        /// Updates the user asynchronous.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult> UpdateUserAsync(EditUserInput input);

        /// <summary>
        /// 团队分钱
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult> TeamExpendToUserAsync(EditTeamExpendInput input);

        /// <summary>
        /// 折扣
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult> UpdateTeamDiscountAsync(EditTeamDiscountInput input);

        /// <summary>
        /// 发改委给团队发钱
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult> InsertFGWMoneyAsync(EditFGWMoneyInput input);

        /// <summary>
        /// 客户线上支付
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult> InsertCustomPaymentAsync(EditCustomPaymentInput input);

        /// <summary>
        /// GenerateQRCode
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="logourl">The logourl.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult> GenerateQRCodeAsync(Guid id, string logourl = "");


        /// <summary>
        /// GenerateQRCode
        /// </summary>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult> InitActivityAsync();
        /// <summary>
        /// Starts the activity asynchronous.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult> StartActivityAsync();
        /// <summary>
        /// Stops the activity asynchronous.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        Task<ServiceResult> StopActivityAsync();
    }
}