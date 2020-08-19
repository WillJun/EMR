
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using EMR.Application.TeamBuilding;
using EMR.Domain.TeamBuilding;
using EMR.ToolKits.Helper;

using Microsoft.AspNetCore.Mvc;

using Volo.Abp.AspNetCore.Mvc;

using static EMR.Domain.Shared.EMRConsts;

namespace EMR.HttpApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_v1)]
    public class TeamBuildingController : AbpController
    {
        private readonly ITeamBuildingService _tbService;

        public TeamBuildingController(ITeamBuildingService tbService)
        {
            _tbService = tbService;
        }

        [HttpPost]
        public async Task InsertAsync()
        {
            ExcelObject excelObject = new ExcelObject(@"E:\Git\EMR\Grouping.xlsx");

            var teamtable = excelObject.ReadTable("Team");
            List<Team> teamlist = new List<Team>();
            foreach (DataRow ddr in teamtable.Rows)
            {
                Team t = new Team();
                t.TeamName = ddr["Name"].ToString().Trim();
                t.TeamLeader = ddr["Leader"].ToString().Trim();
                t.IsOrganiser = ddr["IsOraganiser"].ToString().Trim() == "0" ? false : true;
                t.CreateTime = DateTime.Now;
                teamlist.Add(t);

            }
            var usertable = excelObject.ReadTable("TeamUser");
            List<User> userlist = new List<User>();
            foreach (DataRow ddr in usertable.Rows)
            {
                User u = new User();
                u.Account = ddr["Account"].ToString().Trim();
                u.UserEnName = ddr["UserEnName"].ToString().Trim();
                u.UserName = ddr["UserName"].ToString().Trim();
                u.Email = ddr["Email"].ToString().Trim();
                u.Dept = ddr["Dept"].ToString().Trim();

                string teamname = ddr["Group"].ToString().Trim();
                var teaminfo = teamlist.Where(p => p.TeamName == teamname).FirstOrDefault();
                if (teaminfo != null)
                {
                    u.TeamId = teaminfo.Id;
                }
                u.IsLeader = ddr["IsLeader"].ToString().Trim() == "0" ? false : true;
                u.IsOverspend = false;
                u.Balance = 200.00;
                userlist.Add(u);
            }

            await _tbService.TeamBulkInsertAsync(teamlist);
            await _tbService.UserBulkInsertAsync(userlist);

        }


    }
}
