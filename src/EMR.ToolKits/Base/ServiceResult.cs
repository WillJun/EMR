// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="ServiceResult.cs" company="EMR.ToolKits">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

using EMR.ToolKits.Base.Enum;

/// <summary>
/// The Base namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.ToolKits.Base
{
    /// <summary>
    /// 服务层响应实体
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class ServiceResult
    {
        /// <summary>
        /// 响应码
        /// </summary>
        /// <value>The code.</value>
        /// <remarks>Will Wu</remarks>
        public ServiceResultCode Code { get; set; }

        /// <summary>
        /// 响应信息
        /// </summary>
        /// <value>The message.</value>
        /// <remarks>Will Wu</remarks>
        public string Message { get; set; }

        /// <summary>
        /// 成功
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        /// <remarks>Will Wu</remarks>
        public bool Success => Code == ServiceResultCode.Succeed;

        /// <summary>
        /// 时间戳(毫秒)
        /// </summary>
        /// <value>The timestamp.</value>
        /// <remarks>Will Wu</remarks>
        public long Timestamp { get; } = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="message">The message.</param>
        /// <remarks>Will Wu</remarks>
        public void IsSuccess(string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Succeed;
        }

        /// <summary>
        /// 响应失败
        /// </summary>
        /// <param name="message">The message.</param>
        /// <remarks>Will Wu</remarks>
        public void IsFailed(string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Failed;
        }

        /// <summary>
        /// Determines whether the specified exception is failed.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <remarks>Will Wu</remarks>
        public void IsFailed(Exception exception)
        {
            Message = exception.InnerException?.StackTrace;
            Code = ServiceResultCode.Failed;
        }
    }
}