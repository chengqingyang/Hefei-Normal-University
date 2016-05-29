<%@ WebHandler Language="C#" Class="HomeWorkHandler" %>

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


public class HomeWorkHandler : BaseHandler
{    
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "zyedit":
                HomeWorkInfo_Save();
                break;
            case "zydel":
                HomeWorkInfo_Del();
                break;
            //case "personedit":
            //    PersonSave();
            //    break;
        }
    }

    private void HomeWorkInfo_Save()
    {
        string tgh = GetParam("tgh");
        string date = GetParam("date");
        string text = GetParam("text");
        string state = GetParam("state");
        string cid = GetParam("cid");
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
        HomeWorkInfo hwinfo = new HomeWorkInfo();
        hwinfo.LSH = lsh;
        hwinfo.TGH = tgh;
        hwinfo.CID = cid;
        hwinfo.BZRQ = date;
        hwinfo.ZYZW = text;
        hwinfo.STATE=state;
        hwinfo.SchoolNo = schoolno;
        hwinfo.ClassNo=classno;
        hwinfo.XNNO=xnno;
        hwinfo.XQNO = xqno;
        hwinfo.ZYNO = HomeWorkDAL.GetHomeWorkNo();

        result = HomeWorkDAL.SaveData(hwinfo).ToString();
        Output(result);
    }

    private void HomeWorkInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;

        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("YW_HOMEWORK", "LSH", sublsh, false).ToString();
        }
        Output(result);
    }

}