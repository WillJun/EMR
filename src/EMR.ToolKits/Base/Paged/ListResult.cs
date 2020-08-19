//========================================================================
// Copyright(C): Emerson AFTC
//
// CLR Version : 4.0.30319.42000
// NameSpace : EMR.ToolKits.Base.Paged
// FileName : ListResult
//
// Created by : Will.Wu at 2020/8/5 8:38:52
//
//
//========================================================================
using System.Collections.Generic;

namespace EMR.ToolKits.Base.Paged
{
    public class ListResult<T> : IListResult<T>
    {
        private IReadOnlyList<T> item;

        public IReadOnlyList<T> Item
        {
            get => item ?? (item = new List<T>());
            set => item = value;
        }

        public ListResult()
        {
        }

        public ListResult(IReadOnlyList<T> item)
        {
            Item = item;
        }
    }
}