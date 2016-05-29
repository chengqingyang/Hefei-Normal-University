<%@ WebHandler Language="C#" Class="XsqjHandler" %>

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

public class XsqjHandler : BaseHandler,IRequiresSessionState,IHttpHandler,IReadOnlySessionState
{
    
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "xsqjedit":
                XsqjInfo_Save();
                break;
            case "xsqjdel":
                XsqjInfo_Del();
                break;
            case "qjshedit":
                Xsqjsp_Save();
                break;
                
        }
    }

    private void XsqjInfo_Save()
    {
        string sQjjs = GetParam("qjjs");
        string sQjsj = GetParam("qjsj");
        string sQjsy = GetParam("qjsy");
        string sXsqz = GetParam("xsqz");
        string sDqzt = GetParam("dqzt");
        string sJsqz = GetParam("jsqz");
        Nullable<int> lsh =null;
        try
        {
           lsh = int.Parse(GetParam("lsh"));
        }
        catch
        { }
        string result = string.Empty;
        XsqjInfo xsqjinfo = new XsqjInfo();
        xsqjinfo.LSH = lsh;
        xsqjinfo.QJZT = sQjjs;
        xsqjinfo.QJSJ = sQjsj;
        xsqjinfo.QJLY = sQjsy;
        xsqjinfo.XSQZ = sXsqz;
        xsqjinfo.DQZT = sDqzt;
        xsqjinfo.JSQZ = sJsqz;
        if (HttpContext.Current.Session["cx"].ToString()=="学生")
        {
            xsqjinfo.SNO = HttpContext.Current.Session["username"].ToString();
            xsqjinfo.SNAME = HttpContext.Current.Session["truename"].ToString();
            xsqjinfo.SCHOOLNO = HttpContext.Current.Session["schoolno"].ToString();
            xsqjinfo.SCHOOLNAME = HttpContext.Current.Session["schoolname"].ToString();
            xsqjinfo.CALSSNO = HttpContext.Current.Session["CLASSNO"].ToString();
            xsqjinfo.CLASSNAME = HttpContext.Current.Session["CLASSNAME"].ToString();
        
        }
        result = XsqjDAL.SaveData(xsqjinfo).ToString();
        Output(result);
    }

    private void Xsqjsp_Save()
    {
        string sDqzt = GetParam("dqzt");
        string sJsqz = GetParam("jsqz");
        Nullable<int> lsh = null;
        try
        {
            lsh = int.Parse(GetParam("lsh"));
        }
        catch
        { }
        string result = string.Empty;
        XsqjInfo xsqjinfo = new XsqjInfo();
        xsqjinfo.DQZT = sDqzt;
        xsqjinfo.JSQZ = sJsqz;
        xsqjinfo.LSH = lsh;
        result = XsqjDAL.SaveQjspData(xsqjinfo).ToString();
        Output(result);
    }
    
    
    
    
    
    /// <summary>
    /// 删除请假条
    /// </summary>
    private void XsqjInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;
        
        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("YW_XSQJINFO", "LSH", sublsh, false).ToString();
        }
        Output(result);
    }
}