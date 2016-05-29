<%@ WebHandler Language="C#" Class="StudentHandler" %>

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


public class StudentHandler : BaseHandler
{

    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "stuedit":
                StudentInfo_Save();
                break;
            case "studel":
                StudentInfo_Del();
                break;
            //case "personedit":
            //    PersonSave();
            //    break;
            case "stupic":
                Student_Pic();
                break;
        }
    }

    private void StudentInfo_Save()
    {
        string stuid = GetParam("stuid");
        string stupwd = stuid;
        string stuname = GetParam("stuname");
        string stusex = GetParam("stusex");
        string stuclass = GetParam("stuclass");
        string classname = GetParam("classname");
        string stuschool = GetParam("stuschool");
        string schoolname = GetParam("schoolname");
        string stuphone = GetParam("userphone");
        string cardid = GetParam("cardid");
        string address = GetParam("address");
        string remark = GetParam("remark");
        string picpath = GetParam("picpath");
        Nullable<int> stulsh = null;
        try
        {
            stulsh = int.Parse(GetParam("stulsh"));
        }
        catch
        { }
        string result = string.Empty;
        StudentInfo stuinfo = new StudentInfo();
        stuinfo.LSH = stulsh;
        stuinfo.SNO = stuid;
        stuinfo.SPWD = stupwd;
        stuinfo.SNAME = stuname;
        stuinfo.XB = stusex;
        stuinfo.SCHOOLNO = stuschool;
        stuinfo.SCHOOLNAME = schoolname; 
        stuinfo.BJ = stuclass;
        stuinfo.CLASSNAME = classname;
        stuinfo.ZPPATH = picpath;
        stuinfo.LXDH = stuphone;
        stuinfo.JTZZ = address;
        stuinfo.SFZH = cardid;
        stuinfo.BZ = remark;

        result = StudentDAL.SaveData(stuinfo).ToString(); 
        Output(result);
    }

    private void StudentInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;

        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("YW_STUDENT", "LSH", sublsh,false).ToString();
        }
        Output(result);
    }
    
    private void Student_Pic()
    {
        //string filepath = "../images/avatar/";
        //if (Directory.Exists(Server.MapPath(filepath)) == false)//如果不存在就创建file文件夹
        //{
        //    Directory.CreateDirectory(Server.MapPath(filepath));
        //}
        //string virpath = filepath + DateTime.Now.ToString("yyyyMMddHHmmss") + fileExtension;//这是存到服务器上的虚拟路径
        //string mappath = Server.MapPath(virpath);//转换成服务器上的物理路径
        //pic_upload.PostedFile.SaveAs(mappath);//保存图片
        ////显示图片
        ////pic.ImageUrl = virpath;
        //pic.Src = virpath;
        //lab_picpath.Value = virpath;
        ////清空提示
        //lbl_pic.Text = "";
    }

}