// ***********************************************************************
// Assembly         : EMR.Swagger
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="EMRSwaggerModule.cs" company="EMR.Swagger">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using EMR.Domain;

using Microsoft.AspNetCore.Builder;

using Volo.Abp;
using Volo.Abp.Modularity;

/// <summary>
/// The Swagger namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Swagger
{
    /// <summary>
    /// Class EMRSwaggerModule.
    /// Implements the <see cref="Volo.Abp.Modularity.AbpModule" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Modularity.AbpModule" />
    /// <remarks>Will Wu</remarks>
    [DependsOn(
             typeof(EMRDomainModule)
         )]
    public class EMRSwaggerModule : AbpModule
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <remarks>Will Wu</remarks>
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSwagger();
        }

        /// <summary>
        /// Called when [application initialization].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <remarks>Will Wu</remarks>
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.GetApplicationBuilder().UseSwagger().UseSwaggerUI();
        }
    }
}