// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-02-2020
// ***********************************************************************
// <copyright file="QueryUserDto.cs" company="EMR.Application.Contracts">
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
    /// Class QueryUserDto.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class QueryUserDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        /// <remarks>Will Wu</remarks>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>The account.</value>
        /// <remarks>Will Wu</remarks>
        public string Account { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        /// <remarks>Will Wu</remarks>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the name of the user en.
        /// </summary>
        /// <value>The name of the user en.</value>
        /// <remarks>Will Wu</remarks>
        public string UserEnName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        /// <remarks>Will Wu</remarks>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the dept.
        /// </summary>
        /// <value>The dept.</value>
        /// <remarks>Will Wu</remarks>
        public string Dept { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is leader.
        /// </summary>
        /// <value><c>true</c> if this instance is leader; otherwise, <c>false</c>.</value>
        /// <remarks>Will Wu</remarks>
        public bool IsLeader { get; set; }

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