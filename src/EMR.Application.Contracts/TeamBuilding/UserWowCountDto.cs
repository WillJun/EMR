// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="UserWowCountDto.cs" company="EMR.Application.Contracts">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;

/// <summary>
/// The TeamBuilding namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Application.Contracts.TeamBuilding
{
    /// <summary>
    /// Class UserWowCountDto.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class UserWowCountDto
    {
        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>The account.</value>
        /// <remarks>Will Wu</remarks>
        public string Account { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        /// <remarks>Will Wu</remarks>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the wows.
        /// </summary>
        /// <value>The wows.</value>
        /// <remarks>Will Wu</remarks>
        public IEnumerable<TeamWowDto> Wows { get; set; }
    }
}