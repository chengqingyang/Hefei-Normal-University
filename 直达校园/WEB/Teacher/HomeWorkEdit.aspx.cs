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
    public partial class Teacher_HomeWorkEdit : BasePage
    {
        string tgh = "";
        string schoolno = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            tgh = Session["username"].ToString();
            schoolno = TeacherDAL.GetTeacherSchoolNo(tgh);
            hidschool.Value = schoolno;

            if (!IsPostBack)
            {
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
                    DataSet ds = HomeWorkDAL.GetHomeWorkList(Request.QueryString["getid"].ToString());
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    txtdate.Value = ds.Tables[0].Rows[0]["BZRQ"].ToString();
                    txtbody.Value = ds.Tables[0].Rows[0]["ZYZW"].ToString();
                    ddlVisible.SelectedValue = ds.Tables[0].Rows[0]["STATE"].ToString();
                    
                    CommonDAL.BindDropControl(ddlCourse, CourseDAL.GetCourseList(tgh), "COURSENAME", "COURSENO", "请选择");
                    ddlCourse.SelectedValue = ds.Tables[0].Rows[0]["CID"].ToString();
                    ddlXueNian.SelectedValue = ds.Tables[0].Rows[0]["XNNO"].ToString();

                    string[] values = { schoolno, ddlXueNian.SelectedValue };
                    CommonDAL.BindDropControl(ddlXueQi, XueQiDAL.GetXueQiList(values), "XQNAME", "XQNO", "请选择");
                    ddlXueQi.SelectedValue = ds.Tables[0].Rows[0]["XQNO"].ToString();
                    ddlClass.SelectedValue = ds.Tables[0].Rows[0]["CLASSNO"].ToString();
                }
                catch
                { }
            }
            #endregion
        }
        protected void btn_addTime_Click(object sender, ImageClickEventArgs e)
        {
            txtdate.Value = DateTime.Now.ToLongDateString();
        }
        protected void ddlXueNian_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] values = { schoolno, ddlXueNian.SelectedValue };
            CommonDAL.BindDropControl(ddlXueQi, XueQiDAL.GetXueQiList(values), "XQNAME", "XQNO", "请选择");
        }
    }
}