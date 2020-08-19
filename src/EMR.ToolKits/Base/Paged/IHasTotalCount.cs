//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.ToolKits.Base.Paged
// FileName : IHasTotalCount
//
// Created by : Will.Wu at 2020/8/5 8:37:22
//
//
//========================================================================

namespace EMR.ToolKits.Base.Paged
{
    public interface IHasTotalCount
    {
        /// <summary>
        /// 总数
        /// </summary>
        int Total { get; set; }
    }
}