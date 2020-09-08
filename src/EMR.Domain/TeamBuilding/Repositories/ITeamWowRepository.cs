// ***********************************************************************
// Assembly         : EMR.Domain
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="ITeamWowRepository.cs" company="EMR.Domain">
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
    /// Interface ITeamWowRepository
    /// Implements the <see cref="Volo.Abp.Domain.Repositories.IRepository{EMR.Domain.TeamBuilding.TeamWow, System.Guid}" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Repositories.IRepository{EMR.Domain.TeamBuilding.TeamWow, System.Guid}" />
    /// <remarks>Will Wu</remarks>
    public interface ITeamWowRepository : IRepository<TeamWow, Guid>
    {
    }
}