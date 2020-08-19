//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding
// FileName : PersonalExpenditureDto
//
// Created by : Will.Wu at 2020/8/19 12:56:02
//
//
//========================================================================
using System;

namespace EMR.Application.Contracts.TeamBuilding
{
    public class PersonalExpenditureDto
    {
        public string ExpenditureName { get; set; }

        public double Expend { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNumber { get; set; }

        public string Comment { get; set; }
        public DateTime CreateTime { get; set; }
    }
}