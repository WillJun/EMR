// ***********************************************************************
// Assembly         : EMR.HttpApi.Hosting
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 09-05-2020
// ***********************************************************************
// <copyright file="Startup.cs" company="EMR.HttpApi.Hosting">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// The Hosting namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.HttpApi.Hosting
{
    /// <summary>
    /// Class Startup.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <remarks>Will Wu</remarks>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<EMRHttpApiHostingModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <remarks>Will Wu</remarks>
        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
            app.UseStaticFiles();
        }
    }
}