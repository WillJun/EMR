//========================================================================
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
    }
}