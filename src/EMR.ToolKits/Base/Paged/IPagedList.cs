// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="IPagedList.cs" company="EMR.ToolKits">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The Paged namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.ToolKits.Base.Paged
{
    /// <summary>
    /// Interface IPagedList
    /// Implements the <see cref="EMR.ToolKits.Base.Paged.IListResult{T}" />
    /// Implements the <see cref="EMR.ToolKits.Base.Paged.IHasTotalCount" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="EMR.ToolKits.Base.Paged.IListResult{T}" />
    /// <seealso cref="EMR.ToolKits.Base.Paged.IHasTotalCount" />
    /// <remarks>Will Wu</remarks>
    public interface IPagedList<T> : IListResult<T>, IHasTotalCount
    {
    }
}