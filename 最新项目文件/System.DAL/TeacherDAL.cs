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
    public class TeacherDAL
    {
        public TeacherDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TGH)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from YW_TEACHER");
            strSql.Append(" where TGH=@TGH ");
            SqlParameter[] parameters = {
					new SqlParameter("@TGH", SqlDbType.VarChar,50)			};
            parameters[0].Value = TGH;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(TeacherInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into YW_TEACHER(");
            strSql.Append("TGH,TNAME,TPWD,CSRQ,SFZH,XB,ZC,ZPPATH,ZJKC,LXDH,BZ,DJSJ,JLZT)");
            strSql.Append(" values (");
            strSql.Append("@TGH,@TNAME,@TPWD,@CSRQ,@SFZH,@XB,@ZC,@ZPPATH,@ZJKC,@LXDH,@BZ,@DJSJ,@JLZT)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TGH", SqlDbType.VarChar,50),
					new SqlParameter("@TNAME", SqlDbType.VarChar,50),
					new SqlParameter("@TPWD", SqlDbType.VarChar,50),
					new SqlParameter("@CSRQ", SqlDbType.DateTime),
					new SqlParameter("@SFZH", SqlDbType.VarChar,300),
					new SqlParameter("@XB", SqlDbType.VarChar,50),
					new SqlParameter("@ZC", SqlDbType.VarChar,50),
					new SqlParameter("@ZPPATH", SqlDbType.VarChar,50),
					new SqlParameter("@ZJKC", SqlDbType.VarChar,50),
					new SqlParameter("@LXDH", SqlDbType.VarChar,50),
					new SqlParameter("@BZ", SqlDbType.VarChar,500),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50)};
            parameters[0].Value = model.TGH;
            parameters[1].Value = model.TNAME;
            parameters[2].Value = model.TPWD;
            parameters[3].Value = model.CSRQ;
            parameters[4].Value = model.SFZH;
            parameters[5].Value = model.XB;
            parameters[6].Value = model.ZC;
            parameters[7].Value = model.ZPPATH;
            parameters[8].Value = model.ZJKC;
            parameters[9].Value = model.LXDH;
            parameters[10].Value = model.BZ;
            parameters[11].Value = model.DJSJ;
            parameters[12].Value = model.JLZT;

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
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(TeacherInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update YW_TEACHER set ");
            strSql.Append("TNAME=@TNAME,");
            strSql.Append("TPWD=@TPWD,");
            strSql.Append("CSRQ=@CSRQ,");
            strSql.Append("SFZH=@SFZH,");
            strSql.Append("XB=@XB,");
            strSql.Append("ZC=@ZC,");
            strSql.Append("ZPPATH=@ZPPATH,");
            strSql.Append("ZJKC=@ZJKC,");
            strSql.Append("LXDH=@LXDH,");
            strSql.Append("BZ=@BZ,");
            strSql.Append("DJSJ=@DJSJ,");
            strSql.Append("JLZT=@JLZT");
            strSql.Append(" where LSH=@LSH");
            SqlParameter[] parameters = {
					new SqlParameter("@TNAME", SqlDbType.VarChar,50),
					new SqlParameter("@TPWD", SqlDbType.VarChar,50),
					new SqlParameter("@CSRQ", SqlDbType.DateTime),
					new SqlParameter("@SFZH", SqlDbType.VarChar,300),
					new SqlParameter("@XB", SqlDbType.VarChar,50),
					new SqlParameter("@ZC", SqlDbType.VarChar,50),
					new SqlParameter("@ZPPATH", SqlDbType.VarChar,50),
					new SqlParameter("@ZJKC", SqlDbType.VarChar,50),
					new SqlParameter("@LXDH", SqlDbType.VarChar,50),
					new SqlParameter("@BZ", SqlDbType.VarChar,500),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4),
					new SqlParameter("@TGH", SqlDbType.VarChar,50)};
            parameters[0].Value = model.TNAME;
            parameters[1].Value = model.TPWD;
            parameters[2].Value = model.CSRQ;
            parameters[3].Value = model.SFZH;
            parameters[4].Value = model.XB;
            parameters[5].Value = model.ZC;
            parameters[6].Value = model.ZPPATH;
            parameters[7].Value = model.ZJKC;
            parameters[8].Value = model.LXDH;
            parameters[9].Value = model.BZ;
            parameters[10].Value = model.DJSJ;
            parameters[11].Value = model.JLZT;
            parameters[12].Value = model.LSH;
            parameters[13].Value = model.TGH;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from YW_TEACHER ");
            strSql.Append(" where LSH=@LSH");
            SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
            parameters[0].Value = LSH;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(string TGH)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from YW_TEACHER ");
            strSql.Append(" where TGH=@TGH ");
            SqlParameter[] parameters = {
					new SqlParameter("@TGH", SqlDbType.VarChar,50)			};
            parameters[0].Value = TGH;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string LSHlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from YW_TEACHER ");
            strSql.Append(" where LSH in (" + LSHlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public TeacherInfo GetModel(int LSH)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LSH,TGH,TNAME,TPWD,CSRQ,SFZH,XB,ZC,ZPPATH,ZJKC,LXDH,BZ,DJSJ,JLZT from YW_TEACHER ");
            strSql.Append(" where LSH=@LSH");
            SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
            parameters[0].Value = LSH;

            TeacherInfo model = new TeacherInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public TeacherInfo DataRowToModel(DataRow row)
        {
            TeacherInfo model = new TeacherInfo();
            if (row != null)
            {
                if (row["LSH"] != null && row["LSH"].ToString() != "")
                {
                    model.LSH = int.Parse(row["LSH"].ToString());
                }
                if (row["TGH"] != null)
                {
                    model.TGH = row["TGH"].ToString();
                }
                if (row["TNAME"] != null)
                {
                    model.TNAME = row["TNAME"].ToString();
                }
                if (row["TPWD"] != null)
                {
                    model.TPWD = row["TPWD"].ToString();
                }
                if (row["CSRQ"] != null && row["CSRQ"].ToString() != "")
                {
                    model.CSRQ = DateTime.Parse(row["CSRQ"].ToString());
                }
                if (row["SFZH"] != null)
                {
                    model.SFZH = row["SFZH"].ToString();
                }
                if (row["XB"] != null)
                {
                    model.XB = row["XB"].ToString();
                }
                if (row["ZC"] != null)
                {
                    model.ZC = row["ZC"].ToString();
                }
                if (row["ZPPATH"] != null)
                {
                    model.ZPPATH = row["ZPPATH"].ToString();
                }
                if (row["ZJKC"] != null)
                {
                    model.ZJKC = row["ZJKC"].ToString();
                }
                if (row["LXDH"] != null)
                {
                    model.LXDH = row["LXDH"].ToString();
                }
                if (row["BZ"] != null)
                {
                    model.BZ = row["BZ"].ToString();
                }
                if (row["DJSJ"] != null && row["DJSJ"].ToString() != "")
                {
                    model.DJSJ = DateTime.Parse(row["DJSJ"].ToString());
                }
                if (row["JLZT"] != null)
                {
                    model.JLZT = row["JLZT"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LSH,TGH,TNAME,TPWD,CSRQ,SFZH,XB,ZC,ZPPATH,ZJKC,LXDH,BZ,DJSJ,JLZT ");
            strSql.Append(" FROM YW_TEACHER ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" LSH,TGH,TNAME,TPWD,CSRQ,SFZH,XB,ZC,ZPPATH,ZJKC,LXDH,BZ,DJSJ,JLZT ");
            strSql.Append(" FROM YW_TEACHER ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM YW_TEACHER ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.LSH desc");
            }
            strSql.Append(")AS Row, T.*  from YW_TEACHER T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

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
            parameters[0].Value = "YW_TEACHER";
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
        public static DataSet GetTeacherList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_TeacherList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }

        public static DataSet GetTeacherList(string lsh)
        {
            return SqlDataProvider.GetResultBySql("select * from YW_TEACHER where jlzt=0 and lsh=@lsh",
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.VarChar, lsh));
        }

        public static DataTable GetTeacherList()
        {
            return CommonDAL.GetObjList("YW_TEACHER");
        }

        public static string GetTeacherSchoolNo(string tgh)
        {
            string schoolno = "";
            DataSet ds= SqlDataProvider.GetResultBySql("select schoolno from YW_TEACHER where jlzt=0 and tgh=@tgh",
                SqlDataProvider.CreateSqlParameter("@tgh", SqlDbType.VarChar, tgh));
            if (ds.Tables[0].Rows.Count>0)
            {
                schoolno = ds.Tables[0].Rows[0]["schoolno"].ToString();
            }
            return schoolno;
        }

        public static int SaveData(TeacherInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = TeacherDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = TeacherDAL.InsertCommand(model);
            }
         return result;
        }
        
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(TeacherInfo model)
        {
            int num = CommonDAL.ObjectExists("YW_TEACHER", "and TGH='" + model.TGH + "'and SCHOOLNO='" + model.SCHOOLNO + "' and lsh !=" + model.LSH.ToString());
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update YW_TEACHER set ");
                strSql.Append("TGH=@TGH,");
                strSql.Append("SCHOOLNO=@SCHOOLNO,");
                strSql.Append("TNAME=@TNAME,");
                strSql.Append("TPWD=@TPWD,");
                strSql.Append("CSRQ=@CSRQ,");
                strSql.Append("SFZH=@SFZH,");
                strSql.Append("XB=@XB,");
                strSql.Append("ZC=@ZC,");
                strSql.Append("ZPPATH=@ZPPATH,");
                strSql.Append("ZJKC=@ZJKC,");
                strSql.Append("LXDH=@LXDH,");
                strSql.Append("BZ=@BZ,");
                strSql.Append("DJSJ=@DJSJ,");
                strSql.Append("JLZT=@JLZT,");
                strSql.Append("SCHOOLNAME=@SCHOOLNAME");
                strSql.Append(" where LSH=@LSH");
                SqlParameter[] parameters = {
					new SqlParameter("@TGH", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30),
					new SqlParameter("@TNAME", SqlDbType.VarChar,50),
					new SqlParameter("@TPWD", SqlDbType.VarChar,50),
					new SqlParameter("@CSRQ", SqlDbType.DateTime),
					new SqlParameter("@SFZH", SqlDbType.VarChar,300),
					new SqlParameter("@XB", SqlDbType.VarChar,50),
					new SqlParameter("@ZC", SqlDbType.VarChar,50),
					new SqlParameter("@ZPPATH", SqlDbType.VarChar,50),
					new SqlParameter("@ZJKC", SqlDbType.VarChar,50),
					new SqlParameter("@LXDH", SqlDbType.VarChar,50),
					new SqlParameter("@BZ", SqlDbType.VarChar,500),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNAME", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4)};
                parameters[0].Value = model.TGH;
                parameters[1].Value = model.SCHOOLNO;
                parameters[2].Value = model.TNAME;
                parameters[3].Value = model.TPWD;
                parameters[4].Value = model.CSRQ;
                parameters[5].Value = model.SFZH;
                parameters[6].Value = model.XB;
                parameters[7].Value = model.ZC;
                parameters[8].Value = model.ZPPATH;
                parameters[9].Value = model.ZJKC;
                parameters[10].Value = model.LXDH;
                parameters[11].Value = model.BZ;
                parameters[12].Value = model.DJSJ;
                parameters[13].Value = model.JLZT;
                parameters[14].Value = model.SCHOOLNAME;
                parameters[15].Value = model.LSH.ToString();

                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
        public static bool UpdateCommand(string newpwd, string lsh)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE [YW_TEACHER]");
            sb.AppendLine(" set [TPWD] = @loginpwd");
            sb.AppendLine("WHERE lsh=@lsh");
            int temp = SqlDataProvider.ExecuteBySql(sb.ToString(),
                SqlDataProvider.CreateSqlParameter("@loginpwd", SqlDbType.VarChar, newpwd),
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.VarChar, lsh)
                );
            return temp >= 0 ? true : false;
        }
        public static bool UpdateCommand(string username, string connphone, string cardid, string zc, string lsh)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE [YW_TEACHER]");
            sb.AppendLine("SET [TNAME] = @username");
            sb.AppendLine("  ,[LXDH] = @connphone");
            sb.AppendLine("  ,[SFZH] = @cardid");
            sb.AppendLine("  ,[ZC] = @zc");
            sb.AppendLine(" WHERE lsh=@lsh");
            int temp = SqlDataProvider.ExecuteBySql(sb.ToString(),
                SqlDataProvider.CreateSqlParameter("@username", SqlDbType.VarChar, username),
                SqlDataProvider.CreateSqlParameter("@connphone", SqlDbType.VarChar, connphone),
                SqlDataProvider.CreateSqlParameter("@cardid", SqlDbType.VarChar, cardid),
                SqlDataProvider.CreateSqlParameter("@zc", SqlDbType.VarChar, zc),
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.Int, lsh)
                );
            return temp >= 0 ? true : false;
        }

        public static int InsertCommand(TeacherInfo model)
        {
            //先判断用户是否存在
            int num = CommonDAL.ObjectExists("YW_TEACHER", "and TGH='" + model.TGH + "'and SCHOOLNO='" + model.SCHOOLNO + "'");
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into YW_TEACHER(");
                strSql.Append("TGH,SCHOOLNO,TNAME,TPWD,CSRQ,SFZH,XB,ZC,ZPPATH,ZJKC,LXDH,BZ,DJSJ,JLZT,SCHOOLNAME)");
                strSql.Append(" values (");
                strSql.Append("@TGH,@SCHOOLNO,@TNAME,@TPWD,@CSRQ,@SFZH,@XB,@ZC,@ZPPATH,@ZJKC,@LXDH,@BZ,@DJSJ,@JLZT,@SCHOOLNAME)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@TGH", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30),
					new SqlParameter("@TNAME", SqlDbType.VarChar,50),
					new SqlParameter("@TPWD", SqlDbType.VarChar,50),
					new SqlParameter("@CSRQ", SqlDbType.DateTime),
					new SqlParameter("@SFZH", SqlDbType.VarChar,300),
					new SqlParameter("@XB", SqlDbType.VarChar,50),
					new SqlParameter("@ZC", SqlDbType.VarChar,50),
					new SqlParameter("@ZPPATH", SqlDbType.VarChar,50),
					new SqlParameter("@ZJKC", SqlDbType.VarChar,50),
					new SqlParameter("@LXDH", SqlDbType.VarChar,50),
					new SqlParameter("@BZ", SqlDbType.VarChar,500),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNAME", SqlDbType.VarChar,50)};
                parameters[0].Value = model.TGH;
                parameters[1].Value = model.SCHOOLNO;
                parameters[2].Value = model.TNAME;
                parameters[3].Value = model.TPWD;
                parameters[4].Value = model.CSRQ;
                parameters[5].Value = model.SFZH;
                parameters[6].Value = model.XB;
                parameters[7].Value = model.ZC;
                parameters[8].Value = model.ZPPATH;
                parameters[9].Value = model.ZJKC;
                parameters[10].Value = model.LXDH;
                parameters[11].Value = model.BZ;
                parameters[12].Value = model.DJSJ;
                parameters[13].Value = model.JLZT;
                parameters[14].Value = model.SCHOOLNAME;

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
