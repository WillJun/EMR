// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="TeamSalesQuotaTotalDto.cs" company="EMR.Application.Contracts">
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
    /// Class TeamSalesQuotaTotalDto.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class TeamSalesQuotaTotalDto
    {
        /// <summary>
        /// Gets or sets the name of the team.
        /// </summary>
        /// <value>The name of the team.</value>
        /// <remarks>Will Wu</remarks>
        public string TeamName { get; set; }
        /// <summary>
        /// Gets or sets the total income.
        /// </summary>
        /// <value>The total income.</value>
        /// <remarks>Will Wu</remarks>
        public double TotalIncome { get; set; }
    }
}