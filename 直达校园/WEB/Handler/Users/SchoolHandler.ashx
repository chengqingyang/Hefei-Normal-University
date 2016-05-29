<%@ WebHandler Language="C#" Class="SchoolHandler" %>

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

public class SchoolHandler : BaseHandler
{
    
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "schooledit":
                SchoolInfo_Save();
                break;
            case "schooldel":
                SchoolInfo_Del();
                break;
        }
    }
    
    private void SchoolInfo_Save()
    {
        string schoolname = GetParam("name");
        string xzname = GetParam("xzname");
        string schooladdr = GetParam("addr");
        string remark = GetParam("remark");
        Nullable<int> lsh =null;
        try
        {
           lsh = int.Parse(GetParam("lsh"));
        }
        catch
        { }
        string result = string.Empty;
        SchoolInfo schoolinfo = new SchoolInfo();
        schoolinfo.LSH = lsh;
        schoolinfo.SCHOOLNAME = schoolname;
        schoolinfo.XZNAME = xzname;
        schoolinfo.SCHOOLADDR = schooladdr;
        schoolinfo.BZ = remark;
        schoolinfo.SCHOOLNO = SchoolDAL.GetSchoolNo();
        
        result = SchoolDAL.SaveData(schoolinfo).ToString();
        Output(result);
    }

    private void SchoolInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;
        
        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("SYS_SCHOOLINFO", "LSH", sublsh,false).ToString();
        }
        Output(result);
    }
}