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

namespace EMR.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_v1)]
    public class TeamBuildingInitController : AbpController
    {
        private readonly ITeamBuildingService _tbService;
        private readonly IGuidGenerator _guidGenerator;

        public TeamBuildingInitController(ITeamBuildingService tbService, IGuidGenerator guidGenerator)
        {
            _tbService = tbService;
            _guidGenerator = guidGenerator;
        }

        [HttpPost]
        public async Task InsertAsync()
        {
            Random rd = new Random();
            List<tempteam> tempteams = ToolKits.Helper.ImportExcelUtil<tempteam>.InputExcel(@"D:\Git\EMR\Grouping.xlsx", "Team");

            List<tempuser> tempusers = ToolKits.Helper.ImportExcelUtil<tempuser>.InputExcel(@"D:\Git\EMR\Grouping.xlsx", "TeamUser");
            Guid SourceId = Guid.Empty;
            List<Team> teamlist = new List<Team>();
            foreach (var item in tempteams)
            {
                Team t = new Team(_guidGenerator.Create());

                t.TeamName = item.Name.Trim();
                t.TeamLeader = string.IsNullOrWhiteSpace(item.Leader) ? "" : item.Leader.Trim();
                t.IsOrganiser = item.IsOraganiser.Trim() == "0" ? false : true;
                t.CreateTime = DateTime.Now;
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
                u.IsLeader = item.IsLeader.ToString().Trim() == "0" ? false : true;
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

    public class tempuser
    {
        public string Group { get; set; }
        public string Dept { get; set; }
        public string Account { get; set; }
        public string UserEnName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string IsLeader { get; set; }
    }

    public class tempteam
    {
        public string Name { get; set; }
        public string Leader { get; set; }
        public string IsOraganiser { get; set; }
    }
}