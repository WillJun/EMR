//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding
// FileName : PersonalRechargeDto
//
// Created by : Will.Wu at 2020/8/19 12:54:52
//
//
//========================================================================
using System;

namespace EMR.Application.Contracts.TeamBuilding
{
    public class PersonalRechargeDto
    {
        public string SerialNumber { get; set; }

        public string SourceName { get; set; }

        public double Amount { get; set; }

        public string Comment { get; set; }
        public DateTime CreateTime { get; set; }
    }
}