// ***********************************************************************
// Assembly         : EMR.HttpApi.Hosting
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="EMRExceptionFilter.cs" company="EMR.HttpApi.Hosting">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using log4net;

using Microsoft.AspNetCore.Mvc.Filters;

/// <summary>
/// The Filters namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.HttpApi.Hosting.Filters
{
    /// <summary>
    /// Class EMRExceptionFilter.
    /// Implements the <see cref="Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter" />
    /// <remarks>Will Wu</remarks>
    public class EMRExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// The log
        /// </summary>
        private readonly ILog _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="EMRExceptionFilter"/> class.
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public EMRExceptionFilter()
        {
            _log = LogManager.GetLogger(typeof(EMRExceptionFilter));
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context">The context.</param>
        /// <remarks>Will Wu</remarks>
        public void OnException(ExceptionContext context)
        {
            // 错误日志记录
            _log.Error($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}