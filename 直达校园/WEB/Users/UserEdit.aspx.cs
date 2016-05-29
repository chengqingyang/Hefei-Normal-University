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
    public partial class Users_UserEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                CommonDAL.BindDropControl(ddlSchool, SchoolDAL.GetSchoolList(), "SCHOOLNAME", "SCHOOLNO", "请选择");

                CommonDAL.BindDropControl(ddlrole, RoleDAL.GetRoleList(), "ROLENAME", "lsh", "请选择");
            
            }


            #region 用户信息
            if (Request.QueryString["getid"] != null)
            {
                try
                {
                    DataSet ds = UserDAL.GetUserList(Request.QueryString["getid"].ToString());
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    txtusername.Value = ds.Tables[0].Rows[0]["LOGINNAME"].ToString();
                    txtuserpwd.Value = ds.Tables[0].Rows[0]["LOGINPWD"].ToString();
                    ddlrole.SelectedValue = ds.Tables[0].Rows[0]["ROLECODE"].ToString();
                    txtconnphone.Value = ds.Tables[0].Rows[0]["CONNPHONE"].ToString();
                    txtcardid.Value = ds.Tables[0].Rows[0]["CARDID"].ToString();
                    txtaddress.Value = ds.Tables[0].Rows[0]["ADDRESS"].ToString();
                    ddlstate.Value = ds.Tables[0].Rows[0]["USERSTATE"].ToString();
                    txtTrueName.Value = ds.Tables[0].Rows[0]["TRUENAME"].ToString();
                    ddlSchool.SelectedValue = ds.Tables[0].Rows[0]["SCHOOLNO"].ToString();
                    txtusername.Disabled = true;
                }
                catch
                { }
            }
            #endregion
        }
    }
}
