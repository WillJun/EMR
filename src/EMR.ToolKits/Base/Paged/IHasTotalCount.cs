// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="IHasTotalCount.cs" company="EMR.ToolKits">
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
    /// Interface IHasTotalCount
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public interface IHasTotalCount
    {
        /// <summary>
        /// 总数
        /// </summary>
        /// <value>The total.</value>
        /// <remarks>Will Wu</remarks>
        int Total { get; set; }
    }
}