// ***********************************************************************
// Assembly         : EMR.Domain
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="PersonalExpenditure.cs" company="EMR.Domain">
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
    /// Class PersonalExpenditure.
    /// Implements the <see cref="Volo.Abp.Domain.Entities.Entity{System.Guid}" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Entities.Entity{System.Guid}" />
    /// <remarks>Will Wu</remarks>
    public class PersonalExpenditure : Entity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalExpenditure"/> class.
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public PersonalExpenditure()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalExpenditure"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <remarks>Will Wu</remarks>
        public PersonalExpenditure(Guid id) : base(id)
        {
        }

        /// <summary>
        /// Gets or sets the expenditure team identifier.
        /// </summary>
        /// <value>The expenditure team identifier.</value>
        /// <remarks>Will Wu</remarks>
        public Guid ExpenditureTeamId { get; set; }
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        /// <remarks>Will Wu</remarks>
        public Guid UserId { get; set; }
        /// <summary>
        /// Gets or sets the expend.
        /// </summary>
        /// <value>The expend.</value>
        /// <remarks>Will Wu</remarks>
        public double Expend { get; set; }

        /// <summary>
        /// 流水号
        /// </summary>
        /// <value>The serial number.</value>
        /// <remarks>Will Wu</remarks>
        public string SerialNumber { get; set; }

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