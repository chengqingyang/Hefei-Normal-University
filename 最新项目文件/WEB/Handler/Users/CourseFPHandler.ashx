<%@ WebHandler Language="C#" Class="CourseFPHandler" %>

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

public class CourseFPHandler : BaseHandler
{
    
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "fpedit":
                CourseFPInfo_Save();
                break;
            case "fpdel":
                CourseFPInfo_Del();
                break;
        }
    }
    
    private void CourseFPInfo_Save()
    {
        string schoolno = GetParam("schoolno");
        string courseno = GetParam("courseno");
        string classno = GetParam("classno");
        string teacherno = GetParam("teacherno");
        string state = GetParam("state");
        string username=GetParam("username");
        Nullable<int> lsh =null;
        try
        {
           lsh = int.Parse(GetParam("lsh"));
        }
        catch
        { }
        string result = string.Empty;
        CourseFenPeiInfo coursefpinfo = new CourseFenPeiInfo();
        coursefpinfo.LSH = lsh;
        coursefpinfo.SCHOOLNO = schoolno;
        coursefpinfo.COURSENO = courseno;
        coursefpinfo.CLASSNO = classno;
        coursefpinfo.TGH = teacherno;
        coursefpinfo.XGSJ = DateTime.Now;
        coursefpinfo.DJRYGH = username;
        coursefpinfo.STATE = state;
        
        result = CourseFenPeiDAL.SaveData(coursefpinfo).ToString();
        Output(result);
    }

    private void CourseFPInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;
        
        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("SYS_COURSEFP", "LSH", sublsh,false).ToString();
        }
        Output(result);
    }
}