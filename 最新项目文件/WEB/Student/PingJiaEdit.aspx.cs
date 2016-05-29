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

    public partial class Student_PingJiaEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //要评价的教师
                string sno = Session["username"].ToString();
                DataSet ds = PingJiaDAL.GetPingJiaList("0", "sno", sno);
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.Rows[0];
                rpt_tname.DataSource = ds;
                rpt_tname.DataBind();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string stack = ex.StackTrace;
            }

            if (Request.QueryString["getid"] != null && Request.QueryString["getid"] != "")
            {
                string lsh = Request.QueryString["getid"].ToString();
                hidlsh.Value=lsh;
                DataSet ds = null;
                bool state = PingJiaDAL.GetPingJiaState(lsh, ref ds);
                if (state)
                {
                    div_info.InnerHtml = "您正在对&nbsp; <b>" + ds.Tables[0].Rows[0]["TNAME"].ToString() + "</b>&nbsp; 进行评价。";
                }
                else
                {
                    div_info.InnerHtml = "";
                    Response.Write("<script>alert(\"" + "您已评价过！" + "\")</script>");
                    //Response.Write("<script language=javascript>alert('您已评价过！')</script>");
                    txtpf.Value = ds.Tables[0].Rows[0]["PF"].ToString();
                    txtpy.Value = ds.Tables[0].Rows[0]["PY"].ToString();

                    txtpy.Disabled = true;
                    txtpf.Disabled = true;
                }
            }
            
        }
    }
}