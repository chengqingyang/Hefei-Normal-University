<%@ WebHandler Language="C#" Class="ClassHandler" %>

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

public class ClassHandler : BaseHandler
{
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "classedit":
                ClassInfo_Save();
                break;
            case "classdel":
                ClassInfo_Del();
                break;
        }
    }
    
    private void ClassInfo_Save()
    {
        string schoolno = GetParam("schoolno");
        string classname = GetParam("name");
        string bzrname = GetParam("bzrname");
        string remark = GetParam("remark");
        Nullable<int> lsh =null;
        try
        {
           lsh = int.Parse(GetParam("lsh"));
        }
        catch
        { }
        string result = string.Empty;
        ClassInfo classinfo = new ClassInfo();
        classinfo.LSH = lsh;
        classinfo.CLASSNAME = classname;
        classinfo.BZRNAME = bzrname;
        classinfo.SCHOOLNO = schoolno;
        classinfo.BZ = remark;
        classinfo.CLASSNO = ClassDAL.GetClassNo();
        
        result = ClassDAL.SaveData(classinfo).ToString();
        Output(result);
    }

    private void ClassInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;
        
        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("SYS_CLASSINFO", "LSH", sublsh,false).ToString();
        }
        Output(result);
    }
}