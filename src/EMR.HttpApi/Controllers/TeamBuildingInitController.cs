// ***********************************************************************
// Assembly         : EMR.HttpApi
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="TeamBuildingInitController.cs" company="EMR.HttpApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using EMR.Application.TeamBuilding;
using EMR.Domain.TeamBuilding;

using Microsoft.AspNetCore.Mvc;

using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Guids;

using static EMR.Domain.Shared.EMRConsts;

/// <summary>
/// The Controllers namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.HttpApi.Controllers
{
    /// <summary>
    /// Class TeamBuildingInitController.
    /// Implements the <see cref="Volo.Abp.AspNetCore.Mvc.AbpController" />
    /// </summary>
    /// <seealso cref="Volo.Abp.AspNetCore.Mvc.AbpController" />
    /// <remarks>Will Wu</remarks>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_v1)]
    public class TeamBuildingInitController : AbpController
    {
        /// <summary>
        /// The tb service
        /// </summary>
        private readonly ITeamBuildingService _tbService;
        /// <summary>
        /// The unique identifier generator
        /// </summary>
        private readonly IGuidGenerator _guidGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamBuildingInitController" /> class.
        /// </summary>
        /// <param name="tbService">The tb service.</param>
        /// <param name="guidGenerator">The unique identifier generator.</param>
        /// <remarks>Will Wu</remarks>
        public TeamBuildingInitController(ITeamBuildingService tbService, IGuidGenerator guidGenerator)
        {
            _tbService = tbService;
            _guidGenerator = guidGenerator;
        }

        /// <summary>
        /// insert as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        [HttpPost]
        public async Task InsertAsync()
        {
            Random rd = new Random();
            List<Tempteam> tempteams = ToolKits.Helper.ImportExcelUtil<Tempteam>.InputExcel(@"D:\Git\EMR\Grouping.xlsx", "Team");

            List<Tempuser> tempusers = ToolKits.Helper.ImportExcelUtil<Tempuser>.InputExcel(@"D:\Git\EMR\Grouping.xlsx", "TeamUser");
            Guid SourceId = Guid.Empty;
            List<Team> teamlist = new List<Team>();
            foreach (var item in tempteams)
            {
                Team t = new Team(_guidGenerator.Create())
                {
                    TeamName = item.Name.Trim(),
                    TeamLeader = string.IsNullOrWhiteSpace(item.Leader) ? "" : item.Leader.Trim(),
                    IsOrganiser = item.IsOraganiser.Trim() != "0",
                    CreateTime = DateTime.Now
                };
                teamlist.Add(t);

                if (item.Name == "发改委")
                {
                    SourceId = t.Id;
                }
            }
            List<User> userlist = new List<User>();

            List<PersonalRecharge> personalRecharges = new List<PersonalRecharge>();

            foreach (var item in tempusers)
            {
                User u = new User(_guidGenerator.Create());
                u.Account = item.Account.Trim();
                u.UserEnName = string.IsNullOrWhiteSpace(item.UserEnName) ? "" : item.UserEnName.ToString().Trim();
                u.UserName = string.IsNullOrWhiteSpace(item.UserName) ? "" : item.UserName.ToString().Trim();
                u.Email = string.IsNullOrWhiteSpace(item.Email) ? "" : item.Email.ToString().Trim();
                u.Dept = string.IsNullOrWhiteSpace(item.Dept) ? "" : item.Dept.ToString().Trim();

                string teamname = item.Group.ToString().Trim();
                var teaminfo = teamlist.Where(p => p.TeamName == teamname).FirstOrDefault();
                if (teaminfo != null)
                {
                    u.TeamId = teaminfo.Id;
                }
                u.IsLeader = item.IsLeader.ToString().Trim() != "0";
                u.IsOverspend = false;

                if (teamname == "发改委" || teamname == "评委")
                {
                    u.Balance = 700.00;
                }
                else
                {
                    u.Balance = 280.00;
                }

                userlist.Add(u);

                PersonalRecharge pr = new PersonalRecharge(_guidGenerator.Create());
                DateTime time = DateTime.Now;
                pr.SerialNumber = time.ToString("yyyyMMddHHmmss") + rd.Next(0, 9999).ToString("0000");
                pr.SourceId = SourceId;
                pr.UserId = u.Id;
                if (teamname == "发改委" || teamname == "评委")
                {
                    pr.Amount = 700.00;
                }
                else
                {
                    pr.Amount = 280.00;
                }
                pr.Comment = "初始金额";
                pr.CreateTime = time;
                personalRecharges.Add(pr);
            }

            await _tbService.TeamBulkInsertAsync(teamlist);
            await _tbService.UserBulkInsertAsync(userlist);
            await _tbService.PersonalRechargeBulkInsertAsync(personalRecharges);
        }
    }

    /// <summary>
    /// Class Tempuser.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class Tempuser
    {
        /// <summary>
        /// Gets or sets the group.
        /// </summary>
        /// <value>The group.</value>
        /// <remarks>Will Wu</remarks>
        public string Group { get; set; }
        /// <summary>
        /// Gets or sets the dept.
        /// </summary>
        /// <value>The dept.</value>
        /// <remarks>Will Wu</remarks>
        public string Dept { get; set; }
        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>The account.</value>
        /// <remarks>Will Wu</remarks>
        public string Account { get; set; }
        /// <summary>
        /// Gets or sets the name of the user en.
        /// </summary>
        /// <value>The name of the user en.</value>
        /// <remarks>Will Wu</remarks>
        public string UserEnName { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        /// <remarks>Will Wu</remarks>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        /// <remarks>Will Wu</remarks>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the is leader.
        /// </summary>
        /// <value>The is leader.</value>
        /// <remarks>Will Wu</remarks>
        public string IsLeader { get; set; }
    }

    /// <summary>
    /// Class Tempteam.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class Tempteam
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks>Will Wu</remarks>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the leader.
        /// </summary>
        /// <value>The leader.</value>
        /// <remarks>Will Wu</remarks>
        public string Leader { get; set; }
        /// <summary>
        /// Gets or sets the is oraganiser.
        /// </summary>
        /// <value>The is oraganiser.</value>
        /// <remarks>Will Wu</remarks>
        public string IsOraganiser { get; set; }
    }
}