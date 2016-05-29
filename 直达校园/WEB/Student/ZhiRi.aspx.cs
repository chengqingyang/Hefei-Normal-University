using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.DAL;

namespace BaseSystem
{
    public partial class Student_ZhiRi : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 值日信息
            try
            {
                DataSet ds = ZhiRiDAL.GetZhiRiFirst();
                HtmlGenericControl[] divs = { div_mon, div_tue, div_wed, div_thu, div_fri, div_content };
                string[] fields = { "MON","TUE","WED","THU","FRI","ZRNR"};
                string[] ss = null;
                string persons = "";
                string html = "";
                char[] sps={'，',',','、',' ','\t'};
                string strsp = ",，、 ";
                if(ds.Tables[0].Rows.Count==1)
                {
                    int i;
                    for (i = 0; i < divs.Length-1;i++ )//Length-1 值日内容不需要分割
                    {
                        persons = ds.Tables[0].Rows[0][fields[i]].ToString(); 
                        if (persons!=null&&persons!="")
                        {
                            if (persons.Contains(",") || persons.Contains("，") || persons.Contains("、") 
                                || persons.Contains(" "))
                            {//有多个人值日
                                ss = persons.Split(sps);
                                html = "";
                                foreach(string s in ss)
                                {
                                    html += s + "<br/>";
                                }
                                divs[i].InnerHtml = html;
                            }
                            else
                            {//只有一个人值日
                                divs[i].InnerHtml = persons;
                            }
                        }
                    }
                    persons=ds.Tables[0].Rows[0][fields[i]].ToString();
                    divs[i].InnerHtml = ds.Tables[0].Rows[0][fields[i]].ToString(); 
                }
                else
                {
                    string empty = "暂未安排";
                    div_mon.InnerHtml = empty;
                    div_tue.InnerHtml = empty;
                    div_wed.InnerHtml = empty;
                    div_thu.InnerHtml = empty;
                    div_fri.InnerHtml = empty;
                    div_content.InnerHtml = empty;
                }                
            }
            catch
            { }
            #endregion
        }
    }
}