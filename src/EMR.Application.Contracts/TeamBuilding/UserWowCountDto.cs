//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding
// FileName : UserWowCountDto
//
// Created by : Will.Wu at 2020/8/19 15:42:45
//
//
//========================================================================

using System.Collections.Generic;

namespace EMR.Application.Contracts.TeamBuilding
{
    public class UserWowCountDto
    {
        public string Account { get; set; }

        public int Count { get; set; }

        public IEnumerable<TeamWowDto> Wows { get; set; }
    }
}