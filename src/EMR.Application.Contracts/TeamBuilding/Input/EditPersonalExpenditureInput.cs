// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="EditPersonalExpenditureInput.cs" company="EMR.Application.Contracts">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

/// <summary>
/// The Input namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Application.Contracts.TeamBuilding.Input
{
    /// <summary>
    /// Class EditPersonalExpenditureInput.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class EditPersonalExpenditureInput
    {
        /// <summary>
        /// Gets or sets the id of the expenditure.
        /// </summary>
        /// <value>The id of the expenditure.</value>
        /// <remarks>Will Wu</remarks>
        public Guid ExpenditureTeamId { get; set; }

        /// <summary>
        /// Gets or sets the id of the expenditure.
        /// </summary>
        /// <value>The id of the expenditure.</value>
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