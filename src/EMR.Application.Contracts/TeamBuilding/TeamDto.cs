// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-03-2020
// ***********************************************************************
// <copyright file="TeamDto.cs" company="EMR.Application.Contracts">
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
    /// Class TeamDto.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class TeamDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        /// <remarks>Will Wu</remarks>
        public Guid Id { get; set; }
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
        /// Gets or sets the logo.
        /// </summary>
        /// <value>The logo.</value>
        /// <remarks>Will Wu</remarks>
        public string Logo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is organiser.
        /// </summary>
        /// <value><c>true</c> if this instance is organiser; otherwise, <c>false</c>.</value>
        /// <remarks>Will Wu</remarks>
        public bool IsOrganiser { get; set; }

        /// <summary>
        /// Gets or sets the create time.
        /// </summary>
        /// <value>The create time.</value>
        /// <remarks>Will Wu</remarks>
        public DateTime CreateTime { get; set; }
    }
}