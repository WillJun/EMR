//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding
// FileName : EditPersonalRechargeInput
//
// Created by : Will.Wu at 2020/8/21 16:20:20
//
//
//========================================================================

using System;

namespace EMR.Application.Contracts.TeamBuilding.Input
{
    public class EditPersonalRechargeInput
    {
        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value> The serial number. </value>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the SourceId.
        /// </summary>
        public Guid SourceId { get; set; }

        /// <summary>
        /// Gets or sets the SourceId.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value> The amount. </value>
        public double Amount { get; set; }

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