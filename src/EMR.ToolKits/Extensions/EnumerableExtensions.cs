// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="EnumerableExtensions.cs" company="EMR.ToolKits">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The Extensions namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.ToolKits.Extensions
{
    /// <summary>
    /// Class EnumerableExtensions.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 去重
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <returns>IEnumerable&lt;TSource&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();
            return source.Where(element => seenKeys.Add(keySelector(element)));
        }

        /// <summary>
        /// 是否有重复
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <returns><c>true</c> if the specified key selector has repeat; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool HasRepeat<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            source.ThrowIfNull();
            var seenKeys = new HashSet<TKey>();
            return source.Count(element => seenKeys.Add(keySelector(element))) != source.Count();
        }

        /// <summary>
        /// 是否有重复
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns><c>true</c> if the specified source has repeat; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool HasRepeat<TSource>(this IEnumerable<TSource> source)
        {
            source.ThrowIfNull();
            var seenKeys = new HashSet<TSource>();
            return source.Count(item => seenKeys.Add(item)) != source.Count();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public static IEnumerable<T> PageByIndex<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            query.ThrowIfNull();

            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }
            if (pageSize <= 0)
            {
                pageSize = 10;
            }
            return query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// 随机化 IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="count">The count.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source, int count = -1)
        {
            source.ThrowIfNull();

            var rnd = new Random();
            source = source.OrderBy(item => rnd.Next());
            if (count > 0)
            {
                source = source.Take(count);
            }
            return source;
        }
    }
}