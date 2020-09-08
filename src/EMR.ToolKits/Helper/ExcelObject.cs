// ***********************************************************************
// Assembly         : EMR.ToolKits
// Author           : WuJun
// Created          : 08-19-2020
//
// Last Modified By : WuJun
// Last Modified On : 08-19-2020
// ***********************************************************************
// <copyright file="ExcelObject.cs" company="EMR.ToolKits">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The Helper namespace.
/// </summary>
/// <remarks>Will Wu</remarks>
namespace EMR.ToolKits.Helper
{
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Text;
    /// <summary>
    /// Class ExcelObject.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <remarks>Will Wu</remarks>
    public class ExcelObject : IDisposable
    {

        /// <summary>
        /// The excel object
        /// </summary>
        private string excelObject = "Provider=Microsoft.{0}.OLEDB.{1};Data Source={2};Extended Properties=\"Excel {3};HDR=YES\"";
        /// <summary>
        /// The filepath
        /// </summary>
        private string filepath = string.Empty;
        /// <summary>
        /// The con
        /// </summary>
        private OleDbConnection con = null;

        /// <summary>
        /// Delegate ProgressWork
        /// </summary>
        /// <param name="percentage">The percentage.</param>
        /// <remarks>Will Wu</remarks>
        public delegate void ProgressWork(float percentage);
        /// <summary>
        /// Occurs when [reading].
        /// </summary>
        /// <remarks>Will Wu</remarks>
        private event ProgressWork Reading;
        /// <summary>
        /// Occurs when [writeing].
        /// </summary>
        /// <remarks>Will Wu</remarks>
        private event ProgressWork Writeing;
        /// <summary>
        /// Occurs when [connection string change].
        /// </summary>
        /// <remarks>Will Wu</remarks>
        private event EventHandler connectionStringChange;

        /// <summary>
        /// Occurs when [read progress].
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public event ProgressWork ReadProgress
        {
            add
            {
                Reading += value;
            }
            remove
            {
                Reading -= value;
            }
        }

        /// <summary>
        /// Ons the read progress.
        /// </summary>
        /// <param name="percentage">The percentage.</param>
        /// <remarks>Will Wu</remarks>
        public virtual void onReadProgress(float percentage)
        {
            if (Reading != null)
                Reading(percentage);
        }


        /// <summary>
        /// Occurs when [write progress].
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public event ProgressWork WriteProgress
        {
            add
            {


                Writeing += value;
            }
            remove
            {



                Writeing -= value;
            }
        }

        /// <summary>
        /// Ons the write progress.
        /// </summary>
        /// <param name="percentage">The percentage.</param>
        /// <remarks>Will Wu</remarks>
        public virtual void onWriteProgress(float percentage)
        {
            if (Writeing != null)
                Writeing(percentage);
        }


        /// <summary>
        /// Occurs when [connection string changed].
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public event EventHandler ConnectionStringChanged
        {
            add
            {
                connectionStringChange += value;
            }
            remove
            {

                connectionStringChange -= value;
            }
        }

        /// <summary>
        /// Ons the connection string changed.
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public virtual void onConnectionStringChanged()
        {
            if (this.Connection != null && !this.Connection.ConnectionString.Equals(this.ConnectionString))
            {
                if (this.Connection.State == ConnectionState.Open)
                    this.Connection.Close();
                this.Connection.Dispose();
                this.con = null;

            }
            if (connectionStringChange != null)
            {
                connectionStringChange(this, new EventArgs());
            }
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        /// <remarks>Will Wu</remarks>
        public string ConnectionString
        {
            get
            {
                if (!(this.filepath == string.Empty))
                {
                    //Check for File Format
                    FileInfo fi = new FileInfo(this.filepath);
                    if (fi.Extension.ToLower().Equals(".xls"))
                    {
                        return string.Format(this.excelObject, "Jet", "4.0", this.filepath, "8.0");
                    }
                    else if (fi.Extension.ToLower().Equals(".xlsx"))
                    {
                        return string.Format(this.excelObject, "Ace", "12.0", this.filepath, "12.0");
                    }
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>The connection.</value>
        /// <remarks>Will Wu</remarks>
        public OleDbConnection Connection
        {
            get
            {
                if (con == null)
                {
                    OleDbConnection _con = new OleDbConnection { ConnectionString = this.ConnectionString };
                    this.con = _con;
                }
                return this.con;
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelObject"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <remarks>Will Wu</remarks>
        public ExcelObject(string path)
        {

            this.filepath = path;
            this.onConnectionStringChanged();
        }

        /// <summary>
        /// Gets the schema.
        /// </summary>
        /// <returns>DataTable.</returns>
        /// <remarks>Will Wu</remarks>
        public DataTable GetSchema()
        {
            DataTable dtSchema = null;
            if (this.Connection.State != ConnectionState.Open) this.Connection.Open();
            dtSchema = this.Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            //sheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();//取得第一个表名

            return dtSchema;
        }


        /// <summary>
        /// Reads the table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>DataTable.</returns>
        /// <remarks>Will Wu</remarks>
        public DataTable ReadTable(string tableName)
        {
            return this.ReadTable(tableName, "");
        }


        /// <summary>
        /// Reads the table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="criteria">The criteria.</param>
        /// <returns>DataTable.</returns>
        /// <remarks>Will Wu</remarks>
        public DataTable ReadTable(string tableName, string criteria)
        {

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                {
                    this.Connection.Open();
                    onReadProgress(10);

                }
                string cmdText = "Select * from [{0}]";
                if (!string.IsNullOrEmpty(criteria))
                {
                    cmdText += " Where " + criteria;
                }
                OleDbCommand cmd = new OleDbCommand(string.Format(cmdText, tableName));
                cmd.Connection = this.Connection;
                OleDbDataAdapter adpt = new OleDbDataAdapter(cmd);
                onReadProgress(30);

                DataSet ds = new DataSet();
                onReadProgress(50);

                adpt.Fill(ds, tableName);
                onReadProgress(100);

                if (ds.Tables.Count == 1)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                //MessageBox.Show("Table Cannot be read");
                return null;
            }
        }

        /// <summary>
        /// Drops the table.
        /// </summary>
        /// <param name="tablename">The tablename.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <remarks>Will Wu</remarks>
        public bool DropTable(string tablename)
        {

            try
            {
                if (this.Connection.State != ConnectionState.Open)
                {
                    this.Connection.Open();
                    onWriteProgress(10);

                }
                string cmdText = "Drop Table [{0}]";
                using (OleDbCommand cmd = new OleDbCommand(string.Format(cmdText, tablename), this.Connection))
                {
                    onWriteProgress(30);

                    cmd.ExecuteNonQuery();
                    onWriteProgress(80);

                }
                this.Connection.Close();
                onWriteProgress(100);

                return true;
            }
            catch (Exception)
            {
                onWriteProgress(0);
                //throw ex;
                return false;
            }
        }

        /// <summary>
        /// Writes the table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="tableDefination">The table defination.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <remarks>Will Wu</remarks>
        public bool WriteTable(string tableName, Dictionary<string, string> tableDefination)
        {
            using (OleDbCommand cmd = new OleDbCommand(this.GenerateCreateTable(tableName, tableDefination), this.Connection))
            {
                if (this.Connection.State != ConnectionState.Open) this.Connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        /// <summary>
        /// Adds the new row.
        /// </summary>
        /// <param name="dr">The dr.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <remarks>Will Wu</remarks>
        public bool AddNewRow(DataRow dr)
        {

            using (OleDbCommand cmd = new OleDbCommand(this.GenerateInsertStatement(dr), this.Connection))
            {


                cmd.ExecuteNonQuery();
            }
            return true;
        }

        /// <summary>
        /// Generates Create Table Script
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="tableDefination">The table defination.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        private string GenerateCreateTable(string tableName, Dictionary<string, string> tableDefination)
        {

            StringBuilder sb = new StringBuilder();
            bool firstcol = true;
            sb.AppendFormat("CREATE TABLE [{0}](", tableName);
            firstcol = true;
            foreach (KeyValuePair<string, string> keyvalue in tableDefination)
            {
                if (!firstcol)
                {
                    sb.Append(",");
                }
                firstcol = false;
                sb.AppendFormat("[{0}] {1}", keyvalue.Key, keyvalue.Value);
            }

            sb.Append(")");
            return sb.ToString();
        }

        /// <summary>
        /// Generates the insert statement.
        /// </summary>
        /// <param name="dr">The dr.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Will Wu</remarks>
        private string GenerateInsertStatement(DataRow dr)
        {
            StringBuilder sb = new StringBuilder();
            bool firstcol = true;
            sb.AppendFormat("INSERT INTO [{0}](", dr.Table.TableName);


            foreach (DataColumn dc in dr.Table.Columns)
            {
                if (!firstcol)
                {
                    sb.Append(",");
                }
                firstcol = false;

                sb.Append(dc.Caption);
            }

            sb.Append(") VALUES(");
            firstcol = true;
            for (int i = 0; i <= dr.Table.Columns.Count - 1; i++)
            {
                if (!object.ReferenceEquals(dr.Table.Columns[i].DataType, typeof(int)))
                {
                    sb.Append("'");
                    sb.Append(dr[i].ToString().Replace("'", "''"));
                    sb.Append("'");
                }
                else
                {
                    sb.Append(dr[i].ToString().Replace("'", "''"));
                }
                if (i != dr.Table.Columns.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append(")");
            return sb.ToString();
        }



        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <remarks>Will Wu</remarks>
        public void Dispose()
        {
            if (this.con != null && this.con.State == ConnectionState.Open)
                this.con.Close();
            if (this.con != null)
                this.con.Dispose();
            this.con = null;
            this.filepath = string.Empty;
        }

        #endregion

        #region  Function add by machao

        /// <summary>
        /// Reads the first table.
        /// </summary>
        /// <returns>DataTable.</returns>
        /// <remarks>Will Wu</remarks>
        public DataTable ReadFirstTable()
        {
            return this.ReadTable(GetSchema().Rows[0]["TABLE_NAME"].ToString(), "");
        }

        /// <summary>
        /// Writes the new table.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <remarks>Will Wu</remarks>
        public void WriteNewTable(DataTable dt)
        {
            //创建表
            Dictionary<string, string> columns = new Dictionary<string, string>();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string excelType = "TEXT";
                //if (!object.ReferenceEquals(dt.Columns[i].DataType, typeof(int)))
                //{
                //    excelType = "char";
                //}
                if (object.ReferenceEquals(dt.Columns[i].DataType, typeof(System.DateTime)))
                {
                    excelType = "DATETIME";
                }
                if (object.ReferenceEquals(dt.Columns[i].DataType, typeof(System.Double)))
                {
                    excelType = "FLOAT";
                }
                columns.Add(dt.Columns[i].Caption, excelType);
            }
            WriteTable(dt.TableName, columns);

            //添加行
            string strColumns = string.Join(",", dt.Columns.Cast<DataColumn>().Select(t =>
            {
                if (t.Caption.Contains(" ")) return "[" + t.Caption + "]";
                else return t.Caption;
            }).ToArray());
            DateTime temDt;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                DataRow dr = dt.Rows[j];
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("INSERT INTO [{0}] ({1}) VALUES(", dr.Table.TableName, strColumns);
                for (int i = 0; i <= dr.Table.Columns.Count - 1; i++)
                {
                    if (object.ReferenceEquals(dr[i].GetType(), typeof(System.DBNull)))
                    {
                        sb.Append(" NULL ");
                    }
                    else if (object.ReferenceEquals(dr.Table.Columns[i].DataType, typeof(System.DateTime)))
                    {
                        temDt = Convert.ToDateTime(dr[i]);
                        if (temDt.Year >= 1900)
                        {
                            sb.Append("'" + temDt.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                        }
                        else
                        {
                            sb.Append(" NULL ");
                        }

                    }
                    else if (object.ReferenceEquals(dr.Table.Columns[i].DataType, typeof(System.Double)))
                    {
                        sb.Append(dr[i].ToString().Replace("'", "''"));
                    }
                    else if (object.ReferenceEquals(dr.Table.Columns[i].DataType, typeof(int)))
                    {
                        sb.Append(dr[i].ToString().Replace("'", "''"));
                    }
                    else
                    {
                        sb.Append("'");
                        sb.Append(dr[i].ToString().Replace("'", "''"));
                        sb.Append("'");
                    }
                    if (i != dr.Table.Columns.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                sb.Append(")");
                using (OleDbCommand cmd = new OleDbCommand(sb.ToString(), this.Connection))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
        #endregion

    }
}
