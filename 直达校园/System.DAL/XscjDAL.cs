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
    public class XscjDAL
    {
        public XscjDAL()
        { }
        
        #region  基础方法

        /// <summary>
        /// 学生成绩查询（教师）
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="xmlQuery"></param>
        /// <param name="recordcount"></param>
        /// <returns></returns>
        public static DataSet GetXscjList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_XscjList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }

        /// <summary>
        /// 学生成绩查询（学生）
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="xmlQuery"></param>
        /// <param name="recordcount"></param>
        /// <returns></returns>
        public static DataSet GetGrcjList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_GetGrcj", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }
        #endregion  基础方法
    }
}