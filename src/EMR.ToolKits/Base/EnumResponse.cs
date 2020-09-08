// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="EnumResponse.cs" company="EMR.ToolKits">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
/// <summary>
/// The Base namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.ToolKits.Base
{
    /// <summary>
    /// Class EnumResponse.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public class EnumResponse
    {
        /// <summary>
        /// Key
        /// </summary>
        /// <value>The key.</value>
        /// <remarks>Will Wu</remarks>
        public string Key { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        /// <value>The value.</value>
        /// <remarks>Will Wu</remarks>
        public int Value { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        /// <value>The description.</value>
        /// <remarks>Will Wu</remarks>
        public string Description { get; set; }
    }
}