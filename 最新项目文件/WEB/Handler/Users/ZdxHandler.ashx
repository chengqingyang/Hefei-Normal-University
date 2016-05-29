<%@ WebHandler Language="C#" Class="ZdxHandler" %>

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

public class ZdxHandler : BaseHandler
{
    
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "zdxedit":
                Zdxnfo_Save();
                break;
            case "zdxdel":
                ZdxInfo_Del();
                break;
        }
    }

    private void Zdxnfo_Save()
    {
        string sDazx = GetParam("dazx");
        string sWtbh = GetParam("wtbh");
        string sWtnr = GetParam("wtnr");
        string sDabh = GetParam("dabh");
        string sDaxx = GetParam("daxx");
        string sBz = GetParam("bz");
        Nullable<int> lsh =null;
        try
        {
           lsh = int.Parse(GetParam("lsh"));
        }
        catch
        { }
        string result = string.Empty;
        DictionaryInfo zdxinfo = new DictionaryInfo();
        zdxinfo.DAZX = sDazx;
        zdxinfo.WTBH = sWtbh;
        zdxinfo.WTNR = sWtnr;
        zdxinfo.DABH = sDabh;
        zdxinfo.DAXX = sDaxx;
        zdxinfo.BZ = sBz;
        result = ZdxDAL.SaveData(zdxinfo).ToString();
        Output(result);
    }

    private void ZdxInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;
        
        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("SYS_DICTIONARY", "LSH", sublsh, false).ToString();
        }
        Output(result);
    }
}