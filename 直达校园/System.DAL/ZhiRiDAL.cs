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
    public class ZhiRiDAL
    {
        public ZhiRiDAL()
        { }
        #region  BasicMethod
        /*
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string WNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from YW_ZHIRI");
			strSql.Append(" where WNO=@WNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@WNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = WNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.YW_ZHIRI model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YW_ZHIRI(");
			strSql.Append("WNO,TGH,MON,TUE,WED,THU,FRI,ZRNR,DJSJ,JLZT)");
			strSql.Append(" values (");
			strSql.Append("@WNO,@TGH,@MON,@TUE,@WED,@THU,@FRI,@ZRNR,@DJSJ,@JLZT)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@WNO", SqlDbType.VarChar,50),
					new SqlParameter("@TGH", SqlDbType.VarChar,50),
					new SqlParameter("@MON", SqlDbType.VarChar,100),
					new SqlParameter("@TUE", SqlDbType.VarChar,100),
					new SqlParameter("@WED", SqlDbType.VarChar,100),
					new SqlParameter("@THU", SqlDbType.VarChar,100),
					new SqlParameter("@FRI", SqlDbType.VarChar,100),
					new SqlParameter("@ZRNR", SqlDbType.VarChar,200),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50)};
			parameters[0].Value = model.WNO;
			parameters[1].Value = model.TGH;
			parameters[2].Value = model.MON;
			parameters[3].Value = model.TUE;
			parameters[4].Value = model.WED;
			parameters[5].Value = model.THU;
			parameters[6].Value = model.FRI;
			parameters[7].Value = model.ZRNR;
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
		public bool Update(Maticsoft.Model.YW_ZHIRI model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YW_ZHIRI set ");
			strSql.Append("TGH=@TGH,");
			strSql.Append("MON=@MON,");
			strSql.Append("TUE=@TUE,");
			strSql.Append("WED=@WED,");
			strSql.Append("THU=@THU,");
			strSql.Append("FRI=@FRI,");
			strSql.Append("ZRNR=@ZRNR,");
			strSql.Append("DJSJ=@DJSJ,");
			strSql.Append("JLZT=@JLZT");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@TGH", SqlDbType.VarChar,50),
					new SqlParameter("@MON", SqlDbType.VarChar,100),
					new SqlParameter("@TUE", SqlDbType.VarChar,100),
					new SqlParameter("@WED", SqlDbType.VarChar,100),
					new SqlParameter("@THU", SqlDbType.VarChar,100),
					new SqlParameter("@FRI", SqlDbType.VarChar,100),
					new SqlParameter("@ZRNR", SqlDbType.VarChar,200),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4),
					new SqlParameter("@WNO", SqlDbType.VarChar,50)};
			parameters[0].Value = model.TGH;
			parameters[1].Value = model.MON;
			parameters[2].Value = model.TUE;
			parameters[3].Value = model.WED;
			parameters[4].Value = model.THU;
			parameters[5].Value = model.FRI;
			parameters[6].Value = model.ZRNR;
			parameters[7].Value = model.DJSJ;
			parameters[8].Value = model.JLZT;
			parameters[9].Value = model.LSH;
			parameters[10].Value = model.WNO;

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
			strSql.Append("delete from YW_ZHIRI ");
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
		public bool Delete(string WNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from YW_ZHIRI ");
			strSql.Append(" where WNO=@WNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@WNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = WNO;

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
			strSql.Append("delete from YW_ZHIRI ");
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
		public Maticsoft.Model.YW_ZHIRI GetModel(int LSH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LSH,WNO,TGH,MON,TUE,WED,THU,FRI,ZRNR,DJSJ,JLZT from YW_ZHIRI ");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
			parameters[0].Value = LSH;

			Maticsoft.Model.YW_ZHIRI model=new Maticsoft.Model.YW_ZHIRI();
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
		public Maticsoft.Model.YW_ZHIRI DataRowToModel(DataRow row)
		{
			Maticsoft.Model.YW_ZHIRI model=new Maticsoft.Model.YW_ZHIRI();
			if (row != null)
			{
				if(row["LSH"]!=null && row["LSH"].ToString()!="")
				{
					model.LSH=int.Parse(row["LSH"].ToString());
				}
				if(row["WNO"]!=null)
				{
					model.WNO=row["WNO"].ToString();
				}
				if(row["TGH"]!=null)
				{
					model.TGH=row["TGH"].ToString();
				}
				if(row["MON"]!=null)
				{
					model.MON=row["MON"].ToString();
				}
				if(row["TUE"]!=null)
				{
					model.TUE=row["TUE"].ToString();
				}
				if(row["WED"]!=null)
				{
					model.WED=row["WED"].ToString();
				}
				if(row["THU"]!=null)
				{
					model.THU=row["THU"].ToString();
				}
				if(row["FRI"]!=null)
				{
					model.FRI=row["FRI"].ToString();
				}
				if(row["ZRNR"]!=null)
				{
					model.ZRNR=row["ZRNR"].ToString();
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
			strSql.Append("select LSH,WNO,TGH,MON,TUE,WED,THU,FRI,ZRNR,DJSJ,JLZT ");
			strSql.Append(" FROM YW_ZHIRI ");
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
			strSql.Append(" LSH,WNO,TGH,MON,TUE,WED,THU,FRI,ZRNR,DJSJ,JLZT ");
			strSql.Append(" FROM YW_ZHIRI ");
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
			strSql.Append("select count(1) FROM YW_ZHIRI ");
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
			strSql.Append(")AS Row, T.*  from YW_ZHIRI T ");
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
            parameters[0].Value = "YW_ZHIRI";
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
        public static DataSet GetZhiRiList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_ZhiRiList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }

        public static DataSet GetZhiRiList(string lsh)
        {
            return SqlDataProvider.GetResultBySql("select * from YW_ZHIRI where jlzt=0 and lsh=@lsh",
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.VarChar, lsh));
        }

        public static DataTable GetZhiRiList()
        {
            return CommonDAL.GetObjList("YW_ZHIRI");
        }

        public static string GetZhiRiNo()
        {
            string wno = null;
            DataSet ds = SqlDataProvider.GetResultBySql("select LSH from YW_ZHIRI order by LSH desc",
                null);
            if (ds.Tables[0].Rows.Count == 0)
            {
                wno = "1";
            }
            else
            {
                string s = ds.Tables[0].Rows[0]["LSH"].ToString();
                wno = ((int.Parse(s)) + 1).ToString();
            }
            return wno;
        }   

        public static int SaveData(ZhiRiInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = ZhiRiDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = ZhiRiDAL.InsertCommand(model);
            }
            return result;
        }

        /// <summary>
        /// 修改值日
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(ZhiRiInfo model)
        {
            int num = CommonDAL.ObjectExists("YW_ZHIRI", "and WNO='" + model.WNO + "' and TGH='" + model.TGH 
                + "' and lsh !=" + model.LSH.ToString());
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("UPDATE [YW_ZHIRI]");
                strSql.AppendLine("SET [MON] = @mon");
                strSql.AppendLine("  ,[TUE] = @tue");
                strSql.AppendLine("  ,[WED] = @wed");
                strSql.AppendLine("  ,[THU] = @thu");
                strSql.AppendLine("  ,[FRI] = @fri");
                strSql.AppendLine("  ,[ZRNR] = @content");
                strSql.AppendLine("  ,[CLASSNO] = @classno");
                strSql.AppendLine("  ,[XNNO] = @xnno");
                strSql.AppendLine("  ,[XQNO] = @xqno");
                strSql.AppendLine(" WHERE lsh=@lsh");

                SqlParameter[] parameters = {
					new SqlParameter("@mon", SqlDbType.VarChar,100),
					new SqlParameter("@tue", SqlDbType.VarChar,100),
                    new SqlParameter("@wed", SqlDbType.VarChar,100),
                    new SqlParameter("@thu", SqlDbType.VarChar,100),
                    new SqlParameter("@fri", SqlDbType.VarChar,100),
                    new SqlParameter("@content", SqlDbType.VarChar,200), 
                    new SqlParameter("@classno", SqlDbType.VarChar,50), 
                    new SqlParameter("@xnno", SqlDbType.VarChar,50), 
                    new SqlParameter("@xqno", SqlDbType.VarChar,50),
                    new SqlParameter("@lsh", SqlDbType.VarChar,20)};
                parameters[0].Value = model.MON;
                parameters[1].Value = model.TUE;
                parameters[2].Value = model.WED;
                parameters[3].Value = model.THU;
                parameters[4].Value = model.FRI;
                parameters[5].Value = model.ZRNR;
                parameters[6].Value = model.ClassNo;
                parameters[7].Value = model.XNNO;
                parameters[8].Value = model.XQNO;
                parameters[9].Value = model.LSH.ToString();

                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
        //public static bool UpdateCommand(string username, string connphone, string cardid, string zc, string lsh)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("UPDATE [YW_ZHIRI]");
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
        public static bool UpdateState(string lsh,string state)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE [YW_ZHIRI]");
            sb.AppendLine("SET [STATE] = @state");
            sb.AppendLine(" WHERE lsh=@lsh");
            int temp = SqlDataProvider.ExecuteBySql(sb.ToString(),
                SqlDataProvider.CreateSqlParameter("@state", SqlDbType.VarChar, state),
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.Int, lsh)
                );
            return temp >= 0 ? true : false;
        }

        public static int InsertCommand(ZhiRiInfo model)
        {
            //先判断周次是否存在
            int num = CommonDAL.ObjectExists("YW_ZHIRI", "and WNO='" + model.WNO + "'");
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("INSERT INTO [YW_ZHIRI]");
                sb.AppendLine("([WNO]");
                sb.AppendLine(",[TGH]");
                sb.AppendLine(",[MON]");
                sb.AppendLine(",[TUE]");
                sb.AppendLine(",[WED]");
                sb.AppendLine(",[THU]");
                sb.AppendLine(",[FRI]");
                sb.AppendLine(",[CLASSNO]");
                sb.AppendLine(",[SCHOOLNO]");
                sb.AppendLine(",[XNNO]");
                sb.AppendLine(",[XQNO]");
                sb.AppendLine(",[ZRNR])");
                sb.AppendLine("VALUES");
                sb.AppendLine("(@id");
                sb.AppendLine(",@tgh");
                sb.AppendLine(",@mon");
                sb.AppendLine(",@tue");
                sb.AppendLine(",@wed");
                sb.AppendLine(",@thu");
                sb.AppendLine(",@fri");
                sb.AppendLine(",@classno");
                sb.AppendLine(",@schoolno");
                sb.AppendLine(",@xnno");
                sb.AppendLine(",@xqno");
                sb.AppendLine(",@content)");
                sb.AppendLine(";select @@IDENTITY");

                SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.VarChar,50),
					new SqlParameter("@tgh", SqlDbType.VarChar,50),
					new SqlParameter("@mon", SqlDbType.VarChar,100),
					new SqlParameter("@tue", SqlDbType.VarChar,100),
                    new SqlParameter("@wed", SqlDbType.VarChar,100),
                    new SqlParameter("@thu", SqlDbType.VarChar,100),
                    new SqlParameter("@fri", SqlDbType.VarChar,100),
                    new SqlParameter("@classno", SqlDbType.VarChar,50),
                    new SqlParameter("@schoolno", SqlDbType.VarChar,50),
                    new SqlParameter("@xnno", SqlDbType.VarChar,50),
                    new SqlParameter("@xqno", SqlDbType.VarChar,50),
                    new SqlParameter("@content", SqlDbType.VarChar,200)};
                parameters[0].Value = model.WNO;
                parameters[1].Value = model.TGH;
                parameters[2].Value = model.MON;
                parameters[3].Value = model.TUE;
                parameters[4].Value = model.WED;
                parameters[5].Value = model.THU;
                parameters[6].Value = model.FRI;
                parameters[7].Value = model.ClassNo;
                parameters[8].Value = model.SchoolNo;
                parameters[9].Value = model.XNNO;
                parameters[10].Value = model.XQNO;
                parameters[11].Value = model.ZRNR;

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

        public static DataSet GetZhiRiFirst()
        {
            return SqlDataProvider.GetResultBySql("select top 1 * from YW_ZHIRI where state='0' and jlzt=0 order by lsh desc",
                null);
        }
        #endregion  ExtensionMethod
    }
}
