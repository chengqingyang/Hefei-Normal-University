using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.DAL;

namespace BaseSystem
{
    public partial class Users_SchoolEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 学生请假
            if (Request.QueryString["getid"] != null)
            {
                try
                {
                    string lsh = Request.QueryString["getid"].ToString();
                    DataSet ds = XsqjDAL.GetXsqjbyLsh("lsh",lsh);
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    hiddqzt.Value = ds.Tables[0].Rows[0]["DQZT"].ToString();
                    txtQjjs.Value = ds.Tables[0].Rows[0]["QJZT"].ToString();
                    txtQjsj.Value = ds.Tables[0].Rows[0]["QJSJ"].ToString();
                    txtQjsy.Value = ds.Tables[0].Rows[0]["QJLY"].ToString();
                    txtXsqz.Value = ds.Tables[0].Rows[0]["XSQZ"].ToString();
                    if (hiddqzt.Value=="0")
                    {
                        labSpzt.Text = "未提交";
                    }
                    else if (hiddqzt.Value == "1")
                    {
                        labSpzt.Text = "待审批";
                    }
                    else if (hiddqzt.Value == "2")
                    {
                        labSpzt.Text = "已批准";
                    }
                    else if (hiddqzt.Value == "3")
                    {
                        labSpzt.Text = "未批准";
                    }
                    else
                    {
                        labSpzt.Text = "未知";
                    }
                   
                }
                catch
                { }
            }
            #endregion 学生请假
        }
    }
}