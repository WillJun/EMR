//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding.Input
// FileName : EditFGWMoneyInput
//
// Created by : Will.Wu at 2020/9/2 12:45:23
//
//
//========================================================================
using System;

namespace EMR.Application.Contracts.TeamBuilding.Input
{
    public class EditFGWMoneyInput
    {
        public Guid SourceId { get; set; }

        public string TeamIds { get; set; }
        public double Amount { get; set; }
    }
}