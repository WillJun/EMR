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
    public class EditCostInput
    {
        /// <summary>
        /// Gets or sets the id of the expenditure.
        /// </summary>
        /// <value> The id of the expenditure. </value>
        public Guid TeamId
        { get; set; }

        /// <summary>
        /// Gets or sets the id of the expenditure.
        /// </summary>
        /// <value> The id of the expenditure. </value>
        public Guid OperatorId { get; set; }

        /// <summary>
        /// Gets or sets the id of the expenditure.
        /// </summary>
        /// <value> The id of the expenditure. </value>
        public string Account { get; set; }

        /// <summary>
        /// Gets or sets the expend.
        /// </summary>
        /// <value> The Amount. </value>
        public double Amount
        { get; set; }
    }
}