// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-02-2020
// ***********************************************************************
// <copyright file="TeamWowDto.cs" company="EMR.Application.Contracts">
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
    /// Class TeamWowDto.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class TeamWowDto
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