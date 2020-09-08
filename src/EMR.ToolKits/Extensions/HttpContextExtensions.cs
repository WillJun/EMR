// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="HttpContextExtensions.cs" company="EMR.ToolKits">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;

using Microsoft.AspNetCore.Http;

/// <summary>
/// The Extensions namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.ToolKits.Extensions
{
    /// <summary>
    /// Class HttpContextExtensions.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public static class HttpContextExtensions
    {
        /// <summary>
        /// 获取客户端Ip
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        public static string GetClientIp(this HttpRequest request)
        {
            var ip = request.Headers["X-Real-IP"].FirstOrDefault() ??
                     request.Headers["X-Forwarded-For"].FirstOrDefault() ??
                     request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            return ip;
        }
    }
}