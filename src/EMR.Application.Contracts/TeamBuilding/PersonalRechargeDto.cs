//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding
// FileName : PersonalRechargeDto
//
// Created by : Will.Wu at 2020/8/19 12:54:52
//
//
//========================================================================
using System;

namespace EMR.Application.Contracts.TeamBuilding
{
    public class PersonalRechargeDto
    {
        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value> The serial number. </value>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the source.
        /// </summary>
        /// <value> The name of the source. </value>
        public string SourceName { get; set; }

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