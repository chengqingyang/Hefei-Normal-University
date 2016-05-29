using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MicroSoft.EnterpriseLibrary.Data;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cx.Items.Add("超级管理员");
            cx.Items.Add("管理员");
            cx.Items.Add("教师");
            cx.Items.Add("学生");
            //cx.Items.Add("家长");

        }

        //Session["username"] = "admin";
        //Session["cx"] = "管理员";
        //Session["lsh"] = "1";
        //Response.Redirect("main.aspx");

        //Session["username"] = "201";
        //Session["cx"] = "教师";
        //Session["lsh"] = "2";
        //Response.Redirect("main.aspx");

        //Session["username"] = "101";
        //Session["cx"] = "学生";
        //Session["lsh"] = "1";
        //Response.Redirect("main.aspx");
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox2.Text.ToString().Trim() == "" || TextBox1.Text.ToString().Trim() == "")
        {
            Response.Write("<script>javascript:alert('请输入完整');history.back();</script>");
            Response.End();
        }
        string sql;
        sql = "";
        if (cx.Text.ToString().Trim() == "超级管理员")
        {
            sql = "select * from SYS_USER where LOGINNAME='" + TextBox1.Text.ToString().Trim() + "' and LOGINPWD='" + TextBox2.Text.ToString().Trim() + "' and USERSTATE='1' and ROLECODE='2'";
        }
        if (cx.Text.ToString().Trim() == "管理员")
        {
            sql = "select * from SYS_USER where LOGINNAME='" + TextBox1.Text.ToString().Trim() + "' and LOGINPWD='" + TextBox2.Text.ToString().Trim() + "' and USERSTATE='1'and ROLECODE='1'";
        }
        if (cx.Text.ToString().Trim() == "学生")
        {
            sql = "select * from YW_STUDENT where SNO='" + TextBox1.Text.ToString().Trim() + "' and SPWD='" + TextBox2.Text.ToString().Trim() + "' and JLZT='0'";
        }
        if (cx.Text.ToString().Trim() == "教师")
        {
            sql = "select * from YW_TEACHER where TGH='" + TextBox1.Text.ToString().Trim() + "' and TPWD='" + TextBox2.Text.ToString().Trim() + "' and JLZT='0' ";
        }
        //if (cx.Text.ToString().Trim() == "家长")
        //{
        //    sql = "select * from YW_JZINFO where PLOGINNAME='" + TextBox1.Text.ToString().Trim() + "' and PWD='" + TextBox2.Text.ToString().Trim() + "' ";
        //}
        DataSet result = new DataSet();
        result = DbHelperSQL.Query(sql);
        if (result != null)
        {
            if (result.Tables[0].Rows.Count > 0)
            {
                Session["username"] = TextBox1.Text.ToString().Trim();

                if (cx.Text.ToString().Trim() == "超级管理员")
                {
                    Session["truename"] = result.Tables[0].Rows[0]["TRUENAME"].ToString();

                    if (result.Tables[0].Rows[0]["ROLECODE"].ToString()=="2")
                    {
                        Session["schoolname"] ="最高权限" ;
                        Session["schoolno"] = "0000";
                    }
                }

                if (cx.Text.ToString().Trim() == "管理员")
                {
                    Session["truename"] = result.Tables[0].Rows[0]["TRUENAME"].ToString();
                    string xxmc = result.Tables[0].Rows[0]["SCHOOLNAME"].ToString();
                    string xxno = result.Tables[0].Rows[0]["SCHOOLNO"].ToString();

                    if (xxmc != "" && xxno != "")
                    {
                        Session["schoolname"] = result.Tables[0].Rows[0]["SCHOOLNAME"].ToString();
                        Session["schoolno"] = result.Tables[0].Rows[0]["SCHOOLNO"].ToString();
                    }
                    else
                    {
                        Session["schoolname"] = "未知";
                        Session["schoolno"] = "1111";
                    }

                }
                if (cx.Text.ToString().Trim() == "学生")
                {
                    Session["truename"] = result.Tables[0].Rows[0]["SNAME"].ToString();
                    string xxmc =  result.Tables[0].Rows[0]["SCHOOLNAME"].ToString();
                    string xxno =  result.Tables[0].Rows[0]["SCHOOLNO"].ToString();
                    string bjmc = result.Tables[0].Rows[0]["CLASSNAME"].ToString();
                    string bjno = result.Tables[0].Rows[0]["BJ"].ToString();
                    if (xxmc != "" && xxno != "")
                    {
                        Session["schoolname"] = result.Tables[0].Rows[0]["SCHOOLNAME"].ToString();
                        Session["schoolno"] = result.Tables[0].Rows[0]["SCHOOLNO"].ToString();
                    }
                    else
                    {
                        Session["schoolname"] = "未知";
                        Session["schoolno"] = "1111";
                    }
                    if (bjmc != "" && bjno != "")
                    {
                        Session["CLASSNAME"] = result.Tables[0].Rows[0]["CLASSNAME"].ToString();
                        Session["CLASSNO"] = result.Tables[0].Rows[0]["BJ"].ToString();
                    }
                    else
                    {
                        Session["CLASSNAME"] = "未知";
                        Session["CLASSNO"] = "1111";
                    }

                }
                if (cx.Text.ToString().Trim() == "教师")
                {
                    Session["truename"] = result.Tables[0].Rows[0]["TNAME"].ToString();
                    Session["TGH"] = result.Tables[0].Rows[0]["TGH"].ToString();
                    string xxmc = result.Tables[0].Rows[0]["SCHOOLNAME"].ToString();
                    string xxno = result.Tables[0].Rows[0]["SCHOOLNO"].ToString();

                    if (xxmc != "" && xxno != "")
                    {
                        Session["schoolname"] = result.Tables[0].Rows[0]["SCHOOLNAME"].ToString();
                        Session["schoolno"] = result.Tables[0].Rows[0]["SCHOOLNO"].ToString();
                    }
                    else
                    {
                        Session["schoolname"] = "未知";
                        Session["schoolno"] = "1111";
                    }

                }
                Session["cx"] = cx.Text.ToString().Trim();


                Session["lsh"] = result.Tables[0].Rows[0]["lsh"].ToString();

                Response.Redirect("main.aspx");
            }
            else
            {
                Response.Write("<script>javascript:alert('对不起，用户名或密码不正确!');history.back();</script>");
            }
        }
        else
        {
            Response.Write("<script>javascript:alert('对不起，系统错误，请不要越权操作!');</script>");
        }
    }
}
