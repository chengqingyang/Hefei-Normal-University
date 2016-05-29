using System;
using System.Collections.Generic;

using System.Text;

using MicroSoft.EnterpriseLibrary.Data;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
namespace System.DAL
{
    public class CommonDAL
    {
        /// <summary>
        /// 通用删除方法
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="keycode">主键字段</param>
        /// <param name="keyvalue">值</param>
        /// <returns>-1：表示删除异常</returns>
        public static int ObjectDel(string tablename, string keycode, string keyvalue)
        {
            int result = -1;
            try
            {
                string sqlstr = "delete from " + tablename + " where " + keycode + "='" + keyvalue + "'";
                result = SqlDataProvider.ExecuteBySql(sqlstr);
            }
            catch
            { }
            return result;
        }
        /// <summary>
        /// 通用删除方法--标记删除
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="keycode">主键字段</param>
        /// <param name="keyvalue">值</param>
        /// <param name="flag">表示标记删除(建议取false表示假删除)</param>
        /// <returns>-1：表示删除异常</returns>
        public static int ObjectDel(string tablename, string keycode, string keyvalue,bool flag)
        {
            int result = -1;
            try
            {
                string sqlstr = "update " + tablename + " set jlzt=1 where " + keycode + "='" + keyvalue + "'";
                result = SqlDataProvider.ExecuteBySql(sqlstr);
            }
            catch
            { }
            return result;
        }

        /// <summary>
        /// 通用删除方法
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="keycode">主键字段</param>
        /// <param name="keyvalue">值</param>
        /// <returns>-1：表示删除异常</returns>
        public static int ObjectDel(string tablename, string keycode, int keyvalue)
        {
            int result = -1;
            try
            {
                string sqlstr = "delete from " + tablename + " where " + keycode + "=" + keyvalue;
                result = SqlDataProvider.ExecuteBySql(sqlstr);
            }
            catch
            { }
            return result;
        }

        /// <summary>
        /// 通用查找对象是否存在方法
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="rearch"></param>
        /// <returns></returns>
        public static int ObjectExists(string tablename,string rearch)
        {
            int result = -1;
            string sqlstr = "select count(1) from " + tablename + " where 1=1 " + rearch;
            object obj = SqlDataProvider.GetScalarBySql(sqlstr);
            try
            {
                result = int.Parse(obj.ToString());
            }
            catch
            { 
            }
            return result;
        }

        /// <summary>
        /// 通用保存下拉列表框方法
        /// </summary>
        /// <param name="ddl">下拉控件</param>
        /// <param name="dt">数据源</param>
        /// <param name="text">显示值</param>
        /// <param name="key">value值</param>
        public static void BindDropControl(DropDownList ddl,DataSet ds,string text,string key)
        {
            ddl.DataSource = ds;
            ddl.DataTextField = text;
            ddl.DataValueField = key;
            ddl.DataBind();
        }

        /// <summary>
        /// 通用保存下拉列表框方法
        /// </summary>
        /// <param name="ddl">下拉控件</param>
        /// <param name="dt">数据源</param>
        /// <param name="text">显示值</param>
        /// <param name="key">value值</param>
        /// <param name="init">初始化值</param>
        public static void BindDropControl(DropDownList ddl,DataSet ds,string text,string key,string init)
        {
            ddl.DataSource = ds;
            ddl.DataTextField = text;
            ddl.DataValueField = key;
            ddl.DataBind();

            ddl.DataSource = null;
            ddl.Items.Insert(0, new ListItem(init, ""));
        }

        public static void BindDropControl(DropDownList ddl, DataTable dt, string text, string key, string init)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = text;
            ddl.DataValueField = key;
            ddl.DataBind();

            ddl.DataSource = null;
            ddl.Items.Insert(0, new ListItem(init, ""));
        }

        public static void BindDropControl(DropDownList ddl, string init, string keycode)
        {
            DataSet ds = null;
            try
            {
                ds = SqlDataProvider.GetResultBySql("select * from SYS_DATA where topiccode=@topiccode order by itemcode", SqlDataProvider.CreateSqlParameter("@topiccode", SqlDbType.VarChar, keycode));
            }
            catch
            { }
            ddl.DataSource = ds;
            ddl.DataTextField = "itemname";
            ddl.DataValueField = "itemcode";
            ddl.DataBind();

            ddl.DataSource = null;
            ddl.Items.Insert(0, new ListItem(init, ""));
        }

        public static void BindDept(DropDownList ddl)
        {
            DataSet ds = null;
            try
            {
                ds = SqlDataProvider.GetResultBySql("select deptcode,deptname from SYS_DEPTMENT");
            }
            catch
            { }
            ddl.DataSource = ds;
            ddl.DataTextField = "deptname";
            ddl.DataValueField = "deptcode";
            ddl.DataBind();

            ddl.DataSource = null;
            ddl.Items.Insert(0, new ListItem("请选择部门", ""));
        }

        public static void BindOrgan(DropDownList ddl)
        {
            DataSet ds = null;
            try
            {
                ds = SqlDataProvider.GetResultBySql("select code,organame from SYS_ORGANIZATION");
            }
            catch
            { }
            ddl.DataSource = ds;
            ddl.DataTextField = "organame";
            ddl.DataValueField = "code";
            ddl.DataBind();

            ddl.DataSource = null;
            ddl.Items.Insert(0, new ListItem("请选择机构", ""));
        }

        public static DataSet GetRoleList()
        {
            return SqlDataProvider.GetResultBySql("select lsh,rolename from SYS_ROLE order by lsh");
        }

        /// <summary>
        /// 筛选dt(dtFf = new JhmyYwgl().GetNewDataTable(dtMain, "JZZT=3", ""))
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="condition"></param>
        /// <param name="sortstr"></param>
        /// <returns></returns>
        public static DataTable GetNewDataTable(DataTable dt, string condition, string sortstr)
        {
            try
            {
                DataTable newdt = new DataTable();
                newdt = dt.Clone();
                DataRow[] dr = dt.Select(condition, sortstr);
                for (int i = 0; i < dr.Length; i++)
                {
                    newdt.ImportRow((DataRow)dr[i]);
                }
                return newdt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取指定字段名以及对应值的datatable
        /// </summary>
        /// <param name="tableName">数据库表名</param>
        /// <param name="keyCode">字段名</param>
        /// <param name="keyValue">字段值</param>
        /// <returns></returns>
        public static DataTable GetObjList(string tableName,string keyCode,string keyValue)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * from ");
            sb.AppendLine(tableName);
            sb.AppendLine("where ");
            sb.AppendLine(keyCode);
            sb.AppendLine("=");
            sb.AppendLine(keyValue);
            DataTable ResultDt = null;
            try
            {
                ResultDt = SqlDataProvider.GetResultBySql(sb.ToString()).Tables[0];
            }
            catch
            { }
            return ResultDt;
        }

        /// <summary>
        /// 获取指定字段名以及对应值的datatable
        /// </summary>
        /// <param name="tableName">数据库表名</param>
        /// <param name="keyCode">字段名</param>
        /// <param name="keyValue">字段值</param>
        /// <returns></returns>
        public static DataTable GetObjList(string tableName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * from ");
            sb.AppendLine(tableName);
            sb.AppendLine(" where jlzt='0'");
            DataTable ResultDt = null;
            try
            {
                ResultDt = SqlDataProvider.GetResultBySql(sb.ToString()).Tables[0];
            }
            catch
            { }
            return ResultDt;
        }

        /// <summary>
        /// 获取指定字段名以及对应值的datatable
        /// </summary>
        /// <param name="tableName">数据库表名</param>
        /// <param name="keyCode">字段名</param>
        /// <param name="keyValue">字段值</param>
        /// <returns></returns>
        public static DataTable GetObjList(string tableName,string order)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * from ");
            sb.AppendLine(tableName);
            sb.AppendLine(" where jlzt=0");
            sb.AppendLine(" order by " + order);
            DataTable ResultDt = null;
            try
            {
                ResultDt = SqlDataProvider.GetResultBySql(sb.ToString()).Tables[0];
            }
            catch
            { }
            return ResultDt;
        }

        /// <summary>
        /// 解压ZIP文件包
        /// </summary>
        /// <param name="strZipFile">ZIP文件路径</param>
        /// <param name="strDir">解压后的文件目录路径</param>
        /// <returns>是否解压成功</returns>
        public static bool UnZipFiles(string strZipFile, string strDir)
        {
            //判断ZIP文件是否存在
            if (File.Exists(strZipFile))
            {
                //获得ZIP数据流
                ZipInputStream zipStream = new ZipInputStream(File.OpenRead(strZipFile));
                if (zipStream != null)
                {
                    try
                    {
                        ZipEntry zipEntry = null;
                        while ((zipEntry = zipStream.GetNextEntry()) != null)
                        {
                            string strUnzipFile = strDir + "\\" + zipEntry.Name;
                            string strFileName = Path.GetFileName(strUnzipFile);
                            string strDirName = Path.GetDirectoryName(strUnzipFile);

                            //是否为解压目录
                            if (!string.IsNullOrEmpty(strDirName))
                                Directory.CreateDirectory(strDirName);

                            //是否为解压文件
                            if (!string.IsNullOrEmpty(strFileName))
                            {
                                //解压文件
                                FileStream unzipFileStream = new FileStream(strUnzipFile, FileMode.Create);
                                if (unzipFileStream != null)
                                {
                                    byte[] buf = new byte[2048];
                                    int size = 0;
                                    while ((size = zipStream.Read(buf, 0, 2048)) > 0)
                                        unzipFileStream.Write(buf, 0, size);
                                    //关闭Stream
                                    unzipFileStream.Flush();
                                    unzipFileStream.Close();
                                }
                            }
                        }
                        //关闭ZIP流
                        zipStream.Close();
                        //返回值
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 通用分页
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="getFields">返回列名，全部返回用*号</param>
        /// <param name="getFields">排序字段名</param>
        /// <param name="pageindex">显示的页号</param>
        /// <param name="pagesize">每页显示的记录数</param>
        /// <param name="strWhere">查询条件，不要带where</param>
        /// <returns></returns>
        public static DataSet CommonPageList(string tablename,string getFields,string orderName,int pageindex,int pagesize,string strWhere,ref int totalNum)
        {
            DataSet dsResult = null;
            totalNum = 0;
            if (string.IsNullOrEmpty(getFields))
            {
                getFields = "*";
            }
            try
            {
                dsResult = SqlDataProvider.GetResultByProc("usp_Publish_ShowPage", tablename, getFields, orderName, pageindex, pagesize, strWhere);
                totalNum = int.Parse(dsResult.Tables[1].Rows[0][0].ToString());
            }
            catch
            {
            }
            return dsResult;
        }

        public static string GetEmpName(string empcode)
        {
            string result = string.Empty;
            try
            {
                DataSet ds = SqlDataProvider.GetResultBySql("select empname from SYS_EMPLOYEE where code=@code",
                    SqlDataProvider.CreateSqlParameter("@code", SqlDbType.VarChar, empcode));
                result = ds.Tables[0].Rows[0][0].ToString();
            }
            catch
            { }
            return result;
        }

        public static string GetBtnRole(string menuname,string rolecode)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select typecode from dbo.SYS_ROLEMENU where menucode=");
            sb.AppendLine("(");
            sb.AppendLine("    select menucode from sys_menu where ParentID !='0' and menuname=@menuname");
            sb.AppendLine(") and rolecode=@rolecode");
            string result = string.Empty;
            try
            {
                DataSet ds = SqlDataProvider.GetResultBySql(sb.ToString(),
                    SqlDataProvider.CreateSqlParameter("@menuname", SqlDbType.VarChar, menuname),
                    SqlDataProvider.CreateSqlParameter("@rolecode", SqlDbType.VarChar, rolecode));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(result))
                        {
                            result = ds.Tables[0].Rows[i]["typecode"].ToString();
                        }
                        else
                        {
                            result = result + "," + ds.Tables[0].Rows[i]["typecode"].ToString();
                        }
                    }
                }
            }
            catch
            { }
            return result;
        }

        /// <summary>
        /// 获取机构信息
        /// </summary>
        /// <returns></returns>
        public static DataSet GetOrgxx()
        {
            string sql = "select code,organame from SYS_ORGANIZATION";
            return SqlDataProvider.GetResultBySql(sql);
        }

        /// <summary>
        /// 取Excel数据
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static DataSet ReadEexcel(string FilePath)
        {
            string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;data source=" + FilePath;
            string sql = "SELECT distinct * FROM [Sheet1$]";
            DataSet ds = new DataSet();
            System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter(sql, connStr);
            da.Fill(ds);
            return ds;
        }


        /// <summary>
        /// 通用修改记录状态方法
        /// </summary>
        /// <param name="tName">数据表名</param>
        /// <param name="key">条件字段名</param>
        /// <param name="keyvalue">条件字段值</param>
        /// <param name="state">状态值</param>
        /// <returns></returns>
        public static bool UpdateObjState(string tName,string key,string keyvalue, string state)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE ["+tName+"]");
            sb.AppendLine("SET [STATE] = @state");
            sb.AppendLine(" WHERE "+key+"=@keyvalue");
            int temp = SqlDataProvider.ExecuteBySql(sb.ToString(),
                SqlDataProvider.CreateSqlParameter("@state", SqlDbType.VarChar, state),
                SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.Int, keyvalue)
                );
            return temp >= 0 ? true : false;
        }
        /// <summary>
        /// 通用修改记录状态方法
        /// </summary>
        /// <param name="tName">数据表名</param>
        /// <param name="lsh">流水号</param>
        /// <param name="state">状态值</param>
        /// <returns></returns>
        public static bool UpdateObjState(string tName, string lsh, string state)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE ["+tName+"]");
            sb.AppendLine("SET [STATE] = @state");
            sb.AppendLine(" WHERE lsh=@lsh");
            int temp = SqlDataProvider.ExecuteBySql(sb.ToString(),
                SqlDataProvider.CreateSqlParameter("@state", SqlDbType.VarChar, state),
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.Int, lsh)
                );
            return temp >= 0 ? true : false;
        }
        /// <summary>
        /// 通用修改记录排序方法
        /// </summary>
        /// <param name="tName">数据表名</param>
        /// <param name="lsh">流水号</param>
        /// <param name="sort">排序值</param>
        /// <returns></returns>
        public static bool UpdateObjSort(string tName, string lsh, int sort)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE [" + tName + "]");
            sb.AppendLine("SET [SORT] = @sort");
            sb.AppendLine(" WHERE lsh=@lsh");
            int temp = SqlDataProvider.ExecuteBySql(sb.ToString(),
                SqlDataProvider.CreateSqlParameter("@sort", SqlDbType.Int, sort),
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.Int, lsh)
                );
            return temp >= 0 ? true : false;
        }
    }
}
