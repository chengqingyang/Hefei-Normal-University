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
using System.Model;

namespace BaseSystem
{
    public partial class Users_XueQiList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pager.PageSize = int.Parse(System.Configuration.ConfigurationSettings.AppSettings.Get("pagesize"));
            if (Request.QueryString["st"] != null && Request.QueryString["st"] != "")
            {
                string state = Request.QueryString["st"].ToString();
                string lsh = Request.QueryString["lsh"].ToString();
                if (state == "0")
                {
                    state = "1";
                }
                else if (state == "1")
                {
                    state = "0";
                }
                CommonDAL.UpdateObjState("SYS_XUEQI", lsh, state);
            }
            if (Request.QueryString["sort"] != null && Request.QueryString["sort"] != "")
            {
                string sort = Request.QueryString["sort"].ToString();
                string lsh = Request.QueryString["lsh"].ToString();
                string sw = Request.QueryString["sw"].ToString();

                int sortVal = int.Parse(sort);
                if (sw == "up")
                {
                    sortVal--;
                    if (sortVal <= 0)
                        sortVal = 1;
                }
                else if (sw == "down")
                    sortVal++;
                CommonDAL.UpdateObjSort("SYS_XUEQI", lsh, sortVal);
            }

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
            string key = ddlQuery.SelectedValue;
            string value = txtQuery.Value.Trim();
            xmlQuery += "  <XmlDataTable>";
            xmlQuery += "    <KEY>" + key + "</KEY>";
            xmlQuery += "    <VALUE>" + value + "</VALUE>";
            xmlQuery += "  </XmlDataTable>";
            #endregion

            int recordcount = 0;
            DataSet ds = XueQiDAL.GetXueQiList(pageindex, pagesize, xmlQuery, ref recordcount);
            rpt_xuenian.DataSource = ds;
            rpt_xuenian.DataBind();
            Pager.RecordCount = recordcount;
            Pager.SetPageIndex(pageindex);
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindRepeater(Pager.PageSize, 1);
        }
    }
}