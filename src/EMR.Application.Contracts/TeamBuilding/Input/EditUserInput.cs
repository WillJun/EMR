//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding.Input
// FileName : EditUserInput
//
// Created by : Will.Wu at 2020/8/23 12:12:48
//
//
//========================================================================
using System;

namespace EMR.Application.Contracts.TeamBuilding.Input
{
    public class EditUserInput
    {
        /// <summary>
        /// Gets or sets the id of the expenditure.
        /// </summary>
        /// <value> The id of the expenditure. </value>
        public Guid Id { get; set; }

        public double Balance { get; set; }

        public bool IsOverspend { get; set; }
    }
}