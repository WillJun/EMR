//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding
// FileName : SalesQuotaDto
//
// Created by : Will.Wu at 2020/8/19 14:56:28
//
//
//========================================================================
using System;

namespace EMR.Application.Contracts.TeamBuilding
{
    public class SalesQuotaDto
    {
        public string SerialNumber { get; set; }
        public string TeamName { get; set; }
        public string Operator { get; set; }
        public double Income { get; set; }
        public string Comment { get; set; }
        public DateTime CreateTime { get; set; }
    }
}