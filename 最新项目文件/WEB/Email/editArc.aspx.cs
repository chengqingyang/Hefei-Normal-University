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

public partial class editArc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (SqlConnection conn = new SqlConnection(new comClass().getConnStr()))
            {
                using (SqlCommand cmd = new SqlCommand("", conn))
                {
                    cmd.CommandText = string.Format("select userCode,sex,birthday,MPhone,email,FAdd,QQ,homeUrl from users where userCode='{0}'",User.Identity.Name);
 
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            TextBox1.Text = User.Identity.Name;
                            TextBox2.Text = dr[1].ToString();
                            //TextBox3.Text = dr[3].ToString();
                            TextBox4.Text = dr[3].ToString();
                            TextBox5.Text = dr[4].ToString();
                            TextBox6.Text = dr[5].ToString();
                            TextBox7.Text = dr[6].ToString();
                            TextBox8.Text = dr[7].ToString();
                        }
                    }
                    conn.Close();
                }
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("welcome.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        using (SqlConnection conn = new SqlConnection(new comClass().getConnStr()))
        {
            using (SqlCommand cmd = new SqlCommand("", conn))
            {
                cmd.CommandText = string.Format("update users set sex='{0}',MPhone='{1}',email='{2}',FAdd='{3}',QQ='{4}',homeUrl='{5}' where userCode='{6}'"
                    ,TextBox2.Text,TextBox4.Text,TextBox5.Text,TextBox6.Text,TextBox7.Text,TextBox8.Text,User.Identity.Name);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        Server.Transfer("inf.aspx?msg=个人资料修改成功！");
    }
}
