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
using System.Data.SqlClient;
using System.DAL;
using  System.Model;
namespace BaseSystem
{
    public partial class Users_UserList : BasePage
    {
        public static string connstring = ConfigurationManager.AppSettings["connstr"];
        private int id = 0;
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
            xmlQuery += "    <SNAME>" + sname.Value + "</SNAME>";
            xmlQuery += "    <SNO>" + sno.Value+ "</SNO>";
            xmlQuery += "    <SCHOOLNO>" + Session["schoolno"].ToString() + "</SCHOOLNO>";
            xmlQuery += "    <BEGINDATE>" + BeginDate.Value + "</BEGINDATE>";
            xmlQuery += "    <ENDDATE>" + EndDate.Value + "</ENDDATE>";
            xmlQuery += "  </XmlDataTable>";
            #endregion

            int recordcount = 0;
            DataSet ds = XskqDAL.GetXskqList(pageindex, pagesize, xmlQuery, ref recordcount);
            rpt_user.DataSource = ds;
            rpt_user.DataBind();
            Pager.RecordCount = recordcount;
            Pager.SetPageIndex(pageindex);
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            BindRepeater(Pager.PageSize, 1);
        }

        public int hsgexucute(string sql)  //自定义函数:执行sql语句,如果执行成功,返回值1,否则0
        {
            SqlConnection conn = new SqlConnection();   //定义新数据库连接
            conn.ConnectionString = connstring;  //设置该新连接字符串是connstr,即上面的webconfig里的cn值
            SqlCommand myCommand = new SqlCommand(sql, conn); //设置新执行命令

            try
            {
                conn.Open();  //打开数据库连接
                myCommand.ExecuteNonQuery(); //执行sql语句
                return 1;  //执行成功,返回1
            }
            catch
            {
                //Console.WriteLine("SqlException:{0}",SQLexc);
                return 0;  //执行失败,返回0

            }
            finally
            {
                conn.Close(); //关闭数据库连接
            }
        }
        protected void rptUser_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Data.DataRowView dr = (System.Data.DataRowView)e.Item.DataItem;

                int userId = int.Parse(dr["LSH"].ToString());
                if (userId != id)
                {
                    ((Panel)e.Item.FindControl("plItem")).Visible = true;
                    ((Panel)e.Item.FindControl("plEdit")).Visible = false;
                }
                else
                {
                    ((Panel)e.Item.FindControl("plItem")).Visible = false;
                    ((Panel)e.Item.FindControl("plEdit")).Visible = true;
                }

            }
        }

        protected void rptUser_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                id = int.Parse(e.CommandArgument.ToString());
            }
            else if (e.CommandName == "Cancel")
            {
                id = -1;
            }
            else if (e.CommandName == "Update")
            {
                string CQ = ((CheckBox)this.rpt_user.Items[e.Item.ItemIndex].FindControl("CheckBox1")).Checked.ToString() == "True" ? "1" : "0";
                string KK = ((CheckBox)this.rpt_user.Items[e.Item.ItemIndex].FindControl("CheckBox2")).Checked.ToString() == "True" ? "1" : "0";
                string SJ = ((CheckBox)this.rpt_user.Items[e.Item.ItemIndex].FindControl("CheckBox3")).Checked.ToString() == "True" ? "1" : "0";
                string BJ = ((CheckBox)this.rpt_user.Items[e.Item.ItemIndex].FindControl("CheckBox4")).Checked.ToString() == "True" ? "1" : "0";
                string sql;

                sql = "update YW_XSKQINFO set CQ='" + CQ + "',KK='" + KK + "',SJ='" + SJ + "',BJ='" + BJ + "' where LSH=" + int.Parse(e.CommandArgument.ToString());
                int result;
                result = hsgexucute(sql);
                if (result == 1)
                {
                    Response.Write("<script>javascript:alert('考勤成功！');</script>");
                }
                else
                {
                    Response.Write("<script>javascript:alert('考勤失败！');</script>");
                }

            }
            else
            {
                string sql2 = "update YW_XSKQINFO set jlzt='1' where LSH=" + int.Parse(e.CommandArgument.ToString());
                int result;
                result = hsgexucute(sql2);
                if (result == 1)
                {
                    Response.Write("<script>javascript:alert('删除考勤记录成功！');</script>");
                }
                else
                {
                    Response.Write("<script>javascript:alert('删除考勤记录失败！');</script>");
                }

            }

            BindRepeater(Pager.PageSize, 1);
        }
}
}
