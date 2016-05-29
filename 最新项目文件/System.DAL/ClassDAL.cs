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
    public class ClassDAL
    {
        public ClassDAL()
		{}
		#region  BasicMethod
        /*
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CALSSNO)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SYS_CLASSINFO");
			strSql.Append(" where CALSSNO=@CALSSNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@CALSSNO", SqlDbType.VarChar,30)			};
			parameters[0].Value = CALSSNO;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.SYS_CLASSINFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SYS_CLASSINFO(");
			strSql.Append("CALSSNO,CLASSNAME,BZRNAME,BZ,DJSJ,JLZT,SCHOOLNO)");
			strSql.Append(" values (");
			strSql.Append("@CALSSNO,@CLASSNAME,@BZRNAME,@BZ,@DJSJ,@JLZT,@SCHOOLNO)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CALSSNO", SqlDbType.VarChar,30),
					new SqlParameter("@CLASSNAME", SqlDbType.VarChar,50),
					new SqlParameter("@BZRNAME", SqlDbType.VarChar,50),
					new SqlParameter("@BZ", SqlDbType.VarChar,200),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30)};
			parameters[0].Value = model.CALSSNO;
			parameters[1].Value = model.CLASSNAME;
			parameters[2].Value = model.BZRNAME;
			parameters[3].Value = model.BZ;
			parameters[4].Value = model.DJSJ;
			parameters[5].Value = model.JLZT;
			parameters[6].Value = model.SCHOOLNO;

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
		public bool Update(Maticsoft.Model.SYS_CLASSINFO model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SYS_CLASSINFO set ");
			strSql.Append("CLASSNAME=@CLASSNAME,");
			strSql.Append("BZRNAME=@BZRNAME,");
			strSql.Append("BZ=@BZ,");
			strSql.Append("DJSJ=@DJSJ,");
			strSql.Append("JLZT=@JLZT,");
			strSql.Append("SCHOOLNO=@SCHOOLNO");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@CLASSNAME", SqlDbType.VarChar,50),
					new SqlParameter("@BZRNAME", SqlDbType.VarChar,50),
					new SqlParameter("@BZ", SqlDbType.VarChar,200),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30),
					new SqlParameter("@LSH", SqlDbType.Int,4),
					new SqlParameter("@CALSSNO", SqlDbType.VarChar,30)};
			parameters[0].Value = model.CLASSNAME;
			parameters[1].Value = model.BZRNAME;
			parameters[2].Value = model.BZ;
			parameters[3].Value = model.DJSJ;
			parameters[4].Value = model.JLZT;
			parameters[5].Value = model.SCHOOLNO;
			parameters[6].Value = model.LSH;
			parameters[7].Value = model.CALSSNO;

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
			strSql.Append("delete from SYS_CLASSINFO ");
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
		public bool Delete(string CALSSNO)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SYS_CLASSINFO ");
			strSql.Append(" where CALSSNO=@CALSSNO ");
			SqlParameter[] parameters = {
					new SqlParameter("@CALSSNO", SqlDbType.VarChar,30)			};
			parameters[0].Value = CALSSNO;

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
			strSql.Append("delete from SYS_CLASSINFO ");
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
		public Maticsoft.Model.SYS_CLASSINFO GetModel(int LSH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LSH,CALSSNO,CLASSNAME,BZRNAME,BZ,DJSJ,JLZT,SCHOOLNO from SYS_CLASSINFO ");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
			parameters[0].Value = LSH;

			Maticsoft.Model.SYS_CLASSINFO model=new Maticsoft.Model.SYS_CLASSINFO();
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
		public Maticsoft.Model.SYS_CLASSINFO DataRowToModel(DataRow row)
		{
			Maticsoft.Model.SYS_CLASSINFO model=new Maticsoft.Model.SYS_CLASSINFO();
			if (row != null)
			{
				if(row["LSH"]!=null && row["LSH"].ToString()!="")
				{
					model.LSH=int.Parse(row["LSH"].ToString());
				}
				if(row["CALSSNO"]!=null)
				{
					model.CALSSNO=row["CALSSNO"].ToString();
				}
				if(row["CLASSNAME"]!=null)
				{
					model.CLASSNAME=row["CLASSNAME"].ToString();
				}
				if(row["BZRNAME"]!=null)
				{
					model.BZRNAME=row["BZRNAME"].ToString();
				}
				if(row["BZ"]!=null)
				{
					model.BZ=row["BZ"].ToString();
				}
				if(row["DJSJ"]!=null && row["DJSJ"].ToString()!="")
				{
					model.DJSJ=DateTime.Parse(row["DJSJ"].ToString());
				}
				if(row["JLZT"]!=null)
				{
					model.JLZT=row["JLZT"].ToString();
				}
				if(row["SCHOOLNO"]!=null)
				{
					model.SCHOOLNO=row["SCHOOLNO"].ToString();
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
			strSql.Append("select LSH,CALSSNO,CLASSNAME,BZRNAME,BZ,DJSJ,JLZT,SCHOOLNO ");
			strSql.Append(" FROM SYS_CLASSINFO ");
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
			strSql.Append(" LSH,CALSSNO,CLASSNAME,BZRNAME,BZ,DJSJ,JLZT,SCHOOLNO ");
			strSql.Append(" FROM SYS_CLASSINFO ");
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
			strSql.Append("select count(1) FROM SYS_CLASSINFO ");
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
			strSql.Append(")AS Row, T.*  from SYS_CLASSINFO T ");
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
			parameters[0].Value = "SYS_CLASSINFO";
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
        public static DataSet GetClassList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_ClassList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }
        public static DataSet GetClassList(string key, string keyvalue)
        {
            string sql = "select * from SYS_CLASSINFO where jlzt=0 and " + key + "=@keyvalue";
            return SqlDataProvider.GetResultBySql(sql, SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.VarChar, keyvalue));
        }
        public static DataSet GetClassList(string tgh)
        {
            string sql = "select DISTINCT(B.CLASSNO),CLASSNAME from SYS_CLASSINFO B,SYS_COURSEFP C"
                        +" WHERE C.CLASSNO=B.CLASSNO AND C.TGH='"+ tgh +"'";
            return SqlDataProvider.GetResultBySql(sql, null);
        }

        public static DataTable GetClassList()
        {
            return CommonDAL.GetObjList("SYS_CLASSINFO");
        }
        public static string GetClassNo()
        {
            string no = null;
            DataSet ds = SqlDataProvider.GetResultBySql("select LSH from SYS_CLASSINFO order by LSH desc",
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
        
        public static int SaveData(ClassInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = ClassDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = ClassDAL.InsertCommand(model);
            }
            return result;
        }

        /// <summary>
        /// 修改作业
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(ClassInfo model)
        {
            int num = CommonDAL.ObjectExists("SYS_CLASSINFO", "and CLASSNAME='" + model.CLASSNAME + "'and SCHOOLNO='" + model.SCHOOLNO + "' and lsh =" + model.LSH.ToString());
            if (num <= 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update SYS_CLASSINFO set ");
                strSql.Append("CLASSNAME=@CLASSNAME,");
                strSql.Append("SCHOOLNO=@SCHOOLNO,");
                strSql.Append("BZRNAME=@BZRNAME,");
                strSql.Append("BZ=@BZ");
                strSql.Append(" where LSH=@LSH");
                SqlParameter[] parameters = {
					    new SqlParameter("@CLASSNAME", SqlDbType.VarChar,50),
					    new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30),
					    new SqlParameter("@BZRNAME", SqlDbType.VarChar,50),
					    new SqlParameter("@BZ", SqlDbType.VarChar,200),
					    new SqlParameter("@LSH", SqlDbType.Int,4)};
                parameters[0].Value = model.CLASSNAME;
                parameters[1].Value = model.SCHOOLNO;
                parameters[2].Value = model.BZRNAME;
                parameters[3].Value = model.BZ;
                parameters[4].Value = model.LSH;

                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
        //public static bool UpdateCommand(string username, string connphone, string cardid, string zc, string lsh)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("UPDATE [SYS_CLASSINFO]");
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

        public static int InsertCommand(ClassInfo model)
        {
            //先判断资料是否存在
            int num = CommonDAL.ObjectExists("SYS_CLASSINFO", "and CLASSNAME='" + model.CLASSNAME + "'and SCHOOLNO='" + model.SCHOOLNO + "'");
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();

                strSql.Append("insert into SYS_CLASSINFO(");
                strSql.Append("SCHOOLNO,CLASSNO,CLASSNAME,BZRNAME,BZ)");
                strSql.Append(" values (");
                strSql.Append("@SCHOOLNO,@CLASSNO,@CLASSNAME,@BZRNAME,@BZ)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					    new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30),
					    new SqlParameter("@CLASSNO", SqlDbType.VarChar,50),
					    new SqlParameter("@CLASSNAME", SqlDbType.VarChar,50),
					    new SqlParameter("@BZRNAME", SqlDbType.VarChar,50),
					    new SqlParameter("@BZ", SqlDbType.VarChar,200)};
                parameters[0].Value = model.SCHOOLNO;
                parameters[1].Value = model.CLASSNO;
                parameters[2].Value = model.CLASSNAME;
                parameters[3].Value = model.BZRNAME;
                parameters[4].Value = model.BZ;

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
