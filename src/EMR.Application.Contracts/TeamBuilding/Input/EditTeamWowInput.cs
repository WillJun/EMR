//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding.Input
// FileName : EditTeamWowInput
//
// Created by : Will.Wu at 2020/8/21 16:25:57
//
//
//========================================================================
using System;

namespace EMR.Application.Contracts.TeamBuilding.Input
{
    public class EditTeamWowInput
    {
        public Guid TeamId { get; set; }

        public Guid UserId { get; set; }

        public bool IsWow { get; set; }

        public DateTime WowTime { get; set; }
    }
}