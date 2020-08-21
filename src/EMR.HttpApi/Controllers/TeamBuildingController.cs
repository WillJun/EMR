//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.HttpApi.Controllers
// FileName : TeamBuildingController
//
// Created by : Will.Wu at 2020/8/20 10:58:36
//
//
//========================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
using EMR.Application.TeamBuilding;
using EMR.ToolKits.Base;

using Microsoft.AspNetCore.Mvc;

using Volo.Abp.AspNetCore.Mvc;

using static EMR.Domain.Shared.EMRConsts;

namespace EMR.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_v2)]
    public class TeamBuildingController : AbpController
    {
        private readonly ITeamBuildingService _tbService;

        public TeamBuildingController(ITeamBuildingService tbService)
        {
            _tbService = tbService;
        }

        /// <summary>
        /// 查询User信息
        /// </summary>
        /// <returns> </returns>
        [HttpGet]
        [Route("user/info")]
        public async Task<ServiceResult<UserDetailDto>> GetUserDetailAsync(string account)
        {
            return await _tbService.GetUserDetailAsync(account);
        }

        /// <summary>
        /// 查询Teams列表
        /// </summary>
        /// <returns> </returns>
        [HttpGet]
        [Route("teams")]
        public async Task<ServiceResult<IEnumerable<TeamDto>>> QueryTeamsAsync()
        {
            return await _tbService.QueryTeamsAsync();
        }

        /// <summary>
        /// 根据团队id获取成员
        /// </summary>
        /// <param name="id"> 团队id </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("users/team")]
        public async Task<ServiceResult<IEnumerable<QueryUserDto>>> QueryUsersByTeamAsync([Required] Guid id)
        {
            return await _tbService.QueryUsersByTeamAsync(id);
        }

        /// <summary>
        /// 获取全部点赞数.
        /// </summary>
        /// <returns> </returns>
        [HttpGet]
        [Route("wows")]
        public async Task<ServiceResult<IEnumerable<TeamWowCountDto>>> QueryTeamWowCountsAsync()
        {
            return await _tbService.QueryTeamWowCountsAsync();
        }

        /// <summary>
        /// 根据团队id获取点赞数.
        /// </summary>
        /// <param name="id"> The 团队id. </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("wow/team")]
        public async Task<ServiceResult<TeamWowCountDto>> QueryTeamWowCountsByTeamAsync([Required] Guid id)
        {
            return await _tbService.QueryTeamWowCountsByTeamAsync(id);
        }

        /// <summary>
        /// 根据员工id获取点赞数
        /// </summary>
        /// <param name="id"> The account. </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("wow/user")]
        public async Task<ServiceResult<UserWowCountDto>> QueryUserWowCountsByUserAsync([Required] Guid id)
        {
            return await _tbService.QueryUserWowCountsByUserAsync(id);
        }

        /// <summary>
        /// 根据员工id获取消费清单
        /// </summary>
        /// <param name="id"> </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("personalexpend/user")]
        public async Task<ServiceResult<IEnumerable<PersonalExpenditureDto>>> QueryPersonalExpendituresByUserAsync([Required] Guid id)
        {
            return await _tbService.QueryPersonalExpendituresByUserAsync(id);
        }

        /// <summary>
        /// 根据员工id获取充值记录
        /// </summary>
        /// <param name="id"> </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("personalrecharge/user")]
        public async Task<ServiceResult<IEnumerable<PersonalRechargeDto>>> QueryPersonalRechargesByUserAsync([Required] Guid id)
        {
            return await _tbService.QueryPersonalRechargesByUserAsync(id);
        }

        /// <summary>
        /// 根据团队id获取流水
        /// </summary>
        /// <param name="id"> </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("salesquotas/team")]
        public async Task<ServiceResult<IEnumerable<SalesQuotaDto>>> QuerySalesQuotasByTeamAsync([Required] Guid id)
        {
            return await _tbService.QuerySalesQuotasByTeamAsync(id);
        }

        /// <summary>
        /// 根据员工id获取流水
        /// </summary>
        /// <param name="id"> </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("salesquotas/user")]
        public async Task<ServiceResult<IEnumerable<SalesQuotaDto>>> QuerySalesQuotasByUserAsync([Required] Guid id)
        {
            return await _tbService.QuerySalesQuotasByUserAsync(id);
        }

        /// <summary>
        /// 根据团队id获取流水总额
        /// </summary>
        /// <param name="id"> </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("salesquota/team")]
        public async Task<ServiceResult<TeamSalesQuotaTotalDto>> QueryTeamSalesQuotasAsync([Required] Guid id)
        {
            return await _tbService.QueryTeamSalesQuotasByTeamAsync(id);
        }

        /// <summary>
        /// 根据员工id获取流水总额
        /// </summary>
        /// <param name="id"> </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("salesquota/user")]
        public async Task<ServiceResult<UserSalesQuotaTotalDto>> QueryUserSalesQuotasByUserAsync([Required] Guid id)
        {
            return await _tbService.QueryUserSalesQuotasByUserAsync(id);
        }

        /// <summary>
        /// 获取所有团队流水总额
        /// </summary>

        /// <returns> </returns>
        [HttpGet]
        [Route("salesquotas")]
        public async Task<ServiceResult<IEnumerable<TeamSalesQuotaTotalDto>>> QueryTeamSalesQuotasAsync()
        {
            return await _tbService.QueryTeamSalesQuotasAsync();
        }
    }
}