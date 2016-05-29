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

public partial class changePW : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
                object objPW = null;
                cmd.CommandText = "select userPW from users where userCode=" + User.Identity.Name;
                cmd.Parameters.Add("@p0", SqlDbType.VarChar, 20).Value = User.Identity.Name;
                conn.Open();
                objPW = cmd.ExecuteScalar();
                if (objPW != null)
                {


                    cmd.CommandText = "update users set userPW='" + new DESEncDEC().EncryptString(TextBox2.Text) + "' where userCode=" + User.Identity.Name;
                        cmd.ExecuteNonQuery();
                        Server.Transfer("inf.aspx?msg=密码修改成功！请妥善保存。");
                  
                    
                        
                }
                conn.Close();
            }
        }
    }
}
