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

namespace BaseSystem
{
    public partial class Student_HomeWorkEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 调课信息
            try
            {
                DataSet ds = HomeWorkDAL.GetHomeWorkList(Request.QueryString["getid"].ToString());
                //hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                div_course.InnerHtml = ds.Tables[0].Rows[0]["CID"].ToString();
                div_date.InnerHtml = ds.Tables[0].Rows[0]["BZRQ"].ToString();
                div_content.InnerHtml = ds.Tables[0].Rows[0]["ZYZW"].ToString();
            }
            catch
            { }
            #endregion
        }
    }
}
