//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding
// FileName : TeamDto
//
// Created by : Will.Wu at 2020/8/19 12:53:31
//
//
//========================================================================
using System;

namespace EMR.Application.Contracts.TeamBuilding
{
    public class TeamDto
    {
        public string TeamName { get; set; }

        public string TeamLeader { get; set; }

        public bool IsOrganiser { get; set; }

        public DateTime CreateTime { get; set; }
    }
}