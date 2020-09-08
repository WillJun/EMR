// ***********************************************************************
// Assembly         : EMR.HttpApi
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="TeamBuildingController.cs" company="EMR.HttpApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using EMR.Application.Contracts.TeamBuilding;
using EMR.Application.TeamBuilding;
using EMR.ToolKits.Base;

using Microsoft.AspNetCore.Hosting;
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
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_v2)]
    public partial class TeamBuildingController : AbpController
    {
        /// <summary>
        /// The tb service
        /// </summary>
        private readonly ITeamBuildingService _tbService;
        /// <summary>
        /// The hosting environment
        /// </summary>
        private readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamBuildingController" /> class.
        /// </summary>
        /// <param name="tbService">The tb service.</param>
        /// <param name="hostingEnvironment">The hosting environment.</param>
        /// <remarks>Will Wu</remarks>
        public TeamBuildingController(ITeamBuildingService tbService, IHostingEnvironment hostingEnvironment)
        {
            _tbService = tbService;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// 查询User信息
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>Task&lt;ServiceResult&lt;UserDetailDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("user/info")]
        public async Task<ServiceResult<UserDetailDto>> GetUserDetailAsync(string account)
        {
            return await _tbService.GetUserDetailAsync(account);
        }

        /// <summary>
        /// 查询Teams列表
        /// </summary>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;TeamDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("teams")]
        public async Task<ServiceResult<IEnumerable<TeamDto>>> QueryTeamsAsync()
        {
            return await _tbService.QueryTeamsAsync();
        }

        /// <summary>
        /// 根据团队id获取成员
        /// </summary>
        /// <param name="id">团队id</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;QueryUserDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("users/team")]
        public async Task<ServiceResult<IEnumerable<QueryUserDto>>> QueryUsersByTeamAsync([Required] Guid id)
        {
            return await _tbService.QueryUsersByTeamAsync(id);
        }

        /// <summary>
        /// 获取全部点赞数.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;TeamWowCountDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("wows")]
        public async Task<ServiceResult<IEnumerable<TeamWowCountDto>>> QueryTeamWowCountsAsync()
        {
            return await _tbService.QueryTeamWowCountsAsync();
        }

        /// <summary>
        /// 根据团队id获取点赞数.
        /// </summary>
        /// <param name="id">The 团队id.</param>
        /// <returns>Task&lt;ServiceResult&lt;TeamWowCountDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("wow/team")]
        public async Task<ServiceResult<TeamWowCountDto>> QueryTeamWowCountsByTeamAsync([Required] Guid id)
        {
            return await _tbService.QueryTeamWowCountsByTeamAsync(id);
        }

        /// <summary>
        /// 根据员工id获取点赞数
        /// </summary>
        /// <param name="id">The account.</param>
        /// <returns>Task&lt;ServiceResult&lt;UserWowCountDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("wow/user")]
        public async Task<ServiceResult<UserWowCountDto>> QueryUserWowCountsByUserAsync([Required] Guid id)
        {
            return await _tbService.QueryUserWowCountsByUserAsync(id);
        }

        /// <summary>
        /// 根据员工id获取消费清单
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;PersonalExpenditureDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("personalexpend/user")]
        public async Task<ServiceResult<IEnumerable<PersonalExpenditureDto>>> QueryPersonalExpendituresByUserAsync([Required] Guid id)
        {
            return await _tbService.QueryPersonalExpendituresByUserAsync(id);
        }

        /// <summary>
        /// 根据员工id获取充值记录
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;PersonalRechargeDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("personalrecharge/user")]
        public async Task<ServiceResult<IEnumerable<PersonalRechargeDto>>> QueryPersonalRechargesByUserAsync([Required] Guid id)
        {
            return await _tbService.QueryPersonalRechargesByUserAsync(id);
        }

        /// <summary>
        /// 根据团队id获取流水
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;SalesQuotaWithUserDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("salesquotas/team")]
        public async Task<ServiceResult<IEnumerable<SalesQuotaWithUserDto>>> QuerySalesQuotasByTeamAsync([Required] Guid id)
        {
            return await _tbService.QuerySalesQuotasByTeamAsync(id);
        }

        /// <summary>
        /// 根据员工id获取流水
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;SalesQuotaWithUserDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("salesquotas/user")]
        public async Task<ServiceResult<IEnumerable<SalesQuotaWithUserDto>>> QuerySalesQuotasByUserAsync([Required] Guid id)
        {
            return await _tbService.QuerySalesQuotasByUserAsync(id);
        }

        /// <summary>
        /// 根据团队id获取流水总额
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;TeamSalesQuotaTotalDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("salesquota/team")]
        public async Task<ServiceResult<TeamSalesQuotaTotalDto>> QueryTeamSalesQuotasAsync([Required] Guid id)
        {
            return await _tbService.QueryTeamSalesQuotasByTeamAsync(id);
        }

        /// <summary>
        /// 根据员工id获取流水总额
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&lt;UserSalesQuotaTotalDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("salesquota/user")]
        public async Task<ServiceResult<UserSalesQuotaTotalDto>> QueryUserSalesQuotasByUserAsync([Required] Guid id)
        {
            return await _tbService.QueryUserSalesQuotasByUserAsync(id);
        }

        /// <summary>
        /// 获取所有团队流水总额
        /// </summary>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;TeamSalesQuotaTotalDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("salesquotas")]
        public async Task<ServiceResult<IEnumerable<TeamSalesQuotaTotalDto>>> QueryTeamSalesQuotasAsync()
        {
            return await _tbService.QueryTeamSalesQuotasAsync();
        }

        /// <summary>
        /// 获取所有团队消费总额
        /// </summary>
        /// <returns>Task&lt;ServiceResult&lt;IEnumerable&lt;TeamExpenditureTotalDto&gt;&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("teamexpends")]
        public async Task<ServiceResult<IEnumerable<TeamExpenditureTotalDto>>> QueryTeamExpendituresAsync()
        {
            return await _tbService.QueryTeamExpendituresAsync();
        }

        /// <summary>
        /// Generate QRCode
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ServiceResult&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("team/generateqr")]
        [ApiExplorerSettings(GroupName = Grouping.GroupName_v3)]
        public async Task<ServiceResult> GenerateQRCodeAsync([Required] Guid id)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;

            var teamsresult = await _tbService.QueryTeamsAsync();
            var team = teamsresult.Result.Where(p => p.Id == id).FirstOrDefault();
            if (team != null)
            {
                if (team.IsOrganiser)
                {
                    var result2 = new ServiceResult();
                    result2.IsFailed("非活动团队无需二维码");
                    return result2;
                }

                if (!string.IsNullOrWhiteSpace(team.Logo))
                {
                    string logourl = webRootPath + team.Logo;
                    return await _tbService.GenerateQRCodeAsync(id, logourl);
                }
                return await _tbService.GenerateQRCodeAsync(id);
            }
            var result = new ServiceResult();
            result.IsFailed("团队不存在");
            return result;
        }

        /// <summary>
        /// get activity as an asynchronous operation.
        /// </summary>
        /// <returns>Task&lt;ServiceResult&lt;ActivityDto&gt;&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpGet]
        [Route("activity")]
        public async Task<ServiceResult<ActivityDto>> GetActivityAsync()
        {
            return await _tbService.GetActivityAsync();
        }

    }
}