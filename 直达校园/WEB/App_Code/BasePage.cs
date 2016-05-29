using System;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Configuration;
using System.Text;
using System.IO;

namespace BaseSystem
{
    /// <summary>
    /// 页面的基类


    /// </summary>
    public class BasePage : System.Web.UI.Page
    {

        #region 继承页面生命周期中的各个阶段函数

        /// <summary>
        /// 页面开始时间


        /// </summary>
        private DateTime startTime;

        /// <summary>
        /// 页面请求对象
        /// </summary>
        private HttpRequest request;

        protected override void OnPreInit(EventArgs e)
        {
            // 检查登录用户信息
            if (Session["userinfo"] == null)
            {

                //Response.Redirect("/login.htm");
                return;
            }
            try
            {
                this.Title = System.Configuration.ConfigurationSettings.AppSettings["titlename"].ToString();
            }
            catch
            {
                //Response.Redirect("/login.htm");
            }
            base.OnPreInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
        }

        protected void ExportExcel(DataTable DetailDT, string[,] ht, string subhead, string FileName, string username)
        {
            StringBuilder OutTable = new StringBuilder();
            OutTable.Append("<table cellspacing=\"0\" cellpadding=\"5\" rules=\"all\" border=\"1\">");
            OutTable.Append("<tr style=\"height:50px; font-weight:bold;font-size:20pt\" align=\"center\">");
            OutTable.Append("<td colspan='" + Convert.ToString(ht.Length / 2) + "'>");
            OutTable.Append(FileName);
            OutTable.Append("</td>");
            OutTable.Append("</tr>");
            if (subhead.Length > 0)
            {
                OutTable.Append("<tr style=\"height:30px;\" align=\"right\">");
                OutTable.Append("<td colspan='" + Convert.ToString(ht.Length / 2) + "'>");
                OutTable.Append(subhead);
                OutTable.Append("</td>");
                OutTable.Append("</tr>");
            }
            OutTable.Append("<tr style=\"height:30px;\">");
            for (int i = 0; i < ht.Length / 2; i++)
            {
                OutTable.Append("<td>");
                OutTable.Append(ht[i, 0]);
                OutTable.Append("</td>");
            }

            OutTable.Append("</tr>");
            if (DetailDT != null)
            {
                for (int n = 0; n < DetailDT.Rows.Count; n++)
                {
                    OutTable.Append("<tr style=\"height:30px;\">");
                    for (int ii = 0; ii < ht.Length / 2; ii++)
                    {
                        OutTable.Append("<td>");
                        OutTable.Append(DetailDT.Rows[n][ht[ii, 1]].ToString());
                        OutTable.Append("</td>");
                    }
                    OutTable.Append("</tr>");
                }
            }
            OutTable.Append("<tr style=\"height:30px;\">");
            OutTable.Append("<td colspan='" + Convert.ToString(ht.Length / 2) + "'><span style=\"width:50%\" align=\"left\">");
            OutTable.Append("制表人：" + username + "\t");
            OutTable.Append("</span><span align=\"right\">");
            OutTable.Append("制表时间：" + DateTime.Now.ToShortDateString());
            OutTable.Append("</span></td>");
            OutTable.Append("</tr>");
            OutTable.Append("</table>");
            ExportDsToXls(this, FileName, OutTable.ToString());
        }
        /// <summary>
        /// 导出EXCEL方法
        /// </summary>
        /// <param name="page"></param>
        /// <param name="fileName"></param>
        /// <param name="html"></param>
        protected void ExportDsToXls(Page page, string fileName, string html)
        {

            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            Response.Clear();
            Response.Charset = "gb2312";
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(fileName) + ".xls");
            Response.Write("<html><head><META http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\"></head><body>");

            Response.Write(html);

            Response.Write(tw.ToString());
            Response.Write("</body></html>");
            Response.End();
            hw.Close();
            hw.Flush();
            tw.Close();
            tw.Flush();
        }
        #endregion
    }
}