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

public partial class viewMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string istate = "0";
        if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            istate = Request.QueryString["id"].ToString();

        if (!string.IsNullOrEmpty(istate))
        {
            string istat = new comClass().getValWithSQL("mails","state","id="+istate);
            string name = new comClass().getValWithSQL("mails", "toUser", "id=" + istate);
            if (istat == "1"&&(name == User.Identity.Name))
                new comClass().execSQL("","update mails set state=0 where id="+istate);

            showMail(int.Parse(istate));
        }
        ViewState["id"] = istate;
    }

    void showMail(int id)
    {
        using (SqlConnection conn = new SqlConnection(new comClass().getConnStr()))
        {
            using (SqlCommand cmd = new SqlCommand("", conn))
            {
                cmd.CommandText = "select ID,fromUser,toUser,subject,body,FDate,filesize,filename from mails where id=" + id;
                conn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        lab_date.Text = dr[5].ToString();
                        lab_from.Text = dr[1].ToString();
                        lab_to.Text = dr[2].ToString();
                        lab_sub.Text = dr[3].ToString();
                        lab_fjsize.Text = dr[6].ToString()+"KB";
                        lab_fjname.Text = dr[7].ToString();

                        div_body.InnerHtml = dr[4].ToString();
                    }
                }
                conn.Close();
            }
        }
    }

    void delMails(bool del)
    {
        if (string.IsNullOrEmpty(ViewState["id"].ToString()))
            return;

        bool isExe = false;
        using (SqlConnection conn = new SqlConnection(new comClass().getConnStr()))
        {
            using (SqlCommand cmd = new SqlCommand("", conn))
            {
                if (del)
                    cmd.CommandText = "delete from mails where id=?";
                else
                    cmd.CommandText = "update mails set state=2 where id=?";

                cmd.Parameters.Add("@p0", SqlDbType.Int).Value = ViewState["id"].ToString();

                conn.Open();
                cmd.ExecuteNonQuery();
                isExe = true;
                conn.Close();
                if (isExe)
                    Server.Transfer("inf.aspx?msg=删除邮件成功！");
            }
        }
    }
    protected void btn_del_Click(object sender, EventArgs e)
    {
        delMails(false);
    }
    protected void btn_del1_Click(object sender, EventArgs e)
    {
        delMails(true);
    }
}
