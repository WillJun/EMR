//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding
// FileName : TeamWowCountDto
//
// Created by : Will.Wu at 2020/8/19 15:41:05
//
//
//========================================================================

using System;

namespace EMR.Application.Contracts.TeamBuilding
{
    public class TeamWowCountDto
    {
        public string TeamName { get; set; }
        public int Count { get; set; }

        public DateTime LastDateTime { get; set; }
    }
}