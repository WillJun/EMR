// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="Log4NetExtensions.cs" company="EMR.ToolKits">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;
using System.Reflection;

using log4net;
using log4net.Config;

using Microsoft.Extensions.Hosting;

/// <summary>
/// The Extensions namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.ToolKits.Extensions
{
    /// <summary>
    /// Class Log4NetExtensions.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public static class Log4NetExtensions
    {
        /// <summary>
        /// Uses the log4 net.
        /// </summary>
        /// <param name="hostBuilder">The host builder.</param>
        /// <returns>IHostBuilder.</returns>
        /// <remarks>Will Wu</remarks>
        public static IHostBuilder UseLog4Net(this IHostBuilder hostBuilder)
        {
            var log4netRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(log4netRepository, new FileInfo("Resources/log4net.config"));

            return hostBuilder;
        }
    }
}