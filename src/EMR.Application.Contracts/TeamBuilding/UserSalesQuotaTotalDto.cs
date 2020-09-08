// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="UserSalesQuotaTotalDto.cs" company="EMR.Application.Contracts">
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
    /// Class UserSalesQuotaTotalDto.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class UserSalesQuotaTotalDto
    {
        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>The account.</value>
        /// <remarks>Will Wu</remarks>
        public string Account { get; set; }
        /// <summary>
        /// Gets or sets the total income.
        /// </summary>
        /// <value>The total income.</value>
        /// <remarks>Will Wu</remarks>
        public double TotalIncome { get; set; }
    }
}