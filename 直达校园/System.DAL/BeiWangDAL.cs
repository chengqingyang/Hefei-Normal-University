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
    public class BeiWangDAL
    {
        public BeiWangDAL()
		{}
		#region  BasicMethod
        /*
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string BWNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from YW_BEIWANG");
			strSql.Append(" where BWNO=@BWNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@BWNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = BWNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.YW_BEIWANG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YW_BEIWANG(");
			strSql.Append("BWNO,CJZ,TITLE,BWZW,BWSJ,TYPE,DJSJ,JLZT)");
			strSql.Append(" values (");
			strSql.Append("@BWNO,@CJZ,@TITLE,@BWZW,@BWSJ,@TYPE,@DJSJ,@JLZT)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@BWNO", SqlDbType.VarChar,50),
					new SqlParameter("@CJZ", SqlDbType.VarChar,50),
					new SqlParameter("@TITLE", SqlDbType.VarChar,100),
					new SqlParameter("@BWZW", SqlDbType.VarChar,200),
					new SqlParameter("@BWSJ", SqlDbType.VarChar,50),
					new SqlParameter("@TYPE", SqlDbType.VarChar,50),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50)};
			parameters[0].Value = model.BWNO;
			parameters[1].Value = model.CJZ;
			parameters[2].Value = model.TITLE;
			parameters[3].Value = model.BWZW;
			parameters[4].Value = model.BWSJ;
			parameters[5].Value = model.TYPE;
			parameters[6].Value = model.DJSJ;
			parameters[7].Value = model.JLZT;

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
		public bool Update(Maticsoft.Model.YW_BEIWANG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YW_BEIWANG set ");
			strSql.Append("CJZ=@CJZ,");
			strSql.Append("TITLE=@TITLE,");
			strSql.Append("BWZW=@BWZW,");
			strSql.Append("BWSJ=@BWSJ,");
			strSql.Append("TYPE=@TYPE,");
			strSql.Append("DJSJ=@DJSJ,");
			strSql.Append("JLZT=@JLZT");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@CJZ", SqlDbType.VarChar,50),
					new SqlParameter("@TITLE", SqlDbType.VarChar,100),
					new SqlParameter("@BWZW", SqlDbType.VarChar,200),
					new SqlParameter("@BWSJ", SqlDbType.VarChar,50),
					new SqlParameter("@TYPE", SqlDbType.VarChar,50),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4),
					new SqlParameter("@BWNO", SqlDbType.VarChar,50)};
			parameters[0].Value = model.CJZ;
			parameters[1].Value = model.TITLE;
			parameters[2].Value = model.BWZW;
			parameters[3].Value = model.BWSJ;
			parameters[4].Value = model.TYPE;
			parameters[5].Value = model.DJSJ;
			parameters[6].Value = model.JLZT;
			parameters[7].Value = model.LSH;
			parameters[8].Value = model.BWNO;

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
			strSql.Append("delete from YW_BEIWANG ");
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
		public bool Delete(string BWNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from YW_BEIWANG ");
			strSql.Append(" where BWNO=@BWNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@BWNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = BWNO;

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
			strSql.Append("delete from YW_BEIWANG ");
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
		public Maticsoft.Model.YW_BEIWANG GetModel(int LSH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LSH,BWNO,CJZ,TITLE,BWZW,BWSJ,TYPE,DJSJ,JLZT from YW_BEIWANG ");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
			parameters[0].Value = LSH;

			Maticsoft.Model.YW_BEIWANG model=new Maticsoft.Model.YW_BEIWANG();
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
		public Maticsoft.Model.YW_BEIWANG DataRowToModel(DataRow row)
		{
			Maticsoft.Model.YW_BEIWANG model=new Maticsoft.Model.YW_BEIWANG();
			if (row != null)
			{
				if(row["LSH"]!=null && row["LSH"].ToString()!="")
				{
					model.LSH=int.Parse(row["LSH"].ToString());
				}
				if(row["BWNO"]!=null)
				{
					model.BWNO=row["BWNO"].ToString();
				}
				if(row["CJZ"]!=null)
				{
					model.CJZ=row["CJZ"].ToString();
				}
				if(row["TITLE"]!=null)
				{
					model.TITLE=row["TITLE"].ToString();
				}
				if(row["BWZW"]!=null)
				{
					model.BWZW=row["BWZW"].ToString();
				}
				if(row["BWSJ"]!=null)
				{
					model.BWSJ=row["BWSJ"].ToString();
				}
				if(row["TYPE"]!=null)
				{
					model.TYPE=row["TYPE"].ToString();
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
			strSql.Append("select LSH,BWNO,CJZ,TITLE,BWZW,BWSJ,TYPE,DJSJ,JLZT ");
			strSql.Append(" FROM YW_BEIWANG ");
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
			strSql.Append(" LSH,BWNO,CJZ,TITLE,BWZW,BWSJ,TYPE,DJSJ,JLZT ");
			strSql.Append(" FROM YW_BEIWANG ");
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
			strSql.Append("select count(1) FROM YW_BEIWANG ");
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
			strSql.Append(")AS Row, T.*  from YW_BEIWANG T ");
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
			parameters[0].Value = "YW_BEIWANG";
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
        public static DataSet GetBeiWangList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_BeiWangList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }
        public static DataSet GetBeiWangList(string key, string keyvalue)
        {
            string sql = "select * from YW_BEIWANG where jlzt=0 and " + key + "=@keyvalue";
            return SqlDataProvider.GetResultBySql(sql, SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.VarChar, keyvalue));
        }

        public static DataTable GetBeiWangList()
        {
            return CommonDAL.GetObjList("YW_BEIWANG");
        }
        public static string GetBeiWangNo()
        {
            string no = null;
            DataSet ds = SqlDataProvider.GetResultBySql("select LSH from YW_BEIWANG order by LSH desc",
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

        public static int SaveData(BeiWangInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = BeiWangDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = BeiWangDAL.InsertCommand(model);
            }
            return result;
        }

        /// <summary>
        /// 修改备忘
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(BeiWangInfo model)
        {
            int num = CommonDAL.ObjectExists("YW_BEIWANG", " and lsh =" + model.LSH.ToString());
            if (num <= 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("UPDATE [YW_BEIWANG]");
                strSql.AppendLine("SET [TITLE] = @title");
                strSql.AppendLine("  ,[BWZW] = @content");
                strSql.AppendLine("  ,[BWSJ] = @date");
                strSql.AppendLine(" WHERE lsh=@lsh");

                SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,100),
                    new SqlParameter("@content", SqlDbType.VarChar,200),
                    new SqlParameter("@date", SqlDbType.VarChar,50),
                    new SqlParameter("@lsh", SqlDbType.VarChar,50)};
                parameters[0].Value = model.TITLE;
                parameters[1].Value = model.BWZW;
                parameters[2].Value = model.BWSJ;
                parameters[3].Value = model.LSH.ToString();

                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
        public static int InsertCommand(BeiWangInfo model)
        {
            //先判断资料是否存在
            int num = CommonDAL.ObjectExists("YW_BEIWANG", "and BWNO='" + model.BWNO + "'");
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("INSERT INTO [YW_BEIWANG]");
                sb.AppendLine("([BWNO]");
                sb.AppendLine(",[CJZ]");
                sb.AppendLine(",[TITLE]");
                sb.AppendLine(",[BWZW]");
                sb.AppendLine(",[BWSJ]");
                sb.AppendLine(",[TYPE])");  
                sb.AppendLine("VALUES");
                sb.AppendLine("(@bwno");
                sb.AppendLine(",@cjz");
                sb.AppendLine(",@title");
                sb.AppendLine(",@content");
                sb.AppendLine(",@date");
                sb.AppendLine(",@type)");
                sb.AppendLine(";select @@IDENTITY");

                SqlParameter[] parameters = {
                    new SqlParameter("@bwno", SqlDbType.VarChar,50),
                    new SqlParameter("@cjz", SqlDbType.VarChar,50),
                    new SqlParameter("@title", SqlDbType.VarChar,100),
                    new SqlParameter("@content", SqlDbType.VarChar,200),
					new SqlParameter("@date", SqlDbType.VarChar,50),
					new SqlParameter("@type", SqlDbType.VarChar,50)};
                parameters[0].Value = model.BWNO;
                parameters[1].Value = model.CJZ;
                parameters[2].Value = model.TITLE;
                parameters[3].Value = model.BWZW;
                parameters[4].Value = model.BWSJ;
                parameters[5].Value = model.TYPE;

                object obj = DbHelperSQL.GetSingle(sb.ToString(), parameters);
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
