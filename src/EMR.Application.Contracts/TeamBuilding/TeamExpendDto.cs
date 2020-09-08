// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 09-02-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-02-2020
// ***********************************************************************
// <copyright file="TeamExpendDto.cs" company="EMR.Application.Contracts">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

/// <summary>
/// The TeamBuilding namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Application.Contracts.TeamBuilding
{
    /// <summary>
    /// Class TeamExpendDto.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class TeamExpendDto
    {
        /// <summary>
        /// Gets or sets the name of the expend.
        /// </summary>
        /// <value>The name of the expend.</value>
        /// <remarks>Will Wu</remarks>
        public string TeamName { get; set; }

        /// <summary>
        /// Gets or sets the expend.
        /// </summary>
        /// <value>The expend.</value>
        /// <remarks>Will Wu</remarks>
        public double Expend { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        /// <value>The serial number.</value>
        /// <remarks>Will Wu</remarks>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        /// <value>The comment.</value>
        /// <remarks>Will Wu</remarks>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>The create time.</value>
        /// <remarks>Will Wu</remarks>
        public DateTime CreateTime { get; set; }
    }
}