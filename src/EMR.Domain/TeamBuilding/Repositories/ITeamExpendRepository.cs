// ***********************************************************************
// Assembly         : EMR.Domain
// Author           : WuJun
// Created          : 09-02-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-02-2020
// ***********************************************************************
// <copyright file="ITeamExpendRepository.cs" company="EMR.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

using Volo.Abp.Domain.Repositories;

/// <summary>
/// The Repositories namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Domain.TeamBuilding.Repositories
{
    /// <summary>
    /// Interface ITeamExpendRepository
    /// Implements the <see cref="Volo.Abp.Domain.Repositories.IRepository{EMR.Domain.TeamBuilding.TeamExpend, System.Guid}" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Repositories.IRepository{EMR.Domain.TeamBuilding.TeamExpend, System.Guid}" />
    /// <remarks>Will Wu</remarks>
    public interface ITeamExpendRepository : IRepository<TeamExpend, Guid>
    {
    }
}