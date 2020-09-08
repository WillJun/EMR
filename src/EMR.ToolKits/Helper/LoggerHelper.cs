// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="LoggerHelper.cs" company="EMR.ToolKits">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;

using log4net;
using log4net.Config;
using log4net.Repository;

/// <summary>
/// The Helper namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.ToolKits.Helper
{
    /// <summary>
    /// Class LoggerHelper.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public static class LoggerHelper
    {
        /// <summary>
        /// The repository
        /// </summary>
        private static readonly ILoggerRepository Repository = LogManager.CreateRepository("NETCoreRepository");
        /// <summary>
        /// The log
        /// </summary>
        private static readonly ILog Log = LogManager.GetLogger(Repository.Name, "NETCorelog4net");

        /// <summary>
        /// Initializes static members of the <see cref="LoggerHelper"/> class.
        /// </summary>
        /// <remarks>Will Wu</remarks>
        static LoggerHelper()
        {
            XmlConfigurator.Configure(Repository, new FileInfo("log4net.config"));
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">The message.</param>
        /// <remarks>Will Wu</remarks>
        public static void WriteToFile(string message)
        {
            Log.Info(message);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        /// <remarks>Will Wu</remarks>
        public static void WriteToFile(string message, Exception ex)
        {
            if (string.IsNullOrEmpty(message))
                message = ex.Message;

            Log.Error(message, ex);
        }
    }
}