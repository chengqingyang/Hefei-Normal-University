
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MicroSoft.EnterpriseLibrary.Data;
namespace System.DAL
{
	public partial class XskqDAL
	{
        public XskqDAL()
		{}
        //#region  BasicMethod



        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public int Add(Maticsoft.Model.YW_XSKQINFO model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("insert into YW_XSKQINFO(");
        //    strSql.Append("SNO,CQ,KK,SJ,BJ,DJRYGH,DJRQ,BZ,XGSJ,LRSJ,JLZT)");
        //    strSql.Append(" values (");
        //    strSql.Append("@SNO,@CQ,@KK,@SJ,@BJ,@DJRYGH,@DJRQ,@BZ,@XGSJ,@LRSJ,@JLZT)");
        //    strSql.Append(";select @@IDENTITY");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@SNO", SqlDbType.VarChar,50),
        //            new SqlParameter("@CQ", SqlDbType.VarChar,2),
        //            new SqlParameter("@KK", SqlDbType.VarChar,2),
        //            new SqlParameter("@SJ", SqlDbType.VarChar,2),
        //            new SqlParameter("@BJ", SqlDbType.VarChar,2),
        //            new SqlParameter("@DJRYGH", SqlDbType.VarChar,50),
        //            new SqlParameter("@DJRQ", SqlDbType.DateTime),
        //            new SqlParameter("@BZ", SqlDbType.VarChar,100),
        //            new SqlParameter("@XGSJ", SqlDbType.DateTime),
        //            new SqlParameter("@LRSJ", SqlDbType.DateTime),
        //            new SqlParameter("@JLZT", SqlDbType.VarChar,50)};
        //    parameters[0].Value = model.SNO;
        //    parameters[1].Value = model.CQ;
        //    parameters[2].Value = model.KK;
        //    parameters[3].Value = model.SJ;
        //    parameters[4].Value = model.BJ;
        //    parameters[5].Value = model.DJRYGH;
        //    parameters[6].Value = model.DJRQ;
        //    parameters[7].Value = model.BZ;
        //    parameters[8].Value = model.XGSJ;
        //    parameters[9].Value = model.LRSJ;
        //    parameters[10].Value = model.JLZT;

        //    object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public bool Update(Maticsoft.Model.YW_XSKQINFO model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("update YW_XSKQINFO set ");
        //    strSql.Append("SNO=@SNO,");
        //    strSql.Append("CQ=@CQ,");
        //    strSql.Append("KK=@KK,");
        //    strSql.Append("SJ=@SJ,");
        //    strSql.Append("BJ=@BJ,");
        //    strSql.Append("DJRYGH=@DJRYGH,");
        //    strSql.Append("DJRQ=@DJRQ,");
        //    strSql.Append("BZ=@BZ,");
        //    strSql.Append("XGSJ=@XGSJ,");
        //    strSql.Append("LRSJ=@LRSJ,");
        //    strSql.Append("JLZT=@JLZT");
        //    strSql.Append(" where LSH=@LSH");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@SNO", SqlDbType.VarChar,50),
        //            new SqlParameter("@CQ", SqlDbType.VarChar,2),
        //            new SqlParameter("@KK", SqlDbType.VarChar,2),
        //            new SqlParameter("@SJ", SqlDbType.VarChar,2),
        //            new SqlParameter("@BJ", SqlDbType.VarChar,2),
        //            new SqlParameter("@DJRYGH", SqlDbType.VarChar,50),
        //            new SqlParameter("@DJRQ", SqlDbType.DateTime),
        //            new SqlParameter("@BZ", SqlDbType.VarChar,100),
        //            new SqlParameter("@XGSJ", SqlDbType.DateTime),
        //            new SqlParameter("@LRSJ", SqlDbType.DateTime),
        //            new SqlParameter("@JLZT", SqlDbType.VarChar,50),
        //            new SqlParameter("@LSH", SqlDbType.Int,4)};
        //    parameters[0].Value = model.SNO;
        //    parameters[1].Value = model.CQ;
        //    parameters[2].Value = model.KK;
        //    parameters[3].Value = model.SJ;
        //    parameters[4].Value = model.BJ;
        //    parameters[5].Value = model.DJRYGH;
        //    parameters[6].Value = model.DJRQ;
        //    parameters[7].Value = model.BZ;
        //    parameters[8].Value = model.XGSJ;
        //    parameters[9].Value = model.LRSJ;
        //    parameters[10].Value = model.JLZT;
        //    parameters[11].Value = model.LSH;

        //    int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public bool Delete(int LSH)
        //{
			
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("delete from YW_XSKQINFO ");
        //    strSql.Append(" where LSH=@LSH");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@LSH", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = LSH;

        //    int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        ///// <summary>
        ///// 批量删除数据
        ///// </summary>
        //public bool DeleteList(string LSHlist )
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("delete from YW_XSKQINFO ");
        //    strSql.Append(" where LSH in ("+LSHlist + ")  ");
        //    int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public Maticsoft.Model.YW_XSKQINFO GetModel(int LSH)
        //{
			
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select  top 1 LSH,SNO,CQ,KK,SJ,BJ,DJRYGH,DJRQ,BZ,XGSJ,LRSJ,JLZT from YW_XSKQINFO ");
        //    strSql.Append(" where LSH=@LSH");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@LSH", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = LSH;

        //    Maticsoft.Model.YW_XSKQINFO model=new Maticsoft.Model.YW_XSKQINFO();
        //    DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
        //    if(ds.Tables[0].Rows.Count>0)
        //    {
        //        return DataRowToModel(ds.Tables[0].Rows[0]);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public Maticsoft.Model.YW_XSKQINFO DataRowToModel(DataRow row)
        //{
        //    Maticsoft.Model.YW_XSKQINFO model=new Maticsoft.Model.YW_XSKQINFO();
        //    if (row != null)
        //    {
        //        if(row["LSH"]!=null && row["LSH"].ToString()!="")
        //        {
        //            model.LSH=int.Parse(row["LSH"].ToString());
        //        }
        //        if(row["SNO"]!=null)
        //        {
        //            model.SNO=row["SNO"].ToString();
        //        }
        //        if(row["CQ"]!=null)
        //        {
        //            model.CQ=row["CQ"].ToString();
        //        }
        //        if(row["KK"]!=null)
        //        {
        //            model.KK=row["KK"].ToString();
        //        }
        //        if(row["SJ"]!=null)
        //        {
        //            model.SJ=row["SJ"].ToString();
        //        }
        //        if(row["BJ"]!=null)
        //        {
        //            model.BJ=row["BJ"].ToString();
        //        }
        //        if(row["DJRYGH"]!=null)
        //        {
        //            model.DJRYGH=row["DJRYGH"].ToString();
        //        }
        //        if(row["DJRQ"]!=null && row["DJRQ"].ToString()!="")
        //        {
        //            model.DJRQ=DateTime.Parse(row["DJRQ"].ToString());
        //        }
        //        if(row["BZ"]!=null)
        //        {
        //            model.BZ=row["BZ"].ToString();
        //        }
        //        if(row["XGSJ"]!=null && row["XGSJ"].ToString()!="")
        //        {
        //            model.XGSJ=DateTime.Parse(row["XGSJ"].ToString());
        //        }
        //        if(row["LRSJ"]!=null && row["LRSJ"].ToString()!="")
        //        {
        //            model.LRSJ=DateTime.Parse(row["LRSJ"].ToString());
        //        }
        //        if(row["JLZT"]!=null)
        //        {
        //            model.JLZT=row["JLZT"].ToString();
        //        }
        //    }
        //    return model;
        //}

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select LSH,SNO,CQ,KK,SJ,BJ,DJRYGH,DJRQ,BZ,XGSJ,LRSJ,JLZT ");
        //    strSql.Append(" FROM YW_XSKQINFO ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

        ///// <summary>
        ///// 获得前几行数据
        ///// </summary>
        //public DataSet GetList(int Top,string strWhere,string filedOrder)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select ");
        //    if(Top>0)
        //    {
        //        strSql.Append(" top "+Top.ToString());
        //    }
        //    strSql.Append(" LSH,SNO,CQ,KK,SJ,BJ,DJRYGH,DJRQ,BZ,XGSJ,LRSJ,JLZT ");
        //    strSql.Append(" FROM YW_XSKQINFO ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    strSql.Append(" order by " + filedOrder);
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

        ///// <summary>
        ///// 获取记录总数
        ///// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) FROM YW_XSKQINFO ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    object obj = DbHelperSQL.GetSingle(strSql.ToString());
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("SELECT * FROM ( ");
        //    strSql.Append(" SELECT ROW_NUMBER() OVER (");
        //    if (!string.IsNullOrEmpty(orderby.Trim()))
        //    {
        //        strSql.Append("order by T." + orderby );
        //    }
        //    else
        //    {
        //        strSql.Append("order by T.LSH desc");
        //    }
        //    strSql.Append(")AS Row, T.*  from YW_XSKQINFO T ");
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //    {
        //        strSql.Append(" WHERE " + strWhere);
        //    }
        //    strSql.Append(" ) TT");
        //    strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

        ///*
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@tblName", SqlDbType.VarChar, 255),
        //            new SqlParameter("@fldName", SqlDbType.VarChar, 255),
        //            new SqlParameter("@PageSize", SqlDbType.Int),
        //            new SqlParameter("@PageIndex", SqlDbType.Int),
        //            new SqlParameter("@IsReCount", SqlDbType.Bit),
        //            new SqlParameter("@OrderType", SqlDbType.Bit),
        //            new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
        //            };
        //    parameters[0].Value = "YW_XSKQINFO";
        //    parameters[1].Value = "LSH";
        //    parameters[2].Value = PageSize;
        //    parameters[3].Value = PageIndex;
        //    parameters[4].Value = 0;
        //    parameters[5].Value = 0;
        //    parameters[6].Value = strWhere;	
        //    return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        //}*/

        //#endregion  BasicMethod


		#region  ExtensionMethod

        /// <summary>
        /// 分页获取数据学生考勤列表
        /// </summary>
        public static DataSet GetXskqList(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_XskqList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }
        /// <summary>
        /// 分页获取考勤信息
        /// </summary>
        public static DataSet GetXskqListXs(int pageindex, int pagesize, string xmlQuery, ref int recordcount)
        {
            DataSet result = null;
            result = SqlDataProvider.GetResultByProc("Page_GetKqList", pageindex, pagesize, xmlQuery);
            try
            {
                recordcount = int.Parse(result.Tables[1].Rows[0][0].ToString());
            }
            catch
            { }
            return result;
        }
		#endregion  ExtensionMethod
	}
}

