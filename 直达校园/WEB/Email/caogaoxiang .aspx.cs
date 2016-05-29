using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class caogaoxiang : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lab_user.Text = "您好，<b>" + User.Identity.Name + "</b>";

        string istate = "0";
        if (Request.QueryString["state"] != null && Request.QueryString["state"] != "")
            istate = Request.QueryString["state"].ToString();

        mailList(int.Parse(istate));
    }

    void mailList(int state)
    {
        string ssql = "";
        switch (state)
        {
            //case 0://收件箱
            //    ssql = string.Format("state<>2 and toUser='{0}'and sfcg=0", User.Identity.Name);
            //    break;
            //case 1://已发送
            //    ssql = string.Format("state<>2 and fromUser='{0}'and sfcg=0", User.Identity.Name);
            //    break;
            //case 2://已删除
            //    //ssql = string.Format("state=2 and toUser='{0}'", User.Identity.Name);
            //    ssql = string.Format("(state=2 and toUser='{0}') or (state=2 and fromUser='{0}') ", User.Identity.Name, User.Identity.Name);
            //    break;
            case 3://草稿箱
                ssql = string.Format("state<>2 and fromUser='{0}'and sfcg=1", User.Identity.Name);
                break;
            default:
                ssql = string.Format("state<>2 and toUser='{0}'", User.Identity.Name);
                break;
        }

        using (SqlConnection conn = new SqlConnection(new comClass().getConnStr()))
        {
            using (SqlCommand cmd = new SqlCommand("", conn))
            {
                string sid, sf, st, ss, sdate,fjsize,fjname,fjpath;
                string srs, ers;

                cmd.CommandText = "select id,fromUser,toUser,subject,FDate,state,filesize,filename,filepath from mails where " + ssql + " order by FDate desc";
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    int ii = 0;
                    while (dr.Read())
                    {
                        ii++;

                        if (dr[5].ToString() == "1" && state==0)
                        {
                            srs = "<b>";
                            ers = "</b>";
                        }
                        else
                        {
                            srs = "";
                            ers = "";
                        }

                        sid = dr[0].ToString();
                        sf = dr[1].ToString();
                        st = dr[2].ToString();
                        ss = dr[3].ToString();
                        sdate = dr[4].ToString();

                        fjsize = dr[6].ToString();
                        fjname = dr[7].ToString();
                        fjpath = dr[8].ToString();
                        HtmlTableRow row = new HtmlTableRow();

                        //checkbox
                        HtmlTableCell cell = new HtmlTableCell();
                        cell.InnerHtml = "<input id=\"chk_" + ii + "\" type=\"checkbox\" name=\"chk_" + ii + "\"/>";
                        row.Cells.Add(cell);

                        //发件人
                        cell = new HtmlTableCell();
                        cell.InnerHtml = srs + sf + ers;
                        row.Cells.Add(cell);

                        //收件人
                        cell = new HtmlTableCell();
                        cell.InnerHtml = srs+st+ers;
                        row.Cells.Add(cell);

                        //邮件主题
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<a href=\"viewMail.aspx?id=" + sid + "\" target=\"mainFrame\">" + srs+ss+ers + "</a>";
                        row.Cells.Add(cell);

                        //附件名称
                        cell = new HtmlTableCell();
                        //cell.InnerHtml = "<a href=\"viewMail.aspx?id=" + sid + "\" >" + srs + ss + ers + "</a>";
                        cell.InnerHtml = "<a href=\"fujianfile/Download.aspx?filepath=" + fjpath + "" + fjname + " \" >" + srs + fjname + ers + "</a>";
                        row.Cells.Add(cell);

                        //附件大小
                        cell = new HtmlTableCell();
                        cell.InnerHtml = srs + fjsize + ers;
                        row.Cells.Add(cell);


                        //日期
                        cell = new HtmlTableCell();
                        cell.InnerHtml = srs+sdate+ers;
                        row.Cells.Add(cell);

                        //重新发送
                        cell = new HtmlTableCell();
                        cell.InnerHtml = "<a href=\"resendmail .aspx?id=" + sid + " \" >" + srs + "重新发送" + ers + "</a>";
                        row.Cells.Add(cell);

                        //ID
                        cell = new HtmlTableCell();
                        cell.InnerHtml = sid;
                        cell.Visible = false;
                        row.Cells.Add(cell);

                        tab_mails.Rows.Add(row);
                    }
                }
                conn.Close();
            }
        }
    }

    protected void lb_logout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Write("<script>window.open('login.aspx','_top')</script>");
    }


    protected void btn_del_Click(object sender, EventArgs e)
    {
        delMails(false);
    }

    protected void btn_del1_Click(object sender, EventArgs e)
    {
        delMails(true);
    }

    void delMails(bool del)
    {
        bool isExe = false;
        using (SqlConnection conn = new SqlConnection(new comClass().getConnStr()))
        {
            using (SqlCommand cmd = new SqlCommand("", conn))
            {
               


                conn.Open();
                for (int i = 1; i <= tab_mails.Rows.Count - 1; i++)
                {
                    string schk = Request.Form["chk_" + i.ToString()];
                    if (!string.IsNullOrEmpty(schk) && schk == "on")
                    {
                        string sid = tab_mails.Rows[i].Cells[8].InnerText;

                        if (del)
                            cmd.CommandText = "delete from mails where id=" + sid;
                        else
                            cmd.CommandText = "update mails set state=2 where id=" + sid;

                        cmd.ExecuteNonQuery();
                        isExe = true;
                    }
                }
                conn.Close();
                if (isExe)
                    Server.Transfer("inf.aspx?msg=删除邮件成功！");
            }
        }
    }
}
