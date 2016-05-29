using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;

using System.DAL;

namespace BaseSystem
{
    public partial class Teacher_PingJiaEdit : BasePage
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
                    DataSet ds = PingJiaDAL.GetPingJiaList("lsh",getid);
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    string sno = ds.Tables[0].Rows[0]["SNO"].ToString();
                    string sname = ds.Tables[0].Rows[0]["SNAME"].ToString();
                    info.InnerHtml = "请输入对【&nbsp;<b>"+sno + "&nbsp; " + sname+"</b>&nbsp;】的评价";

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