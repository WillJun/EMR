// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 09-02-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-02-2020
// ***********************************************************************
// <copyright file="TeamExpendTotalDto.cs" company="EMR.Application.Contracts">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The TeamBuilding namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Application.Contracts.TeamBuilding
{
    /// <summary>
    /// Class TeamExpendTotalDto.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class TeamExpendTotalDto
    {
        /// <summary>
        /// Gets or sets the name of the team.
        /// </summary>
        /// <value>The name of the team.</value>
        /// <remarks>Will Wu</remarks>
        public string TeamName { get; set; }
        /// <summary>
        /// Gets or sets the total expend.
        /// </summary>
        /// <value>The total expend.</value>
        /// <remarks>Will Wu</remarks>
        public double TotalExpend { get; set; }
    }
}