﻿// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-27-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-27-2020
// ***********************************************************************
// <copyright file="NPOIHelper.cs" company="EMR.ToolKits">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using Microsoft.AspNetCore.Http;

using NPOI.SS.UserModel;

/// <summary>
/// The Helper namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.ToolKits.Helper
{
    /// <summary>
    /// Excel导入帮助类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>Will Wu</remarks>
    public class ImportExcelUtil<T> where T : new()
    {
        //合法文件扩展名
        /// <summary>
        /// The ext name
        /// </summary>
        private static List<string> extName = new List<string>() { ".xls", ".xlsx" };

        /// <summary>
        /// Inputs the excel.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <returns>List&lt;T&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public static List<T> InputExcel(IFormFile file, string sheetName = null)
        {
            //获取文件后缀名
            string type = Path.GetExtension(file.FileName);
            //判断是否导入合法文件
            if (!extName.Contains(type))
            {
                return null;
            }
            //转成为文件流
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            ms.Seek(0, SeekOrigin.Begin);
            //实例化T数组
            List<T> list = new List<T>();
            //获取数据
            list = InputExcel(ms, sheetName);
            return list;
        }

        /// <summary>
        /// Inputs the excel.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <returns>List&lt;T&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        public static List<T> InputExcel(string fileName, string sheetName = null)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }
            //根据指定路径读取文件
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //实例化T数组
            List<T> list = new List<T>();
            //获取数据
            list = InputExcel(fs, sheetName);

            return list;
        }

        /// <summary>
        /// Inputs the excel.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <returns>List&lt;T&gt;.</returns>
        /// <remarks>Will Wu</remarks>
        private static List<T> InputExcel(Stream fileStream, string sheetName = null)
        {
            //创建Excel数据结构
            IWorkbook workbook = WorkbookFactory.Create(fileStream);
            //如果有指定工作表名称
            ISheet sheet = null;
            if (!string.IsNullOrEmpty(sheetName))
            {
                sheet = workbook.GetSheet(sheetName);
                //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                if (sheet == null)
                {
                    sheet = workbook.GetSheetAt(0);
                }
            }
            else
            {
                //如果没有指定的sheetName，则尝试获取第一个sheet
                sheet = workbook.GetSheetAt(0);
            }
            //实例化T数组
            List<T> list = new List<T>();
            if (sheet != null)
            {
                //一行最后一个cell的编号 即总的列数
                IRow cellNum = sheet.GetRow(0);
                int num = cellNum.LastCellNum;
                //获取泛型对象T的所有属性
                var propertys = typeof(T).GetProperties();
                //每行转换为单个T对象
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    var obj = new T();
                    for (int j = 0; j < num; j++)
                    {
                        //没有数据的单元格都默认是null
                        ICell cell = row.GetCell(j);
                        if (cell != null)
                        {
                            var value = row.GetCell(j).ToString();
                            string str = (propertys[j].PropertyType).FullName;
                            if (str == "System.String")
                            {
                                propertys[j].SetValue(obj, value, null);
                            }
                            else if (str == "System.DateTime")
                            {
                                DateTime pdt = Convert.ToDateTime(value, CultureInfo.InvariantCulture);
                                propertys[j].SetValue(obj, pdt, null);
                            }
                            else if (str == "System.Boolean")
                            {
                                bool pb = Convert.ToBoolean(value);
                                propertys[j].SetValue(obj, pb, null);
                            }
                            else if (str == "System.Int16")
                            {
                                short pi16 = Convert.ToInt16(value);
                                propertys[j].SetValue(obj, pi16, null);
                            }
                            else if (str == "System.Int32")
                            {
                                int pi32 = Convert.ToInt32(value);
                                propertys[j].SetValue(obj, pi32, null);
                            }
                            else if (str == "System.Int64")
                            {
                                long pi64 = Convert.ToInt64(value);
                                propertys[j].SetValue(obj, pi64, null);
                            }
                            else if (str == "System.Byte")
                            {
                                byte pb = Convert.ToByte(value);
                                propertys[j].SetValue(obj, pb, null);
                            }
                            else
                            {
                                propertys[j].SetValue(obj, null, null);
                            }
                        }
                    }
                    list.Add(obj);
                }
            }
            return list;
        }
    }
}