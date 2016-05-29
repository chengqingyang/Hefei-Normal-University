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
    public class XueNianDAL
    {
        public XueNianDAL()
		{}
		#region  BasicMethod
        /*
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string XNNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SYS_XUENIAN");
			strSql.Append(" where XNNO=@XNNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@XNNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = XNNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.SYS_XUENIAN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SYS_XUENIAN(");
			strSql.Append("XNNO,SCHOOLNO,XNNAME,KSRQ,JSRQ,DJRYGH,STATE,XGSJ,DJSJ,JLZT)");
			strSql.Append(" values (");
			strSql.Append("@XNNO,@SCHOOLNO,@XNNAME,@KSRQ,@JSRQ,@DJRYGH,@STATE,@XGSJ,@DJSJ,@JLZT)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@XNNO", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,50),
					new SqlParameter("@XNNAME", SqlDbType.VarChar,50),
					new SqlParameter("@KSRQ", SqlDbType.DateTime),
					new SqlParameter("@JSRQ", SqlDbType.DateTime),
					new SqlParameter("@DJRYGH", SqlDbType.VarChar,50),
					new SqlParameter("@STATE", SqlDbType.VarChar,10),
					new SqlParameter("@XGSJ", SqlDbType.DateTime),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50)};
			parameters[0].Value = model.XNNO;
			parameters[1].Value = model.SCHOOLNO;
			parameters[2].Value = model.XNNAME;
			parameters[3].Value = model.KSRQ;
			parameters[4].Value = model.JSRQ;
			parameters[5].Value = model.DJRYGH;
			parameters[6].Value = model.STATE;
			parameters[7].Value = model.XGSJ;
			parameters[8].Value = model.DJSJ;
			parameters[9].Value = model.JLZT;

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
		public bool Update(Maticsoft.Model.SYS_XUENIAN model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SYS_XUENIAN set ");
			strSql.Append("SCHOOLNO=@SCHOOLNO,");
			strSql.Append("XNNAME=@XNNAME,");
			strSql.Append("KSRQ=@KSRQ,");
			strSql.Append("JSRQ=@JSRQ,");
			strSql.Append("DJRYGH=@DJRYGH,");
			strSql.Append("STATE=@STATE,");
			strSql.Append("XGSJ=@XGSJ,");
			strSql.Append("DJSJ=@DJSJ,");
			strSql.Append("JLZT=@JLZT");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,50),
					new SqlParameter("@XNNAME", SqlDbType.VarChar,50),
					new SqlParameter("@KSRQ", SqlDbType.DateTime),
					new SqlParameter("@JSRQ", SqlDbType.DateTime),
					new SqlParameter("@DJRYGH", SqlDbType.VarChar,50),
					new SqlParameter("@STATE", SqlDbType.VarChar,10),
					new SqlParameter("@XGSJ", SqlDbType.DateTime),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4),
					new SqlParameter("@XNNO", SqlDbType.VarChar,50)};
			parameters[0].Value = model.SCHOOLNO;
			parameters[1].Value = model.XNNAME;
			parameters[2].Value = model.KSRQ;
			parameters[3].Value = model.JSRQ;
			parameters[4].Value = model.DJRYGH;
			parameters[5].Value = model.STATE;
			parameters[6].Value = model.XGSJ;
			parameters[7].Value = model.DJSJ;
			parameters[8].Value = model.JLZT;
			parameters[9].Value = model.LSH;
			parameters[10].Value = model.XNNO;

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
			strSql.Append("delete from SYS_XUENIAN ");
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
		public bool Delete(string XNNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SYS_XUENIAN ");
			strSql.Append(" where XNNO=@XNNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@XNNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = XNNO;

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
			strSql.Append("delete from SYS_XUENIAN ");
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
		public Maticsoft.Model.SYS_XUENIAN GetModel(int LSH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LSH,XNNO,SCHOOLNO,XNNAME,KSRQ,JSRQ,DJRYGH,STATE,XGSJ,DJSJ,JLZT from SYS_XUENIAN ");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
			parameters[0].Value = LSH;

			Maticsoft.Model.SYS_XUENIAN model=new Maticsoft.Model.SYS_XUENIAN();
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
		public Maticsoft.Model.SYS_XUENIAN DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SYS_XUENIAN model=new Maticsoft.Model.SYS_XUENIAN();
			if (row != null)
			{
				if(row["LSH"]!=null && row["LSH"].ToString()!="")
				{
					model.LSH=int.Parse(row["LSH"].ToString());
				}
				if(row["XNNO"]!=null)
				{
					model.XNNO=row["XNNO"].ToString();
				}
				if(row["SCHOOLNO"]!=null)
				{
					model.SCHOOLNO=row["SCHOOLNO"].ToString();
				}
				if(row["XNNAME"]!=null)
				{
					model.XNNAME=row["XNNAME"].ToString();
				}
				if(row["KSRQ"]!=null && row["KSRQ"].ToString()!="")
				{
					model.KSRQ=DateTime.Parse(row["KSRQ"].ToString());
				}
				if(row["JSRQ"]!=null && row["JSRQ"].ToString()!="")
				{
					model.JSRQ=DateTime.Parse(row["JSRQ"].ToString());
				}
				if(row["DJRYGH"]!=null)
				{
					model.DJRYGH=row["DJRYGH"].ToString();
				}
				if(row["STATE"]!=null)
				{
					model.STATE=row["STATE"].ToString();
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
			strSql.Append("select LSH,XNNO,SCHOOLNO,XNNAME,KSRQ,JSRQ,DJRYGH,STATE,XGSJ,DJSJ,JLZT ");
			strSql.Append(" FROM SYS_XUENIAN ");
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
			strSql.Append(" LSH,XNNO,SCHOOLNO,XNNAME,KSRQ,JSRQ,DJRYGH,STATE,XGSJ,DJSJ,JLZT ");
			strSql.Append(" FROM SYS_XUENIAN ");
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
			strSql.Append("select count(1) FROM SYS_XUENIAN ");
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
			strSql.Append(")AS Row, T.*  from SYS_XUENIAN T ");
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
			parameters[0].Value = "SYS_XUENIAN";
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
        public static DataSet GetXueNianList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_XueNianList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }
        public static DataSet GetXueNianList(string key, string keyvalue)
        {
            string sql = "select * from SYS_XUENIAN where jlzt=0 and state=0 and " + key + "=@keyvalue order by sort asc,lsh desc";
            return SqlDataProvider.GetResultBySql(sql, SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.VarChar, keyvalue));
        }

        public static DataTable GetXueNianList()
        {
            return CommonDAL.GetObjList("SYS_XUENIAN");
        }
        public static string GetXueNianNo()
        {
            string no = null;
            DataSet ds = SqlDataProvider.GetResultBySql("select LSH from SYS_XUENIAN order by LSH desc",
                null);
            if (ds.Tables[0].Rows.Count == 0)
            {
                no = "1";
            }
            else
            {
                string s = ds.Tables[0].Rows[0]["LSH"].ToString();
                no = ((int.Parse(s)) + 1).ToString();
            }
            return no;
        }
        
        public static int SaveData(XueNianInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = XueNianDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = XueNianDAL.InsertCommand(model);
            }
            return result;
        }

        /// <summary>
        /// 修改作业
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(XueNianInfo model)
        {
            int num = CommonDAL.ObjectExists("SYS_XUENIAN", " and lsh =" + model.LSH.ToString());
            if (num <= 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update SYS_XUENIAN set ");
                strSql.Append("SCHOOLNO=@SCHOOLNO,");
			    strSql.Append("XNNAME=@XNNAME,");
			    strSql.Append("KSRQ=@KSRQ,");
			    strSql.Append("JSRQ=@JSRQ,");
			    strSql.Append("STATE=@STATE,");
			    strSql.Append("XGSJ=@XGSJ");
			    strSql.Append(" where LSH=@LSH");
			    SqlParameter[] parameters = {
					    new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,50),
					    new SqlParameter("@XNNAME", SqlDbType.VarChar,50),
					    new SqlParameter("@KSRQ", SqlDbType.DateTime),
					    new SqlParameter("@JSRQ", SqlDbType.DateTime),
					    new SqlParameter("@STATE", SqlDbType.VarChar,10),
					    new SqlParameter("@XGSJ", SqlDbType.DateTime),
					    new SqlParameter("@LSH", SqlDbType.Int,4)};
			    parameters[0].Value = model.SCHOOLNO;
			    parameters[1].Value = model.XNNAME;
			    parameters[2].Value = model.KSRQ;
			    parameters[3].Value = model.JSRQ;
			    parameters[4].Value = model.STATE;
			    parameters[5].Value = model.XGSJ;
			    parameters[6].Value = model.LSH;

                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
        //public static bool UpdateCommand(string username, string connphone, string cardid, string zc, string lsh)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("UPDATE [SYS_XUENIAN]");
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

        public static int InsertCommand(XueNianInfo model)
        {
            //先判断资料是否存在
            int num = CommonDAL.ObjectExists("SYS_XUENIAN", "and XNNO='" + model.XNNO + "'");
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into SYS_XUENIAN(");
			    strSql.Append("XNNO,SCHOOLNO,XNNAME,KSRQ,JSRQ,DJRYGH,STATE)");
			    strSql.Append(" values (");
			    strSql.Append("@XNNO,@SCHOOLNO,@XNNAME,@KSRQ,@JSRQ,@DJRYGH,@STATE)");
			    strSql.Append(";select @@IDENTITY");
			    SqlParameter[] parameters = {
					    new SqlParameter("@XNNO", SqlDbType.VarChar,50),
					    new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,50),
					    new SqlParameter("@XNNAME", SqlDbType.VarChar,50),
					    new SqlParameter("@KSRQ", SqlDbType.DateTime),
					    new SqlParameter("@JSRQ", SqlDbType.DateTime),
					    new SqlParameter("@DJRYGH", SqlDbType.VarChar,50),
					    new SqlParameter("@STATE", SqlDbType.VarChar,10)};
			    parameters[0].Value = model.XNNO;
			    parameters[1].Value = model.SCHOOLNO;
			    parameters[2].Value = model.XNNAME;
			    parameters[3].Value = model.KSRQ;
			    parameters[4].Value = model.JSRQ;
			    parameters[5].Value = model.DJRYGH;
			    parameters[6].Value = model.STATE;

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
