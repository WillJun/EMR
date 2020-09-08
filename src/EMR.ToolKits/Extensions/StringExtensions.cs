// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="StringExtensions.cs" company="EMR.ToolKits">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// The Extensions namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.ToolKits.Extensions
{
    /// <summary>
    /// Class StringExtensions.
    /// </summary>
    /// <remarks>Will Wu</remarks>
    public static class StringExtensions
    {
        #region 空判断

        /// <summary>
        /// Determines whether [is null or empty] [the specified input string].
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <returns><c>true</c> if [is null or empty] [the specified input string]; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool IsNullOrEmpty(this string inputStr)
        {
            return string.IsNullOrEmpty(inputStr);
        }

        /// <summary>
        /// Determines whether [is null or white space] [the specified input string].
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <returns><c>true</c> if [is null or white space] [the specified input string]; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool IsNullOrWhiteSpace(this string inputStr)
        {
            return string.IsNullOrWhiteSpace(inputStr);
        }

        /// <summary>
        /// Determines whether [is not null or empty] [the specified input string].
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <returns><c>true</c> if [is not null or empty] [the specified input string]; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool IsNotNullOrEmpty(this string inputStr)
        {
            return !string.IsNullOrEmpty(inputStr);
        }

        /// <summary>
        /// Determines whether [is not null or white space] [the specified input string].
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <returns><c>true</c> if [is not null or white space] [the specified input string]; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool IsNotNullOrWhiteSpace(this string inputStr)
        {
            return !string.IsNullOrWhiteSpace(inputStr);
        }

        #endregion

        #region 常用正则表达式

        /// <summary>
        /// The email regex
        /// </summary>
        private static readonly Regex EmailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);

        /// <summary>
        /// The mobile regex
        /// </summary>
        private static readonly Regex MobileRegex = new Regex("^1[0-9]{10}$");

        /// <summary>
        /// The phone regex
        /// </summary>
        private static readonly Regex PhoneRegex = new Regex(@"^(\d{3,4}-?)?\d{7,8}$");

        /// <summary>
        /// The ip regex
        /// </summary>
        private static readonly Regex IpRegex = new Regex(@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");

        /// <summary>
        /// The date regex
        /// </summary>
        private static readonly Regex DateRegex = new Regex(@"(\d{4})-(\d{1,2})-(\d{1,2})");

        /// <summary>
        /// The numeric regex
        /// </summary>
        private static readonly Regex NumericRegex = new Regex(@"^[-]?[0-9]+(\.[0-9]+)?$");

        /// <summary>
        /// The zipcode regex
        /// </summary>
        private static readonly Regex ZipcodeRegex = new Regex(@"^\d{6}$");

        /// <summary>
        /// The identifier regex
        /// </summary>
        private static readonly Regex IdRegex = new Regex(@"^[1-9]\d{16}[\dXx]$");

        /// <summary>
        /// 是否中文
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns><c>true</c> if the specified string is chinese; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool IsChinese(this string str)
        {
            return Regex.IsMatch(@"^[\u4e00-\u9fa5]+$", str);
        }

        /// <summary>
        /// 是否为邮箱名
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns><c>true</c> if the specified s is email; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool IsEmail(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            return EmailRegex.IsMatch(s);
        }

        /// <summary>
        /// 是否为手机号
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns><c>true</c> if the specified s is mobile; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool IsMobile(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            return MobileRegex.IsMatch(s);
        }

        /// <summary>
        /// 是否为固话号
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns><c>true</c> if the specified s is phone; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool IsPhone(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            return PhoneRegex.IsMatch(s);
        }

        /// <summary>
        /// 是否为IP
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns><c>true</c> if the specified s is ip; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool IsIp(this string s)
        {
            return IpRegex.IsMatch(s);
        }

        /// <summary>
        /// 是否是身份证号
        /// </summary>
        /// <param name="idCard">The identifier card.</param>
        /// <returns><c>true</c> if [is identifier card] [the specified identifier card]; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool IsIdCard(this string idCard)
        {
            if (string.IsNullOrEmpty(idCard))
                return false;
            return IdRegex.IsMatch(idCard);
        }

        /// <summary>
        /// 是否为日期
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns><c>true</c> if the specified s is date; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool IsDate(this string s)
        {
            return DateRegex.IsMatch(s);
        }

        /// <summary>
        /// 是否是数值(包括整数和小数)
        /// </summary>
        /// <param name="numericStr">The numeric string.</param>
        /// <returns><c>true</c> if the specified numeric string is numeric; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool IsNumeric(this string numericStr)
        {
            return NumericRegex.IsMatch(numericStr);
        }

        /// <summary>
        /// 是否为邮政编码
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns><c>true</c> if [is zip code] [the specified s]; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool IsZipCode(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;
            return ZipcodeRegex.IsMatch(s);
        }

        /// <summary>
        /// 是否是图片文件名
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns><c>true</c> if [is img file name] [the specified file name]; otherwise, <c>false</c>.</returns>
        /// <remarks>Will Wu</remarks>
        public static bool IsImgFileName(this string fileName)
        {
            var suffix = new List<string>() { ".jpg", ".jpeg", ".png" };

            var fileSuffix = Path.GetExtension(fileName).ToLower();

            return suffix.Contains(fileSuffix);
        }

        #endregion

        #region 字符串截取

        /// <summary>
        /// Subs the specified length.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        public static string Sub(this string inputStr, int length)
        {
            if (inputStr.IsNullOrEmpty())
                return null;

            return inputStr.Length >= length ? inputStr.Substring(0, length) : inputStr;
        }

        /// <summary>
        /// Tries the replace.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="oldStr">The old string.</param>
        /// <param name="newStr">The new string.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        public static string TryReplace(this string inputStr, string oldStr, string newStr)
        {
            return inputStr.IsNullOrEmpty() ? inputStr : inputStr.Replace(oldStr, newStr);
        }

        /// <summary>
        /// Regexes the replace.
        /// </summary>
        /// <param name="inputStr">The input string.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="replacement">The replacement.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        public static string RegexReplace(this string inputStr, string pattern, string replacement)
        {
            return inputStr.IsNullOrEmpty() ? inputStr : Regex.Replace(inputStr, pattern, replacement);
        }

        #endregion

        #region Format

        /// <summary>
        /// Format
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        public static string Format(this string format, object arg0, object arg1)
        {
            return string.Format(format, arg0, arg1);
        }

        /// <summary>
        /// Format
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        public static string Format(this string format, object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// Format
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        public static string Format(this string format, object arg0, object arg1, object arg2)
        {
            return string.Format(format, arg0, arg1, arg2);
        }

        /// <summary>
        /// Format
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg0">The arg0.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        public static string Format(this string format, object arg0)
        {
            return string.Format(format, arg0);
        }

        /// <summary>
        /// FormatWith
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="values">The values.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        public static string FormatWith(this string @this, params object[] values)
        {
            return string.Format(@this, values);
        }

        /// <summary>
        /// FormatWith
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        public static string FormatWith(this string @this, object arg0, object arg1, object arg2)
        {
            return string.Format(@this, arg0, arg1, arg2);
        }

        /// <summary>
        /// FormatWith
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="arg0">The arg0.</param>
        /// <param name="arg1">The arg1.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        public static string FormatWith(this string @this, object arg0, object arg1)
        {
            return string.Format(@this, arg0, arg1);
        }

        /// <summary>
        /// FormatWith
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="arg0">The arg0.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        public static string FormatWith(this string @this, object arg0)
        {
            return string.Format(@this, arg0);
        }

        #endregion
    }
}