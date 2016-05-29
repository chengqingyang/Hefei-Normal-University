<%@ WebHandler Language="C#" Class="PingJiaHandler" %>

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


public class PingJiaHandler : BaseHandler
{
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "pjedit":
                PingJiaInfo_Save();
                break;
            case "pjdel":
                PingJiaInfo_Del();
                break;
            //case "personedit":
            //    PersonSave();
            //    break;
        }
    }

    private void PingJiaInfo_Save()
    {
        string tgh = GetParam("tgh");
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        string py = GetParam("py");
        string pf= GetParam("pf");
        string state = "1";
        Nullable<int> lsh = null;
        try
        {
            lsh = int.Parse(GetParam("lsh"));
        }
        catch
        { }
        string result = string.Empty;
        PingJiaInfo pjinfo = new PingJiaInfo();
        pjinfo.LSH = lsh;
        pjinfo.TGH = tgh;
        pjinfo.PJSJ = date;
        pjinfo.PY = py;
        try
        {
            pjinfo.PF = int.Parse(pf);
        }
        catch { pjinfo.PF = 60; }
        pjinfo.STATE=state;
        pjinfo.PJNO = PingJiaDAL.GetPingJiaNo();

        result = PingJiaDAL.SaveData(pjinfo).ToString();
        Output(result);
    }

    private void PingJiaInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;

        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("YW_PINGJIA", "LSH", sublsh, false).ToString();
        }
        Output(result);
    }

}