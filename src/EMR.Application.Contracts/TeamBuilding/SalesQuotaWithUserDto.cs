// ***********************************************************************
// Assembly         : EMR.Application.Contracts
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="SalesQuotaWithUserDto.cs" company="EMR.Application.Contracts">
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
    /// Class SalesQuotaWithUserDto.
    /// Implements the <see cref="EMR.Application.Contracts.TeamBuilding.SalesQuotaDto" />
    /// </summary>
    /// <seealso cref="EMR.Application.Contracts.TeamBuilding.SalesQuotaDto" />
    /// <remarks>Will Wu</remarks>
    public class SalesQuotaWithUserDto : SalesQuotaDto
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        /// <remarks>Will Wu</remarks>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the user account.
        /// </summary>
        /// <value>The user account.</value>
        /// <remarks>Will Wu</remarks>
        public string UserAccount { get; set; }
    }
}