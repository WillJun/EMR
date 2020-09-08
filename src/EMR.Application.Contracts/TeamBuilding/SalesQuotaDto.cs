// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="SalesQuotaDto.cs" company="EMR.Application.Contracts">
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
    /// Class SalesQuotaDto.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class SalesQuotaDto
    {
        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>The serial number.</value>
        /// <remarks>Will Wu</remarks>
        public string SerialNumber { get; set; }
        /// <summary>
        /// Gets or sets the name of the team.
        /// </summary>
        /// <value>The name of the team.</value>
        /// <remarks>Will Wu</remarks>
        public string TeamName { get; set; }
        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        /// <value>The operator.</value>
        /// <remarks>Will Wu</remarks>
        public string Operator { get; set; }
        /// <summary>
        /// Gets or sets the income.
        /// </summary>
        /// <value>The income.</value>
        /// <remarks>Will Wu</remarks>
        public double Income { get; set; }
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