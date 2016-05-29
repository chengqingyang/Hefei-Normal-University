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
    public class XueQiDAL
    {
        public XueQiDAL()
		{}
		#region  BasicMethod
        /*
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string XQNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SYS_XUEQI");
			strSql.Append(" where XQNO=@XQNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@XQNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = XQNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.SYS_XUEQI model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SYS_XUEQI(");
			strSql.Append("XQNO,XQNAME,XNNO,SCHOOLNO,KSRQ,JSRQ,XGSJ,DJSJ,JLZT)");
			strSql.Append(" values (");
			strSql.Append("@XQNO,@XQNAME,@XNNO,@SCHOOLNO,@KSRQ,@JSRQ,@XGSJ,@DJSJ,@JLZT)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@XQNO", SqlDbType.VarChar,50),
					new SqlParameter("@XQNAME", SqlDbType.VarChar,50),
					new SqlParameter("@XNNO", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,50),
					new SqlParameter("@KSRQ", SqlDbType.DateTime),
					new SqlParameter("@JSRQ", SqlDbType.DateTime),
					new SqlParameter("@XGSJ", SqlDbType.DateTime),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50)};
			parameters[0].Value = model.XQNO;
			parameters[1].Value = model.XQNAME;
			parameters[2].Value = model.XNNO;
			parameters[3].Value = model.SCHOOLNO;
			parameters[4].Value = model.KSRQ;
			parameters[5].Value = model.JSRQ;
			parameters[6].Value = model.XGSJ;
			parameters[7].Value = model.DJSJ;
			parameters[8].Value = model.JLZT;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.SYS_XUEQI model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SYS_XUEQI set ");
			strSql.Append("XQNAME=@XQNAME,");
			strSql.Append("XNNO=@XNNO,");
			strSql.Append("SCHOOLNO=@SCHOOLNO,");
			strSql.Append("KSRQ=@KSRQ,");
			strSql.Append("JSRQ=@JSRQ,");
			strSql.Append("XGSJ=@XGSJ,");
			strSql.Append("DJSJ=@DJSJ,");
			strSql.Append("JLZT=@JLZT");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@XQNAME", SqlDbType.VarChar,50),
					new SqlParameter("@XNNO", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,50),
					new SqlParameter("@KSRQ", SqlDbType.DateTime),
					new SqlParameter("@JSRQ", SqlDbType.DateTime),
					new SqlParameter("@XGSJ", SqlDbType.DateTime),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4),
					new SqlParameter("@XQNO", SqlDbType.VarChar,50)};
			parameters[0].Value = model.XQNAME;
			parameters[1].Value = model.XNNO;
			parameters[2].Value = model.SCHOOLNO;
			parameters[3].Value = model.KSRQ;
			parameters[4].Value = model.JSRQ;
			parameters[5].Value = model.XGSJ;
			parameters[6].Value = model.DJSJ;
			parameters[7].Value = model.JLZT;
			parameters[8].Value = model.LSH;
			parameters[9].Value = model.XQNO;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LSH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SYS_XUEQI ");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
			parameters[0].Value = LSH;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string XQNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SYS_XUEQI ");
			strSql.Append(" where XQNO=@XQNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@XQNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = XQNO;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string LSHlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SYS_XUEQI ");
			strSql.Append(" where LSH in ("+LSHlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.SYS_XUEQI GetModel(int LSH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LSH,XQNO,XQNAME,XNNO,SCHOOLNO,KSRQ,JSRQ,XGSJ,DJSJ,JLZT from SYS_XUEQI ");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
			parameters[0].Value = LSH;

			Maticsoft.Model.SYS_XUEQI model=new Maticsoft.Model.SYS_XUEQI();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.SYS_XUEQI DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SYS_XUEQI model=new Maticsoft.Model.SYS_XUEQI();
			if (row != null)
			{
				if(row["LSH"]!=null && row["LSH"].ToString()!="")
				{
					model.LSH=int.Parse(row["LSH"].ToString());
				}
				if(row["XQNO"]!=null)
				{
					model.XQNO=row["XQNO"].ToString();
				}
				if(row["XQNAME"]!=null)
				{
					model.XQNAME=row["XQNAME"].ToString();
				}
				if(row["XNNO"]!=null)
				{
					model.XNNO=row["XNNO"].ToString();
				}
				if(row["SCHOOLNO"]!=null)
				{
					model.SCHOOLNO=row["SCHOOLNO"].ToString();
				}
				if(row["KSRQ"]!=null && row["KSRQ"].ToString()!="")
				{
					model.KSRQ=DateTime.Parse(row["KSRQ"].ToString());
				}
				if(row["JSRQ"]!=null && row["JSRQ"].ToString()!="")
				{
					model.JSRQ=DateTime.Parse(row["JSRQ"].ToString());
				}
				if(row["XGSJ"]!=null && row["XGSJ"].ToString()!="")
				{
					model.XGSJ=DateTime.Parse(row["XGSJ"].ToString());
				}
				if(row["DJSJ"]!=null && row["DJSJ"].ToString()!="")
				{
					model.DJSJ=DateTime.Parse(row["DJSJ"].ToString());
				}
				if(row["JLZT"]!=null)
				{
					model.JLZT=row["JLZT"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LSH,XQNO,XQNAME,XNNO,SCHOOLNO,KSRQ,JSRQ,XGSJ,DJSJ,JLZT ");
			strSql.Append(" FROM SYS_XUEQI ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" LSH,XQNO,XQNAME,XNNO,SCHOOLNO,KSRQ,JSRQ,XGSJ,DJSJ,JLZT ");
			strSql.Append(" FROM SYS_XUEQI ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM SYS_XUEQI ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.LSH desc");
			}
			strSql.Append(")AS Row, T.*  from SYS_XUEQI T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}
        */
		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "SYS_XUEQI";
			parameters[1].Value = "LSH";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
        #region  ExtensionMethod
        public static DataSet GetXueQiList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_XueQiList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }
        public static DataSet GetXueQiList(string key, string keyvalue)
        {
            string sql = "select * from SYS_XUEQI where jlzt=0 and state=0 and " + key + "=@keyvalue order by sort asc,lsh desc";
            return SqlDataProvider.GetResultBySql(sql, SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.VarChar, keyvalue));
        }
        /// <summary>
        /// 获取学期列表
        /// </summary>
        /// <param name="values">values:字段值数组，0--schoolno,1--xnno</param>
        /// <returns></returns>
        public static DataSet GetXueQiList(string[] values)
        {
            string sql = "select * from SYS_XUEQI where jlzt=0 and state=0 and schoolno='"+values[0]+"' and xnno='"+values[1]+"'";
            return SqlDataProvider.GetResultBySql(sql, null);
        }

        public static DataTable GetXueQiList()
        {
            return CommonDAL.GetObjList("SYS_XUEQI");
        }
        /// <summary>
        /// 获取学期编号
        /// </summary>
        /// <param name="xnno"></param>
        /// <returns></returns>
        public static string GetXueQiNo(string xnno)
        {
            string no = null;
            string sql = "select xqno,xqname from sys_xueqi a,sys_xuenian b where a.xnno=b.xnno and a.xnno='" +
                xnno + "' and a.state='0' order by xqno desc";
            DataSet ds = SqlDataProvider.GetResultBySql(sql,null);
            if (ds.Tables[0].Rows.Count == 0)
            {
                no = "1";
            }
            else
            {
                string s = ds.Tables[0].Rows[0]["XQNO"].ToString();
                no = ((int.Parse(s)) + 1).ToString();
            }
            return no;
        }

        public static int SaveData(XueQiInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = XueQiDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = XueQiDAL.InsertCommand(model);
            }
            return result;
        }

        /// <summary>
        /// 修改作业
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(XueQiInfo model)
        {
            int num = CommonDAL.ObjectExists("SYS_XUEQI", " and lsh =" + model.LSH.ToString());
            if (num <= 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update SYS_XUEQI set ");
                strSql.Append("XQNAME=@XQNAME,");
                strSql.Append("SCHOOLNO=@SCHOOLNO,");
                strSql.Append("KSRQ=@KSRQ,");
                strSql.Append("JSRQ=@JSRQ,");
                strSql.Append("XGSJ=@XGSJ,");
                strSql.Append("STATE=@STATE");
                //strSql.Append("JLZT=@JLZT");
                strSql.Append(" where LSH=@LSH");
                SqlParameter[] parameters = {
					new SqlParameter("@XQNAME", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,50),
					new SqlParameter("@KSRQ", SqlDbType.DateTime),
					new SqlParameter("@JSRQ", SqlDbType.DateTime),
					new SqlParameter("@XGSJ", SqlDbType.DateTime),
					new SqlParameter("@STATE", SqlDbType.VarChar,10),
					new SqlParameter("@LSH", SqlDbType.Int,4)};
                parameters[0].Value = model.XQNAME;
                parameters[1].Value = model.SCHOOLNO;
                parameters[2].Value = model.KSRQ;
                parameters[3].Value = model.JSRQ;
                parameters[4].Value = model.XGSJ;
                parameters[5].Value = model.STATE;
                parameters[6].Value = model.LSH;

                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
        //public static bool UpdateCommand(string username, string connphone, string cardid, string zc, string lsh)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("UPDATE [SYS_XUEQI]");
        //    sb.AppendLine("SET [TNAME] = @username");
        //    sb.AppendLine("  ,[LXDH] = @connphone");
        //    sb.AppendLine("  ,[SFZH] = @cardid");
        //    sb.AppendLine("  ,[ZC] = @zc");
        //    sb.AppendLine(" WHERE lsh=@lsh");
        //    int temp = SqlDataProvider.ExecuteBySql(sb.ToString(),
        //        SqlDataProvider.CreateSqlParameter("@username", SqlDbType.VarChar, username),
        //        SqlDataProvider.CreateSqlParameter("@connphone", SqlDbType.VarChar, connphone),
        //        SqlDataProvider.CreateSqlParameter("@cardid", SqlDbType.VarChar, cardid),
        //        SqlDataProvider.CreateSqlParameter("@zc", SqlDbType.VarChar, zc),
        //        SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.Int, lsh)
        //        );
        //    return temp >= 0 ? true : false;
        //}

        public static int InsertCommand(XueQiInfo model)
        {
            //先判断资料是否存在
            int num = CommonDAL.ObjectExists("SYS_XUEQI", "and XQNO='" + model.XQNO + "'"
                + " and XNNO='" + model.XNNO + "'" + " and SCHOOLNO='" + model.SCHOOLNO + "'");
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into SYS_XUEQI(");
                strSql.Append("XQNO,XQNAME,XNNO,SCHOOLNO,KSRQ,JSRQ,STATE)");
                strSql.Append(" values (");
                strSql.Append("@XQNO,@XQNAME,@XNNO,@SCHOOLNO,@KSRQ,@JSRQ,@STATE)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@XQNO", SqlDbType.VarChar,50),
					new SqlParameter("@XQNAME", SqlDbType.VarChar,50),
					new SqlParameter("@XNNO", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,50),
					new SqlParameter("@KSRQ", SqlDbType.DateTime),
					new SqlParameter("@JSRQ", SqlDbType.DateTime),
					new SqlParameter("@XGSJ", SqlDbType.DateTime),
					new SqlParameter("@STATE", SqlDbType.VarChar,10)};
                parameters[0].Value = model.XQNO;
                parameters[1].Value = model.XQNAME;
                parameters[2].Value = model.XNNO;
                parameters[3].Value = model.SCHOOLNO;
                parameters[4].Value = model.KSRQ;
                parameters[5].Value = model.JSRQ;
                parameters[6].Value = model.XGSJ;
                parameters[7].Value = model.STATE;

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
        }
        #endregion  ExtensionMethod
	}
}
