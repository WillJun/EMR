// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="ServiceResultOfT.cs" company="EMR.ToolKits">
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
    /// 服务层响应实体(泛型)
    /// Implements the <see cref="EMR.ToolKits.Base.ServiceResult" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="EMR.ToolKits.Base.ServiceResult" />
    /// <remarks>Will Wu</remarks>
    public class ServiceResult<T> : ServiceResult where T : class
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        /// <value>The result.</value>
        /// <remarks>Will Wu</remarks>
        public T Result { get; set; }

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="message">The message.</param>
        /// <remarks>Will Wu</remarks>
        public void IsSuccess(T result = null, string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Succeed;
            Result = result;
        }

        /// <summary>
        /// Determines whether the specified p is failed.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <remarks>Will Wu</remarks>
        public void IsFailed(object p)
        {
            throw new NotImplementedException();
        }
    }
}