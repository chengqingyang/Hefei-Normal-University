using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.DAL;

namespace BaseSystem
{

    public partial class Student_PingJiaShow : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 评价信息
            if (Request.QueryString["getid"] != null)
            {
                string getid = Request.QueryString["getid"].ToString();
                //Response.Write("=[" + Request.QueryString["getid"].ToString() + "]<br/>");
                try
                {
                    DataSet ds = PingJiaDAL.GetPingJiaList("lsh", getid);
                    //hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    string tname = ds.Tables[0].Rows[0]["TNAME"].ToString();
                    string sno = ds.Tables[0].Rows[0]["SNO"].ToString();
                    string sname = ds.Tables[0].Rows[0]["SNAME"].ToString();
                    div_info.InnerHtml = "<b>&nbsp;"+tname+"老师</b>&nbsp; 对&nbsp;<b>" + sname + "</b>&nbsp;的评价：";

                    div_content.InnerHtml = ds.Tables[0].Rows[0]["PY"].ToString();
                    div_tcsign.InnerHtml = "教师签名：<i>"+tname+"</i>";
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    string stack = ex.StackTrace;
                }
            }
            #endregion
        }
    }
}
