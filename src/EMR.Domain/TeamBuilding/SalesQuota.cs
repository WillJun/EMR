// ***********************************************************************
// Assembly         : EMR.Domain
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="SalesQuota.cs" company="EMR.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

using Volo.Abp.Domain.Entities;

/// <summary>
/// The TeamBuilding namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Domain.TeamBuilding
{
    /// <summary>
    /// Class SalesQuota.
    /// Implements the <see cref="Volo.Abp.Domain.Entities.Entity{System.Guid}" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Entities.Entity{System.Guid}" />
    /// <remarks>Will Wu</remarks>
    public class SalesQuota : Entity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesQuota"/> class.
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public SalesQuota()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesQuota"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <remarks>Will Wu</remarks>
        public SalesQuota(Guid id) : base(id)
        {
        }

        /// <summary>
        /// 流水号
        /// </summary>
        /// <value>The serial number.</value>
        /// <remarks>Will Wu</remarks>

        public string SerialNumber { get; set; }
        /// <summary>
        /// Gets or sets the team identifier.
        /// </summary>
        /// <value>The team identifier.</value>
        /// <remarks>Will Wu</remarks>
        public Guid TeamId { get; set; }
        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        /// <value>The operator.</value>
        /// <remarks>Will Wu</remarks>
        public Guid Operator { get; set; }
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