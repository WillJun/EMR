//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.Application.Contracts.TeamBuilding
// FileName : TeamExpendDto
//
// Created by : Will.Wu at 2020/8/19 12:56:02
//
//
//========================================================================
using System;

namespace EMR.Application.Contracts.TeamBuilding
{
    public class TeamExpendDto
    {
        /// <summary>
        /// Gets or sets the name of the expend.
        /// </summary>
        /// <value> The name of the expend. </value>
        public string TeamName { get; set; }

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