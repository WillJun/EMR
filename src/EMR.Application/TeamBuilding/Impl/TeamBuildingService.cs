//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.TeamBuilding.Impl
// FileName : TeamBuildingService
//
// Created by : Will.Wu at 2020/8/19 13:06:23
//
//
//========================================================================
using EMR.Domain.TeamBuilding.Repositories;

namespace EMR.Application.TeamBuilding.Impl
{
    public partial class TeamBuildingService : ServiceBase, ITeamBuildingService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ISalesQuotaRepository _salesquotaRepository;
        private readonly IPersonalRechargeRepository _personalrechargeRepository;
        private readonly IPersonalExpenditureRepository _personalexpenditureRepository;

        private readonly ITeamWowRepository _teamwowRepository;

        public TeamBuildingService(IUserRepository userRepository, ITeamRepository teamRepository, ISalesQuotaRepository salesquotaRepository, IPersonalRechargeRepository personalrechargeRepository, IPersonalExpenditureRepository personalexpenditureRepository, ITeamWowRepository teamwowRepository)
        {
            _userRepository = userRepository;
            _teamRepository = teamRepository;
            _salesquotaRepository = salesquotaRepository;
            _personalrechargeRepository = personalrechargeRepository;
            _personalexpenditureRepository = personalexpenditureRepository;
            _teamwowRepository = teamwowRepository;
        }
    }
}