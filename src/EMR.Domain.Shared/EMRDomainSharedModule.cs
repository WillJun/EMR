// ***********************************************************************
// Assembly         : EMR.Domain.Shared
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="EMRDomainSharedModule.cs" company="EMR.Domain.Shared">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Volo.Abp.Identity;
using Volo.Abp.Modularity;

/// <summary>
/// The Shared namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Domain.Shared
{
    /// <summary>
    /// Class EMRDomainSharedModule.
    /// Implements the <see cref="Volo.Abp.Modularity.AbpModule" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Modularity.AbpModule" />
    /// <remarks>Will Wu</remarks>
    [DependsOn(typeof(AbpIdentityDomainModule))]
    public class EMRDomainSharedModule : AbpModule
    {
    }
}