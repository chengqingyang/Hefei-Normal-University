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
    public partial class Teacher_ZhiRiEdit : BasePage
    {
        string username = "";
        string schoolno = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Session["username"].ToString();
            schoolno = TeacherDAL.GetTeacherSchoolNo(username);
            hidschoolno.Value=schoolno;
            if (!IsPostBack)
            {
                CommonDAL.BindDropControl(ddlXueNian, XueNianDAL.GetXueNianList("schoolno", schoolno), "XNNAME", "XNNO", "请选择");
                string[] values = { schoolno, ddlXueNian.SelectedValue };
                CommonDAL.BindDropControl(ddlXueQi, XueQiDAL.GetXueQiList(values), "XQNAME", "XQNO", "请选择");
                CommonDAL.BindDropControl(ddlClass, ClassDAL.GetClassList(username), "CLASSNAME", "CLASSNO", "请选择");
            }
            #region 值日信息
            if (Request.QueryString["getid"] != null)
            {
                string getid = Request.QueryString["getid"].ToString();
                try
                {
                    DataSet ds = ZhiRiDAL.GetZhiRiList(getid);
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    txtid.Value = ds.Tables[0].Rows[0]["WNO"].ToString();
                    txtmon.Value = ds.Tables[0].Rows[0]["MON"].ToString();
                    txttue.Value = ds.Tables[0].Rows[0]["TUE"].ToString();
                    txtwed.Value = ds.Tables[0].Rows[0]["WED"].ToString().Split(' ')[0];
                    txtthu.Value = ds.Tables[0].Rows[0]["THU"].ToString();
                    txtfri.Value = ds.Tables[0].Rows[0]["FRI"].ToString();
                    txtcontent.Value = ds.Tables[0].Rows[0]["ZRNR"].ToString();
                    ddlClass.SelectedValue = ds.Tables[0].Rows[0]["CLASSNO"].ToString();
                    ddlXueNian.SelectedValue = ds.Tables[0].Rows[0]["XNNO"].ToString();
                    
                    string[] values = { schoolno, ddlXueNian.SelectedValue };
                    CommonDAL.BindDropControl(ddlXueQi, XueQiDAL.GetXueQiList(values), "XQNAME", "XQNO", "请选择");
                    ddlXueQi.SelectedValue = ds.Tables[0].Rows[0]["XQNO"].ToString();
                    txtid.Disabled = true;
                }
                catch
                { }
            }
            else
            {
                string wno = ZhiRiDAL.GetZhiRiNo();
                txtid.Value = wno;
                txtid.Disabled = true;
            }
            #endregion
        }
        protected void ddlXueNian_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] values = { schoolno, ddlXueNian.SelectedValue };
            CommonDAL.BindDropControl(ddlXueQi, XueQiDAL.GetXueQiList(values), "XQNAME", "XQNO", "请选择");
        }
    }
}