﻿//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.HttpApi.Controllers
// FileName : TeamBuildingController
//
// Created by : Will.Wu at 2020/8/21 16:11:50
//
//
//========================================================================
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding.Input;
using EMR.ToolKits.Base;

using Microsoft.AspNetCore.Mvc;

using Volo.Abp.AspNetCore.Mvc;

using static EMR.Domain.Shared.EMRConsts;

namespace EMR.HttpApi.Controllers
{
    public partial class TeamBuildingController : AbpController
    {
        /// <summary>
        /// 点赞
        /// </summary>
        /// <returns> </returns>
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
        /// <returns> </returns>
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
        /// <returns> </returns>
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
        /// <returns> </returns>
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
        /// <returns> </returns>
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
        /// <returns> </returns>
        [HttpPost]
        [Route("cost")]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
        public async Task<ServiceResult> InsertCostAsync([FromBody] EditCostInput input)
        {
            return await _tbService.InsertCostAsync(input);
        }
    }
}