//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding.Input
// FileName : EditCostInput
//
// Created by : Will.Wu at 2020/8/23 11:44:59
//
//
//========================================================================
using System;

namespace EMR.Application.Contracts.TeamBuilding.Input
{
    public class EditTeamDiscountInput
    {
        public Guid Id { get; set; }
        public Guid TeamId { get; set; }
        public bool IsDisable { get; set; }

        public double FullAmount { get; set; }

        public string Operation { get; set; }

        public double Discount { get; set; }
        public string Discription { get; set; }
    }
}