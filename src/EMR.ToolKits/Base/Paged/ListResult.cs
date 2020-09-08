// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="ListResult.cs" company="EMR.ToolKits">
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
    /// Class ListResult.
    /// Implements the <see cref="EMR.ToolKits.Base.Paged.IListResult{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="EMR.ToolKits.Base.Paged.IListResult{T}" />
    /// <remarks>Will Wu</remarks>
    public class ListResult<T> : IListResult<T>
    {
        /// <summary>
        /// The item
        /// </summary>
        private IReadOnlyList<T> item;

        /// <summary>
        /// 返回结果
        /// </summary>
        /// <value>The item.</value>
        /// <remarks>Will Wu</remarks>
        public IReadOnlyList<T> Item
        {
            get => item ?? (item = new List<T>());
            set => item = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListResult{T}"/> class.
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public ListResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListResult{T}"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <remarks>Will Wu</remarks>
        public ListResult(IReadOnlyList<T> item)
        {
            Item = item;
        }
    }
}