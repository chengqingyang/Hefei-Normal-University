<%@ WebHandler Language="C#" Class="ZiLiaoHandler" %>

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


public class ZiLiaoHandler : BaseHandler
{
    
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "zledit":
                ZiLiaoInfo_Save();
                break;
            case "zldel":
                ZiLiaoInfo_Del();
                break;
            //case "personedit":
            //    PersonSave();
            //    break;
        }
    }

    private void ZiLiaoInfo_Save()
    {
        string course = GetParam("course");
        string tgh = GetParam("tgh");
        string filename = GetParam("filename");
        string filepath = GetParam("filepath");
        string state = GetParam("state");
        string flag = GetParam("flag");
        if (flag == "学生")
        {
            flag = "1";
        }
        else if (flag == "教师")
        {
            flag = "0";
        }
        Nullable<int> lsh = null;
        try
        {
            lsh = int.Parse(GetParam("lsh"));
        }
        catch
        { }
        string result = string.Empty;
        ZiLiaoInfo zlinfo = new ZiLiaoInfo();
        zlinfo.LSH = lsh;
        zlinfo.ZLNO = ZiLiaoDAL.GetZiLiaoNo();
        zlinfo.CID = course;
        zlinfo.SCZ = tgh;
        zlinfo.ZLNAME = filename;
        zlinfo.ZLPATH = filepath;
        zlinfo.FLAG = flag;
        zlinfo.SCSJ = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm");
        zlinfo.STATE = state;
        
        result = ZiLiaoDAL.SaveData(zlinfo).ToString();
        Output(result);
    }

    private void ZiLiaoInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;

        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("YW_ZILIAO", "LSH", sublsh, false).ToString();
        }
        Output(result);
    }
}