// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="IListResult.cs" company="EMR.ToolKits">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

/// <summary>
/// The Paged namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.ToolKits.Base.Paged
{
    /// <summary>
    /// Interface IListResult
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>Will Wu</remarks>
    public interface IListResult<T>
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        /// <value>The item.</value>
        /// <remarks>Will Wu</remarks>
        IReadOnlyList<T> Item { get; set; }
    }
}