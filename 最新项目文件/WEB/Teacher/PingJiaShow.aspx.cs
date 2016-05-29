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

    public partial class Teacher_PingJiaShow : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string tgh = Session["username"].ToString();
                DataSet ds = PingJiaDAL.GetTeacherPingJia(tgh);
                int ypj = ds.Tables[0].Rows.Count;    //已评价人数
                int sum = ds.Tables[1].Rows.Count;    //全部参与的人数
                sp_totalStu.InnerHtml = sum.ToString()+"&nbsp; &nbsp; 有效评价："+ypj;
                if (ypj > 0)
                {
                    sp_avg.InnerHtml = ds.Tables[2].Rows[0]["PJF"].ToString();

                    ListItem li = null;
                    int num = 1;
                    string py;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        py = dr["PY"].ToString();
                        li = new ListItem(num + " ： " + py);
                        lbox_scanPY.Items.Add(li);
                        num++;
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string stack = ex.StackTrace;
            }
        }
    }
}
