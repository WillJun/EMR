// ***********************************************************************
// Assembly         : EMR.EntityFrameworkCore
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="PersonalExpenditureRepository.cs" company="EMR.EntityFrameworkCore">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

using EMR.Domain.TeamBuilding;
using EMR.Domain.TeamBuilding.Repositories;

using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

/// <summary>
/// The TeamBuilding namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.EntityFrameworkCore.Repositories.TeamBuilding
{
    /// <summary>
    /// Class PersonalExpenditureRepository.
    /// Implements the <see cref="Volo.Abp.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{EMR.EntityFrameworkCore.EMRDbContext, EMR.Domain.TeamBuilding.PersonalExpenditure, System.Guid}" />
    /// Implements the <see cref="EMR.Domain.TeamBuilding.Repositories.IPersonalExpenditureRepository" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Domain.Repositories.EntityFrameworkCore.EfCoreRepository{EMR.EntityFrameworkCore.EMRDbContext, EMR.Domain.TeamBuilding.PersonalExpenditure, System.Guid}" />
    /// <seealso cref="EMR.Domain.TeamBuilding.Repositories.IPersonalExpenditureRepository" />
    /// <remarks>Will Wu</remarks>
    public class PersonalExpenditureRepository : EfCoreRepository<EMRDbContext, PersonalExpenditure, Guid>, IPersonalExpenditureRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonalExpenditureRepository"/> class.
        /// </summary>
        /// <param name="dbContextProvider">The database context provider.</param>
        /// <remarks>Will Wu</remarks>
        public PersonalExpenditureRepository(IDbContextProvider<EMRDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}