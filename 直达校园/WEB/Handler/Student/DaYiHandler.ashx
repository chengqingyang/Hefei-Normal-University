<%@ WebHandler Language="C#" Class="DaYiHandler" %>

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

public class DaYiHandler : BaseHandler
{
    
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "dyedit":
                DaYiInfo_Save();
                break;
            case "dydel":
                DaYiInfo_Del();
                break;
        }
    }

    private void DaYiInfo_Save()
    {
        string course = GetParam("course");
        string sno = GetParam("uname");
        string title = GetParam("title");
        string content = GetParam("content");
        string answer = GetParam("answer");
        string state = GetParam("state");

        Nullable<int> lsh = null;
        try
        {
            lsh = int.Parse(GetParam("lsh"));
        }
        catch
        { }
        string result = string.Empty;
        DaYiInfo dyinfo = new DaYiInfo();
        dyinfo.LSH = lsh;
        dyinfo.WTNO = DaYiDAL.GetDaYiNo();
        dyinfo.CID = course;
        dyinfo.TWZ = sno;
        dyinfo.TITLE = title;
        dyinfo.WTZW = content;
        dyinfo.TWSJ = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        dyinfo.ANSWER = answer;
        dyinfo.HDSJ = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        dyinfo.STATE=state;
        
        result = DaYiDAL.SaveData(dyinfo).ToString();
        Output(result);
    }

    private void DaYiInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;

        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("YW_DAYI", "LSH", sublsh, false).ToString();
        }
        Output(result);
    }
}