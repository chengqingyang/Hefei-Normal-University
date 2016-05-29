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
    public partial class Teacher_TiaoKeList : BasePage
    {
        string tgh = "";
        string schoolno = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Pager.PageSize = int.Parse(System.Configuration.ConfigurationSettings.AppSettings.Get("pagesize"));
            btnQuery.Attributes.Add("OnClick", "DataCheck();"); 
            tgh = Session["username"].ToString();
            schoolno = TeacherDAL.GetTeacherSchoolNo(tgh);

            if (!IsPostBack)
            {                
                CommonDAL.BindDropControl(ddlXueNian, XueNianDAL.GetXueNianList("schoolno", schoolno), "XNNAME", "XNNO", "请选择");
                string[] values = { schoolno, ddlXueNian.SelectedValue };
                CommonDAL.BindDropControl(ddlXueQi, XueQiDAL.GetXueQiList(values), "XQNAME", "XQNO", "请选择");
                CommonDAL.BindDropControl(ddlClass, ClassDAL.GetClassList(tgh), "CLASSNAME", "CLASSNO", "请选择");
            } 
            if (Request.QueryString["st"] != null && Request.QueryString["st"] != "")
            {
                string state = Request.QueryString["st"].ToString();
                string lsh = Request.QueryString["lsh"].ToString();
                if (state == "0")
                {
                    state = "1";
                }
                else if (state == "1")
                {
                    state = "0";
                }
                CommonDAL.UpdateObjState("YW_TIAOKE", lsh, state);
            }

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

            //#region 查询条件
            //string xmlQuery = string.Empty;
            //xmlQuery += "  <XmlDataTable>";
            //xmlQuery += "    <LOGINNAME>" + loginName.Value + "</LOGINNAME>";
            //xmlQuery += "    <STATE></STATE>";
            //xmlQuery += "  </XmlDataTable>";
            //#endregion
            #region 查询条件
            string xmlQuery = string.Empty;
            xmlQuery += "  <XmlDataTable>";
            xmlQuery += "    <LOGINNAME>" + tgh + "</LOGINNAME>";
            xmlQuery += "    <TKNO>" + loginName.Value + "</TKNO>";
            xmlQuery += "    <SCHOOLNO>" + schoolno + "</SCHOOLNO>";
            xmlQuery += "    <XNNO>" + ddlXueNian.SelectedValue + "</XNNO>";
            xmlQuery += "    <XQNO>" + ddlXueQi.SelectedValue + "</XQNO>";
            xmlQuery += "    <CLASSNO>" + ddlClass.SelectedValue + "</CLASSNO>";
            xmlQuery += "  </XmlDataTable>";
            #endregion

            int recordcount = 0;
            DataSet ds = TiaoKeDAL.GetTiaoKeList(pageindex, pagesize, xmlQuery, ref recordcount);
            rpt_stu.DataSource = ds;
            rpt_stu.DataBind();
            Pager.RecordCount = recordcount;
            Pager.SetPageIndex(pageindex);
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindRepeater(Pager.PageSize, 1);
        }
        protected void ddlXueNian_SelectedIndexChanged(object sender, EventArgs e)
        {
            tgh = Session["username"].ToString();
            schoolno = TeacherDAL.GetTeacherSchoolNo(tgh);
            string xnno = ddlXueNian.SelectedValue;
            string[] values = { schoolno, xnno };
            CommonDAL.BindDropControl(ddlXueQi, XueQiDAL.GetXueQiList(values), "XQNAME", "XQNO", "请选择");

            BindRepeater(Pager.PageSize, 1);
        }
    }
}
