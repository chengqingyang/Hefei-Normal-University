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
    public partial class Users_CourseEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CommonDAL.BindDropControl(ddlSchool, SchoolDAL.GetSchoolList(), "SCHOOLNAME", "SCHOOLNO", "请选择");
            #region 用户信息
            if (Request.QueryString["getid"] != null)
            {
                try
                {
                    string lsh = Request.QueryString["getid"].ToString();
                    DataSet ds = CourseDAL.GetCourseList("lsh", lsh);
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    ddlSchool.SelectedValue = ds.Tables[0].Rows[0]["SCHOOLNO"].ToString();
                    txtcoursename.Value = ds.Tables[0].Rows[0]["COURSENAME"].ToString();
                    txtremark.Value = ds.Tables[0].Rows[0]["BZ"].ToString();
                }
                catch
                { }
            }
            #endregion
        }
    }
}