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

using System.DAL;

namespace BaseSystem
{
    public partial class Users_XueQiEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.BindDropControl(ddlSchool, SchoolDAL.GetSchoolList(), "SCHOOLNAME", "SCHOOLNO", "请选择");
            }
            #region 学期信息
            if (Request.QueryString["getid"] != null)
            {
                try
                {
                    string lsh = Request.QueryString["getid"].ToString();
                    DataSet ds = XueQiDAL.GetXueQiList("lsh", lsh);
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    txtxueqiname.Value = ds.Tables[0].Rows[0]["XQNAME"].ToString();
                    txtxueqino.Value = ds.Tables[0].Rows[0]["XQNO"].ToString();
                    txtdatestart.Value = ds.Tables[0].Rows[0]["KSRQ"].ToString().Split(' ')[0];
                    txtdateend.Value = ds.Tables[0].Rows[0]["JSRQ"].ToString().Split(' ')[0];
                    ddlSchool.SelectedValue = ds.Tables[0].Rows[0]["SCHOOLNO"].ToString();
                    
                    string schoolno = ddlSchool.SelectedValue;
                    CommonDAL.BindDropControl(ddlXueNian, XueNianDAL.GetXueNianList("schoolno", schoolno), "XNNAME", "XNNO", "请选择");
        
                    ddlXueNian.SelectedValue = ds.Tables[0].Rows[0]["XNNO"].ToString();
                    ddlState.SelectedValue = ds.Tables[0].Rows[0]["STATE"].ToString();
                }
                catch
                { }
            }
            else
            {
                string xnno = ddlXueNian.SelectedValue;
                txtxueqino.Value = XueQiDAL.GetXueQiNo(xnno);
            }
            #endregion
        }
        protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            string schoolno = ddlSchool.SelectedValue;
            if (schoolno == "")
                return;
            CommonDAL.BindDropControl(ddlXueNian, XueNianDAL.GetXueNianList("schoolno", schoolno),"XNNAME", "XNNO", "请选择");
        }
    }
}