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
    public class ZiLiaoDAL
    {
        public ZiLiaoDAL()
        { }
        #region  BasicMethod
        /*
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ZLNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from YW_ZILIAO");
			strSql.Append(" where ZLNO=@ZLNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@ZLNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = ZLNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.YW_ZILIAO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YW_ZILIAO(");
			strSql.Append("ZLNO,SCZ,CID,ZLPATH,ZLNAME,FLAG,SCSJ,STATE,XZCS,DJSJ,JLZT)");
			strSql.Append(" values (");
			strSql.Append("@ZLNO,@SCZ,@CID,@ZLPATH,@ZLNAME,@FLAG,@SCSJ,@STATE,@XZCS,@DJSJ,@JLZT)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ZLNO", SqlDbType.VarChar,50),
					new SqlParameter("@SCZ", SqlDbType.VarChar,50),
					new SqlParameter("@CID", SqlDbType.VarChar,50),
					new SqlParameter("@ZLPATH", SqlDbType.VarChar,256),
					new SqlParameter("@ZLNAME", SqlDbType.VarChar,256),
					new SqlParameter("@FLAG", SqlDbType.VarChar,50),
					new SqlParameter("@SCSJ", SqlDbType.VarChar,50),
					new SqlParameter("@STATE", SqlDbType.VarChar,50),
					new SqlParameter("@XZCS", SqlDbType.Int,4),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50)};
			parameters[0].Value = model.ZLNO;
			parameters[1].Value = model.SCZ;
			parameters[2].Value = model.CID;
			parameters[3].Value = model.ZLPATH;
			parameters[4].Value = model.ZLNAME;
			parameters[5].Value = model.FLAG;
			parameters[6].Value = model.SCSJ;
			parameters[7].Value = model.STATE;
			parameters[8].Value = model.XZCS;
			parameters[9].Value = model.DJSJ;
			parameters[10].Value = model.JLZT;

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
		public bool Update(Maticsoft.Model.YW_ZILIAO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YW_ZILIAO set ");
			strSql.Append("SCZ=@SCZ,");
			strSql.Append("CID=@CID,");
			strSql.Append("ZLPATH=@ZLPATH,");
			strSql.Append("ZLNAME=@ZLNAME,");
			strSql.Append("FLAG=@FLAG,");
			strSql.Append("SCSJ=@SCSJ,");
			strSql.Append("STATE=@STATE,");
			strSql.Append("XZCS=@XZCS,");
			strSql.Append("DJSJ=@DJSJ,");
			strSql.Append("JLZT=@JLZT");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@SCZ", SqlDbType.VarChar,50),
					new SqlParameter("@CID", SqlDbType.VarChar,50),
					new SqlParameter("@ZLPATH", SqlDbType.VarChar,256),
					new SqlParameter("@ZLNAME", SqlDbType.VarChar,256),
					new SqlParameter("@FLAG", SqlDbType.VarChar,50),
					new SqlParameter("@SCSJ", SqlDbType.VarChar,50),
					new SqlParameter("@STATE", SqlDbType.VarChar,50),
					new SqlParameter("@XZCS", SqlDbType.Int,4),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4),
					new SqlParameter("@ZLNO", SqlDbType.VarChar,50)};
			parameters[0].Value = model.SCZ;
			parameters[1].Value = model.CID;
			parameters[2].Value = model.ZLPATH;
			parameters[3].Value = model.ZLNAME;
			parameters[4].Value = model.FLAG;
			parameters[5].Value = model.SCSJ;
			parameters[6].Value = model.STATE;
			parameters[7].Value = model.XZCS;
			parameters[8].Value = model.DJSJ;
			parameters[9].Value = model.JLZT;
			parameters[10].Value = model.LSH;
			parameters[11].Value = model.ZLNO;

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
			strSql.Append("delete from YW_ZILIAO ");
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
		public bool Delete(string ZLNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from YW_ZILIAO ");
			strSql.Append(" where ZLNO=@ZLNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@ZLNO", SqlDbType.VarChar,50)			};
			parameters[0].Value = ZLNO;

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
			strSql.Append("delete from YW_ZILIAO ");
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
		public Maticsoft.Model.YW_ZILIAO GetModel(int LSH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LSH,ZLNO,SCZ,CID,ZLPATH,ZLNAME,FLAG,SCSJ,STATE,XZCS,DJSJ,JLZT from YW_ZILIAO ");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
			parameters[0].Value = LSH;

			Maticsoft.Model.YW_ZILIAO model=new Maticsoft.Model.YW_ZILIAO();
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
		public Maticsoft.Model.YW_ZILIAO DataRowToModel(DataRow row)
		{
			Maticsoft.Model.YW_ZILIAO model=new Maticsoft.Model.YW_ZILIAO();
			if (row != null)
			{
				if(row["LSH"]!=null && row["LSH"].ToString()!="")
				{
					model.LSH=int.Parse(row["LSH"].ToString());
				}
				if(row["ZLNO"]!=null)
				{
					model.ZLNO=row["ZLNO"].ToString();
				}
				if(row["SCZ"]!=null)
				{
					model.SCZ=row["SCZ"].ToString();
				}
				if(row["CID"]!=null)
				{
					model.CID=row["CID"].ToString();
				}
				if(row["ZLPATH"]!=null)
				{
					model.ZLPATH=row["ZLPATH"].ToString();
				}
				if(row["ZLNAME"]!=null)
				{
					model.ZLNAME=row["ZLNAME"].ToString();
				}
				if(row["FLAG"]!=null)
				{
					model.FLAG=row["FLAG"].ToString();
				}
				if(row["SCSJ"]!=null)
				{
					model.SCSJ=row["SCSJ"].ToString();
				}
				if(row["STATE"]!=null)
				{
					model.STATE=row["STATE"].ToString();
				}
				if(row["XZCS"]!=null && row["XZCS"].ToString()!="")
				{
					model.XZCS=int.Parse(row["XZCS"].ToString());
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
			strSql.Append("select LSH,ZLNO,SCZ,CID,ZLPATH,ZLNAME,FLAG,SCSJ,STATE,XZCS,DJSJ,JLZT ");
			strSql.Append(" FROM YW_ZILIAO ");
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
			strSql.Append(" LSH,ZLNO,SCZ,CID,ZLPATH,ZLNAME,FLAG,SCSJ,STATE,XZCS,DJSJ,JLZT ");
			strSql.Append(" FROM YW_ZILIAO ");
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
			strSql.Append("select count(1) FROM YW_ZILIAO ");
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
			strSql.Append(")AS Row, T.*  from YW_ZILIAO T ");
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
            parameters[0].Value = "YW_ZILIAO";
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
        public static DataSet GetZiLiaoList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_ZiLiaoList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }
        //public static DataSet GetZiLiaoList()
        //{
        //    return SqlDataProvider.GetResultBySql("select * from YW_ZILIAO where jlzt=0 and " + key + "=@keyvalue",
        //        SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.VarChar, keyvalue));
        //}
        public static DataSet GetZiLiaoList(string key, string keyvalue)
        {
            string sql = "select * from YW_ZILIAO where jlzt=0 and " + key + "=@keyvalue";
            return SqlDataProvider.GetResultBySql(sql, SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.VarChar, keyvalue));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag">记录类型0--教师，1--学生，""--所有</param>
        /// <param name="key"></param>
        /// <param name="keyvalue"></param>
        /// <returns></returns>
        public static DataSet GetZiLiaoList(string flag, string key, string keyvalue)
        {
            string sql = "select A.*,sname,tname from YW_ZILIAO A,YW_STUDENT B,YW_TEACHER C where A.sno=B.sno"
                + " and A.tgh=C.tgh and A.jlzt=0 and flag like '" + flag + "%' and A." + key + "=@keyvalue";
            return SqlDataProvider.GetResultBySql(sql, SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.VarChar, keyvalue));
        }

        public static DataTable GetZiLiaoList()
        {
            return CommonDAL.GetObjList("YW_ZILIAO");
        }
        public static bool GetZiLiaoState(string lsh, ref DataSet ds)
        {
            bool ret = false;
            string sql = "select A.*,sname,tname from YW_ZILIAO A,YW_STUDENT B,YW_TEACHER C where A.sno=B.sno"
                + " and A.tgh=C.tgh and A.jlzt=0 and A.lsh=@lsh";
            ds = SqlDataProvider.GetResultBySql(sql, SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.VarChar, lsh));
            if (ds.Tables[0].Rows.Count > 0)
            {
                string state = ds.Tables[0].Rows[0]["state"].ToString();
                if (state == "0")
                    ret = true;
            }
            else
            {
                ds = null;
            }
            return ret;
        }

        public static string GetZiLiaoNo()
        {
            string zlno = null;
            DataSet ds = SqlDataProvider.GetResultBySql("select LSH from YW_ZILIAO order by LSH desc",
                null);
            if (ds.Tables[0].Rows.Count == 0)
            {
                zlno = "1";
            }
            else
            {
                string s = ds.Tables[0].Rows[0]["LSH"].ToString();
                zlno = ((int.Parse(s)) + 1).ToString();
            }
            return zlno;
        }

        public static int SaveData(ZiLiaoInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = ZiLiaoDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = ZiLiaoDAL.InsertCommand(model);
            }
            return result;
        }

        /// <summary>
        /// 修改作业
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(ZiLiaoInfo model)
        {
            int num = CommonDAL.ObjectExists("YW_ZILIAO", " and lsh =" + model.LSH.ToString());
            if (num <= 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("UPDATE [YW_ZILIAO]");
                strSql.AppendLine("SET [CID] = @cid");
                strSql.AppendLine("  ,[ZLPATH] = @path");
                strSql.AppendLine("  ,[ZLNAME] = @name");
                strSql.AppendLine("  ,[SCSJ] = @date");
                strSql.AppendLine("  ,[STATE] = @state");
                strSql.AppendLine("  ,[XZCS] = @download");
                strSql.AppendLine(" WHERE lsh=@lsh");

                SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.VarChar,50),
					new SqlParameter("@path", SqlDbType.VarChar,256),
                    new SqlParameter("@name", SqlDbType.VarChar,256),
                    new SqlParameter("@date", SqlDbType.VarChar,50),
                    new SqlParameter("@state", SqlDbType.VarChar,50),
                    new SqlParameter("@download", SqlDbType.Int,4),
                    new SqlParameter("@lsh", SqlDbType.VarChar,50)};
                parameters[0].Value = model.CID;
                parameters[1].Value = model.ZLPATH;
                parameters[2].Value = model.ZLNAME;
                parameters[3].Value = model.SCSJ;
                parameters[4].Value = model.STATE;
                parameters[5].Value = model.XZCS;
                parameters[6].Value = model.LSH.ToString();

                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
        /// <summary>
        /// 更新下载次数
        /// </summary>
        /// <param name="zlno"></param>
        /// <returns></returns>
        public static bool UpdateDownload(string zlno)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE [YW_ZILIAO]");
            sb.AppendLine("SET [XZCS] = [XZCS]+1");
            sb.AppendLine(" WHERE ZLNO=@zlno");
            int temp = SqlDataProvider.ExecuteBySql(sb.ToString(),
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.Int, zlno)
                );
            return temp >= 0 ? true : false;
        }
        //public static bool UpdateCommand(string username, string connphone, string cardid, string zc, string lsh)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("UPDATE [YW_ZILIAO]");
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

        public static int InsertCommand(ZiLiaoInfo model)
        {
            //先判断资料是否存在
            int num = CommonDAL.ObjectExists("YW_ZILIAO", "and ZLNO='" + model.ZLNO + "'");
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("INSERT INTO [YW_ZILIAO]");
                sb.AppendLine("([ZLNO]");
                sb.AppendLine(",[SCZ]");
                sb.AppendLine(",[CID]");
                sb.AppendLine(",[ZLPATH]");
                sb.AppendLine(",[ZLNAME]");
                sb.AppendLine(",[FLAG]");
                sb.AppendLine(",[SCSJ]");                
                sb.AppendLine(",[STATE]");
                sb.AppendLine(",[XZCS])");
                sb.AppendLine("VALUES");
                sb.AppendLine("(@zlno");
                sb.AppendLine(",@scz");
                sb.AppendLine(",@cid");
                sb.AppendLine(",@path");
                sb.AppendLine(",@name");
                sb.AppendLine(",@flag");
                sb.AppendLine(",@date");
                sb.AppendLine(",@state");
                sb.AppendLine(",@download)");
                sb.AppendLine(";select @@IDENTITY");

                SqlParameter[] parameters = {
                    new SqlParameter("@zlno", SqlDbType.VarChar,50),
                    new SqlParameter("@scz", SqlDbType.VarChar,50),
                    new SqlParameter("@cid", SqlDbType.VarChar,50),
					new SqlParameter("@path", SqlDbType.VarChar,256),
                    new SqlParameter("@name", SqlDbType.VarChar,256),
					new SqlParameter("@flag", SqlDbType.VarChar,50),
                    new SqlParameter("@date", SqlDbType.VarChar,50),
                    new SqlParameter("@state", SqlDbType.VarChar,50),
                    new SqlParameter("@download", SqlDbType.Int,4)};
                parameters[0].Value = model.ZLNO;
                parameters[1].Value = model.SCZ;
                parameters[2].Value = model.CID;
                parameters[3].Value = model.ZLPATH;
                parameters[4].Value = model.ZLNAME;
                parameters[5].Value = model.FLAG;
                parameters[6].Value = model.SCSJ;
                parameters[7].Value = model.STATE;
                parameters[8].Value = model.XZCS;

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

        public static DataSet GetZiLiaoFirst()
        {
            return SqlDataProvider.GetResultBySql("select top 1 * from YW_ZILIAO where jlzt=0 order by lsh desc",
                null);
        }

        #endregion  ExtensionMethod
    }
}
