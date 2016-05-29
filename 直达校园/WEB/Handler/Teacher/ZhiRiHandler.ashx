<%@ WebHandler Language="C#" Class="ZhiRiHandler" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web.SessionState;
using System.IO;

using System.DAL;
using System.Model;
using BaseSystem;


public class ZhiRiHandler : BaseHandler
{
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "zredit":
                ZhiRiInfo_Save();
                break;
            case "zrdel":
                ZhiRiInfo_Del();
                break;
            //case "personedit":
            //    PersonSave();
            //    break;
        }
    }

    private void ZhiRiInfo_Save()
    {
        string id = GetParam("id");
        string tgh = GetParam("tgh");
        string mon = GetParam("mon");
        string tue = GetParam("tue");
        string wed = GetParam("wed");
        string thu = GetParam("thu");
        string fri = GetParam("fri");
        string content = GetParam("content");
        string classno = GetParam("classno");
        string schoolno = GetParam("schoolno");
        string xnno = GetParam("xnno");
        string xqno = GetParam("xqno");
        Nullable<int> lsh = null;
        try
        {
            lsh = int.Parse(GetParam("lsh"));
        }
        catch
        { }
        string result = string.Empty;
        ZhiRiInfo zrinfo = new ZhiRiInfo();
        zrinfo.LSH = lsh;
        zrinfo.WNO = id;
        zrinfo.TGH = tgh;
        zrinfo.MON = mon;
        zrinfo.TUE = tue;
        zrinfo.WED = wed;
        zrinfo.THU = thu;
        zrinfo.FRI = fri;
        zrinfo.ZRNR = content;
        zrinfo.ClassNo = classno;
        zrinfo.SchoolNo = schoolno;
        zrinfo.XNNO = xnno;
        zrinfo.XQNO = xqno;
        
        result = ZhiRiDAL.SaveData(zrinfo).ToString();
        Output(result);
    }

    private void ZhiRiInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;

        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("YW_ZHIRI", "LSH", sublsh, false).ToString();
        }
        Output(result);
    }
}