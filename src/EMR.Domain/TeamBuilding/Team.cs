// ***********************************************************************
// Assembly         : EMR.Domain
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-03-2020
// ***********************************************************************
// <copyright file="Team.cs" company="EMR.Domain">
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
    /// Class Team.
    /// Implements the <see cref="Volo.Abp.Domain.Entities.Entity{System.Guid}" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Entities.Entity{System.Guid}" />
    /// <remarks>Will Wu</remarks>
    public class Team : Entity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class.
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public Team()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <remarks>Will Wu</remarks>
        public Team(Guid id) : base(id)
        {
        }

        /// <summary>
        /// Gets or sets the name of the team.
        /// </summary>
        /// <value>The name of the team.</value>
        /// <remarks>Will Wu</remarks>
        public string TeamName { get; set; }

        /// <summary>
        /// Gets or sets the team leader.
        /// </summary>
        /// <value>The team leader.</value>
        /// <remarks>Will Wu</remarks>
        public string TeamLeader { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is organiser.
        /// </summary>
        /// <value><c>true</c> if this instance is organiser; otherwise, <c>false</c>.</value>
        /// <remarks>Will Wu</remarks>
        public bool IsOrganiser { get; set; }

        /// <summary>
        /// Gets or sets the logo.
        /// </summary>
        /// <value>The logo.</value>
        /// <remarks>Will Wu</remarks>
        public string Logo { get; set; }

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>The create time.</value>
        /// <remarks>Will Wu</remarks>
        public DateTime CreateTime { get; set; }
    }
}