using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Data.SqlClient;

/// <summary>
/// comClass 的摘要说明
/// </summary>
public class comClass
{
    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    /// <returns></returns>
    public string getConnStr()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["mailConnectionString"].ConnectionString;
    }

    /// <summary>
    /// 获取指定Cookie名的值
    /// </summary>
    public string getCookieVal(string cookieName, string defaultVal)
    {
        if (System.Web.HttpContext.Current.Request.Cookies[cookieName] != null && System.Web.HttpContext.Current.Request.Cookies[cookieName].Value != "")
        {
            string sTmp = System.Web.HttpContext.Current.Server.UrlDecode(System.Web.HttpContext.Current.Request.Cookies[cookieName].Value);
            sTmp = new DESEncDEC().DecryptString(sTmp);
            return sTmp;
        }
        else
            return defaultVal;
    }

    public void fillddList(ListControl ddList, string fillField, string valField, string sSQL)
    {
        string sConn = getConnStr();
        SqlConnection conn = new SqlConnection(sConn);
        SqlCommand cmd = new SqlCommand(sSQL, conn);
        try
        {
            ddList.Items.Clear();
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ListItem aa = new ListItem(dr[0].ToString(), dr[1].ToString());
                ddList.Items.Add(aa);
            }
            dr.Close();
            conn.Close();
        }
        finally
        {
            cmd.Dispose();
            conn.Dispose();
        }
    }

    //执行SQL语句
    public void execSQL(string sConn, string sSQL)
    {
        if (string.IsNullOrEmpty(sConn))
            sConn = getConnStr();
        SqlConnection conn = new SqlConnection(sConn);
        SqlCommand cmd = new SqlCommand(sSQL, conn);
        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        finally
        {
            cmd.Dispose();
            conn.Dispose();
        }
    }

    public string getValWithSQL(string sTab, string desField, string sSQL)
    {
        string sTmp = "select " + desField + " from " + sTab + " where 1=1";
        if (!string.IsNullOrEmpty(sSQL))
        {
            if (sSQL.Trim().Substring(0, 3) == "and")
                sTmp += " " + sSQL;
            else
                sTmp += " and " + sSQL;
        }

        string sVal = "";
        string sConn = getConnStr();
        using (SqlConnection conn = new SqlConnection(sConn))
        {
            using (SqlCommand cmd = new SqlCommand(sTmp, conn))
            {
                object objVal = null;
                conn.Open();
                objVal = cmd.ExecuteScalar();
                if (objVal != null)
                    sVal = objVal.ToString();
                conn.Close();
            }
        }
        return sVal;
    }

}


/// <summary>
/// DES算法字符串简单加解密
/// </summary>
public class DESEncDEC
{
    private const string CIV = "pExI9G5+mvU=";//"kXwL7X2+fgM=";//密钥，必须按照前面这个格式来写。不然报错
    private const string CKEY = "FwGQWRRgKCI=";//初始化向量

    /// <summary>
    /// 加密
    /// </summary>
    public string EncryptString(string Value)
    {
        ICryptoTransform ct;
        MemoryStream ms;
        CryptoStream cs;
        byte[] byt;

        ct = new DESCryptoServiceProvider().CreateEncryptor(Convert.FromBase64String(CKEY), Convert.FromBase64String(CIV));

        byt = Encoding.UTF8.GetBytes(Value);

        ms = new MemoryStream();
        cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
        cs.Write(byt, 0, byt.Length);
        cs.FlushFinalBlock();

        cs.Close();

        return Convert.ToBase64String(ms.ToArray());
    }

    /// <summary>
    /// 解密
    /// </summary>
    public string DecryptString(string Value)
    {
        ICryptoTransform ct;
        MemoryStream ms;
        CryptoStream cs;
        byte[] byt;

        ct = new DESCryptoServiceProvider().CreateDecryptor(Convert.FromBase64String(CKEY), Convert.FromBase64String(CIV));

        byt = Convert.FromBase64String(Value);

        ms = new MemoryStream();
        cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
        cs.Write(byt, 0, byt.Length);
        cs.FlushFinalBlock();

        cs.Close();

        return Encoding.UTF8.GetString(ms.ToArray());
    }
}

/// <summary>
/// javascript脚本类，本例子只有一个脚本提示函数
/// </summary>
public class Jscript
{
    /// <summary>
    /// 弹出JavaScript小窗口
    /// </summary>
    /// <param name="js">窗口信息</param>
    public void Alert(string message)
    {
        string js = @"<Script language='JavaScript'>
                    alert('" + message + "');</Script>";
        HttpContext.Current.Response.Write(js);
    }

    /// <summary>
    /// 关闭当前页面，并提示是否关闭
    /// </summary>
    public void closePgae0()
    {
        HttpContext.Current.Response.Write("<script language:javascript>javascript:window.close();</script>");
    }

    /// <summary>
    /// 关闭当前页面，不提示
    /// </summary>
    public void closePage1()
    {
        HttpContext.Current.Response.Write("<script language:javascript>javascript:window.opener=null;window.close();</script>");
    }
}

/// <summary>
/// 常量
/// </summary>
public class comConst
{
    /// <summary>
    /// 登录用户的Cookies名
    /// </summary>
    /// <returns></returns>
    public string userCookies()
    {
        return "user_mail";
    }
}