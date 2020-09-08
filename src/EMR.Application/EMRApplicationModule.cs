// ***********************************************************************
// Assembly         : EMR.Application
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-08-2020
// ***********************************************************************
// <copyright file="EMRApplicationModule.cs" company="EMR.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

/// <summary>
/// The Application namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Application
{

    /// <summary>
    /// Class EMRApplicationModule.
    /// Implements the <see cref="Volo.Abp.Modularity.AbpModule" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Modularity.AbpModule" />
    /// <remarks>Will Wu</remarks>
    [DependsOn(
       typeof(AbpIdentityApplicationModule), typeof(AbpAutoMapperModule)
   )]
    public class EMRApplicationModule : AbpModule
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <remarks>Will Wu</remarks>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<EMRApplicationModule>();
            });
        }
    }
}
