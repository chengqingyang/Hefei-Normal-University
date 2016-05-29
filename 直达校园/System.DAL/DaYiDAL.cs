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
    public class DaYiDAL
    {
        public DaYiDAL()
		{}
		#region  BasicMethod
        /*
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string WTNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from YW_DAYI");
			strSql.Append(" where WTNO=@WTNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@WTNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = WTNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.YW_DAYI model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YW_DAYI(");
			strSql.Append("WTNO,TWZ,CID,BJID,TITLE,WTZW,ANSWER,TWSJ,HDSH,STATE,CLICK,DJSJ,JLZT)");
			strSql.Append(" values (");
			strSql.Append("@WTNO,@TWZ,@CID,@BJID,@TITLE,@WTZW,@ANSWER,@TWSJ,@HDSH,@STATE,@CLICK,@DJSJ,@JLZT)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@WTNO", SqlDbType.VarChar,50),
					new SqlParameter("@TWZ", SqlDbType.VarChar,50),
					new SqlParameter("@CID", SqlDbType.VarChar,50),
					new SqlParameter("@BJID", SqlDbType.VarChar,50),
					new SqlParameter("@TITLE", SqlDbType.VarChar,100),
					new SqlParameter("@WTZW", SqlDbType.VarChar,200),
					new SqlParameter("@ANSWER", SqlDbType.VarChar,200),
					new SqlParameter("@TWSJ", SqlDbType.VarChar,50),
					new SqlParameter("@HDSH", SqlDbType.VarChar,50),
					new SqlParameter("@STATE", SqlDbType.VarChar,50),
					new SqlParameter("@CLICK", SqlDbType.Int,4),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50)};
			parameters[0].Value = model.WTNO;
			parameters[1].Value = model.TWZ;
			parameters[2].Value = model.CID;
			parameters[3].Value = model.BJID;
			parameters[4].Value = model.TITLE;
			parameters[5].Value = model.WTZW;
			parameters[6].Value = model.ANSWER;
			parameters[7].Value = model.TWSJ;
			parameters[8].Value = model.HDSH;
			parameters[9].Value = model.STATE;
			parameters[10].Value = model.CLICK;
			parameters[11].Value = model.DJSJ;
			parameters[12].Value = model.JLZT;

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
		public bool Update(Maticsoft.Model.YW_DAYI model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YW_DAYI set ");
			strSql.Append("TWZ=@TWZ,");
			strSql.Append("CID=@CID,");
			strSql.Append("BJID=@BJID,");
			strSql.Append("TITLE=@TITLE,");
			strSql.Append("WTZW=@WTZW,");
			strSql.Append("ANSWER=@ANSWER,");
			strSql.Append("TWSJ=@TWSJ,");
			strSql.Append("HDSH=@HDSH,");
			strSql.Append("STATE=@STATE,");
			strSql.Append("CLICK=@CLICK,");
			strSql.Append("DJSJ=@DJSJ,");
			strSql.Append("JLZT=@JLZT");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@TWZ", SqlDbType.VarChar,50),
					new SqlParameter("@CID", SqlDbType.VarChar,50),
					new SqlParameter("@BJID", SqlDbType.VarChar,50),
					new SqlParameter("@TITLE", SqlDbType.VarChar,100),
					new SqlParameter("@WTZW", SqlDbType.VarChar,200),
					new SqlParameter("@ANSWER", SqlDbType.VarChar,200),
					new SqlParameter("@TWSJ", SqlDbType.VarChar,50),
					new SqlParameter("@HDSH", SqlDbType.VarChar,50),
					new SqlParameter("@STATE", SqlDbType.VarChar,50),
					new SqlParameter("@CLICK", SqlDbType.Int,4),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4),
					new SqlParameter("@WTNO", SqlDbType.VarChar,50)};
			parameters[0].Value = model.TWZ;
			parameters[1].Value = model.CID;
			parameters[2].Value = model.BJID;
			parameters[3].Value = model.TITLE;
			parameters[4].Value = model.WTZW;
			parameters[5].Value = model.ANSWER;
			parameters[6].Value = model.TWSJ;
			parameters[7].Value = model.HDSH;
			parameters[8].Value = model.STATE;
			parameters[9].Value = model.CLICK;
			parameters[10].Value = model.DJSJ;
			parameters[11].Value = model.JLZT;
			parameters[12].Value = model.LSH;
			parameters[13].Value = model.WTNO;

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
			strSql.Append("delete from YW_DAYI ");
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
		public bool Delete(string WTNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from YW_DAYI ");
			strSql.Append(" where WTNO=@WTNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@WTNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = WTNO;

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
			strSql.Append("delete from YW_DAYI ");
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
		public Maticsoft.Model.YW_DAYI GetModel(int LSH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LSH,WTNO,TWZ,CID,BJID,TITLE,WTZW,ANSWER,TWSJ,HDSH,STATE,CLICK,DJSJ,JLZT from YW_DAYI ");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
			parameters[0].Value = LSH;

			Maticsoft.Model.YW_DAYI model=new Maticsoft.Model.YW_DAYI();
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
		public Maticsoft.Model.YW_DAYI DataRowToModel(DataRow row)
		{
			Maticsoft.Model.YW_DAYI model=new Maticsoft.Model.YW_DAYI();
			if (row != null)
			{
				if(row["LSH"]!=null && row["LSH"].ToString()!="")
				{
					model.LSH=int.Parse(row["LSH"].ToString());
				}
				if(row["WTNO"]!=null)
				{
					model.WTNO=row["WTNO"].ToString();
				}
				if(row["TWZ"]!=null)
				{
					model.TWZ=row["TWZ"].ToString();
				}
				if(row["CID"]!=null)
				{
					model.CID=row["CID"].ToString();
				}
				if(row["BJID"]!=null)
				{
					model.BJID=row["BJID"].ToString();
				}
				if(row["TITLE"]!=null)
				{
					model.TITLE=row["TITLE"].ToString();
				}
				if(row["WTZW"]!=null)
				{
					model.WTZW=row["WTZW"].ToString();
				}
				if(row["ANSWER"]!=null)
				{
					model.ANSWER=row["ANSWER"].ToString();
				}
				if(row["TWSJ"]!=null)
				{
					model.TWSJ=row["TWSJ"].ToString();
				}
				if(row["HDSH"]!=null)
				{
					model.HDSH=row["HDSH"].ToString();
				}
				if(row["STATE"]!=null)
				{
					model.STATE=row["STATE"].ToString();
				}
				if(row["CLICK"]!=null && row["CLICK"].ToString()!="")
				{
					model.CLICK=int.Parse(row["CLICK"].ToString());
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
			strSql.Append("select LSH,WTNO,TWZ,CID,BJID,TITLE,WTZW,ANSWER,TWSJ,HDSH,STATE,CLICK,DJSJ,JLZT ");
			strSql.Append(" FROM YW_DAYI ");
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
			strSql.Append(" LSH,WTNO,TWZ,CID,BJID,TITLE,WTZW,ANSWER,TWSJ,HDSH,STATE,CLICK,DJSJ,JLZT ");
			strSql.Append(" FROM YW_DAYI ");
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
			strSql.Append("select count(1) FROM YW_DAYI ");
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
			strSql.Append(")AS Row, T.*  from YW_DAYI T ");
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
			parameters[0].Value = "YW_DAYI";
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
        public static DataSet GetDaYiList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_DaYiList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }
        public static DataSet GetDaYiList(string key, string keyvalue)
        {
            string sql = "select * from YW_DAYI where jlzt=0 and " + key + "=@keyvalue";
            return SqlDataProvider.GetResultBySql(sql, SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.VarChar, keyvalue));
        }
        
        public static DataTable GetDaYiList()
        {
            return CommonDAL.GetObjList("YW_DAYI");
        }
        public static string GetDaYiNo()
        {
            string no = null;
            DataSet ds = SqlDataProvider.GetResultBySql("select LSH from YW_DAYI order by LSH desc",
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

        public static int SaveData(DaYiInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = DaYiDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = DaYiDAL.InsertCommand(model);
            }
            return result;
        }

        /// <summary>
        /// 修改作业
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(DaYiInfo model)
        {
            int num = CommonDAL.ObjectExists("YW_DAYI", " and lsh =" + model.LSH.ToString());
            if (num <= 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("UPDATE [YW_DAYI]");
                strSql.AppendLine("SET [CID] = @cid");
                strSql.AppendLine("  ,[TITLE] = @title");
                strSql.AppendLine("  ,[WTZW] = @content");
                strSql.AppendLine("  ,[ANSWER] = @answer");
                strSql.AppendLine("  ,[HDSJ] = @hdsj");
                strSql.AppendLine("  ,[STATE] = @state");
                strSql.AppendLine(" WHERE lsh=@lsh");

                SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,100),
                    new SqlParameter("@content", SqlDbType.VarChar,200),
                    new SqlParameter("@answer", SqlDbType.VarChar,200),
                    new SqlParameter("@hdsj", SqlDbType.VarChar,50),
                    new SqlParameter("@state", SqlDbType.VarChar,50),
                    new SqlParameter("@lsh", SqlDbType.VarChar,50)};
                parameters[0].Value = model.CID;
                parameters[1].Value = model.TITLE;
                parameters[2].Value = model.WTZW;
                parameters[3].Value = model.ANSWER;
                parameters[4].Value = model.HDSJ;
                parameters[5].Value = model.STATE;
                parameters[6].Value = model.LSH.ToString();

                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
        /// <summary>
        /// 更新下载次数
        /// </summary>
        /// <param name="zlno"></param>
        /// <returns></returns>
        public static bool UpdateClick(string wtno)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE [YW_DAYI]");
            sb.AppendLine("SET [CLICK] = [CLICK]+1");
            sb.AppendLine(" WHERE WTNO=@wtno");
            int temp = SqlDataProvider.ExecuteBySql(sb.ToString(),
                SqlDataProvider.CreateSqlParameter("@wtno", SqlDbType.Int, wtno)
                );
            return temp >= 0 ? true : false;
        }
        //public static bool UpdateCommand(string username, string connphone, string cardid, string zc, string lsh)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("UPDATE [YW_DAYI]");
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

        public static int InsertCommand(DaYiInfo model)
        {
            //先判断资料是否存在
            int num = CommonDAL.ObjectExists("YW_DAYI", "and WTNO='" + model.WTNO + "'");
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("INSERT INTO [YW_DAYI]");
                sb.AppendLine("([WTNO]");
                sb.AppendLine(",[TWZ]");
                sb.AppendLine(",[CID]");
                sb.AppendLine(",[TITLE]");
                sb.AppendLine(",[WTZW]");
                sb.AppendLine(",[TWSJ])");
                //sb.AppendLine(",[SCSJ]");                
                //sb.AppendLine(",[STATE]");
                //sb.AppendLine(",[XZCS])");
                sb.AppendLine("VALUES");
                sb.AppendLine("(@wtno");
                sb.AppendLine(",@twz");
                sb.AppendLine(",@cid");
                sb.AppendLine(",@title");
                sb.AppendLine(",@content");
                sb.AppendLine(",@twsj)");
                //sb.AppendLine(",@date");
                //sb.AppendLine(",@state");
                //sb.AppendLine(",@download)");
                sb.AppendLine(";select @@IDENTITY");

                SqlParameter[] parameters = {
                    new SqlParameter("@wtno", SqlDbType.VarChar,50),
                    new SqlParameter("@twz", SqlDbType.VarChar,50),
                    new SqlParameter("@cid", SqlDbType.VarChar,50),
					new SqlParameter("@title", SqlDbType.VarChar,256),
                    new SqlParameter("@content", SqlDbType.VarChar,256),
					new SqlParameter("@twsj", SqlDbType.VarChar,50)};
                    //new SqlParameter("@date", SqlDbType.VarChar,50),
                    //new SqlParameter("@state", SqlDbType.VarChar,50),
                    //new SqlParameter("@download", SqlDbType.Int,4)};
                parameters[0].Value = model.WTNO;
                parameters[1].Value = model.TWZ;
                parameters[2].Value = model.CID;
                parameters[3].Value = model.TITLE;
                parameters[4].Value = model.WTZW;
                parameters[5].Value = model.TWSJ;
                //parameters[6].Value = model.SCSJ;
                //parameters[7].Value = model.STATE;
                //parameters[8].Value = model.XZCS;

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
