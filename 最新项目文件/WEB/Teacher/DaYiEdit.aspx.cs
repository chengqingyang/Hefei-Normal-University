using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;

using System.DAL;

namespace BaseSystem
{

    public partial class Teacher_DaYiEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 答疑信息
            if (Request.QueryString["getid"] != null)
            {
                string getid = Request.QueryString["getid"].ToString();
                try
                {
                    DataSet ds = DaYiDAL.GetDaYiList("lsh", getid);
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    ddlCourse.Value = divcourse.InnerHtml = ds.Tables[0].Rows[0]["CID"].ToString();
                    txttitle.Value = divtitle.InnerHtml = ds.Tables[0].Rows[0]["TITLE"].ToString();
                    txtcontent.Value = divcontent.InnerHtml = ds.Tables[0].Rows[0]["WTZW"].ToString();
                    txtanswer.Value = ds.Tables[0].Rows[0]["ANSWER"].ToString();
                }
                catch (Exception exc)
                {
                    string msg = exc.Message;
                    string stack = exc.StackTrace;
                }
            }
            #endregion
        }
    }
}