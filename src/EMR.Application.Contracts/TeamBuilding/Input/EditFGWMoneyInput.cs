// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 09-02-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-02-2020
// ***********************************************************************
// <copyright file="EditFGWMoneyInput.cs" company="EMR.Application.Contracts">
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
    /// Class EditFGWMoneyInput.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class EditFGWMoneyInput
    {
        /// <summary>
        /// Gets or sets the source identifier.
        /// </summary>
        /// <value>The source identifier.</value>
        /// <remarks>Will Wu</remarks>
        public Guid SourceId { get; set; }

        /// <summary>
        /// Gets or sets the team ids.
        /// </summary>
        /// <value>The team ids.</value>
        /// <remarks>Will Wu</remarks>
        public string TeamIds { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        /// <remarks>Will Wu</remarks>
        public double Amount { get; set; }
    }
}