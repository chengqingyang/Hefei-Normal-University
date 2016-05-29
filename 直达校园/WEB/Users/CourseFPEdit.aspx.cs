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

    public partial class Users_CourseFPEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.BindDropControl(ddlSchool, SchoolDAL.GetSchoolList(), "SCHOOLNAME", "SCHOOLNO", "请选择");
            }
            #region 用户信息
            if (Request.QueryString["getid"] != null)
            {                
                try
                {
                    string lsh = Request.QueryString["getid"].ToString();
                    DataSet ds = CourseFenPeiDAL.GetCourseFenPeiList("lsh", lsh);
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    ddlSchool.SelectedValue = ds.Tables[0].Rows[0]["SCHOOLNO"].ToString();

                    string schoolno = ddlSchool.SelectedValue;
                    CommonDAL.BindDropControl(ddlTeacher, TeacherDAL.GetTeacherList(), "TNAME", "TGH", "请选择");
                    CommonDAL.BindDropControl(ddlCourse, CourseDAL.GetCourseList("schoolno", schoolno), "COURSENAME", "COURSENO", "请选择");
                    CommonDAL.BindDropControl(ddlClass, ClassDAL.GetClassList("schoolno", schoolno), "CLASSNAME", "CLASSNO", "请选择");

                    ddlCourse.SelectedValue = ds.Tables[0].Rows[0]["COURSENO"].ToString();
                    ddlClass.SelectedValue = ds.Tables[0].Rows[0]["CLASSNO"].ToString();
                    ddlTeacher.SelectedValue = ds.Tables[0].Rows[0]["TGH"].ToString();
                    ddlState.SelectedValue = ds.Tables[0].Rows[0]["STATE"].ToString();
                }
                catch
                { }
            }
            #endregion
        }
        protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = null;
            string schoolno = ddlSchool.SelectedValue;
            if (schoolno == "")
                return;
            dt = TeacherDAL.GetTeacherList();
            CommonDAL.BindDropControl(ddlTeacher, TeacherDAL.GetTeacherList(), "TNAME", "TGH", "请选择");
            CommonDAL.BindDropControl(ddlCourse, CourseDAL.GetCourseList("schoolno", schoolno), "COURSENAME", "COURSENO", "请选择");
            CommonDAL.BindDropControl(ddlClass, ClassDAL.GetClassList("schoolno", schoolno), "CLASSNAME", "CLASSNO", "请选择");
        }
    }
}