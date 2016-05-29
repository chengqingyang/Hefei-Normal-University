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
    public class RoleDAL
    {
        public static int SaveData(RoleInfo model)
        {
            int result = -1;
            if (model.Lsh.HasValue)
            {// 编号存在更新
                result = RoleDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = RoleDAL.InsertCommand(model);
            }
            return result;
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int UpdateCommand(RoleInfo model)
        {
            int result = -1;

            int objnum = CommonDAL.ObjectExists("SYS_ROLE", "and ROLENAME='" + model.Rolename + "' and lsh !='"+model.Lsh.ToString()+"'");
            if (objnum > 0)
            {
                result = 99;
            }
            else
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("UPDATE [SYS_ROLE] SET " +
                    "[ROLENAME] = @ROLENAME,"+
                    "[ROLEDEMO] = @ROLEDEMO "+
                    "WHERE LSH=@LSH");

                SqlParameter[] parameters = {
					new SqlParameter("@ROLENAME", SqlDbType.VarChar,100),
					new SqlParameter("@ROLEDEMO", SqlDbType.Text),
                    new SqlParameter("@LSH", SqlDbType.VarChar,20)};
                parameters[0].Value = model.Rolename;
                parameters[1].Value = model.Roledemo;
                parameters[2].Value = model.Lsh.ToString();

                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                return rows;
            }

            return result;
        }

        public static int InsertCommand(RoleInfo model)
        {
            int result = -1;
            int objnum = CommonDAL.ObjectExists("SYS_ROLE", "and ROLENAME='" + model.Rolename + "'");
            if (objnum > 0)
            {
                result = 99;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO [SYS_ROLE]"+
                "([ROLENAME],[ROLEDEMO]) VALUES " +
                "(@ROLENAME,@ROLEDEMO)" +
                ";select @@IDENTITY");

                SqlParameter[] parameters = {
					new SqlParameter("@ROLENAME", SqlDbType.VarChar,100),
					new SqlParameter("@ROLEDEMO", SqlDbType.Text)};
                parameters[0].Value = model.Rolename;
                parameters[1].Value = model.Roledemo;

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
            return result;
        }

        public static DataSet GetRoleList(int pageindex,int pagesize,ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Role_PageList", pageindex, pagesize);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }

        public static DataSet GetRoleList(string lsh)
        {
            return SqlDataProvider.GetResultBySql("select * from SYS_ROLE where lsh=@lsh",
                SqlDataProvider.CreateSqlParameter("@lsh",SqlDbType.VarChar,lsh));
        }

        public static DataSet GetRoleList()
        {
            return SqlDataProvider.GetResultBySql("select * from SYS_ROLE order by lsh");
        }

        public static bool ChargeRoleUse(string rolecode)
        {
            object obj = SqlDataProvider.GetScalarBySql("select COUNT(1) from dbo.SYS_USER where ROLECODE=@rolecode",
                SqlDataProvider.CreateSqlParameter("@rolecode", SqlDbType.VarChar, rolecode));
            return Convert.ToInt32(obj) > 0 ? true : false;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="userlsh"></param>
        /// <param name="rolecode"></param>
        /// <returns></returns>
        public static bool DelRole(string rolecode)
        {
            //1.删除用户菜单关系
            //2.删除用户口令

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from sys_rolemenu where rolecode = @rolecode");

            //定义更新基本信息的命令
            SqlCommand comm = new SqlCommand();
            //设置存储过程名
            comm.CommandText = strSql.ToString();

            //设置保存的参数
            comm.Parameters.Add(SqlDataProvider.GetParameterFromString("@rolecode", rolecode));
            ArrayList lstCmd = new ArrayList();
            lstCmd.Add(comm);

            comm = new SqlCommand();
            strSql = new StringBuilder();
            strSql.Append("delete from SYS_ROLE where lsh=@lsh");
            comm.CommandText = strSql.ToString();
            //设置保存的参数
            comm.Parameters.Add(SqlDataProvider.GetParameterFromString("@lsh", rolecode));
            lstCmd.Add(comm);
            bool results = SqlDataProvider.ExecuteTransWithArrayList(lstCmd);

            return results;

        }
    }
}
