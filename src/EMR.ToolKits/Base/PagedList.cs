//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.ToolKits.Base
// FileName : PagedList
//
// Created by : Will.Wu at 2020/8/5 8:40:16
//
//
//========================================================================
using System.Collections.Generic;

using EMR.ToolKits.Base.Paged;

namespace EMR.ToolKits.Base
{
    /// <summary>
    /// 分页响应实体
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public class PagedList<T> : ListResult<T>, IPagedList<T>
    {
        /// <summary>
        /// 总数
        /// </summary>
        public int Total { get; set; }

        public PagedList()
        {
        }

        public PagedList(int total, IReadOnlyList<T> result) : base(result)
        {
            Total = total;
        }
    }
}