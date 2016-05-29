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
/// WebServiceZdxyApp ��ժҪ˵��
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebServiceZdxyApp : System.Web.Services.WebService
{

    public WebServiceZdxyApp()
    {

        //���ʹ����Ƶ��������ȡ��ע�������� 
        //InitializeComponent(); 
    }
    [WebMethod(Description = "���ݵ�¼�û���ȡϵͳ�û���Ϣ")]
    public string GetLoginUserInfoToApp(string loginname)
    {
        DataTable dt = UserDAL.GetLoginUserInfoToApp(loginname);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("{\"data\":");
        sb.Append(JsonClass.DataTable2Json(dt));
        sb.Append("}");
        return sb.ToString();

    }
    [WebMethod(Description = "��ȡϵͳ�û���Ϣ�б�")]
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