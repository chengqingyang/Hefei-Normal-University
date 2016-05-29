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
    public class TestDeatilDAL
    {
        public TestDeatilDAL()
        { }
        #region  BasicMethod
        /*
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LSH)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from YW_TEST_DEATIL");
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
		public int Add(Maticsoft.Model.YW_TEST_DEATIL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YW_TEST_DEATIL(");
			strSql.Append("KSNO,SNO,JS,ZWNO,BZ,STATE,READED,JLZT)");
			strSql.Append(" values (");
			strSql.Append("@KSNO,@SNO,@JS,@ZWNO,@BZ,@STATE,@READED,@JLZT)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@KSNO", SqlDbType.VarChar,50),
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@JS", SqlDbType.VarChar,50),
					new SqlParameter("@ZWNO", SqlDbType.VarChar,50),
					new SqlParameter("@BZ", SqlDbType.VarChar,100),
					new SqlParameter("@STATE", SqlDbType.VarChar,50),
					new SqlParameter("@READED", SqlDbType.VarChar,50),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50)};
			parameters[0].Value = model.KSNO;
			parameters[1].Value = model.SNO;
			parameters[2].Value = model.JS;
			parameters[3].Value = model.ZWNO;
			parameters[4].Value = model.BZ;
			parameters[5].Value = model.STATE;
			parameters[6].Value = model.READED;
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
		public bool Update(Maticsoft.Model.YW_TEST_DEATIL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YW_TEST_DEATIL set ");
			strSql.Append("KSNO=@KSNO,");
			strSql.Append("SNO=@SNO,");
			strSql.Append("JS=@JS,");
			strSql.Append("ZWNO=@ZWNO,");
			strSql.Append("BZ=@BZ,");
			strSql.Append("STATE=@STATE,");
			strSql.Append("READED=@READED,");
			strSql.Append("JLZT=@JLZT");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@KSNO", SqlDbType.VarChar,50),
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@JS", SqlDbType.VarChar,50),
					new SqlParameter("@ZWNO", SqlDbType.VarChar,50),
					new SqlParameter("@BZ", SqlDbType.VarChar,100),
					new SqlParameter("@STATE", SqlDbType.VarChar,50),
					new SqlParameter("@READED", SqlDbType.VarChar,50),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4)};
			parameters[0].Value = model.KSNO;
			parameters[1].Value = model.SNO;
			parameters[2].Value = model.JS;
			parameters[3].Value = model.ZWNO;
			parameters[4].Value = model.BZ;
			parameters[5].Value = model.STATE;
			parameters[6].Value = model.READED;
			parameters[7].Value = model.JLZT;
			parameters[8].Value = model.LSH;

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
			strSql.Append("delete from YW_TEST_DEATIL ");
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
			strSql.Append("delete from YW_TEST_DEATIL ");
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
		public Maticsoft.Model.YW_TEST_DEATIL GetModel(int LSH)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LSH,KSNO,SNO,JS,ZWNO,BZ,STATE,READED,JLZT from YW_TEST_DEATIL ");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
			parameters[0].Value = LSH;

			Maticsoft.Model.YW_TEST_DEATIL model=new Maticsoft.Model.YW_TEST_DEATIL();
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
		public Maticsoft.Model.YW_TEST_DEATIL DataRowToModel(DataRow row)
		{
			Maticsoft.Model.YW_TEST_DEATIL model=new Maticsoft.Model.YW_TEST_DEATIL();
			if (row != null)
			{
				if(row["LSH"]!=null && row["LSH"].ToString()!="")
				{
					model.LSH=int.Parse(row["LSH"].ToString());
				}
				if(row["KSNO"]!=null)
				{
					model.KSNO=row["KSNO"].ToString();
				}
				if(row["SNO"]!=null)
				{
					model.SNO=row["SNO"].ToString();
				}
				if(row["JS"]!=null)
				{
					model.JS=row["JS"].ToString();
				}
				if(row["ZWNO"]!=null)
				{
					model.ZWNO=row["ZWNO"].ToString();
				}
				if(row["BZ"]!=null)
				{
					model.BZ=row["BZ"].ToString();
				}
				if(row["STATE"]!=null)
				{
					model.STATE=row["STATE"].ToString();
				}
				if(row["READED"]!=null)
				{
					model.READED=row["READED"].ToString();
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
			strSql.Append("select LSH,KSNO,SNO,JS,ZWNO,BZ,STATE,READED,JLZT ");
			strSql.Append(" FROM YW_TEST_DEATIL ");
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
			strSql.Append(" LSH,KSNO,SNO,JS,ZWNO,BZ,STATE,READED,JLZT ");
			strSql.Append(" FROM YW_TEST_DEATIL ");
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
			strSql.Append("select count(1) FROM YW_TEST_DEATIL ");
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
			strSql.Append(")AS Row, T.*  from YW_TEST_DEATIL T ");
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
            parameters[0].Value = "YW_TEST_DEATIL";
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
        public static DataSet GetTestDeatilList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_TestDeatilList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }

        public static DataSet GetTestDeatilList(string key,string keyvalue)
        {
            return SqlDataProvider.GetResultBySql("select A.* from YW_TEST_DETAIL A,YW_KAOSHI B where A.KSNO=B.KSNO AND B.STATE='0' AND A.jlzt='0' and " + key + "=@keyvalue",
                SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.VarChar, keyvalue));
        }

        public static DataTable GetTestDeatilList()
        {
            return CommonDAL.GetObjList("YW_TEST_DETAIL","cast(sno as int) ");
        }

        /// <summary>
        /// 未完全实现，暂不能用
        /// </summary>
        /// <param name="lsh"></param>
        /// <returns></returns>
        public static DataSet GetTestDeatilListByTGH(string lsh)
        {
            return SqlDataProvider.GetResultBySql("select * from YW_TEST_DETAIL where jlzt=0 and lsh=@lsh",
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.VarChar, lsh));
        }

        public static int SaveData(TestDetailInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = TestDeatilDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = TestDeatilDAL.InsertCommand(model);
            }
            return result;
        }
        public static bool SaveAllData(TestDetailInfo model)
        {
            bool flag = false;
            int ret = 0;
            int sum = 0;
            int zwno = 0;
            DataTable dt = StudentDAL.GetStudentList();
            int count = dt.Rows.Count;
            if (count > 0)
            {
                try
                {
                    zwno = int.Parse(model.ZWNO);
                }
                catch { zwno = 1; }
                for (int i = 0; i < count; i++)
                {
                    model.ZWNO = (zwno++).ToString();
                    model.SNO = dt.Rows[i]["sno"].ToString();
                    ret = TestDeatilDAL.SaveData(model);
                    if (ret != -1 && ret != 99)
                        sum++;
                }
                if (sum == count)
                {
                    flag = true;
                }
            }
            return flag;
        }

        /// <summary>
        /// 修改考试安排详情
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(TestDetailInfo model)
        {
            int num = CommonDAL.ObjectExists("YW_TEST_DETAIL", "and KSNO='" + model.KSNO 
                +  "' and sno ='" + model.SNO+"'");
            if (num <= 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("UPDATE [YW_TEST_DETAIL]");
                strSql.AppendLine("SET [JS] = @js");
                strSql.AppendLine("  ,[ZWNO] = @zwh");
                strSql.AppendLine("  ,[BZ] = @remark");
                strSql.AppendLine("  ,[READED] = @readed");
                strSql.AppendLine("  ,[STATE] = @state");
                strSql.AppendLine(" WHERE ksno=@ksno and sno =@sno");

                SqlParameter[] parameters = {
					new SqlParameter("@js", SqlDbType.VarChar,50),
                    new SqlParameter("@zwh", SqlDbType.VarChar,50),
                    new SqlParameter("@remark", SqlDbType.VarChar,100),
                    new SqlParameter("@readed", SqlDbType.VarChar,50),
                    new SqlParameter("@state", SqlDbType.VarChar,50),
                    new SqlParameter("@ksno", SqlDbType.VarChar,50),
                    new SqlParameter("@sno", SqlDbType.VarChar,50)};
                parameters[0].Value = model.JS;
                parameters[1].Value = model.ZWNO;
                parameters[2].Value = model.BZ;
                parameters[4].Value = model.READED;
                parameters[5].Value = model.STATE;
                parameters[5].Value = model.KSNO;
                parameters[6].Value = model.SNO;

                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
        //public static bool UpdateCommand(string username, string connphone, string cardid, string zc, string lsh)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("UPDATE [YW_TEST_DETAIL]");
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

        public static int InsertCommand(TestDetailInfo model)
        {
            //先判断周次是否存在
            int num = CommonDAL.ObjectExists("YW_TEST_DETAIL","and 1=0");
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("INSERT INTO [YW_TEST_DETAIL]");
                sb.AppendLine("([KSNO]");
                sb.AppendLine(",[SNO]");
                sb.AppendLine(",[JS]");
                sb.AppendLine(",[ZWNO]");
                sb.AppendLine(",[BZ]");
                sb.AppendLine(",[STATE])");
                sb.AppendLine("VALUES");
                sb.AppendLine("(@ksno");
                sb.AppendLine(",@sno");
                sb.AppendLine(",@js");
                sb.AppendLine(",@zwh");
                sb.AppendLine(",@remark");
                sb.AppendLine(",@state)");
                sb.AppendLine(";select @@IDENTITY");

                SqlParameter[] parameters = {
                    new SqlParameter("@ksno", SqlDbType.VarChar,50),
					new SqlParameter("@sno", SqlDbType.VarChar,50),
                    new SqlParameter("@js", SqlDbType.VarChar,50),
					new SqlParameter("@zwh", SqlDbType.VarChar,50),
					new SqlParameter("@remark", SqlDbType.VarChar,100),
                    new SqlParameter("@state", SqlDbType.VarChar,50)};
                parameters[0].Value = model.KSNO;
                parameters[1].Value = model.SNO;
                parameters[2].Value = model.JS;
                parameters[3].Value = model.ZWNO;
                parameters[4].Value = model.BZ;
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

        public static DataSet GetTestDeatilFirst(string ksno)
        {
            return SqlDataProvider.GetResultBySql("select top 1 * from YW_TEST_DETAIL where jlzt=0 and ksno='"
            +ksno+"' order by lsh",
                null);
        }
        #endregion  ExtensionMethod
    }
}
