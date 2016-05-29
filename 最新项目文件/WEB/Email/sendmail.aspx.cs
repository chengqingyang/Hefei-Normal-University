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

public partial class sendmail : System.Web.UI.Page
{
    SqlHelper data = new SqlHelper();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.DataSource = data.GetDataReader("select * from  users  ");
            DropDownList1.DataTextField = "userCode";
            DropDownList1.DataValueField = "userCode";
            DropDownList1.DataBind();

        }
        if (Request.QueryString["to"] != null && Request.QueryString["to"] != "")
            tb_to.Text = Request.QueryString["to"].ToString();

        if (Request.QueryString["sub"] != null && Request.QueryString["sub"] != "")
            tb_sub.Text = "Re:"+Request.QueryString["sub"].ToString();
    }

    protected void btn_send_Click(object sender, EventArgs e)
    {
        if(tb_to.Text=="")
        {
            Response.Write("<script>alert('收件人不能为空！');</script>");
            return;
        }
        if (tb_sub.Text == "")
        {
            Response.Write("<script>alert('邮件主题不能为空！');</script>");
            return;
        }
        if (tb_con.Text == "")
        {
            Response.Write("<script>alert('邮件内容不能为空！');</script>");
            return;
        }
        using (SqlConnection conn = new SqlConnection(new comClass().getConnStr()))
        {
            using (SqlCommand cmd = new SqlCommand("", conn))
            {
                if (FileUpload1.HasFile == true)
                {
                    string strfilesize = FileUpload1.PostedFile.ContentLength.ToString();
                    string strFile = Server.MapPath(@"~\fujianfile\") + FileUpload1.FileName;
                    FileUpload1.SaveAs(strFile);
                    cmd.CommandText = string.Format("insert into mails(fromUser,toUser,subject,body,state,FDate,filesize,filename,sfcg)values( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", User.Identity.Name, tb_to.Text, tb_sub.Text, tb_con.Text, 1, DateTime.Now, strfilesize, FileUpload1.FileName, 0);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Server.Transfer("inf.aspx?msg=发送邮件成功！");

                }
                else
                {
                    cmd.CommandText = string.Format("insert into mails(fromUser,toUser,subject,body,state,FDate,sfcg)values( '{0}','{1}','{2}','{3}','{4}','{5}','{6}')", User.Identity.Name, tb_to.Text, tb_sub.Text, tb_con.Text, 1, DateTime.Now, 0);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Server.Transfer("inf.aspx?msg=发送邮件成功！");
                
                }

            }
        }
    }

    protected void btn_cancle_Click(object sender, EventArgs e)
    {
        Server.Transfer("welcome.aspx");
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        tb_to.Text = DropDownList1.SelectedItem.Text;
    }
    protected void ibtnAdd_ServerClick(object sender, EventArgs e)
    {

        Server.Transfer("addTxl.aspx");
    }
    protected void btn_caogao_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(new comClass().getConnStr()))
        {
            using (SqlCommand cmd = new SqlCommand("", conn))
            {
                if (FileUpload1.HasFile == true)
                {
                    string strfilesize = FileUpload1.PostedFile.ContentLength.ToString();
                    string strFile = Server.MapPath(@"~\fujianfile\") + FileUpload1.FileName;
                    FileUpload1.SaveAs(strFile);
                    cmd.CommandText = string.Format("insert into mails(fromUser,toUser,subject,body,state,FDate,filesize,filename,sfcg)values( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", User.Identity.Name, tb_to.Text, tb_sub.Text, tb_con.Text, 1, DateTime.Now, strfilesize, FileUpload1.FileName, 1);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Server.Transfer("inf.aspx?msg=邮件存入草稿箱成功！");

                }
                else
                {
                    cmd.CommandText = string.Format("insert into mails(fromUser,toUser,subject,body,state,FDate,sfcg)values( '{0}','{1}','{2}','{3}','{4}','{5}','{6}')", User.Identity.Name, tb_to.Text, tb_sub.Text, tb_con.Text, 1, DateTime.Now, 1);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Server.Transfer("inf.aspx?msg=邮件存入草稿箱成功！");

                }
            }
        }
    }

}
