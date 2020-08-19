//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.ToolKits.Base.Paged
// FileName : IPagedList
//
// Created by : Will.Wu at 2020/8/5 8:39:54
//
//
//========================================================================

namespace EMR.ToolKits.Base.Paged
{
    public interface IPagedList<T> : IListResult<T>, IHasTotalCount
    {
    }
}