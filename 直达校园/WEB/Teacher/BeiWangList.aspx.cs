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
using System.Model;

namespace BaseSystem
{

    public partial class Teacher_BeiWangList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pager.PageSize = int.Parse(System.Configuration.ConfigurationSettings.AppSettings.Get("pagesize"));

            if (!IsPostBack)
            {

                if (Request.QueryString["page"] != "" && Request.QueryString["page"] != null)
                {
                    BindRepeater(Pager.PageSize, int.Parse(Request.QueryString["page"].ToString()));
                }
                else
                {
                    BindRepeater(Pager.PageSize, 1);
                }
            }
            else
            {
                Pager.OnPagerDataBind += new PagerDelegate(BindRepeater);
            }
        }
        protected void BindRepeater(int pagesize, int pageindex)
        {

            #region 查询条件
            string xmlQuery = string.Empty;
            string username = Session["username"].ToString();
            string type = Session["cx"].ToString();
            string query = ddlFilter.SelectedValue;
            string start = "";
            string end = "";
            if (type=="教师")
            {
                type = "0";
            }
            else if (type=="学生"||type=="家长")
            {
                type = "1";
            }

            DateTime date = DateTime.Now;
            TimeSpan tspan = new TimeSpan(0);
            start = date.ToString("yyyy-MM-dd");

            if (query!="自定义范围")
            {
                txtdate1.Style.Remove("visibility");
                txtdate1.Style.Add("visibility", "hidden");
                txtdate2.Style.Remove("visibility");
                txtdate2.Style.Add("visibility", "hidden");
                btnQuery.Visible = false;

                txtdate1.Value = "";
                txtdate2.Value = "";
            }

            if (query=="最近一周")
            {
                end = date.AddDays(7).ToString("yyyy-MM-dd");
            }
            else if (query == "最近一月")
            {
                end = date.AddMonths(1).ToString("yyyy-MM-dd");
            }
            else if (query == "自定义范围")
            {
                txtdate1.Style.Remove("visibility");
                txtdate1.Style.Add("visibility", "visible");
                txtdate2.Style.Remove("visibility");
                txtdate2.Style.Add("visibility", "visible");
                btnQuery.Visible = true;

                start = txtdate1.Value;
                end = txtdate2.Value;                
            }

            xmlQuery += "  <XmlDataTable>";
            xmlQuery += "    <LOGINNAME>" + username + "</LOGINNAME>";
            xmlQuery += "    <TYPE>" + type + "</TYPE>";
            xmlQuery += "    <START>" + start + "</START>";
            xmlQuery += "    <END>" + end + "</END>";
            xmlQuery += "  </XmlDataTable>";
            #endregion

            int recordcount = 0;
            DataSet ds = BeiWangDAL.GetBeiWangList(pageindex, pagesize, xmlQuery, ref recordcount);
            rpt_stu.DataSource = ds;
            rpt_stu.DataBind();
            Pager.RecordCount = recordcount;
            Pager.SetPageIndex(pageindex);
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            bool isOk = true;
            string start = txtdate1.Value;
            string end = txtdate2.Value;
            if (start == "")
            {
                Response.Write("<script>alert('请选择开始日期');</script>");
                isOk = false;
            }
            if (end == "")
            {
                Response.Write("<script>alert('请选择结束日期');</script>");
                isOk = false;
            }

            if (isOk)
            {
                BindRepeater(Pager.PageSize, 1);
            }
        }

        protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRepeater(Pager.PageSize, 1);
        }
    }
}
