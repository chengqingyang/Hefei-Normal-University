<%@ WebHandler Language="C#" Class="BeiWangHandler" %>


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

public class BeiWangHandler : BaseHandler
{
    
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "bwedit":
                BeiWangInfo_Save();
                break;
            case "bwdel":
                BeiWangInfo_Del();
                break;
        }
    }

    private void BeiWangInfo_Save()
    {
        string tgh = GetParam("tgh");
        string date = GetParam("date");
        string text = GetParam("text");
        string title = GetParam("title");
        string type = GetParam("type");
        if (type == "教师")
            type = "0";
        else if (type == "学生" || type == "家长")
            type = "1";
        Nullable<int> lsh = null;
        try
        {
            lsh = int.Parse(GetParam("lsh"));
        }
        catch
        { }
        string result = string.Empty;
        BeiWangInfo bwinfo = new BeiWangInfo();
        bwinfo.LSH = lsh;
        bwinfo.CJZ = tgh;
        bwinfo.BWSJ = date;
        bwinfo.BWZW = text;
        bwinfo.TITLE= title;
        bwinfo.TYPE = type;
        bwinfo.BWNO = BeiWangDAL.GetBeiWangNo();

        result = BeiWangDAL.SaveData(bwinfo).ToString();
        Output(result);
    }

    private void BeiWangInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;

        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("YW_BEIWANG", "LSH", sublsh, false).ToString();
        }
        Output(result);
    }

}