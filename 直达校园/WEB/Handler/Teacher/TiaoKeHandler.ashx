<%@ WebHandler Language="C#" Class="TiaoKeHandler" %>

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


public class TiaoKeHandler : BaseHandler
{

    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "tkedit":
                TiaoKeInfo_Save();
                break;
            case "tkdel":
                TiaoKeInfo_Del();
                break;
            //case "personedit":
            //    PersonSave();
            //    break;
        }
    }

    private void TiaoKeInfo_Save()
    {
        string tgh = GetParam("tgh");
        string date = GetParam("date");
        string text = GetParam("text");
        string state = GetParam("state");
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
        TiaoKeInfo tkinfo = new TiaoKeInfo();
        tkinfo.LSH = lsh;
        tkinfo.TGH = tgh;
        tkinfo.TKRQ = date;
        tkinfo.TKZW = text;
        tkinfo.STATE=state;
        tkinfo.ClassNo = classno;
        tkinfo.SchoolNo=schoolno;
        tkinfo.XNNO = xnno;
        tkinfo.XQNO = xqno;
        tkinfo.TKNO = TiaoKeDAL.GetTiaoKeNo();

        result = TiaoKeDAL.SaveData(tkinfo).ToString();
        Output(result);
    }

    private void TiaoKeInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;

        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("YW_TIAOKE", "LSH", sublsh, false).ToString();
        }
        Output(result);
    }

}