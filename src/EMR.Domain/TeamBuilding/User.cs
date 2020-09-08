// ***********************************************************************
// Assembly         : EMR.Domain
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="User.cs" company="EMR.Domain">
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
    /// Class User.
    /// Implements the <see cref="Volo.Abp.Domain.Entities.Entity{System.Guid}" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Entities.Entity{System.Guid}" />
    /// <remarks>Will Wu</remarks>
    public class User : Entity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public User()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <remarks>Will Wu</remarks>
        public User(Guid id) : base(id)
        {
        }

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
        /// Gets or sets the team identifier.
        /// </summary>
        /// <value>The team identifier.</value>
        /// <remarks>Will Wu</remarks>
        public Guid TeamId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is leader.
        /// </summary>
        /// <value><c>true</c> if this instance is leader; otherwise, <c>false</c>.</value>
        /// <remarks>Will Wu</remarks>
        public bool IsLeader { get; set; }

        /// <summary>
        /// 总经费
        /// </summary>
        /// <value>The balance.</value>
        /// <remarks>Will Wu</remarks>
        public double Balance { get; set; }

        /// <summary>
        /// 是否超支
        /// </summary>
        /// <value><c>true</c> if this instance is overspend; otherwise, <c>false</c>.</value>
        /// <remarks>Will Wu</remarks>

        public bool IsOverspend { get; set; }
    }
}