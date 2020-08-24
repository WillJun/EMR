//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding
// FileName : UserDetailDto
//
// Created by : Will.Wu at 2020/8/19 12:52:29
//
//
//========================================================================

using System;
using System.Collections.Generic;

namespace EMR.Application.Contracts.TeamBuilding
{
    public class UserDetailDto
    {
        public Guid Id { get; set; }
        public string Account { get; set; }
        public string UserName { get; set; }
        public string UserEnName { get; set; }

        public string Email { get; set; }
        public string Dept { get; set; }

        public TeamDto TeamInfo { get; set; }

        public bool IsLeader { get; set; }

        public double Balance { get; set; }

        public bool IsOverspend { get; set; }

        public IEnumerable<PersonalRechargeDto> PersonalRecharges { get; set; }

        public IEnumerable<PersonalExpenditureDto> PersonalExpenditures { get; set; }
    }
}