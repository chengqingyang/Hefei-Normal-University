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
    public partial class Users_SchoolEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 绑定学校信息
            if (Request.QueryString["getid"] != null)
            {
                try
                {
                    string lsh = Request.QueryString["getid"].ToString();
                    DataSet ds = SchoolDAL.GetSchoolList("lsh",lsh);
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    txtschoolname.Value = ds.Tables[0].Rows[0]["SCHOOLNAME"].ToString();
                    txtxzname.Value = ds.Tables[0].Rows[0]["XZNAME"].ToString();
                    txtschooladdr.Value = ds.Tables[0].Rows[0]["SCHOOLADDR"].ToString();
                    txtremark.Value = ds.Tables[0].Rows[0]["BZ"].ToString();
                }
                catch
                { }
            }
            #endregion 绑定学校信息
        }
    }
}