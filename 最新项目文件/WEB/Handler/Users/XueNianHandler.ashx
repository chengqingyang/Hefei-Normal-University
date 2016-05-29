<%@ WebHandler Language="C#" Class="XueNianHandler" %>

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

public class XueNianHandler : BaseHandler
{
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "xnedit":
                XueNianInfo_Save();
                break;
            case "xndel":
                XueNianInfo_Del();
                break;
        }
    }
    
    private void XueNianInfo_Save()
    {
        string xuenianname = GetParam("name");
        string schoolno = GetParam("schoolno");
        string sdate = GetParam("sdate");
        string edate = GetParam("edate");
        string state = GetParam("state");
        string username = GetParam("username");
        Nullable<int> lsh =null;
        try
        {
           lsh = int.Parse(GetParam("lsh"));
        }
        catch
        { }
        string result = string.Empty;
        XueNianInfo xuenianinfo = new XueNianInfo();
        xuenianinfo.LSH = lsh;
        xuenianinfo.SCHOOLNO = schoolno;
        xuenianinfo.XNNAME = xuenianname;
        xuenianinfo.KSRQ = Convert.ToDateTime(sdate);
        xuenianinfo.JSRQ = Convert.ToDateTime(edate);
        xuenianinfo.DJRYGH = username;
        xuenianinfo.STATE = state;
        xuenianinfo.XGSJ = DateTime.Now;
        xuenianinfo.XNNO = XueNianDAL.GetXueNianNo();
        
        result = XueNianDAL.SaveData(xuenianinfo).ToString();
        Output(result);
    }

    private void XueNianInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;
        
        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("SYS_XUENIAN", "LSH", sublsh,false).ToString();
        }
        Output(result);
    }
}