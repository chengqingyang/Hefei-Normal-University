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
using  System.Model;
namespace BaseSystem
{
    public partial class Users_UserList : BasePage
    {
        UserInfo userinfo = new UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            userinfo = (UserInfo)SessionUtil.Session["userinfo"];
            Pager.PageSize = int.Parse(System.Configuration.ConfigurationSettings.AppSettings.Get("pagesize"));

            if (!IsPostBack)
            {
                
                if (Request.QueryString["page"] != "" && Request.QueryString["page"] != null)
                {
                    BindRepeater(Pager.PageSize, int.Parse(Request.QueryString["page"].ToString()));
                }
                else
                {
                    BindRepeater(Pager.PageSize, 1);
                }
            }
            else
            {
                Pager.OnPagerDataBind += new PagerDelegate(BindRepeater);
            }
        }

        protected void BindRepeater(int pagesize, int pageindex)
        {

            #region 查询条件
            string xmlQuery = string.Empty;
            xmlQuery += "  <XmlDataTable>";
            xmlQuery += "    <SNO>" + Session["username"] + "</SNO>";
            xmlQuery += "    <BEGINDATE>" + BeginDate.Value + "</BEGINDATE>";
            xmlQuery += "    <ENDDATE>" + EndDate.Value + "</ENDDATE>";
            xmlQuery += "  </XmlDataTable>";
            #endregion

            int recordcount = 0;
            DataSet ds = XskqDAL.GetXskqListXs(pageindex, pagesize, xmlQuery, ref recordcount);
            rpt_user.DataSource = ds;
            rpt_user.DataBind();
            Pager.RecordCount = recordcount;
            Pager.SetPageIndex(pageindex);
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindRepeater(Pager.PageSize, 1);
        }
}
}
