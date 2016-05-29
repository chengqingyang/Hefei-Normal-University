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
    public class PingJiaDAL
    {
        public PingJiaDAL()
        { }
        #region  BasicMethod
        /*
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string PJNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from YW_PINGJIA");
			strSql.Append(" where PJNO=@PJNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@PJNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = PJNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.YW_PINGJIA model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YW_PINGJIA(");
			strSql.Append("PJNO,SNO,TGH,PF,PY,PJSJ,FLAG,STATE,DJSJ,JLZT)");
			strSql.Append(" values (");
			strSql.Append("@PJNO,@SNO,@TGH,@PF,@PY,@PJSJ,@FLAG,@STATE,@DJSJ,@JLZT)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PJNO", SqlDbType.VarChar,50),
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@TGH", SqlDbType.VarChar,50),
					new SqlParameter("@PF", SqlDbType.Int,4),
					new SqlParameter("@PY", SqlDbType.VarChar,100),
					new SqlParameter("@PJSJ", SqlDbType.VarChar,50),
					new SqlParameter("@FLAG", SqlDbType.VarChar,50),
					new SqlParameter("@STATE", SqlDbType.VarChar,50),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50)};
			parameters[0].Value = model.PJNO;
			parameters[1].Value = model.SNO;
			parameters[2].Value = model.TGH;
			parameters[3].Value = model.PF;
			parameters[4].Value = model.PY;
			parameters[5].Value = model.PJSJ;
			parameters[6].Value = model.FLAG;
			parameters[7].Value = model.STATE;
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
		public bool Update(Maticsoft.Model.YW_PINGJIA model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YW_PINGJIA set ");
			strSql.Append("SNO=@SNO,");
			strSql.Append("TGH=@TGH,");
			strSql.Append("PF=@PF,");
			strSql.Append("PY=@PY,");
			strSql.Append("PJSJ=@PJSJ,");
			strSql.Append("FLAG=@FLAG,");
			strSql.Append("STATE=@STATE,");
			strSql.Append("DJSJ=@DJSJ,");
			strSql.Append("JLZT=@JLZT");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@TGH", SqlDbType.VarChar,50),
					new SqlParameter("@PF", SqlDbType.Int,4),
					new SqlParameter("@PY", SqlDbType.VarChar,100),
					new SqlParameter("@PJSJ", SqlDbType.VarChar,50),
					new SqlParameter("@FLAG", SqlDbType.VarChar,50),
					new SqlParameter("@STATE", SqlDbType.VarChar,50),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4),
					new SqlParameter("@PJNO", SqlDbType.VarChar,50)};
			parameters[0].Value = model.SNO;
			parameters[1].Value = model.TGH;
			parameters[2].Value = model.PF;
			parameters[3].Value = model.PY;
			parameters[4].Value = model.PJSJ;
			parameters[5].Value = model.FLAG;
			parameters[6].Value = model.STATE;
			parameters[7].Value = model.DJSJ;
			parameters[8].Value = model.JLZT;
			parameters[9].Value = model.LSH;
			parameters[10].Value = model.PJNO;

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
			strSql.Append("delete from YW_PINGJIA ");
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
		public bool Delete(string PJNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from YW_PINGJIA ");
			strSql.Append(" where PJNO=@PJNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@PJNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = PJNO;

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
			strSql.Append("delete from YW_PINGJIA ");
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
		public Maticsoft.Model.YW_PINGJIA GetModel(int LSH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LSH,PJNO,SNO,TGH,PF,PY,PJSJ,FLAG,STATE,DJSJ,JLZT from YW_PINGJIA ");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
			parameters[0].Value = LSH;

			Maticsoft.Model.YW_PINGJIA model=new Maticsoft.Model.YW_PINGJIA();
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
		public Maticsoft.Model.YW_PINGJIA DataRowToModel(DataRow row)
		{
			Maticsoft.Model.YW_PINGJIA model=new Maticsoft.Model.YW_PINGJIA();
			if (row != null)
			{
				if(row["LSH"]!=null && row["LSH"].ToString()!="")
				{
					model.LSH=int.Parse(row["LSH"].ToString());
				}
				if(row["PJNO"]!=null)
				{
					model.PJNO=row["PJNO"].ToString();
				}
				if(row["SNO"]!=null)
				{
					model.SNO=row["SNO"].ToString();
				}
				if(row["TGH"]!=null)
				{
					model.TGH=row["TGH"].ToString();
				}
				if(row["PF"]!=null && row["PF"].ToString()!="")
				{
					model.PF=int.Parse(row["PF"].ToString());
				}
				if(row["PY"]!=null)
				{
					model.PY=row["PY"].ToString();
				}
				if(row["PJSJ"]!=null)
				{
					model.PJSJ=row["PJSJ"].ToString();
				}
				if(row["FLAG"]!=null)
				{
					model.FLAG=row["FLAG"].ToString();
				}
				if(row["STATE"]!=null)
				{
					model.STATE=row["STATE"].ToString();
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
			strSql.Append("select LSH,PJNO,SNO,TGH,PF,PY,PJSJ,FLAG,STATE,DJSJ,JLZT ");
			strSql.Append(" FROM YW_PINGJIA ");
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
			strSql.Append(" LSH,PJNO,SNO,TGH,PF,PY,PJSJ,FLAG,STATE,DJSJ,JLZT ");
			strSql.Append(" FROM YW_PINGJIA ");
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
			strSql.Append("select count(1) FROM YW_PINGJIA ");
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
			strSql.Append(")AS Row, T.*  from YW_PINGJIA T ");
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
            parameters[0].Value = "YW_PINGJIA";
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
        public static DataSet GetPingJiaList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_PingJiaList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }
        //public static DataSet GetPingJiaList()
        //{
        //    return SqlDataProvider.GetResultBySql("select * from YW_PINGJIA where jlzt=0 and " + key + "=@keyvalue",
        //        SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.VarChar, keyvalue));
        //}
        public static DataSet GetPingJiaList(string key, string keyvalue)
        {
            string sql = "select A.*,sname,tname from YW_PINGJIA A,YW_STUDENT B,YW_TEACHER C where A.sno=B.sno"
                + " and A.tgh=C.tgh and A.jlzt=0 and A." + key + "=@keyvalue";
            return SqlDataProvider.GetResultBySql(sql,SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.VarChar, keyvalue));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag">记录类型0--教师，1--学生，""--所有</param>
        /// <param name="key"></param>
        /// <param name="keyvalue"></param>
        /// <returns></returns>
        public static DataSet GetPingJiaList(string flag,string key, string keyvalue)
        {
            string sql = "select A.*,sname,tname from YW_PINGJIA A,YW_STUDENT B,YW_TEACHER C where A.sno=B.sno"
                + " and A.tgh=C.tgh and A.jlzt=0 and flag like '"+flag+"%' and A." + key + "=@keyvalue";
            return SqlDataProvider.GetResultBySql(sql, SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.VarChar, keyvalue));
        }

        public static DataTable GetPingJiaList()
        {
            return CommonDAL.GetObjList("YW_PINGJIA");
        }
        public static bool GetPingJiaState(string lsh,ref DataSet ds)
        {
            bool ret = false;
            string sql = "select A.*,sname,tname from YW_PINGJIA A,YW_STUDENT B,YW_TEACHER C where A.sno=B.sno"
                + " and A.tgh=C.tgh and A.jlzt=0 and A.lsh=@lsh";
            ds= SqlDataProvider.GetResultBySql(sql, SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.VarChar, lsh));
            if(ds.Tables[0].Rows.Count>0)
            {
                string state = ds.Tables[0].Rows[0]["state"].ToString();
                if(state=="0")
                    ret = true;
            }
            else
            {
                ds = null;
            }
            return ret;
        }
        public static DataSet GetTeacherPingJia(string tgh)
        {
            string sql = "select * from YW_PINGJIA where flag='0'  and state='1' and tgh='"+tgh+"';select * from"
                + " YW_PINGJIA where flag='0' and tgh='" + tgh + "';select avg(pf) as PJF from YW_PINGJIA where flag='0'"
                +" and state='1' and tgh='"+tgh+"'";
            return SqlDataProvider.GetResultBySql(sql, null);
        }
        /// <summary>
        /// 未完全实现，暂不能用
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public static DataSet GetPingJiaListByTGH(string lsh)
        {
            return SqlDataProvider.GetResultBySql("select * from YW_PINGJIA where jlzt=0 and lsh=@lsh",
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.VarChar, lsh));
        }

        public static string GetPingJiaNo()
        {
            string pjno = null;
            DataSet ds = SqlDataProvider.GetResultBySql("select LSH from YW_PINGJIA order by LSH desc",
                null);
            if (ds.Tables[0].Rows.Count == 0)
            {
                pjno = "1";
            }
            else
            {
                string s = ds.Tables[0].Rows[0]["LSH"].ToString();
                pjno = ((int.Parse(s)) + 1).ToString();
            }
            return pjno;
        }

        public static int SaveData(PingJiaInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = PingJiaDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = PingJiaDAL.InsertCommand(model);
            }
            return result;
        }

        /// <summary>
        /// 修改作业
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(PingJiaInfo model)
        {
            int num = CommonDAL.ObjectExists("YW_PINGJIA", " and lsh =" + model.LSH.ToString());
            if (num <= 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("UPDATE [YW_PINGJIA]");
                strSql.AppendLine("SET [PJSJ] = @date");
                strSql.AppendLine("  ,[PY] = @text");
                strSql.AppendLine("  ,[PF] = @pf");
                strSql.AppendLine("  ,[STATE] = @state");
                strSql.AppendLine(" WHERE lsh=@lsh");

                SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.VarChar,50),
					new SqlParameter("@text", SqlDbType.VarChar,100),
                    new SqlParameter("@pf", SqlDbType.VarChar,50),
                    new SqlParameter("@state", SqlDbType.VarChar,50),
                    new SqlParameter("@lsh", SqlDbType.VarChar,50)};
                parameters[0].Value = model.PJSJ;
                parameters[1].Value = model.PY;
                parameters[2].Value = model.PF;
                parameters[3].Value = model.STATE;
                parameters[4].Value = model.LSH.ToString();

                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
        //public static bool UpdateCommand(string username, string connphone, string cardid, string zc, string lsh)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("UPDATE [YW_PINGJIA]");
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

        public static int InsertCommand(PingJiaInfo model)
        {
            //先判断周次是否存在
            int num = CommonDAL.ObjectExists("YW_PINGJIA", "and PJNO='" + model.PJNO + "'");
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("INSERT INTO [YW_PINGJIA]");
                sb.AppendLine("([PJNO]");
                sb.AppendLine(",[SNO]");
                sb.AppendLine(",[TGH]");
                sb.AppendLine(",[FLAG]");
                sb.AppendLine(",[STATE])");
                sb.AppendLine("VALUES");
                sb.AppendLine("(@pjno");
                sb.AppendLine(",@sno");
                sb.AppendLine(",@tgh");
                sb.AppendLine(",@flag");
                sb.AppendLine(",@state)");
                sb.AppendLine(";select @@IDENTITY");

                SqlParameter[] parameters = {
                    new SqlParameter("@pjno", SqlDbType.VarChar,50),
                    new SqlParameter("@sno", SqlDbType.VarChar,50),
					new SqlParameter("@tgh", SqlDbType.VarChar,50),
					new SqlParameter("@flag", SqlDbType.VarChar,50),
                    new SqlParameter("@state", SqlDbType.VarChar,50)};
                parameters[0].Value = model.PJNO;
                parameters[2].Value = model.SNO;
                parameters[1].Value = model.TGH;
                parameters[3].Value = model.FLAG;
                parameters[5].Value = model.STATE;

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

        public static DataSet GetPingJiaFirst()
        {
            return SqlDataProvider.GetResultBySql("select top 1 * from YW_PINGJIA where jlzt=0 order by lsh desc",
                null);
        }
        #endregion  ExtensionMethod
    }
}
