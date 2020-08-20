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
using System.Collections.Generic;
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
        /// 根据团队名称获取成员
        /// </summary>
        /// <param name="teamname"> 团队名称 </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("users/team")]
        public async Task<ServiceResult<IEnumerable<QueryUserDto>>> QueryUsersByTeamAsync(string teamname)
        {
            return await _tbService.QueryUsersByTeamAsync(teamname);
        }

        /// <summary>
        /// 根据团队名获取点赞数.
        /// </summary>
        /// <param name="teamname"> The teamname. </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("wows/team")]
        public async Task<ServiceResult<TeamWowCountDto>> QueryTeamWowCountsByTeamAsync(string teamname)
        {
            return await _tbService.QueryTeamWowCountsByTeamAsync(teamname);
        }

        /// <summary>
        /// 根据工号获取点赞数
        /// </summary>
        /// <param name="account"> The account. </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("wows/user")]
        public async Task<ServiceResult<UserWowCountDto>> QueryUserWowCountsByUserAsync(string account)
        {
            return await _tbService.QueryUserWowCountsByUserAsync(account);
        }

        /// <summary>
        /// 根据工号获取消费清单
        /// </summary>
        /// <param name="account"> </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("personalexpend/user")]
        public async Task<ServiceResult<IEnumerable<PersonalExpenditureDto>>> QueryPersonalExpendituresByUserAsync(string account)
        {
            return await _tbService.QueryPersonalExpendituresByUserAsync(account);
        }

        /// <summary>
        /// 根据工号获取充值记录
        /// </summary>
        /// <param name="account"> </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("personalrecharge/user")]
        public async Task<ServiceResult<IEnumerable<PersonalRechargeDto>>> QueryPersonalRechargesByUserAsync(string account)
        {
            return await _tbService.QueryPersonalRechargesByUserAsync(account);
        }

        /// <summary>
        /// 根据团队名获取流水
        /// </summary>
        /// <param name="teamname"> </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("salesquotas/team")]
        public async Task<ServiceResult<IEnumerable<SalesQuotaDto>>> QuerySalesQuotasByTeamAsync(string teamname)
        {
            return await _tbService.QuerySalesQuotasByTeamAsync(teamname);
        }

        /// <summary>
        /// 根据工号获取流水
        /// </summary>
        /// <param name="account"> </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("salesquotas/user")]
        public async Task<ServiceResult<IEnumerable<SalesQuotaDto>>> QuerySalesQuotasByUserAsync(string account)
        {
            return await _tbService.QuerySalesQuotasByUserAsync(account);
        }

        /// <summary>
        /// 根据团队名获取流水总额
        /// </summary>
        /// <param name="teamname"> </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("salesquota/team")]
        public async Task<ServiceResult<TeamSalesQuotaTotalDto>> QueryTeamSalesQuotasAsync(string teamname)
        {
            return await _tbService.QueryTeamSalesQuotasByTeamAsync(teamname);
        }

        /// <summary>
        /// 根据工号获取流水总额
        /// </summary>
        /// <param name="account"> </param>
        /// <returns> </returns>
        [HttpGet]
        [Route("salesquota/user")]
        public async Task<ServiceResult<UserSalesQuotaTotalDto>> QueryUserSalesQuotasByUserAsync(string account)
        {
            return await _tbService.QueryUserSalesQuotasByUserAsync(account);
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