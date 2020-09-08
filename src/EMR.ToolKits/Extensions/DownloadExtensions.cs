// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="DownloadExtensions.cs" company="EMR.ToolKits">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;
using System.Threading.Tasks;

/// <summary>
/// The Extensions namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.ToolKits.Extensions
{
    /// <summary>
    /// Class DownloadExtensions.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public static class DownloadExtensions
    {
        /// <summary>
        /// 将数组类型文件保存至指定路径
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task DownloadAsync(this byte[] buffer, string path)
        {
            using var ms = new MemoryStream(buffer);
            using var stream = new FileStream(path, FileMode.Create);

            var bytes = new byte[1024];
            var size = await ms.ReadAsync(bytes, 0, bytes.Length);
            while (size > 0)
            {
                await stream.WriteAsync(bytes, 0, size);
                size = await ms.ReadAsync(bytes, 0, bytes.Length);
            }
        }
    }
}