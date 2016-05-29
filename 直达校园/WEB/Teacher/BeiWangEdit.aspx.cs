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

    public partial class Teacher_BeiWangEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 调课信息
            if (Request.QueryString["getid"] != null)
            {
                //Response.Write("getid=[" + Request.QueryString["getid"].ToString() + "]<br/>");
                try
                {
                    DataSet ds = BeiWangDAL.GetBeiWangList("lsh",Request.QueryString["getid"].ToString());
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    txtdate.Value = ds.Tables[0].Rows[0]["BWSJ"].ToString();
                    txtbody.Value = ds.Tables[0].Rows[0]["BWZW"].ToString();
                    txttitle.Value = ds.Tables[0].Rows[0]["TITLE"].ToString();
                }
                catch
                { }
            }
            #endregion
        }
    }
}