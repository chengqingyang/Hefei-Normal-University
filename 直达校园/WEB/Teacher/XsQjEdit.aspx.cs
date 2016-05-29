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

            #region 设置控件不可编辑

            txtQjzt.Disabled=true;
            txtQjsj.Disabled=true;
            txtQjsy.Disabled=true;
            txtXsqz.Disabled=true;

            #endregion 设置控件不可编辑


            #region 学生请假
            if (Request.QueryString["getid"] != null)
            {
                try
                {
                    string lsh = Request.QueryString["getid"].ToString();
                    DataSet ds = XsqjDAL.GetXsqjbyLsh("lsh", lsh);
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    txtQjzt.Value = ds.Tables[0].Rows[0]["QJZT"].ToString();
                    txtQjsj.Value = ds.Tables[0].Rows[0]["QJSJ"].ToString();
                    txtQjsy.Value = ds.Tables[0].Rows[0]["QJLY"].ToString();
                    txtXsqz.Value = ds.Tables[0].Rows[0]["XSQZ"].ToString();
                    txtJsqz.Value = ds.Tables[0].Rows[0]["JSQZ"].ToString();
                    dlJsyj.SelectedValue = ds.Tables[0].Rows[0]["DQZT"].ToString();
                }
                catch
                { }
            }
            #endregion 学生请假
        }
    }
}