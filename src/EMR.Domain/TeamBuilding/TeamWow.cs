// ***********************************************************************
// Assembly         : EMR.Domain
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="TeamWow.cs" company="EMR.Domain">
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
    /// Class TeamWow.
    /// Implements the <see cref="Volo.Abp.Domain.Entities.Entity{System.Guid}" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Entities.Entity{System.Guid}" />
    /// <remarks>Will Wu</remarks>
    public class TeamWow : Entity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamWow"/> class.
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public TeamWow()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamWow"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <remarks>Will Wu</remarks>
        public TeamWow(Guid id) : base(id)
        {
        }

        /// <summary>
        /// Gets or sets the team identifier.
        /// </summary>
        /// <value>The team identifier.</value>
        /// <remarks>Will Wu</remarks>
        public Guid TeamId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        /// <remarks>Will Wu</remarks>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is wow.
        /// </summary>
        /// <value><c>true</c> if this instance is wow; otherwise, <c>false</c>.</value>
        /// <remarks>Will Wu</remarks>
        public bool IsWow { get; set; }

        /// <summary>
        /// Gets or sets the wow time.
        /// </summary>
        /// <value>The wow time.</value>
        /// <remarks>Will Wu</remarks>
        public DateTime WowTime { get; set; }
    }
}