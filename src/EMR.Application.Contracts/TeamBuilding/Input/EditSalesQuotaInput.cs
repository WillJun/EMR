//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding.Input
// FileName : EditSalesQuotaInput
//
// Created by : Will.Wu at 2020/8/21 16:21:55
//
//
//========================================================================
using System;

namespace EMR.Application.Contracts.TeamBuilding.Input
{
    public class EditSalesQuotaInput
    {
        public string SerialNumber { get; set; }
        public Guid TeamId { get; set; }
        public Guid Operator { get; set; }
        public double Income { get; set; }
        public string Comment { get; set; }
        public DateTime CreateTime { get; set; }
    }
}