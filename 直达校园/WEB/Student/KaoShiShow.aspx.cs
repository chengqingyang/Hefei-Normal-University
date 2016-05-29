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
    public partial class Student_KaoShiShow : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 考试信息
            try
            {
                DataSet ds = TestDeatilDAL.GetTestDeatilList("sno", Session["username"].ToString());
                DataSet ds2;
                string ksno,km,time; 
                HtmlGenericControl div_km;
                HtmlGenericControl div_time;
                RepeaterItem ri;

                rpt_test.DataSource = ds;
                rpt_test.DataBind();
                    
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    ksno = ds.Tables[0].Rows[j]["KSNO"].ToString();
                    ds2 = KaoShiDAL.GetKaoShiList("KSNO", ksno);
                    if (ds2.Tables[0].Rows.Count<=0)
                    {
                        ds.Tables[0].Rows.RemoveAt(j);
                        continue;
                    }
                    km = ds2.Tables[0].Rows[0]["COURSENAME"].ToString();
                    time = ds2.Tables[0].Rows[0]["KSSJ"].ToString();

                    ri = rpt_test.Items[j];
                    div_km = ri.FindControl("div_km") as HtmlGenericControl;
                    div_km.InnerHtml = km;
                    div_time = ri.FindControl("div_time") as HtmlGenericControl;
                    div_time.InnerHtml = time;
                }
            }
            catch(Exception exc)
            {
                string emsg = exc.Message;
                string stack = exc.StackTrace;
            }
            #endregion
        }
    }
}