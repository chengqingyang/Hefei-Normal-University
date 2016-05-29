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
            #region 绑定字典项信息
            if (Request.QueryString["getid"] != null)
            {
                try
                {
                    string lsh = Request.QueryString["getid"].ToString();
                    DataSet ds = ZdxDAL.GetZdxbyLsh("lsh",lsh);
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                   txtDazx.Value = ds.Tables[0].Rows[0]["DAZX"].ToString();
                    txtWtbh.Value = ds.Tables[0].Rows[0]["WTBH"].ToString();
                    txtWtnr.Value = ds.Tables[0].Rows[0]["WTNR"].ToString();
                    txtDabh.Value = ds.Tables[0].Rows[0]["DABH"].ToString();
                    txtDaxx.Value= ds.Tables[0].Rows[0]["DAXX"].ToString();
                    txtBz.Value = ds.Tables[0].Rows[0]["BZ"].ToString();
                }
                catch
                { }
            }
            #endregion 绑定字典项信息
        }
    }
}