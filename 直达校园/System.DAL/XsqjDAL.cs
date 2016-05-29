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
	/// <summary>
	/// 数据访问类:YW_XSQJINFO
	/// </summary>
	public partial class XsqjDAL
	{
		public XsqjDAL()
		{}

		#region 基本事件

        /// <summary>
        /// 学生请假主查询
        /// </summary>
        /// <param name="pageindex">页索引</param>
        /// <param name="pagesize">每页记录数</param>
        /// <param name="xmlQuery">查询条件</param>
        /// <param name="recordcount">返回记录数</param>
        /// <returns></returns>
        public static DataSet GetXsqjList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_XsqjList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }


        /// <summary>
        /// 学生请假保存方法
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        public static int SaveData(XsqjInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = XsqjDAL.UpdateCommand(model);
            }
            else
            {// 编号不存在保存
                result = XsqjDAL.InsertCommand(model);
            }
            return result;
        }

        public static int SaveQjspData(XsqjInfo model)
        {
            int result = -1;
            if (model.LSH.HasValue)
            {// 编号存在更新
                result = XsqjDAL.UpdateQjtCommand(model);
            }
            return result;
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public static int InsertCommand(XsqjInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into YW_XSQJINFO(");
			strSql.Append("SNO,SNAME,XNNAME,XQNAME,CALSSNO,CLASSNAME,SCHOOLNO,SCHOOLNAME,QJZT,QJSJ,QJLY,XSQZ,JSQZ,DQZT,XGSJ,BZ,DJSJ,JLZT)");
			strSql.Append(" values (");
			strSql.Append("@SNO,@SNAME,@XNNAME,@XQNAME,@CALSSNO,@CLASSNAME,@SCHOOLNO,@SCHOOLNAME,@QJZT,@QJSJ,@QJLY,@XSQZ,@JSQZ,@DQZT,@XGSJ,@BZ,@DJSJ,@JLZT)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@SNAME", SqlDbType.VarChar,50),
					new SqlParameter("@XNNAME", SqlDbType.VarChar,50),
					new SqlParameter("@XQNAME", SqlDbType.VarChar,50),
					new SqlParameter("@CALSSNO", SqlDbType.VarChar,30),
					new SqlParameter("@CLASSNAME", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30),
					new SqlParameter("@SCHOOLNAME", SqlDbType.VarChar,50),
					new SqlParameter("@QJZT", SqlDbType.VarChar,100),
					new SqlParameter("@QJSJ", SqlDbType.VarChar,100),
					new SqlParameter("@QJLY", SqlDbType.VarChar,100),
					new SqlParameter("@XSQZ", SqlDbType.VarChar,50),
					new SqlParameter("@JSQZ", SqlDbType.VarChar,50),
					new SqlParameter("@DQZT", SqlDbType.VarChar,50),
					new SqlParameter("@XGSJ", SqlDbType.DateTime),
					new SqlParameter("@BZ", SqlDbType.VarChar,200),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50)};
			parameters[0].Value = model.SNO;
			parameters[1].Value = model.SNAME;
			parameters[2].Value = model.XNNAME;
			parameters[3].Value = model.XQNAME;
			parameters[4].Value = model.CALSSNO;
			parameters[5].Value = model.CLASSNAME;
			parameters[6].Value = model.SCHOOLNO;
			parameters[7].Value = model.SCHOOLNAME;
			parameters[8].Value = model.QJZT;
			parameters[9].Value = model.QJSJ;
			parameters[10].Value = model.QJLY;
			parameters[11].Value = model.XSQZ;
			parameters[12].Value = model.JSQZ;
			parameters[13].Value = model.DQZT;
			parameters[14].Value = model.XGSJ;
			parameters[15].Value = model.BZ;
			parameters[16].Value = model.DJSJ;
			parameters[17].Value = model.JLZT;

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
        public static int UpdateCommand(XsqjInfo  model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update YW_XSQJINFO set ");
			strSql.Append("SNO=@SNO,");
			strSql.Append("SNAME=@SNAME,");
			strSql.Append("XNNAME=@XNNAME,");
			strSql.Append("XQNAME=@XQNAME,");
			strSql.Append("CALSSNO=@CALSSNO,");
			strSql.Append("CLASSNAME=@CLASSNAME,");
			strSql.Append("SCHOOLNO=@SCHOOLNO,");
			strSql.Append("SCHOOLNAME=@SCHOOLNAME,");
			strSql.Append("QJZT=@QJZT,");
			strSql.Append("QJSJ=@QJSJ,");
			strSql.Append("QJLY=@QJLY,");
			strSql.Append("XSQZ=@XSQZ,");
			strSql.Append("JSQZ=@JSQZ,");
			strSql.Append("DQZT=@DQZT,");
			strSql.Append("XGSJ=@XGSJ,");
			strSql.Append("BZ=@BZ,");
			strSql.Append("DJSJ=@DJSJ,");
			strSql.Append("JLZT=@JLZT");
			strSql.Append(" where LSH=@LSH");
			SqlParameter[] parameters = {
					new SqlParameter("@SNO", SqlDbType.VarChar,50),
					new SqlParameter("@SNAME", SqlDbType.VarChar,50),
					new SqlParameter("@XNNAME", SqlDbType.VarChar,50),
					new SqlParameter("@XQNAME", SqlDbType.VarChar,50),
					new SqlParameter("@CALSSNO", SqlDbType.VarChar,30),
					new SqlParameter("@CLASSNAME", SqlDbType.VarChar,50),
					new SqlParameter("@SCHOOLNO", SqlDbType.VarChar,30),
					new SqlParameter("@SCHOOLNAME", SqlDbType.VarChar,50),
					new SqlParameter("@QJZT", SqlDbType.VarChar,100),
					new SqlParameter("@QJSJ", SqlDbType.VarChar,100),
					new SqlParameter("@QJLY", SqlDbType.VarChar,100),
					new SqlParameter("@XSQZ", SqlDbType.VarChar,50),
					new SqlParameter("@JSQZ", SqlDbType.VarChar,50),
					new SqlParameter("@DQZT", SqlDbType.VarChar,50),
					new SqlParameter("@XGSJ", SqlDbType.DateTime),
					new SqlParameter("@BZ", SqlDbType.VarChar,200),
					new SqlParameter("@DJSJ", SqlDbType.DateTime),
					new SqlParameter("@JLZT", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4)};
			parameters[0].Value = model.SNO;
			parameters[1].Value = model.SNAME;
			parameters[2].Value = model.XNNAME;
			parameters[3].Value = model.XQNAME;
			parameters[4].Value = model.CALSSNO;
			parameters[5].Value = model.CLASSNAME;
			parameters[6].Value = model.SCHOOLNO;
			parameters[7].Value = model.SCHOOLNAME;
			parameters[8].Value = model.QJZT;
			parameters[9].Value = model.QJSJ;
			parameters[10].Value = model.QJLY;
			parameters[11].Value = model.XSQZ;
			parameters[12].Value = model.JSQZ;
			parameters[13].Value = model.DQZT;
			parameters[14].Value = model.XGSJ;
			parameters[15].Value = model.BZ;
			parameters[16].Value = model.DJSJ;
			parameters[17].Value = model.JLZT;
			parameters[18].Value = model.LSH;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 审批请假条
        /// </summary>
        public static int UpdateQjtCommand(XsqjInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update YW_XSQJINFO set ");
            strSql.Append("JSQZ=@JSQZ,");
            strSql.Append("DQZT=@DQZT");
            strSql.Append(" where LSH=@LSH");
            SqlParameter[] parameters = {

					new SqlParameter("@JSQZ", SqlDbType.VarChar,50),
					new SqlParameter("@DQZT", SqlDbType.VarChar,50),
					new SqlParameter("@LSH", SqlDbType.Int,4)};

            parameters[0].Value = model.JSQZ;
            parameters[1].Value = model.DQZT;
            parameters[2].Value = model.LSH;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }




        /// <summary>
        /// 根据lsh查询内容
        /// </summary>
        /// <param name="key"></param>
        /// <param name="keyvalue"></param>
        /// <returns></returns>
        public static DataSet GetXsqjbyLsh(string key, string keyvalue)
        {
            string sql = "select * from YW_XSQJINFO where jlzt=0 and " + key + "=@keyvalue";
            return SqlDataProvider.GetResultBySql(sql, SqlDataProvider.CreateSqlParameter("@keyvalue", SqlDbType.VarChar, keyvalue));
        }

        #endregion  基本事件
    }
}

