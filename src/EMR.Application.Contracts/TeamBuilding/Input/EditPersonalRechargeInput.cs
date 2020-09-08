// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="EditPersonalRechargeInput.cs" company="EMR.Application.Contracts">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

/// <summary>
/// The Input namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Application.Contracts.TeamBuilding.Input
{
    /// <summary>
    /// Class EditPersonalRechargeInput.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class EditPersonalRechargeInput
    {
        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>The serial number.</value>
        /// <remarks>Will Wu</remarks>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the SourceId.
        /// </summary>
        /// <value>The source identifier.</value>
        /// <remarks>Will Wu</remarks>
        public Guid SourceId { get; set; }

        /// <summary>
        /// Gets or sets the SourceId.
        /// </summary>
        /// <value>The user identifier.</value>
        /// <remarks>Will Wu</remarks>
        public Guid UserId { get; set; }

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