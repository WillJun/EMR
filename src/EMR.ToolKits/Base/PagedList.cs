// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="PagedList.cs" company="EMR.ToolKits">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

using EMR.ToolKits.Base.Paged;

/// <summary>
/// The Base namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.ToolKits.Base
{
    /// <summary>
    /// 分页响应实体
    /// Implements the <see cref="EMR.ToolKits.Base.Paged.ListResult{T}" />
    /// Implements the <see cref="EMR.ToolKits.Base.Paged.IPagedList{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="EMR.ToolKits.Base.Paged.ListResult{T}" />
    /// <seealso cref="EMR.ToolKits.Base.Paged.IPagedList{T}" />
    /// <remarks>Will Wu</remarks>
    public class PagedList<T> : ListResult<T>, IPagedList<T>
    {
        /// <summary>
        /// 总数
        /// </summary>
        /// <value>The total.</value>
        /// <remarks>Will Wu</remarks>
        public int Total { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public PagedList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        /// <param name="total">The total.</param>
        /// <param name="result">The result.</param>
        /// <remarks>Will Wu</remarks>
        public PagedList(int total, IReadOnlyList<T> result) : base(result)
        {
            Total = total;
        }
    }
}