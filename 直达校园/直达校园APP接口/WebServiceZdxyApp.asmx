<%@ WebService Language="C#" CodeBehind="~/App_Code/WebServiceZdxyApp.cs" Class="WebServiceZdxyApp" %>
using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.DAL;
using System.Model;
using System.Data;

/// <summary>
/// WebServiceZdxyApp 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebServiceZdxyApp : System.Web.Services.WebService
{

    public WebServiceZdxyApp()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }
    [WebMethod(Description = "根据登录用户名取系统用户信息")]
    public string GetLoginUserInfoToApp(string loginname)
    {
        DataTable dt = UserDAL.GetLoginUserInfoToApp(loginname);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("{\"data\":");
        sb.Append(JsonClass.DataTable2Json(dt));
        sb.Append("}");
        return sb.ToString();

    }
    [WebMethod(Description = "获取系统用户信息列表")]
    public string GetLoginUserListToApp()
    {
        DataTable dt = UserDAL.GetLoginUserListToApp();
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("{\"data\":");
        sb.Append(JsonClass.DataTable2Json(dt));
        sb.Append("}");
        return sb.ToString();

    }

}