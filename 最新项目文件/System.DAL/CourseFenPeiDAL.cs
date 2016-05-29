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
    public class CourseFenPeiDAL
    {
        public CourseFenPeiDAL()
		{}
		#region  BasicMethod
        /*
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LSH)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SYS_COURSEFP");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
			parameters[0].Value = LSH;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.SYS_COURSEFP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SYS_COURSEFP(");
			strSql.Append("SCHOOLNO,TGH,CLASSNO,COURSENO,DJRYGH,STATE,XGSJ,DJSH,JLZT)");
			strSql.Append(" values (");
			strSql.Append("@SCHOOLNO,@TGH,@CLASSNO,@COURSENO,@DJRYGH,@STATE,@XGSJ,@DJSH,@JLZT)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30),
					new SqlParameter("@TGH", SqlDbType.VarChar,50),
					new SqlParameter("@CLASSNO", SqlDbType.VarChar,50),
					new SqlParameter("@COURSENO", SqlDbType.VarChar,30),
					new SqlParameter("@DJRYGH", SqlDbType.VarChar,50),
					new SqlParameter("@STATE", SqlDbType.VarChar,10),
					new SqlParameter("@XGSJ", SqlDbType.DateTime),
					new SqlParameter("@DJSH", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50)};
			parameters[0].Value = model.SCHOOLNO;
			parameters[1].Value = model.TGH;
			parameters[2].Value = model.CLASSNO;
			parameters[3].Value = model.COURSENO;
			parameters[4].Value = model.DJRYGH;
			parameters[5].Value = model.STATE;
			parameters[6].Value = model.XGSJ;
			parameters[7].Value = model.DJSH;
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
		public bool Update(Maticsoft.Model.SYS_COURSEFP model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SYS_COURSEFP set ");
			strSql.Append("SCHOOLNO=@SCHOOLNO,");
			strSql.Append("TGH=@TGH,");
			strSql.Append("CLASSNO=@CLASSNO,");
			strSql.Append("COURSENO=@COURSENO,");
			strSql.Append("DJRYGH=@DJRYGH,");
			strSql.Append("STATE=@STATE,");
			strSql.Append("XGSJ=@XGSJ,");
			strSql.Append("DJSH=@DJSH,");
			strSql.Append("JLZT=@JLZT");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30),
					new SqlParameter("@TGH", SqlDbType.VarChar,50),
					new SqlParameter("@CLASSNO", SqlDbType.VarChar,50),
					new SqlParameter("@COURSENO", SqlDbType.VarChar,30),
					new SqlParameter("@DJRYGH", SqlDbType.VarChar,50),
					new SqlParameter("@STATE", SqlDbType.VarChar,10),
					new SqlParameter("@XGSJ", SqlDbType.DateTime),
					new SqlParameter("@DJSH", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4)};
			parameters[0].Value = model.SCHOOLNO;
			parameters[1].Value = model.TGH;
			parameters[2].Value = model.CLASSNO;
			parameters[3].Value = model.COURSENO;
			parameters[4].Value = model.DJRYGH;
			parameters[5].Value = model.STATE;
			parameters[6].Value = model.XGSJ;
			parameters[7].Value = model.DJSH;
			parameters[8].Value = model.JLZT;
			parameters[9].Value = model.LSH;

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
			strSql.Append("delete from SYS_COURSEFP ");
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string LSHlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SYS_COURSEFP ");
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
		public Maticsoft.Model.SYS_COURSEFP GetModel(int LSH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LSH,SCHOOLNO,TGH,CLASSNO,COURSENO,DJRYGH,STATE,XGSJ,DJSH,JLZT from SYS_COURSEFP ");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
			parameters[0].Value = LSH;

			Maticsoft.Model.SYS_COURSEFP model=new Maticsoft.Model.SYS_COURSEFP();
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
		public Maticsoft.Model.SYS_COURSEFP DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SYS_COURSEFP model=new Maticsoft.Model.SYS_COURSEFP();
			if (row != null)
			{
				if(row["LSH"]!=null && row["LSH"].ToString()!="")
				{
					model.LSH=int.Parse(row["LSH"].ToString());
				}
				if(row["SCHOOLNO"]!=null)
				{
					model.SCHOOLNO=row["SCHOOLNO"].ToString();
				}
				if(row["TGH"]!=null)
				{
					model.TGH=row["TGH"].ToString();
				}
				if(row["CLASSNO"]!=null)
				{
					model.CLASSNO=row["CLASSNO"].ToString();
				}
				if(row["COURSENO"]!=null)
				{
					model.COURSENO=row["COURSENO"].ToString();
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
				if(row["DJSH"]!=null && row["DJSH"].ToString()!="")
				{
					model.DJSH=DateTime.Parse(row["DJSH"].ToString());
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
			strSql.Append("select LSH,SCHOOLNO,TGH,CLASSNO,COURSENO,DJRYGH,STATE,XGSJ,DJSH,JLZT ");
			strSql.Append(" FROM SYS_COURSEFP ");
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
			strSql.Append(" LSH,SCHOOLNO,TGH,CLASSNO,COURSENO,DJRYGH,STATE,XGSJ,DJSH,JLZT ");
			strSql.Append(" FROM SYS_COURSEFP ");
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
			strSql.Append("select count(1) FROM SYS_COURSEFP ");
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
			strSql.Append(")AS Row, T.*  from SYS_COURSEFP T ");
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
			parameters[0].Value = "SYS_COURSEFP";
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
        public static DataSet GetCourseFenPeiList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_CourseFenPeiList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }
        public static DataSet GetCourseFenPeiList(string key, string keyvalue)
        {
            string sql = "select * from SYS_COURSEFP where jlzt=0 and " + key + "=@keyvalue";
            return SqlDataProvider.GetResultBySql(sql, SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.VarChar, keyvalue));
        }

        public static DataTable GetCourseFenPeiList()
        {
            return CommonDAL.GetObjList("SYS_COURSEFP");
        }
        
        public static int SaveData(CourseFenPeiInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = CourseFenPeiDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = CourseFenPeiDAL.InsertCommand(model);
            }
            return result;
        }

        /// <summary>
        /// 修改作业
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(CourseFenPeiInfo model)
        {
            int num = CommonDAL.ObjectExists("SYS_COURSEFP", " and lsh =" + model.LSH.ToString());
            if (num <= 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update SYS_COURSEFP set ");
			    strSql.Append("SCHOOLNO=@SCHOOLNO,");
			    strSql.Append("TGH=@TGH,");
			    strSql.Append("CLASSNO=@CLASSNO,");
			    strSql.Append("COURSENO=@COURSENO,");
			    strSql.Append("DJRYGH=@DJRYGH,");
			    strSql.Append("STATE=@STATE,");
			    strSql.Append("XGSJ=@XGSJ");
			    strSql.Append(" where LSH=@LSH");
			    SqlParameter[] parameters = {
					    new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30),
					    new SqlParameter("@TGH", SqlDbType.VarChar,50),
					    new SqlParameter("@CLASSNO", SqlDbType.VarChar,50),
					    new SqlParameter("@COURSENO", SqlDbType.VarChar,30),
					    new SqlParameter("@DJRYGH", SqlDbType.VarChar,50),
					    new SqlParameter("@STATE", SqlDbType.VarChar,10),
					    new SqlParameter("@XGSJ", SqlDbType.DateTime),
					    new SqlParameter("@LSH", SqlDbType.Int,4)};
			    parameters[0].Value = model.SCHOOLNO;
			    parameters[1].Value = model.TGH;
			    parameters[2].Value = model.CLASSNO;
			    parameters[3].Value = model.COURSENO;
			    parameters[4].Value = model.DJRYGH;
			    parameters[5].Value = model.STATE;
			    parameters[6].Value = model.XGSJ;
			    parameters[7].Value = model.LSH;

                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
        //public static bool UpdateCommand(string username, string connphone, string cardid, string zc, string lsh)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("UPDATE [SYS_COURSEFP]");
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

        public static int InsertCommand(CourseFenPeiInfo model)
        {
            //先判断资料是否存在
            int num = CommonDAL.ObjectExists("SYS_COURSEFP", "and LSH='" + model.LSH + "'");
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();

                strSql.Append("insert into SYS_COURSEFP(");
			    strSql.Append("SCHOOLNO,TGH,CLASSNO,COURSENO,DJRYGH)");
			    strSql.Append(" values (");
			    strSql.Append("@SCHOOLNO,@TGH,@CLASSNO,@COURSENO,@DJRYGH)");
			    strSql.Append(";select @@IDENTITY");
			    SqlParameter[] parameters = {
					    new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30),
					    new SqlParameter("@TGH", SqlDbType.VarChar,50),
					    new SqlParameter("@CLASSNO", SqlDbType.VarChar,50),
					    new SqlParameter("@COURSENO", SqlDbType.VarChar,30),
					    new SqlParameter("@DJRYGH", SqlDbType.VarChar,50)};
			    parameters[0].Value = model.SCHOOLNO;
			    parameters[1].Value = model.TGH;
			    parameters[2].Value = model.CLASSNO;
			    parameters[3].Value = model.COURSENO;
			    parameters[4].Value = model.DJRYGH;

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
