//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding
// FileName : TeamWowDto
//
// Created by : Will.Wu at 2020/8/22 11:55:21
//
//
//========================================================================

using System;

namespace EMR.Application.Contracts.TeamBuilding
{
    public class TeamWowDto
    {
        public Guid TeamId { get; set; }

        public Guid UserId { get; set; }

        public bool IsWow { get; set; }

        public DateTime WowTime { get; set; }
    }
}