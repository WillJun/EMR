// ***********************************************************************
// Assembly         : EMR.HttpApi.Hosting
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="ExceptionHandlerMiddleware.cs" company="EMR.HttpApi.Hosting">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Net;
using System.Threading.Tasks;

using EMR.ToolKits.Base;
using EMR.ToolKits.Extensions;

using Microsoft.AspNetCore.Http;

/// <summary>
/// The Middleware namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.HttpApi.Hosting.Middleware
{
    /// <summary>
    /// Class ExceptionHandlerMiddleware.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class ExceptionHandlerMiddleware
    {
        /// <summary>
        /// The next
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandlerMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <remarks>Will Wu</remarks>
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await ExceptionHandlerAsync(context, ex.Message);
            }
            finally
            {
                var statusCode = context.Response.StatusCode;
                if (statusCode != StatusCodes.Status200OK)
                {
                    Enum.TryParse(typeof(HttpStatusCode), statusCode.ToString(), out object message);
                    await ExceptionHandlerAsync(context, message.ToString());
                }
            }
        }

        /// <summary>
        /// 异常处理，返回JSON
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="message">The message.</param>
        /// <returns>Task.</returns>
        /// <remarks>Will Wu</remarks>
        private async Task ExceptionHandlerAsync(HttpContext context, string message)
        {
            context.Response.ContentType = "application/json;charset=utf-8";

            var result = new ServiceResult();
            result.IsFailed(message);

            await context.Response.WriteAsync(result.ToJson());
        }
    }
}