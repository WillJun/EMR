//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding.Input
// FileName : EditTeamExpendInput
//
// Created by : Will.Wu at 2020/8/23 11:44:59
//
//
//========================================================================
using System;

namespace EMR.Application.Contracts.TeamBuilding.Input
{
    public class EditTeamExpendInput
    {
        /// <summary>
        /// Gets or sets the id of the expenditure.
        /// </summary>
        /// <value> The id of the expenditure. </value>
        public Guid TeamId { get; set; }

        public Guid UserId { get; set; }
        public double Expend { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNumber { get; set; }

        public string Comment { get; set; }
        public DateTime CreateTime { get; set; }
    }
}