//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding
// FileName : QueryUserDto
//
// Created by : Will.Wu at 2020/8/19 13:00:23
//
//
//========================================================================

namespace EMR.Application.Contracts.TeamBuilding
{
    public class QueryUserDto
    {
        public string Account { get; set; }
        public string UserName { get; set; }
        public string UserEnName { get; set; }

        public string Email { get; set; }
        public string Dept { get; set; }
        public bool IsLeader { get; set; }

        public double Balance { get; set; }

        public bool IsOverspend { get; set; }
    }
}