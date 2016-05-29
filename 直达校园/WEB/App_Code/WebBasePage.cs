using System;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Configuration;
using System.Text;
using System.IO;

namespace WebSystem
{
    /// <summary>
    /// 页面的基类


    /// </summary>
    public class WebBasePage : System.Web.UI.Page
    {

        #region 继承页面生命周期中的各个阶段函数

        /// <summary>
        /// 页面开始时间


        /// </summary>
        private DateTime startTime;

        /// <summary>
        /// 页面请求对象
        /// </summary>
        private HttpRequest request;

        protected override void OnPreInit(EventArgs e)
        {
            // 检查登录用户信息
            try
            {
                this.Title = System.Configuration.ConfigurationSettings.AppSettings["titlename"].ToString();
            }
            catch
            {
            }
            base.OnPreInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
        }
        #endregion
    }
}