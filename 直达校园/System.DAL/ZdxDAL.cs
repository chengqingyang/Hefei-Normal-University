
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Model;
using MicroSoft.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;

namespace System.DAL
{
	/// <summary>
	/// 数据访问类:SYS_DICTIONARY
	/// </summary>
	public partial class ZdxDAL
	{
        public ZdxDAL()
		{}
		#region  基础方法

        /// <summary>
        /// 字典项主查询
        /// </summary>
        /// <param name="pageindex">页索引</param>
        /// <param name="pagesize">每页记录数</param>
        /// <param name="xmlQuery">查询条件</param>
        /// <param name="recordcount">返回记录数</param>
        /// <returns></returns>
        public static DataSet GetZdxList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_ZdxList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }


        /// <summary>
        /// 字典项保存方法
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        public static int SaveData(DictionaryInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = ZdxDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = ZdxDAL.InsertCommand(model);
            }
            return result;
        }

        /// <summary>
        /// 修改字典项
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(DictionaryInfo model)
        {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("update SYS_DICTIONARY set ");
                strSql.Append("DAZX=@DAZX,");
                strSql.Append("WTBH=@WTBH,");
                strSql.Append("WTNR=@WTNR,");
                strSql.Append("DABH=@DABH,");
                strSql.Append("DAXX=@DAXX,");
                strSql.Append("BZ=@BZ,");
                strSql.Append(" where LSH=@LSH");
                SqlParameter[] parameters = {
					new SqlParameter("@DAZX", SqlDbType.VarChar,4),
					new SqlParameter("@WTBH", SqlDbType.VarChar,8),
					new SqlParameter("@WTNR", SqlDbType.VarChar,100),
					new SqlParameter("@DABH", SqlDbType.VarChar,8),
					new SqlParameter("@DAXX", SqlDbType.VarChar,255),
					new SqlParameter("@BZ", SqlDbType.VarChar,200),
					new SqlParameter("@LSH", SqlDbType.Int,4)};
                parameters[0].Value = model.DAZX;
                parameters[1].Value = model.WTBH;
                parameters[2].Value = model.WTNR;
                parameters[3].Value = model.DABH;
                parameters[4].Value = model.DAXX;
                parameters[5].Value = model.BZ;
                parameters[7].Value = model.LSH;

                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 新增字典项
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int InsertCommand(DictionaryInfo model)
        {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into SYS_DICTIONARY(");
                strSql.Append("DAZX,WTBH,WTNR,DABH,DAXX,BZ)");
                strSql.Append(" values (");
                strSql.Append("@DAZX,@WTBH,@WTNR,@DABH,@DAXX,@BZ)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					    new SqlParameter("@DAZX", SqlDbType.VarChar,4),
					    new SqlParameter("@WTBH", SqlDbType.VarChar,8),
					    new SqlParameter("@WTNR", SqlDbType.VarChar,100),
					    new SqlParameter("@DABH", SqlDbType.VarChar,8),
					    new SqlParameter("@DAXX", SqlDbType.VarChar,255),
					    new SqlParameter("@BZ", SqlDbType.VarChar,200)};
                parameters[0].Value = model.DAZX;
                parameters[1].Value = model.WTBH;
                parameters[2].Value = model.WTNR;
                parameters[3].Value = model.DABH;
                parameters[4].Value = model.DAXX;
                parameters[5].Value = model.BZ;
                object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(obj);
                }
        }

        /// <summary>
        /// 根据lsh查询内容
        /// </summary>
        /// <param name="key"></param>
        /// <param name="keyvalue"></param>
        /// <returns></returns>
        public static DataSet GetZdxbyLsh(string key, string keyvalue)
        {
            string sql = "select * from SYS_DICTIONARY where jlzt=0 and " + key + "=@keyvalue";
            return SqlDataProvider.GetResultBySql(sql, SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.VarChar, keyvalue));
        }

        #endregion  基础方法


        #region  扩展方法

        #endregion  扩展方法
    }
}

