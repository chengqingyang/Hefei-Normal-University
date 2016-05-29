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
    public class UserDAL
    {
        public static int GetLoginState(string username, string userpwd)
        {
            int result = -1;
            try
            {
                DataSet ds = SqlDataProvider.GetResultByProc("LoginInfo",
                    SqlDataProvider.CreateSqlParameter("@username", SqlDbType.VarChar, username),
                    SqlDataProvider.CreateSqlParameter("@userpwd", SqlDbType.VarChar, userpwd));
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    }
                }
            }
            catch
            { }
            return result;
        }


        public static int SaveData(UserInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = UserDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = UserDAL.InsertCommand(model);
            }
            return result;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(UserInfo model)
        {
            int num = CommonDAL.ObjectExists("SYS_USER", "and LOGINNAME='" + model.LOGINNAME + "'and SCHOOLNO='" + model.SCHOOLNO + "' and lsh !=" + model.LSH.ToString());
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update SYS_USER set ");
                strSql.Append("LOGINPWD=@LOGINPWD,");
                strSql.Append("ROLECODE=@ROLECODE,");
                strSql.Append("TRUENAME=@TRUENAME,");
                strSql.Append("CONNPHONE=@CONNPHONE,");
                strSql.Append("CARDID=@CARDID,");
                strSql.Append("ADDRESS=@ADDRESS,");
                strSql.Append("USERSTATE=@USERSTATE,");
                strSql.Append("LASTLOGIN=@LASTLOGIN,");
                strSql.Append("JLZT=@JLZT,");
                strSql.Append("SCHOOLNAME=@SCHOOLNAME,");
                strSql.Append("SCHOOLNO=@SCHOOLNO");
                strSql.Append(" where LSH=@LSH");
                SqlParameter[] parameters = {
					new SqlParameter("@LOGINPWD", SqlDbType.VarChar,50),
					new SqlParameter("@ROLECODE", SqlDbType.Int,4),
					new SqlParameter("@TRUENAME", SqlDbType.VarChar,100),
					new SqlParameter("@CONNPHONE", SqlDbType.VarChar,20),
					new SqlParameter("@CARDID", SqlDbType.VarChar,20),
					new SqlParameter("@ADDRESS", SqlDbType.VarChar,50),
					new SqlParameter("@USERSTATE", SqlDbType.Char,1),
					new SqlParameter("@LASTLOGIN", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNAME", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30),
					new SqlParameter("@LSH", SqlDbType.Int,4),
					new SqlParameter("@LOGINNAME", SqlDbType.VarChar,50)};
                parameters[0].Value = model.LOGINPWD;
                parameters[1].Value = model.ROLECODE;
                parameters[2].Value = model.TRUENAME;
                parameters[3].Value = model.CONNPHONE;
                parameters[4].Value = model.CARDID;
                parameters[5].Value = model.ADDRESS;
                parameters[6].Value = model.USERSTATE;
                parameters[7].Value = model.LASTLOGIN;
                parameters[8].Value = model.JLZT;
                parameters[9].Value = model.SCHOOLNAME;
                parameters[10].Value = model.SCHOOLNO;
                parameters[11].Value = model.LSH.ToString();
                parameters[12].Value = model.LOGINNAME;

                return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
        }

        public static int InsertCommand(UserInfo model)
        {
            //先判断用户是否存在
            int num = CommonDAL.ObjectExists("SYS_USER", "and LOGINNAME='" + model.LOGINNAME + "'and SCHOOLNO='" + model.SCHOOLNO + "'");
            if (num > 0)
            {
                return 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into SYS_USER(");
                strSql.Append("LOGINNAME,LOGINPWD,ROLECODE,TRUENAME,CONNPHONE,CARDID,ADDRESS,USERSTATE,LASTLOGIN,JLZT,SCHOOLNAME,SCHOOLNO)");
                strSql.Append(" values (");
                strSql.Append("@LOGINNAME,@LOGINPWD,@ROLECODE,@TRUENAME,@CONNPHONE,@CARDID,@ADDRESS,@USERSTATE,@LASTLOGIN,@JLZT,@SCHOOLNAME,@SCHOOLNO)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@LOGINNAME", SqlDbType.VarChar,50),
					new SqlParameter("@LOGINPWD", SqlDbType.VarChar,50),
					new SqlParameter("@ROLECODE", SqlDbType.Int,4),
					new SqlParameter("@TRUENAME", SqlDbType.VarChar,100),
					new SqlParameter("@CONNPHONE", SqlDbType.VarChar,20),
					new SqlParameter("@CARDID", SqlDbType.VarChar,20),
					new SqlParameter("@ADDRESS", SqlDbType.VarChar,50),
					new SqlParameter("@USERSTATE", SqlDbType.Char,1),
					new SqlParameter("@LASTLOGIN", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNAME", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30)};
                parameters[0].Value = model.LOGINNAME;
                parameters[1].Value = model.LOGINPWD;
                parameters[2].Value = model.ROLECODE;
                parameters[3].Value = model.TRUENAME;
                parameters[4].Value = model.CONNPHONE;
                parameters[5].Value = model.CARDID;
                parameters[6].Value = model.ADDRESS;
                parameters[7].Value = model.USERSTATE;
                parameters[8].Value = model.LASTLOGIN;
                parameters[9].Value = model.JLZT;
                parameters[10].Value = model.SCHOOLNAME;
                parameters[11].Value = model.SCHOOLNO;

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

        public static bool UpdateCommand(string newpwd, string lsh)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE [SYS_USER]");
            sb.AppendLine(" set [LOGINPWD] = @loginpwd");
            sb.AppendLine("WHERE lsh=@lsh");
            int temp = SqlDataProvider.ExecuteBySql(sb.ToString(),
                SqlDataProvider.CreateSqlParameter("@loginpwd", SqlDbType.VarChar,newpwd),
                SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.VarChar, lsh)
                );
            return temp >= 0 ? true : false; 
        }

        public static bool UpdateCommand(string username,string connphone,string cardid,string address,string lsh)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE [SYS_USER]");
            sb.AppendLine("SET [USERNAME] = @username");
            sb.AppendLine("  ,[CONNPHONE] = @connphone");
            sb.AppendLine("  ,[CARDID] = @cardid");
            sb.AppendLine("  ,[ADDRESS] = @address");
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

        public static DataSet GetUserList(int pageindex, int pagesize,string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_UserList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }

        public static DataSet GetUserSelectList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_UserSelectList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }

        public static DataSet GetUserList(string lsh)
        {
            return SqlDataProvider.GetResultBySql("select A.*,B.rolename from SYS_USER A left join SYS_ROLE B on A.ROLECODE = B.lsh where A.lsh=@lsh",
                SqlDataProvider.CreateSqlParameter("@lsh",SqlDbType.VarChar,lsh));
        }

        public static DataTable GetUserList()
        {
            return CommonDAL.GetObjList("SYS_USER");
        }

        public static DataTable GetUserListBycode(string code)
        {
            DataTable result = null;
            try
            {
                result = SqlDataProvider.GetResultBySql("select * from SYS_USER where lsh !=@lsh",
                    SqlDataProvider.CreateSqlParameter("@lsh", SqlDbType.VarChar, code)).Tables[0];
            }
            catch
            { }
            return result;
        }

        public static DataTable GetUserRelationList(string code)
        {
            return CommonDAL.GetObjList("SYS_USERRELATION", "viewcode", code);
        }

        public static int SaveRelation(string code, string codelist)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("delete from SYS_USERRELATION where viewcode=@code");
            if (!string.IsNullOrEmpty(codelist))
            {
                string[] codestr = codelist.Split(',');
                for (int i = 0; i < codestr.Length; i++)
                {
                    sb.AppendLine("insert into SYS_USERRELATION values(@code," + codestr[i] + ")");
                }
            }

            return SqlDataProvider.ExecuteBySql(sb.ToString(),SqlDataProvider.CreateSqlParameter("@code",SqlDbType.VarChar,code));
        }

        public static DataTable GetUserInfo()
        {
            DataTable result = null;
            try
            {
                result = SqlDataProvider.GetResultBySql("select lsh,isnull(USERNAME,LOGINNAME) username from SYS_USER").Tables[0];
            }
            catch
            { }
            return result;
        }

        public static DataTable GetEmployeeInfo()
        {
            DataTable result = null;
            try
            {
                result = SqlDataProvider.GetResultBySql("select code,empName+'['+B.deptname + ']' empName from SYS_EMPLOYEE A left join SYS_DEPTMENT B on A.deptCode=B.deptcode").Tables[0];
            }
            catch
            { }
            return result;
        }
        /// <summary>
        /// 根据用户名获取登录用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static DataTable GetLoginUserInfoToApp(string username)
        {
            UserInfo userinfo = new UserInfo();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("select A.*,(select rolename from SYS_ROLE where lsh=A.ROLECODE ) rolename from SYS_USER A where JLZT='0' ");
                sb.AppendLine("and A.loginname=@username");
                DataSet ds = SqlDataProvider.GetResultBySql(sb.ToString(), SqlDataProvider.CreateSqlParameter("@username", SqlDbType.VarChar, username));
                return ds.Tables[0];
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取系统用户信息列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLoginUserListToApp()
        {
            DataTable result = null;
            try
            {
                result = SqlDataProvider.GetResultBySql("select A.*,(select rolename from SYS_ROLE where lsh=A.ROLECODE ) rolename from SYS_USER A where JLZT='0' ").Tables[0];
            }
            catch
            { }
            return result;
        }


    }
}
