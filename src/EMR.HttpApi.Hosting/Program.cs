// ***********************************************************************
// Assembly         : EMR.HttpApi.Hosting
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="Program.cs" company="EMR.HttpApi.Hosting">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;

using EMR.ToolKits.Extensions;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using Serilog;

/// <summary>
/// The Hosting namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.HttpApi.Hosting
{
    /// <summary>
    /// Class Program.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args).UseLog4Net()
                       .ConfigureWebHostDefaults(builder =>
                       {
                           builder.UseIISIntegration()
                                  .UseStartup<Startup>();
                       }).UseAutofac().Build().RunAsync();
        }

        /// <summary>
        /// Creates the host builder.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>IHostBuilder.</returns>
        /// <remarks>Will Wu</remarks>
        internal static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseStartup<Startup>();
              })
              .UseAutofac()
              .UseSerilog();
    }
}