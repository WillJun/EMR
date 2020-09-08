// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="PersonalRechargeDto.cs" company="EMR.Application.Contracts">
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
    /// Class PersonalRechargeDto.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class PersonalRechargeDto
    {
        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>The serial number.</value>
        /// <remarks>Will Wu</remarks>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the source.
        /// </summary>
        /// <value>The name of the source.</value>
        /// <remarks>Will Wu</remarks>
        public string SourceName { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        /// <remarks>Will Wu</remarks>
        public double Amount { get; set; }

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