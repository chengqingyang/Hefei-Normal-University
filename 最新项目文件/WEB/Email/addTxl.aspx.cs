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

public partial class addTxl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (!tb_pw.Text.Equals(tb_pw1.Text))
        {
            new Jscript().Alert("两次输入密码不一致，请重新输入！");
            return;
        }



        int ival = regUser(tb_user.Text, tb_pw.Text);
        if (ival == 0)
        {
            new Jscript().Alert("该用户已存在，请换名！");
            return;
        }
        else if (ival == 1)
        {
            new Jscript().Alert("新建联系人成功！");
            //Response.Redirect("Default.aspx", true);
            Server.Transfer("welcome.aspx");
        }
    }

    /// <summary>
    /// 注册用户，-1无响应，0用户名已存在，1注册成功
    /// </summary>
    /// <param name="userCode"></param>
    /// <param name="userPW"></param>
    /// <returns></returns>
    int regUser(string userCode, string userPW)
    {
        int iVal = -1;

        using (SqlConnection conn = new SqlConnection(new comClass().getConnStr()))
        {
            using (SqlCommand cmd = new SqlCommand("", conn))
            {
                cmd.CommandText = string.Format("select count(userCode) from users where userCode='{0}'", userCode);
  
                conn.Open();
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                {
                    cmd.CommandText = string.Format("insert into users(userCode,userPW,sex,MPhone,roles)values('{0}','{1}','{2}','{3}','{4}')"
                       ,userCode ,new DESEncDEC().EncryptString(userPW),rbList_sex.SelectedValue,tb_mp.Text,"user");
 
                    cmd.ExecuteNonQuery();
                    iVal = 1;
                }
                else
                    iVal = 0;
                conn.Close();
            }
        }
        return iVal;
    }

}
