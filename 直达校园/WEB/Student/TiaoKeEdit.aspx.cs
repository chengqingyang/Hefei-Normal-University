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

    public partial class Student_TiaoKeEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 调课信息
            try
            {
                DataSet ds = TiaoKeDAL.GetTiaoKeList(Request.QueryString["getid"].ToString());
                //hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                div_date.InnerHtml = ds.Tables[0].Rows[0]["TKRQ"].ToString();
                div_content.InnerHtml = ds.Tables[0].Rows[0]["TKZW"].ToString();
            }
            catch
            { }
            #endregion
        }
    }
}
