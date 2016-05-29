using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    /// <summary>
    /// 用户登录，-1无响应，0用户名不存，2密码错误，1登录成功
    /// </summary>
    /// <param name="userCode"></param>
    /// <param name="userPW"></param>
    /// <param name="uptLogTimes"></param>
    /// <returns></returns>
    int userLog(string userCode, string userPW)
    {
        int iVal = -1;

        using (SqlConnection conn = new SqlConnection(new comClass().getConnStr()))
        {
            using (SqlCommand cmd = new SqlCommand("", conn))
            {
                object objPW = null;
                cmd.CommandText = string.Format("select userPW from users where userCode='{0}'", userCode);
                conn.Open();
                objPW = cmd.ExecuteScalar();
                if (objPW != null)
                {
                    if (userPW.Equals(new DESEncDEC().DecryptString(objPW.ToString())))
                    {
                        iVal = 1;
                    }
                    else iVal = 2;
                }
                else
                    iVal = 0;
                conn.Close();
            }
        }
        return iVal;
    }

    protected void ibtnLogin_ServerClick(object sender, EventArgs e)
    {
        Response.Cookies[new comConst().userCookies()].Expires = DateTime.Now.AddDays(-10);
        Response.Cookies.Remove(new comConst().userCookies());

        string suser = TxtUserName.Text;

        int ival = userLog(suser, TxtPassword.Text);

        if (ival == 0)
        {
            new Jscript().Alert("您输入的用户名不存在！");
            Server.Transfer("Login.aspx");
        }
        else
            if (ival == 2)
            {
                new Jscript().Alert("您输入的密码不正确！");
                Server.Transfer("Login.aspx");
            }
            else
                if (ival == 1)
                {
                    FormsAuthentication.SetAuthCookie(suser, false);
                    FormsAuthentication.RedirectFromLoginPage(suser, false);// 重定向到用户申请的初始页面
                    Server.Transfer("Default.aspx");
                }
    }

    protected void ibtnCancel_ServerClick(object sender, EventArgs e)
    {
        TxtUserName.Text = "";
        TxtPassword.Text = "";
    
    }
}
