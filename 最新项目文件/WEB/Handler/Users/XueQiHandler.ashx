<%@ WebHandler Language="C#" Class="XueQiHandler" %>

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

public class XueQiHandler : BaseHandler
{
    
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "xqedit":
                XueQiInfo_Save();
                break;
            case "xqdel":
                XueQiInfo_Del();
                break;
        }
    }
    
    private void XueQiInfo_Save()
    {
        string schoolno = GetParam("schoolno");
        string xuenianno = GetParam("xuenianno");
        string xueqino = GetParam("xueqino");
        string xueqiname = GetParam("xueqiname");
        string sdate = GetParam("sdate");
        string edate = GetParam("edate");
        string state = GetParam("state");
        Nullable<int> lsh =null;
        try
        {
           lsh = int.Parse(GetParam("lsh"));
        }
        catch
        { }
        string result = string.Empty;
        XueQiInfo xueqiinfo = new XueQiInfo();
        xueqiinfo.LSH = lsh;
        xueqiinfo.SCHOOLNO = schoolno;
        xueqiinfo.XNNO = xuenianno;
        xueqiinfo.XQNO = xueqino;
        xueqiinfo.XQNAME = xueqiname;
        xueqiinfo.KSRQ = Convert.ToDateTime(sdate);
        xueqiinfo.JSRQ = Convert.ToDateTime(edate);
        xueqiinfo.STATE = state;
        xueqiinfo.XGSJ = DateTime.Now;
        
        result = XueQiDAL.SaveData(xueqiinfo).ToString();
        Output(result);
    }

    private void XueQiInfo_Del()
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