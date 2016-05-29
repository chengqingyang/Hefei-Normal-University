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

    public partial class Users_XueNianEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CommonDAL.BindDropControl(ddlSchool, SchoolDAL.GetSchoolList(), "SCHOOLNAME", "SCHOOLNO", "请选择");
            }
            #region 学年信息
            if (Request.QueryString["getid"] != null)
            {
                try
                {
                    string lsh = Request.QueryString["getid"].ToString();
                    DataSet ds = XueNianDAL.GetXueNianList("lsh", lsh);
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    txtxuenianname.Value = ds.Tables[0].Rows[0]["XNNAME"].ToString();
                    txtdatestart.Value = ds.Tables[0].Rows[0]["KSRQ"].ToString().Split(' ')[0];
                    txtdateend.Value = ds.Tables[0].Rows[0]["JSRQ"].ToString().Split(' ')[0];
                    ddlSchool.SelectedValue = ds.Tables[0].Rows[0]["SCHOOLNO"].ToString();
                    ddlState.SelectedValue = ds.Tables[0].Rows[0]["STATE"].ToString();
                }
                catch
                { }
            }
            #endregion
        }
    }
}