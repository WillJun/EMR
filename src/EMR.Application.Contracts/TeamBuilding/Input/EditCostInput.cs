// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="EditCostInput.cs" company="EMR.Application.Contracts">
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
    /// Class EditCostInput.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class EditCostInput
    {
        /// <summary>
        /// Gets or sets the id of the expenditure.
        /// </summary>
        /// <value>The id of the expenditure.</value>
        /// <remarks>Will Wu</remarks>
        public Guid TeamId
        { get; set; }

        /// <summary>
        /// Gets or sets the id of the expenditure.
        /// </summary>
        /// <value>The id of the expenditure.</value>
        /// <remarks>Will Wu</remarks>
        public Guid OperatorId { get; set; }

        /// <summary>
        /// Gets or sets the id of the expenditure.
        /// </summary>
        /// <value>The id of the expenditure.</value>
        /// <remarks>Will Wu</remarks>
        public string Account { get; set; }

        /// <summary>
        /// Gets or sets the expend.
        /// </summary>
        /// <value>The Amount.</value>
        /// <remarks>Will Wu</remarks>
        public double Amount
        { get; set; }
    }
}