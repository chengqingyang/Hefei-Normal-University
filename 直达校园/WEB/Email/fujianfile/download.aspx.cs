using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class download_download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string filepath = Request["filepath"];
        string filename = Request["filename"];
        //string id = Request["id"];
        ////下载时更新数据库
        //SqlConnection conn = new SqlConnection(new comClass().getConnStr());
        //SqlCommand cmd = new SqlCommand("", conn);
        //string strSQL = "update mails set downloads=downloads+1 where id=" + id;
        //cmd.CommandText = string.Format("update mails set downloads=downloads+1 where id={0}", id);
        //conn.Open();
        //cmd.ExecuteNonQuery();
        Response.Redirect(filepath + filename);

    }
}
