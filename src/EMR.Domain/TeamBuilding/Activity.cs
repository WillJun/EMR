// ***********************************************************************
// Assembly         : EMR.Domain
// Author           : WuJun
// Created          : 09-08-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="Activity.cs" company="EMR.Domain">
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
    /// Class Activity.
    /// Implements the <see cref="Volo.Abp.Domain.Entities.Entity{System.Guid}" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Entities.Entity{System.Guid}" />
    /// <remarks>Will Wu</remarks>
    public class Activity : Entity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Activity"/> class.
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public Activity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Activity"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <remarks>Will Wu</remarks>
        public Activity(Guid id) : base(id)
        {
        }

        /// <summary>
        /// Gets or sets the name of the activity.
        /// </summary>
        /// <value>The name of the activity.</value>
        /// <remarks>Will Wu</remarks>
        public string ActivityName { get; set; }
        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        /// <remarks>Will Wu</remarks>
        public DateTime? Start_Time { get; set; }

        /// <summary>
        /// Gets or sets the finish time.
        /// </summary>
        /// <value>The finish time.</value>
        /// <remarks>Will Wu</remarks>
        public DateTime? Finish_Time { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is start.
        /// </summary>
        /// <value><c>true</c> if this instance is start; otherwise, <c>false</c>.</value>
        /// <remarks>Will Wu</remarks>
        public bool IsStart { get; set; }
    }
}