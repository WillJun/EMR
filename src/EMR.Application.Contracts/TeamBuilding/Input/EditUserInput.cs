// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="EditUserInput.cs" company="EMR.Application.Contracts">
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
    /// Class EditUserInput.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class EditUserInput
    {
        /// <summary>
        /// Gets or sets the id of the expenditure.
        /// </summary>
        /// <value>The id of the expenditure.</value>
        /// <remarks>Will Wu</remarks>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        /// <remarks>Will Wu</remarks>
        public double Balance { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is overspend.
        /// </summary>
        /// <value><c>true</c> if this instance is overspend; otherwise, <c>false</c>.</value>
        /// <remarks>Will Wu</remarks>
        public bool IsOverspend { get; set; }
    }
}