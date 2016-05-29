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
    public partial class Teacher_KaoShiEdit : BasePage
    {
        string ksno = "0";
        string tgh = "";
        string schoolno = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            tgh = Session["username"].ToString();
            schoolno = TeacherDAL.GetTeacherSchoolNo(tgh);
            hidschool.Value = schoolno;
            if (!IsPostBack)
            {
                tgh = Session["username"].ToString();
                schoolno = TeacherDAL.GetTeacherSchoolNo(tgh);
                CommonDAL.BindDropControl(ddlXueNian, XueNianDAL.GetXueNianList("schoolno", schoolno), "XNNAME", "XNNO", "请选择");

                string[] values = { schoolno, ddlXueNian.SelectedValue };
                CommonDAL.BindDropControl(ddlXueQi, XueQiDAL.GetXueQiList(values), "XQNAME", "XQNO", "请选择");                
                CommonDAL.BindDropControl(ddlClass, ClassDAL.GetClassList(tgh), "CLASSNAME", "CLASSNO", "请选择");
                CommonDAL.BindDropControl(ddlCourse, CourseDAL.GetCourseList(tgh), "COURSENAME", "COURSENO", "请选择");
            }
            #region 调课信息
            if (Request.QueryString["getid"] != null)
            {
                //Response.Write("getid=[" + Request.QueryString["getid"].ToString() + "]<br/>");
                try
                {
                    DataSet ds = KaoShiDAL.GetKaoShiList(Request.QueryString["getid"].ToString());
                    DataSet ds2 = TestDeatilDAL.GetTestDeatilFirst(Request.QueryString["getid"].ToString());
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    ddlVisible.SelectedValue = ds.Tables[0].Rows[0]["STATE"].ToString();
                    ddlCourse.SelectedValue = ds.Tables[0].Rows[0]["CID"].ToString();
                    ddlXueNian.SelectedValue = ds.Tables[0].Rows[0]["XNNO"].ToString();

                    string[] values = { schoolno, ddlXueNian.SelectedValue };
                    CommonDAL.BindDropControl(ddlXueQi, XueQiDAL.GetXueQiList(values), "XQNAME", "XQNO", "请选择");
                    ddlXueQi.SelectedValue = ds.Tables[0].Rows[0]["XQNO"].ToString();
                    ddlClass.SelectedValue = ds.Tables[0].Rows[0]["CLASSNO"].ToString();
                    ddltype.SelectedValue = ds.Tables[0].Rows[0]["KSLX"].ToString();
                    txtdate.Value = ds.Tables[0].Rows[0]["KSSJ"].ToString();
                    txtjs.Value = ds2.Tables[0].Rows[0]["JS"].ToString();
                    txtzwh.Value = ds2.Tables[0].Rows[0]["ZWNO"].ToString();
                    txtremark.Value = ds2.Tables[0].Rows[0]["BZ"].ToString();
                }
                catch
                { }

                if (Request.QueryString["did"] != null)
                {
                    ksno = Request.QueryString["did"].ToString();
                    //DataSet ds = TestDeatilDAL.GetTestDeatilList("ksno", ksno);
                    //rpt_test.DataSource=ds;
                    //rpt_test.DataBind();

                    Pager.PageSize = 6;
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

                    div_result.Visible = true;
                    back.Visible = false;
                    save.Visible = false;

                    btn_addTime.Enabled = false;
                    txtdate.Disabled = true;
                    txtjs.Disabled = true;
                    txtzwh.Disabled = true;
                    txtremark.Disabled = true;
                    ddlXueNian.Enabled = false;
                    ddlXueQi.Enabled = false;
                    ddlClass.Enabled = false;
                    ddlVisible.Enabled = false;
                    ddlCourse.Enabled = false;
                    ddltype.Enabled = false;

                }
                else
                {
                    div_result.Visible = false;
                    back.Visible = true;
                    save.Visible = true;

                    btn_addTime.Enabled = true;
                    txtdate.Disabled = false;
                    txtjs.Disabled = false;
                    txtzwh.Disabled = false;
                    txtremark.Disabled = false;
                    ddlXueNian.Enabled = true;
                    ddlXueQi.Enabled = true;
                    ddlClass.Enabled = true;
                    ddlVisible.Enabled = true;
                    ddlCourse.Enabled = true;
                    ddltype.Enabled = true;
                }
            }
            #endregion
        }
        protected void btn_addTime_Click(object sender, ImageClickEventArgs e)
        {
            txtdate.Value = DateTime.Now.ToLongDateString();
        }
        protected void BindRepeater(int pagesize, int pageindex)
        {

            #region 查询条件
            string xmlQuery = string.Empty;
            xmlQuery += "  <XmlDataTable>";
            xmlQuery += "    <LOGINNAME>" + ksno + "</LOGINNAME>";
            xmlQuery += "    <STATE></STATE>";
            xmlQuery += "    <SNO></SNO>";
            xmlQuery += "  </XmlDataTable>";
            #endregion

            int recordcount = 0;
            DataSet ds = TestDeatilDAL.GetTestDeatilList(pageindex, pagesize, xmlQuery, ref recordcount);
            rpt_test.DataSource = ds;
            rpt_test.DataBind();
            Pager.RecordCount = recordcount;
            Pager.SetPageIndex(pageindex);
        }
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string classno = ddlClass.SelectedValue;
            string tgh = Session["username"].ToString();
            tgh += "' AND C.CLASSNO='" + classno;
            CommonDAL.BindDropControl(ddlCourse, CourseDAL.GetCourseList(tgh), "COURSENAME", "COURSENO", "请选择");
        }
        protected void ddlXueNian_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] values = { schoolno, ddlXueNian.SelectedValue };
            CommonDAL.BindDropControl(ddlXueQi, XueQiDAL.GetXueQiList(values), "XQNAME", "XQNO", "请选择");
        }
    }
}