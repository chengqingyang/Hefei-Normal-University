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
    public class StudentDAL
    {
        public StudentDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string SNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from YW_STUDENT");
            strSql.Append(" where SNO=@SNO ");
            SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50)			};
            parameters[0].Value = SNO;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(StudentInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into YW_STUDENT(");
            strSql.Append("SNO,SNAME,BJ,XB,LXDH,ZPPATH,SFZH,JTZZ,BZ,SPWD,DJSJ,JLZT)");
            strSql.Append(" values (");
            strSql.Append("@SNO,@SNAME,@BJ,@XB,@LXDH,@ZPPATH,@SFZH,@JTZZ,@BZ,@SPWD,@DJSJ,@JLZT)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@SNAME", SqlDbType.VarChar,50),
					new SqlParameter("@BJ", SqlDbType.VarChar,50),
					new SqlParameter("@XB", SqlDbType.VarChar,50),
					new SqlParameter("@LXDH", SqlDbType.VarChar,50),
					new SqlParameter("@ZPPATH", SqlDbType.VarChar,50),
					new SqlParameter("@SFZH", SqlDbType.VarChar,50),
					new SqlParameter("@JTZZ", SqlDbType.VarChar,50),
					new SqlParameter("@BZ", SqlDbType.VarChar,50),
					new SqlParameter("@SPWD", SqlDbType.VarChar,50),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SNO;
            parameters[1].Value = model.SNAME;
            parameters[2].Value = model.BJ;
            parameters[3].Value = model.XB;
            parameters[4].Value = model.LXDH;
            parameters[5].Value = model.ZPPATH;
            parameters[6].Value = model.SFZH;
            parameters[7].Value = model.JTZZ;
            parameters[8].Value = model.BZ;
            parameters[9].Value = model.SPWD;
            parameters[10].Value = model.DJSJ;
            parameters[11].Value = model.JLZT;

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
        public bool Update(StudentInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update YW_STUDENT set ");
            strSql.Append("SNAME=@SNAME,");
            strSql.Append("BJ=@BJ,");
            strSql.Append("XB=@XB,");
            strSql.Append("LXDH=@LXDH,");
            strSql.Append("ZPPATH=@ZPPATH,");
            strSql.Append("SFZH=@SFZH,");
            strSql.Append("JTZZ=@JTZZ,");
            strSql.Append("BZ=@BZ,");
            strSql.Append("SPWD=@SPWD,");
            strSql.Append("DJSJ=@DJSJ,");
            strSql.Append("JLZT=@JLZT");
            strSql.Append(" where LSH=@LSH");
            SqlParameter[] parameters = {
					new SqlParameter("@SNAME", SqlDbType.VarChar,50),
					new SqlParameter("@BJ", SqlDbType.VarChar,50),
					new SqlParameter("@XB", SqlDbType.VarChar,50),
					new SqlParameter("@LXDH", SqlDbType.VarChar,50),
					new SqlParameter("@ZPPATH", SqlDbType.VarChar,50),
					new SqlParameter("@SFZH", SqlDbType.VarChar,50),
					new SqlParameter("@JTZZ", SqlDbType.VarChar,50),
					new SqlParameter("@BZ", SqlDbType.VarChar,50),
					new SqlParameter("@SPWD", SqlDbType.VarChar,50),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4),
					new SqlParameter("@SNO", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SNAME;
            parameters[1].Value = model.BJ;
            parameters[2].Value = model.XB;
            parameters[3].Value = model.LXDH;
            parameters[4].Value = model.ZPPATH;
            parameters[5].Value = model.SFZH;
            parameters[6].Value = model.JTZZ;
            parameters[7].Value = model.BZ;
            parameters[8].Value = model.SPWD;
            parameters[9].Value = model.DJSJ;
            parameters[10].Value = model.JLZT;
            parameters[11].Value = model.LSH;
            parameters[12].Value = model.SNO;

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
            strSql.Append("delete from YW_STUDENT ");
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
        public bool Delete(string SNO)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from YW_STUDENT ");
            strSql.Append(" where SNO=@SNO ");
            SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50)			};
            parameters[0].Value = SNO;

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
            strSql.Append("delete from YW_STUDENT ");
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
        public StudentInfo GetModel(int LSH)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LSH,SNO,SNAME,BJ,XB,LXDH,ZPPATH,SFZH,JTZZ,BZ,SPWD,DJSJ,JLZT from YW_STUDENT ");
            strSql.Append(" where LSH=@LSH");
            SqlParameter[] parameters = {
					new SqlParameter("@LSH", SqlDbType.Int,4)
			};
            parameters[0].Value = LSH;

            StudentInfo model = new StudentInfo();
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
        public StudentInfo DataRowToModel(DataRow row)
        {
            StudentInfo model = new StudentInfo();
            if (row != null)
            {
                if (row["LSH"] != null && row["LSH"].ToString() != "")
                {
                    model.LSH = int.Parse(row["LSH"].ToString());
                }
                if (row["SNO"] != null)
                {
                    model.SNO = row["SNO"].ToString();
                }
                if (row["SNAME"] != null)
                {
                    model.SNAME = row["SNAME"].ToString();
                }
                if (row["BJ"] != null)
                {
                    model.BJ = row["BJ"].ToString();
                }
                if (row["XB"] != null)
                {
                    model.XB = row["XB"].ToString();
                }
                if (row["LXDH"] != null)
                {
                    model.LXDH = row["LXDH"].ToString();
                }
                if (row["ZPPATH"] != null)
                {
                    model.ZPPATH = row["ZPPATH"].ToString();
                }
                if (row["SFZH"] != null)
                {
                    model.SFZH = row["SFZH"].ToString();
                }
                if (row["JTZZ"] != null)
                {
                    model.JTZZ = row["JTZZ"].ToString();
                }
                if (row["BZ"] != null)
                {
                    model.BZ = row["BZ"].ToString();
                }
                if (row["SPWD"] != null)
                {
                    model.SPWD = row["SPWD"].ToString();
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
            strSql.Append("select LSH,SNO,SNAME,BJ,XB,LXDH,ZPPATH,SFZH,JTZZ,BZ,SPWD,DJSJ,JLZT ");
            strSql.Append(" FROM YW_STUDENT ");
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
            strSql.Append(" LSH,SNO,SNAME,BJ,XB,LXDH,ZPPATH,SFZH,JTZZ,BZ,SPWD,DJSJ,JLZT ");
            strSql.Append(" FROM YW_STUDENT ");
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
            strSql.Append("select count(1) FROM YW_STUDENT ");
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
            strSql.Append(")AS Row, T.*  from YW_STUDENT T ");
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
            parameters[0].Value = "YW_STUDENT";
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
        public static DataSet GetStudentList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_StudentList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }

        public static DataSet GetStudentList(string lsh)
        {
            return SqlDataProvider.GetResultBySql("select * from YW_STUDENT where jlzt=0 and lsh=@lsh",
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.VarChar, lsh));
        }

        public static DataTable GetStudentList()
        {
            return CommonDAL.GetObjList("YW_STUDENT"," cast(sno as int)");
        }


        public static int SaveData(StudentInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = StudentDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = StudentDAL.InsertCommand(model);
            }
            return result;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(StudentInfo model)
        {
            int num = CommonDAL.ObjectExists("YW_STUDENT", "and sno='" + model.SNO + "'and SCHOOLNO='" + model.SCHOOLNO + "' and lsh !=" + model.LSH.ToString());
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update YW_STUDENT set ");
                strSql.Append("SNO=@SNO,");
                strSql.Append("SCHOOLNO=@SCHOOLNO,");
                strSql.Append("SNAME=@SNAME,");
                strSql.Append("BJ=@BJ,");
                strSql.Append("XB=@XB,");
                strSql.Append("LXDH=@LXDH,");
                strSql.Append("ZPPATH=@ZPPATH,");
                strSql.Append("SFZH=@SFZH,");
                strSql.Append("JTZZ=@JTZZ,");
                strSql.Append("BZ=@BZ,");
                strSql.Append("SPWD=@SPWD,");
                strSql.Append("DJSJ=@DJSJ,");
                strSql.Append("JLZT=@JLZT,");
                strSql.Append("CLASSNAME=@CLASSNAME,");
                strSql.Append("SCHOOLNAME=@SCHOOLNAME");
                strSql.Append(" where LSH=@LSH");
                SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30),
					new SqlParameter("@SNAME", SqlDbType.VarChar,50),
					new SqlParameter("@BJ", SqlDbType.VarChar,50),
					new SqlParameter("@XB", SqlDbType.VarChar,50),
					new SqlParameter("@LXDH", SqlDbType.VarChar,50),
					new SqlParameter("@ZPPATH", SqlDbType.VarChar,50),
					new SqlParameter("@SFZH", SqlDbType.VarChar,50),
					new SqlParameter("@JTZZ", SqlDbType.VarChar,50),
					new SqlParameter("@BZ", SqlDbType.VarChar,50),
					new SqlParameter("@SPWD", SqlDbType.VarChar,50),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@CLASSNAME", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNAME", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4)};
                parameters[0].Value = model.SNO;
                parameters[1].Value = model.SCHOOLNO;
                parameters[2].Value = model.SNAME;
                parameters[3].Value = model.BJ;
                parameters[4].Value = model.XB;
                parameters[5].Value = model.LXDH;
                parameters[6].Value = model.ZPPATH;
                parameters[7].Value = model.SFZH;
                parameters[8].Value = model.JTZZ;
                parameters[9].Value = model.BZ;
                parameters[10].Value = model.SPWD;
                parameters[11].Value = model.DJSJ;
                parameters[12].Value = model.JLZT;
                parameters[13].Value = model.CLASSNAME;
                parameters[14].Value = model.SCHOOLNAME;
                parameters[15].Value = model.LSH.ToString();

                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }
        public static bool UpdateCommand(string newpwd, string lsh)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE [YE_STUDENT]");
            sb.AppendLine(" set [SPWD] = @loginpwd");
            sb.AppendLine("WHERE lsh=@lsh");
            int temp = SqlDataProvider.ExecuteBySql(sb.ToString(),
                SqlDataProvider.CreateSqlParameter("@loginpwd", SqlDbType.VarChar, newpwd),
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.VarChar, lsh)
                );
            return temp >= 0 ? true : false;
        }
        public static bool UpdateCommand(string username, string connphone, string cardid, string address, string lsh)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE [YE_STUDENT]");
            sb.AppendLine("SET [SNAME] = @username");
            sb.AppendLine("  ,[LXDH] = @connphone");
            sb.AppendLine("  ,[SFZH] = @cardid");
            sb.AppendLine("  ,[JTZZ] = @address");
            sb.AppendLine("WHERE lsh=@lsh");
            int temp = SqlDataProvider.ExecuteBySql(sb.ToString(),
                SqlDataProvider.CreateSqlParameter("@username", SqlDbType.VarChar, username),
                SqlDataProvider.CreateSqlParameter("@connphone", SqlDbType.VarChar, connphone),
                SqlDataProvider.CreateSqlParameter("@cardid", SqlDbType.VarChar, cardid),
                SqlDataProvider.CreateSqlParameter("@address", SqlDbType.VarChar, address),
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.Int, lsh)
                );
            return temp >= 0 ? true : false;
        }

        public static int InsertCommand(StudentInfo model)
        {
            //先判断用户是否存在
            int num = CommonDAL.ObjectExists("YW_STUDENT", "and SNO='" + model.SNO + "'and SCHOOLNO='" + model.SCHOOLNO + "'");
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into YW_STUDENT(");
                strSql.Append("SNO,SCHOOLNO,SNAME,BJ,XB,LXDH,ZPPATH,SFZH,JTZZ,BZ,SPWD,DJSJ,JLZT,CLASSNAME,SCHOOLNAME)");
                strSql.Append(" values (");
                strSql.Append("@SNO,@SCHOOLNO,@SNAME,@BJ,@XB,@LXDH,@ZPPATH,@SFZH,@JTZZ,@BZ,@SPWD,@DJSJ,@JLZT,@CLASSNAME,@SCHOOLNAME)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30),
					new SqlParameter("@SNAME", SqlDbType.VarChar,50),
					new SqlParameter("@BJ", SqlDbType.VarChar,50),
					new SqlParameter("@XB", SqlDbType.VarChar,50),
					new SqlParameter("@LXDH", SqlDbType.VarChar,50),
					new SqlParameter("@ZPPATH", SqlDbType.VarChar,50),
					new SqlParameter("@SFZH", SqlDbType.VarChar,50),
					new SqlParameter("@JTZZ", SqlDbType.VarChar,50),
					new SqlParameter("@BZ", SqlDbType.VarChar,50),
					new SqlParameter("@SPWD", SqlDbType.VarChar,50),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@CLASSNAME", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNAME", SqlDbType.VarChar,50)};
                parameters[0].Value = model.SNO;
                parameters[1].Value = model.SCHOOLNO;
                parameters[2].Value = model.SNAME;
                parameters[3].Value = model.BJ;
                parameters[4].Value = model.XB;
                parameters[5].Value = model.LXDH;
                parameters[6].Value = model.ZPPATH;
                parameters[7].Value = model.SFZH;
                parameters[8].Value = model.JTZZ;
                parameters[9].Value = model.BZ;
                parameters[10].Value = model.SPWD;
                parameters[11].Value = model.DJSJ;
                parameters[12].Value = model.JLZT;
                parameters[13].Value = model.CLASSNAME;
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
