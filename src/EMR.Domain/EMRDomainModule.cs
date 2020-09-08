// ***********************************************************************
// Assembly         : EMR.Domain
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="EMRDomainModule.cs" company="EMR.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

/// <summary>
/// The Domain namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.Domain
{
    /// <summary>
    /// Class EMRDomainModule.
    /// Implements the <see cref="Volo.Abp.Modularity.AbpModule" />
    /// </summary>
    /// <seealso cref="Volo.Abp.Modularity.AbpModule" />
    /// <remarks>Will Wu</remarks>
    [DependsOn(

        typeof(AbpIdentityDomainModule)

        )]
    public class EMRDomainModule : AbpModule
    {
        /// <summary>
        /// Pres the configure services.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <remarks>Will Wu</remarks>
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            //BlogDomainObjectExtensions.Configure();
        }

        //public override void ConfigureServices(ServiceConfigurationContext context)
        //{
        //    Configure<AbpMultiTenancyOptions>(options =>
        //    {
        //        options.IsEnabled = MultiTenancyConsts.IsEnabled;
        //    });
        //}
    }
}