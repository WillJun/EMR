// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="SerializeExtensions.cs" company="EMR.ToolKits">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
/// The Extensions namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.ToolKits.Extensions
{
    /// <summary>
    /// Class SerializeExtensions.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public static class SerializeExtensions
    {
        /// <summary>
        /// 实体对象转JSON字符串
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="ignoreNull">if set to <c>true</c> [ignore null].</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        public static string ToJson(this object obj, bool ignoreNull = false)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd HH:mm:ss",
                NullValueHandling = ignoreNull ? NullValueHandling.Ignore : NullValueHandling.Include
            });
        }

        /// <summary>
        /// JSON字符串转实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonStr">The json string.</param>
        /// <returns>T.</returns>
        /// <remarks>Will Wu</remarks>
        public static T FromJson<T>(this string jsonStr)
        {
            return jsonStr.IsNullOrEmpty() ? default : JsonConvert.DeserializeObject<T>(jsonStr);
        }

        /// <summary>
        /// 字符串序列化成字节序列
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.Byte[].</returns>
        /// <remarks>Will Wu</remarks>
        public static byte[] SerializeUtf8(this string str)
        {
            return str == null ? null : Encoding.UTF8.GetBytes(str);
        }

        /// <summary>
        /// 字节序列序列化成字符串
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        public static string DeserializeUtf8(this byte[] stream)
        {
            return stream == null ? null : Encoding.UTF8.GetString(stream);
        }

        /// <summary>
        /// 根据key将json文件内容转换为指定对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static async Task<T> FromJsonFile<T>(this string filePath, string key = "") where T : new()
        {
            if (!File.Exists(filePath)) return new T();

            using StreamReader reader = new StreamReader(filePath);
            var json = await reader.ReadToEndAsync();

            if (string.IsNullOrEmpty(key)) return JsonConvert.DeserializeObject<T>(json);

            return !(JsonConvert.DeserializeObject<object>(json) is JObject obj) ? new T() : JsonConvert.DeserializeObject<T>(obj[key].ToString());
        }
    }
}