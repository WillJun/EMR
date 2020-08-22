//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding.Input
// FileName : EditPersonalExpenditureInput
//
// Created by : Will.Wu at 2020/8/21 16:21:22
//
//
//========================================================================

using System;

namespace EMR.Application.Contracts.TeamBuilding.Input
{
    public class EditPersonalExpenditureInput
    {
        /// <summary>
        /// Gets or sets the id of the expenditure.
        /// </summary>
        /// <value> The id of the expenditure. </value>
        public Guid ExpendId { get; set; }

        /// <summary>
        /// Gets or sets the id of the expenditure.
        /// </summary>
        /// <value> The id of the expenditure. </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the expend.
        /// </summary>
        /// <value> The expend. </value>
        public double Expend { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value> The comment. </value>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value> The create time. </value>
        public DateTime CreateTime { get; set; }
    }
}