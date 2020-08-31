//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Domain.TeamBuilding.Repositories
// FileName : ITeamExpendRepository
//
// Created by : Will.Wu at 2020/8/19 11:36:29
//
//
//========================================================================
using System;

using Volo.Abp.Domain.Repositories;

namespace EMR.Domain.TeamBuilding.Repositories
{
    public interface ITeamExpendRepository : IRepository<TeamExpend, Guid>
    {
    }
}