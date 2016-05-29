<%@ WebHandler Language="C#" Class="TeacherHandler" %>


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



public class TeacherHandler : BaseHandler
{
    protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "tcedit":
                TeacherInfo_Save();
                break;
            case "tcdel":
                TeacherInfo_Del();
                break;
            //case "personedit":
            //    PersonSave();
            //    break;
            //case "tcpic":
            //    Teacher_Pic();
                //break;
        }
    }

    private void TeacherInfo_Save()
    {
        string id = GetParam("id");
        string pwd = id;
        string name = GetParam("name");
        string sex = GetParam("sex");
        string zc = GetParam("zc");
        string phone = GetParam("userphone");
        string cardid = GetParam("cardid");
        string birth = GetParam("birth");
        string remark = GetParam("remark");
        string picpath = GetParam("picpath");
        string course=GetParam("course");
        string schoolno = GetParam("schoolno");
        string schoolname = GetParam("schoolname");
        Nullable<int> lsh = null;
        try
        {
            lsh = int.Parse(GetParam("lsh"));
        }
        catch
        { }
        string result = string.Empty;
        TeacherInfo tcinfo = new TeacherInfo();
        tcinfo.LSH = lsh;
        tcinfo.TGH = id;
        tcinfo.TPWD = pwd;
        tcinfo.TNAME = name;
        tcinfo.XB = sex;
        tcinfo.ZC = zc;
        tcinfo.ZPPATH = picpath;
        tcinfo.LXDH = phone;
        tcinfo.CSRQ = DateTime.Parse(birth);
        tcinfo.SFZH = cardid;
        tcinfo.BZ = remark;
        tcinfo.ZJKC = course;
        tcinfo.SCHOOLNO = schoolno;
        tcinfo.SCHOOLNAME = schoolname;

        result = TeacherDAL.SaveData(tcinfo).ToString();
        Output(result);
    }

    private void TeacherInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;

        foreach (string sublsh in lsh)
        {
            result = CommonDAL.ObjectDel("YW_TEACHER", "LSH", sublsh, false).ToString();
        }
        Output(result);
    }

    private void Teacher_Pic()
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