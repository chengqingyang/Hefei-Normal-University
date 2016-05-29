<%@ WebHandler Language="C#" Class="CourseHandler" %>

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
public class CourseHandler : BaseHandler
{
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "courseedit":
                CourseInfo_Save();
                break;
            case "coursedel":
                CourseInfo_Del();
                break;
        }
    }
    
    private void CourseInfo_Save()
    {
        string schoolno = GetParam("schoolno");
        string coursename = GetParam("name");
        string remark = GetParam("remark");
        string username = GetParam("username");
        Nullable<int> lsh =null;
        try
        {
           lsh = int.Parse(GetParam("lsh"));
        }
        catch
        { }
        string result = string.Empty;
        CourseInfo courseinfo = new CourseInfo();
        courseinfo.LSH = lsh;
        courseinfo.COURSENAME = coursename;
        courseinfo.DJRYGH = username;
        courseinfo.SCHOOLNO = schoolno;
        courseinfo.BZ = remark;
        courseinfo.XGSJ = DateTime.Now;
        courseinfo.COURSENO = CourseDAL.GetCourseNo();
        
        result = CourseDAL.SaveData(courseinfo).ToString();
        Output(result);
    }

    private void CourseInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;
        
        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("SYS_COURSEINFO", "LSH", sublsh,false).ToString();
        }
        Output(result);
    }
}