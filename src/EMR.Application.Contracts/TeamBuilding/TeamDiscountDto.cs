// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-02-2020
// ***********************************************************************
// <copyright file="TeamDiscountDto.cs" company="EMR.Application.Contracts">
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
    /// Class TeamDiscountDto.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class TeamDiscountDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        /// <remarks>Will Wu</remarks>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the team identifier.
        /// </summary>
        /// <value>The team identifier.</value>
        /// <remarks>Will Wu</remarks>
        public Guid TeamId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is disable.
        /// </summary>
        /// <value><c>true</c> if this instance is disable; otherwise, <c>false</c>.</value>
        /// <remarks>Will Wu</remarks>
        public bool IsDisable { get; set; }

        /// <summary>
        /// Gets or sets the full amount.
        /// </summary>
        /// <value>The full amount.</value>
        /// <remarks>Will Wu</remarks>
        public double FullAmount { get; set; }

        /// <summary>
        /// Gets or sets the operation.
        /// </summary>
        /// <value>The operation.</value>
        /// <remarks>Will Wu</remarks>
        public string Operation { get; set; }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        /// <remarks>Will Wu</remarks>
        public double Discount { get; set; }
        /// <summary>
        /// Gets or sets the discription.
        /// </summary>
        /// <value>The discription.</value>
        /// <remarks>Will Wu</remarks>
        public string Discription { get; set; }
    }
}