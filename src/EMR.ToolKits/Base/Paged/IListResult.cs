//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.ToolKits.Base.Paged
// FileName : IListResult
//
// Created by : Will.Wu at 2020/8/5 8:37:48
//
//
//========================================================================
using System.Collections.Generic;

namespace EMR.ToolKits.Base.Paged
{
    public interface IListResult<T>
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        IReadOnlyList<T> Item { get; set; }
    }
}