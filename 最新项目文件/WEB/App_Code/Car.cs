using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

/// <summary>
/// 购物车
/// </summary>
public class Car
{
    HttpCookie aCookie;
    DataTable mytable = new DataTable("info");
    public Car()
    {
        aCookie = System.Web.HttpContext.Current.Request.Cookies["proInfo"];
    }
    /// <summary>    
    /// 获取购物车表    
    /// </summary>    
    public DataTable getTable()
    {
        string[] Gid;
        string[] Gname;
        string[] Gprice;
        string[] Gnum;
        string[] Gsum;
        int j = 0;

        DataColumn c1 = mytable.Columns.Add("Gid");
        DataColumn c2 = mytable.Columns.Add("Gname");
        DataColumn c3 = mytable.Columns.Add("Gprice");
        DataColumn c4 = mytable.Columns.Add("Gnum");
        DataColumn c5 = mytable.Columns.Add("Gsum");
        DataColumn c6 = mytable.Columns.Add("Gfalg");
        if (aCookie != null && !string.IsNullOrEmpty(aCookie.Value))
        {
            Regex r = new Regex(",");
            Gid = r.Split(aCookie.Values["Gid"]);
            Gname = r.Split(aCookie.Values["Gname"]);
            Gprice = r.Split(aCookie.Values["Gprice"]);
            Gnum = r.Split(aCookie.Values["Gnum"]);
            Gsum = r.Split(aCookie.Values["Gsum"]);
            foreach (string a1 in Gid)
            {
                DataRow myrow = mytable.NewRow();
                myrow["Gid"] = Gid[j].Split('|')[0];
                myrow["Gname"] = Gname[j];
                myrow["Gprice"] = Gprice[j];
                myrow["Gnum"] = Gnum[j];
                myrow["Gsum"] = Gsum[j];
                myrow["Gfalg"] = Gid[j].Split('|')[0]; 
                mytable.Rows.Add(myrow);
                j++;
            }
        }
        return mytable;
    }
    /// <summary>    
    /// 将数据库写入Cookie   
    /// </summary>    
    /// <param name="Gid">商品ID</param>    
    /// <param name="Gname">商品名称</param>    
    /// <param name="Gprice">商品单价</param>
    /// <param name="Gsum">商品总量</param>  
    public void writeCookie(string Gid, string Gname, string Gprice, string Gsum)
    {
        if (aCookie != null && !string.IsNullOrEmpty(aCookie.Value))
        {
            if (this.aCookie.Values["Gid"].IndexOf(Gid) == -1)
            {
                this.aCookie.Values["Gid"] = this.aCookie.Values["Gid"] + "," + Gid;
                this.aCookie.Values["Gname"] = this.aCookie.Values["Gname"] + "," + Gname;
                this.aCookie.Values["Gprice"] = this.aCookie.Values["Gprice"] + "," + Gprice;
                this.aCookie.Values["Gnum"] = this.aCookie.Values["Gnum"] + "," + "1";
                this.aCookie.Values["Gsum"] = this.aCookie.Values["Gsum"] + "," + Gsum;
                aCookie.Expires = DateTime.Now.AddDays(1d);
                HttpContext.Current.Response.Cookies.Add(aCookie);
            }

        }
        else
        {
            aCookie = new HttpCookie("proInfo");
            aCookie.Values["Gid"] = Gid;
            aCookie.Values["Gname"] = Gname;
            aCookie.Values["Gprice"] = Gprice;
            aCookie.Values["Gnum"] = "1";
            aCookie.Values["Gsum"] = Gsum;
            aCookie.Expires = DateTime.Now.AddDays(1d);
            HttpContext.Current.Response.Cookies.Add(aCookie);
        }
    }
    /// <summary>    
    /// 将数据库写入Cookie   
    /// </summary>    
    /// <param name="Gid">商品ID</param>    
    /// <param name="Gname">商品名称</param>    
    /// <param name="Gprice">商品单价</param>
    /// <param name="Gnum">购买数量</param>
    /// <param name="Gsum">商品总量</param>  
    public void writeCookie(string Gid, string Gname, string Gprice, string Gnum, string Gsum)
    {
        if (aCookie != null&&!string.IsNullOrEmpty(aCookie.Value))
        {
            if (this.aCookie.Values["Gid"].IndexOf(Gid) == -1)
            {
                this.aCookie.Values["Gid"] = this.aCookie.Values["Gid"] + "," + Gid;
                this.aCookie.Values["Gname"] = this.aCookie.Values["Gname"] + "," + Gname;
                this.aCookie.Values["Gprice"] = this.aCookie.Values["Gprice"] + "," + Gprice;
                this.aCookie.Values["Gnum"] = this.aCookie.Values["Gnum"] + "," + Gnum;
                this.aCookie.Values["Gsum"] = this.aCookie.Values["Gsum"] + "," + Gsum;
                aCookie.Expires = DateTime.Now.AddDays(1d);
                HttpContext.Current.Response.Cookies.Add(aCookie);
            }

        }
        else
        {
            aCookie = new HttpCookie("proInfo");
            aCookie.Values["Gid"] = Gid;
            aCookie.Values["Gname"] = Gname;
            aCookie.Values["Gprice"] = Gprice;
            aCookie.Values["Gnum"] = Gnum;
            aCookie.Values["Gsum"] = Gsum;
            aCookie.Expires = DateTime.Now.AddDays(1d);
            HttpContext.Current.Response.Cookies.Add(aCookie);
        }
    }
    /// <summary>    
    /// 删除购物车中的商品   
    /// </summary>    
    /// <param name="mytable">购物车表</param>    
    public void remove(DataTable mytable)
    {
        aCookie = null;
        HttpContext.Current.Response.Write(mytable.Rows.Count.ToString());
        if (mytable.Rows.Count == 0)
        {
            aCookie = new HttpCookie("proInfo");
            aCookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(aCookie);
        }
        else
        {
            for (int i = 0; i < mytable.Rows.Count; i++)
            {
                writeCookie(mytable.Rows[i][0].ToString(), mytable.Rows[i][1].ToString(), mytable.Rows[i][2].ToString(), mytable.Rows[i][4].ToString());
            }
        }
    }
    /// <summary>    
    /// 更新购物车中商品的数量 
    /// </summary>    
    /// <param name="mytable">购物车中的商品</param>  
    public void updata(DataTable mytable)
    {
        aCookie = null;
        HttpContext.Current.Response.Write("行:" + mytable.Rows.Count.ToString());
        for (int i = 0; i < mytable.Rows.Count; i++)
        {
            writeCookie(mytable.Rows[i][0].ToString(), mytable.Rows[i][1].ToString(), mytable.Rows[i][2].ToString(), mytable.Rows[i][3].ToString(), mytable.Rows[i][4].ToString());
        }
    }
}
