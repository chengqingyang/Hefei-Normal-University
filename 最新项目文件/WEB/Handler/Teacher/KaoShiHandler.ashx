<%@ WebHandler Language="C#" Class="KaoShiHandler" %>

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

public class KaoShiHandler : BaseHandler
{
    
   protected override void ActionHandler(string action)
    {
        switch (action.ToLower())
        {
            case "ksedit":
                KaoShiInfo_Save();
                break;
            case "ksdel":
                KaoShiInfo_Del();
                break;
            //case "personedit":
            //    PersonSave();
            //    break;
        }
    }

   private void KaoShiInfo_Save()
   {
       string tgh = GetParam("tgh");
       string date = GetParam("date");
       string js = GetParam("js");
       string zwh = GetParam("zwh");
       string remark = GetParam("remark");
       string state = GetParam("state");
       string cid = GetParam("cid");
       string classno = GetParam("classno");
       string type = GetParam("type");
       string schoolno = GetParam("schoolno");
       string xnno = GetParam("xnno");
       string xqno = GetParam("xqno");
       Nullable<int> lsh = null;
       try
       {
           lsh = int.Parse(GetParam("lsh"));
       }
       catch
       { }
       string result = string.Empty;
       KaoShiInfo ksinfo = new KaoShiInfo();
       ksinfo.LSH = lsh;
       ksinfo.TGH = tgh;
       ksinfo.CID = cid;
       ksinfo.KSSJ = date;
       ksinfo.KSLX = type;
       ksinfo.STATE = state;
       ksinfo.ClassNo = classno;
       ksinfo.SchoolNo = schoolno;
       ksinfo.XNNO=xnno;
       ksinfo.XQNO=xqno;
       ksinfo.KSNO = KaoShiDAL.GetKaoShiNo();

       TestDetailInfo testInfo = new TestDetailInfo();
       testInfo.LSH = lsh;
       testInfo.KSNO = ksinfo.KSNO;
       testInfo.JS = js;
       testInfo.ZWNO = zwh;
       testInfo.BZ = remark;
       testInfo.STATE = state;

       int ret = 0;
       if (ksinfo.LSH.HasValue)
       {//更新操作，考试详情先修改
           testInfo.KSNO = ksinfo.LSH.ToString();
           if (!TestDeatilDAL.SaveAllData(testInfo))
               result = "99";
           else
               result = KaoShiDAL.SaveData(ksinfo).ToString();
       }
       else
       {//插入操作，考试详细后插入
           ret = KaoShiDAL.SaveData(ksinfo);
           if (ret != -1 && ret != 99)
               result = TestDeatilDAL.SaveAllData(testInfo).ToString();
           else
               result = ret.ToString();          
       }
       Output(result);
   }

    private void KaoShiInfo_Del()
    {
        string[] lsh = GetParam("keyvalue").Split(',');
        string result = string.Empty;

        foreach (string sublsh in lsh)
        {
            if (CommonDAL.ObjectDel("YW_TEST_DETAIL", "KSNO", sublsh, false) > 0)
                result = CommonDAL.ObjectDel("YW_KAOSHI", "LSH", sublsh, false).ToString();
            else
                result = "99";
        }
        Output(result);
    }

}