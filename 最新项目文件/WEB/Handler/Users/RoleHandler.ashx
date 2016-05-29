<%@ WebHandler Language="C#" Class="RoleHandler" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.SessionState;

using System.DAL;
using System.Model;

public class RoleHandler : BaseHandler
{
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "roleedit":
                RoleInfo_Save();
                break;
            case "roledel":
                RoleInfo_Del();
                break;
        }
    }

    private void RoleInfo_Save()
    {
        string rolename = GetParam("rolename");
        string roledemo = GetParam("roledemo");
        Nullable<int> rolelsh = null;
        try
        {
            rolelsh = int.Parse(GetParam("rolelsh"));
        }
        catch
        { }
        string result = string.Empty;
        RoleInfo roleinfo = new RoleInfo();
        roleinfo.Lsh = rolelsh;
        roleinfo.Rolename = rolename;
        roleinfo.Roledemo = roledemo;
        result =RoleDAL.SaveData(roleinfo).ToString(); 
        Output(result);
    }

    private void RoleInfo_Del()
    {
        string [] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;
        for (int i = 0; i < lsh.Length; i++)
        {
            if (RoleDAL.ChargeRoleUse(lsh[i]))
            {
                result = "99";
                continue;
            }
            else
            {
                if (RoleDAL.DelRole(lsh[i]))
                {
                    result = "1"; 
                }
            }
        }
        Output(result);
    }

}