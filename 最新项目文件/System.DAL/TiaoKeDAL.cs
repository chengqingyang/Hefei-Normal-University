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
    public class TiaoKeDAL
    {
        public TiaoKeDAL()
        { }
        #region  BasicMethod
        /*
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string TKNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from YW_TIAOKE");
			strSql.Append(" where TKNO=@TKNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@TKNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = TKNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.YW_TIAOKE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YW_TIAOKE(");
			strSql.Append("TKNO,TGH,TKRQ,TKZW,STATE,READED,DJSJ,JLZT)");
			strSql.Append(" values (");
			strSql.Append("@TKNO,@TGH,@TKRQ,@TKZW,@STATE,@READED,@DJSJ,@JLZT)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TKNO", SqlDbType.VarChar,50),
					new SqlParameter("@TGH", SqlDbType.VarChar,50),
					new SqlParameter("@TKRQ", SqlDbType.VarChar,50),
					new SqlParameter("@TKZW", SqlDbType.VarChar,200),
					new SqlParameter("@STATE", SqlDbType.VarChar,50),
					new SqlParameter("@READED", SqlDbType.VarChar,50),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50)};
			parameters[0].Value = model.TKNO;
			parameters[1].Value = model.TGH;
			parameters[2].Value = model.TKRQ;
			parameters[3].Value = model.TKZW;
			parameters[4].Value = model.STATE;
			parameters[5].Value = model.READED;
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
		public bool Update(Maticsoft.Model.YW_TIAOKE model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YW_TIAOKE set ");
			strSql.Append("TGH=@TGH,");
			strSql.Append("TKRQ=@TKRQ,");
			strSql.Append("TKZW=@TKZW,");
			strSql.Append("STATE=@STATE,");
			strSql.Append("READED=@READED,");
			strSql.Append("DJSJ=@DJSJ,");
			strSql.Append("JLZT=@JLZT");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@TGH", SqlDbType.VarChar,50),
					new SqlParameter("@TKRQ", SqlDbType.VarChar,50),
					new SqlParameter("@TKZW", SqlDbType.VarChar,200),
					new SqlParameter("@STATE", SqlDbType.VarChar,50),
					new SqlParameter("@READED", SqlDbType.VarChar,50),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4),
					new SqlParameter("@TKNO", SqlDbType.VarChar,50)};
			parameters[0].Value = model.TGH;
			parameters[1].Value = model.TKRQ;
			parameters[2].Value = model.TKZW;
			parameters[3].Value = model.STATE;
			parameters[4].Value = model.READED;
			parameters[5].Value = model.DJSJ;
			parameters[6].Value = model.JLZT;
			parameters[7].Value = model.LSH;
			parameters[8].Value = model.TKNO;

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
			strSql.Append("delete from YW_TIAOKE ");
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
		public bool Delete(string TKNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from YW_TIAOKE ");
			strSql.Append(" where TKNO=@TKNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@TKNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = TKNO;

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
			strSql.Append("delete from YW_TIAOKE ");
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
		public Maticsoft.Model.YW_TIAOKE GetModel(int LSH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LSH,TKNO,TGH,TKRQ,TKZW,STATE,READED,DJSJ,JLZT from YW_TIAOKE ");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
			parameters[0].Value = LSH;

			Maticsoft.Model.YW_TIAOKE model=new Maticsoft.Model.YW_TIAOKE();
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
		public Maticsoft.Model.YW_TIAOKE DataRowToModel(DataRow row)
		{
			Maticsoft.Model.YW_TIAOKE model=new Maticsoft.Model.YW_TIAOKE();
			if (row != null)
			{
				if(row["LSH"]!=null && row["LSH"].ToString()!="")
				{
					model.LSH=int.Parse(row["LSH"].ToString());
				}
				if(row["TKNO"]!=null)
				{
					model.TKNO=row["TKNO"].ToString();
				}
				if(row["TGH"]!=null)
				{
					model.TGH=row["TGH"].ToString();
				}
				if(row["TKRQ"]!=null)
				{
					model.TKRQ=row["TKRQ"].ToString();
				}
				if(row["TKZW"]!=null)
				{
					model.TKZW=row["TKZW"].ToString();
				}
				if(row["STATE"]!=null)
				{
					model.STATE=row["STATE"].ToString();
				}
				if(row["READED"]!=null)
				{
					model.READED=row["READED"].ToString();
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
			strSql.Append("select LSH,TKNO,TGH,TKRQ,TKZW,STATE,READED,DJSJ,JLZT ");
			strSql.Append(" FROM YW_TIAOKE ");
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
			strSql.Append(" LSH,TKNO,TGH,TKRQ,TKZW,STATE,READED,DJSJ,JLZT ");
			strSql.Append(" FROM YW_TIAOKE ");
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
			strSql.Append("select count(1) FROM YW_TIAOKE ");
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
			strSql.Append(")AS Row, T.*  from YW_TIAOKE T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}
        */

        /* 自动
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
            parameters[0].Value = "YW_TIAOKE";
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
        public static DataSet GetTiaoKeList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_TiaoKeList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }

        public static DataSet GetTiaoKeList(string lsh)
        {
            return SqlDataProvider.GetResultBySql("select * from YW_TIAOKE where jlzt=0 and lsh=@lsh",
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.VarChar, lsh));
        }

        public static DataTable GetTiaoKeList()
        {
            return CommonDAL.GetObjList("YW_TIAOKE");
        }

        /// <summary>
        /// 为完全实现，暂不能用
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public static DataSet GetTiaoKeListByTGH(string lsh)
        {
            return SqlDataProvider.GetResultBySql("select * from YW_TIAOKE where jlzt=0 and lsh=@lsh",
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.VarChar, lsh));
        }

        public static string GetTiaoKeNo()
        {
            string cno=null;
            DataSet ds = SqlDataProvider.GetResultBySql("select LSH from YW_TIAOKE order by LSH desc",
                null);
            if (ds.Tables[0].Rows.Count==0)
            {
                cno = "1";
            }
            else
            {
                string s = ds.Tables[0].Rows[0]["LSH"].ToString();
                cno = ((int.Parse(s))+1).ToString();
            }
            return cno;
        }        
        
        public static int SaveData(TiaoKeInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = TiaoKeDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = TiaoKeDAL.InsertCommand(model);
            }
            return result;
        }

        /// <summary>
        /// 修改值日
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(TiaoKeInfo model)
        {
            int num = CommonDAL.ObjectExists("YW_TIAOKE", "and TKNO='" + model.TKNO + "' and TGH='" + model.TGH
                + "' and lsh !=" + model.LSH.ToString());
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("UPDATE [YW_TIAOKE]");
                strSql.AppendLine("SET [TKRQ] = @date");
                strSql.AppendLine("  ,[TKZW] = @text");
                strSql.AppendLine("  ,[STATE] = @state");
                strSql.AppendLine("  ,[CLASSNO] = @classno");
                strSql.AppendLine("  ,[XNNO] = @xnno");
                strSql.AppendLine("  ,[XQNO] = @xqno");
                strSql.AppendLine(" WHERE lsh=@lsh");

                SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.VarChar,50),
					new SqlParameter("@text", SqlDbType.VarChar,200),
                    new SqlParameter("@state", SqlDbType.VarChar,50),
                    new SqlParameter("@classno", SqlDbType.VarChar,50),
                    new SqlParameter("@xnno", SqlDbType.VarChar,50),
                    new SqlParameter("@xqno", SqlDbType.VarChar,50),
                    new SqlParameter("@lsh", SqlDbType.VarChar,20)};
                parameters[0].Value = model.TKRQ;
                parameters[1].Value = model.TKZW;
                parameters[2].Value = model.STATE;
                parameters[3].Value = model.ClassNo;
                parameters[4].Value = model.XNNO;
                parameters[5].Value = model.XQNO;
                parameters[6].Value = model.LSH.ToString();

                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
        //public static bool UpdateCommand(string username, string connphone, string cardid, string zc, string lsh)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("UPDATE [YW_TIAOKE]");
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

        public static int InsertCommand(TiaoKeInfo model)
        {
            //先判断周次是否存在
            int num = CommonDAL.ObjectExists("YW_TIAOKE", "and TKNO='" + model.TKNO + "'");
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("INSERT INTO [YW_TIAOKE]");
                sb.AppendLine("([TKNO]");
                sb.AppendLine(",[TGH]");
                sb.AppendLine(",[TKRQ]");
                sb.AppendLine(",[TKZW]");
                sb.AppendLine(",[CLASSNO]");
                sb.AppendLine(",[SCHOOLNO]");
                sb.AppendLine(",[XNNO]");
                sb.AppendLine(",[XQNO]");
                sb.AppendLine(",[STATE])");
                sb.AppendLine("VALUES");
                sb.AppendLine("(@tkno");
                sb.AppendLine(",@tgh");
                sb.AppendLine(",@date");
                sb.AppendLine(",@text");
                sb.AppendLine(",@classno");
                sb.AppendLine(",@schoolno");
                sb.AppendLine(",@xnno");
                sb.AppendLine(",@xqno");
                sb.AppendLine(",@state)");
                sb.AppendLine(";select @@IDENTITY");

                SqlParameter[] parameters = {
                    new SqlParameter("@tkno", SqlDbType.VarChar,50),
					new SqlParameter("@tgh", SqlDbType.VarChar,50),
					new SqlParameter("@date", SqlDbType.VarChar,50),
					new SqlParameter("@text", SqlDbType.VarChar,200),
					new SqlParameter("@classno", SqlDbType.VarChar,50),
					new SqlParameter("@schoolno", SqlDbType.VarChar,50),
					new SqlParameter("@xnno", SqlDbType.VarChar,50),
					new SqlParameter("@xqno", SqlDbType.VarChar,50),
                    new SqlParameter("@state", SqlDbType.VarChar,50)};
                parameters[0].Value = model.TKNO;
                parameters[1].Value = model.TGH;
                parameters[2].Value = model.TKRQ;
                parameters[3].Value = model.TKZW;
                parameters[4].Value = model.ClassNo;
                parameters[5].Value = model.SchoolNo;
                parameters[6].Value = model.XNNO;
                parameters[7].Value = model.XQNO;
                parameters[8].Value = model.STATE;

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

        public static DataSet GetTiaoKeFirst()
        {
            return SqlDataProvider.GetResultBySql("select top 1 * from YW_TIAOKE where jlzt=0 order by lsh desc",
                null);
        }
        #endregion  ExtensionMethod
    }
}
