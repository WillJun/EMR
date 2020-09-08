// ***********************************************************************
// Assembly         : EMR.HttpApi
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="EMRHttpApiModule.cs" company="EMR.HttpApi">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using EMR.Application;

using Volo.Abp.Identity;
using Volo.Abp.Modularity;

/// <summary>
/// The HttpApi namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.HttpApi
{
    /// <summary>
    /// Class EMRHttpApiModule.
    /// Implements the <see cref="Volo.Abp.Modularity.AbpModule" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Modularity.AbpModule" />
    /// <remarks>Will Wu</remarks>
    [DependsOn(

        typeof(AbpIdentityHttpApiModule),

         typeof(EMRApplicationModule)
        )]
    public class EMRHttpApiModule : AbpModule
    {
    }
}
