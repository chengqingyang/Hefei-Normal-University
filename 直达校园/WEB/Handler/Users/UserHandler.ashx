<%@ WebHandler Language="C#" Class="UserHandler" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.SessionState;

using System.DAL;
using System.Model;
using BaseSystem;

public class UserHandler : BaseHandler
{
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "useredit":
                UserInfo_Save();
                break;
            case "userdel":
                UserInfo_Del();
                break;
            //case "personedit":
            //    PersonSave();
            //    break;
        }
    }
    
    private void UserInfo_Save()
    {
        string username = GetParam("username");
        string userpwd = GetParam("userpwd");
        string userrole = GetParam("userrole");
        string truename = GetParam("truename");
        string userphone = GetParam("userphone");
        string cardid = GetParam("cardid");
        string address = GetParam("address");
        string userstate = GetParam("userstate");
        string schoolno = GetParam("schoolno");
        string schoolname = GetParam("schoolname");
        Nullable<int> userlsh =null;
        try
        {
           userlsh = int.Parse(GetParam("userlsh"));
        }
        catch
        { }
        string result = string.Empty;
        UserInfo userinfo = new UserInfo();
        userinfo.LSH = userlsh;
        userinfo.LOGINNAME = username;
        userinfo.LOGINPWD = userpwd;
        Nullable<int> rolecode = null;
        try
        {
            rolecode = int.Parse(userrole);
        }
        catch
        { }
        userinfo.ROLECODE = rolecode;
        
        userinfo.USERSTATE = userstate;
        userinfo.TRUENAME = truename;
        userinfo.CONNPHONE = userphone;
        userinfo.CARDID = cardid;
        userinfo.ADDRESS = address;
        userinfo.SCHOOLNAME = schoolname;
        userinfo.SCHOOLNO = schoolno;
        result = UserDAL.SaveData(userinfo).ToString();
        Output(result);
    }

    private void UserInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;
        
        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("SYS_USER", "LSH", sublsh,false).ToString();
        }
        Output(result);
    }

   

}