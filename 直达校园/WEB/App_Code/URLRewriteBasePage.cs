using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;

/// <summary>
/// URLRewriteBasePage 的摘要说明
/// </summary>
    public class URLRewriteBasePage : System.Web.UI.Page
    {
        public URLRewriteBasePage()
        {
           
        }
        protected override void Render(HtmlTextWriter writer)
        {
            if (writer is System.Web.UI.Html32TextWriter)
            {
                writer = new FormFixerHtml32TextWriter(writer.InnerWriter);
            }
            else
            {
                writer = new FormFixerHtmlTextWriter(writer.InnerWriter);
            }

            base.Render(writer);
        }

        protected override void OnPreInit(EventArgs e)
        {
            try
            {
                //this.Title = System.Configuration.ConfigurationSettings.AppSettings["titlewhere"].ToString() + System.Configuration.ConfigurationSettings.AppSettings["titlename"].ToString();
            }
            catch
            {
            }
            base.OnPreInit(e);
        }
    }
    internal class FormFixerHtml32TextWriter : System.Web.UI.Html32TextWriter
    {
        private string _url; // 假的URL
        internal FormFixerHtml32TextWriter(TextWriter writer)
            : base(writer)
        {
            _url = HttpContext.Current.Request.RawUrl;
        }
        public override void WriteAttribute(string name, string value, bool encode)
        {
            if (_url != null && string.Compare(name, "action", true) == 0)
            {
                value = _url;
            }
            base.WriteAttribute(name, value, encode);
        }
    }

    internal class FormFixerHtmlTextWriter : System.Web.UI.HtmlTextWriter
    {
        private string _url;
        internal FormFixerHtmlTextWriter(TextWriter writer)
            : base(writer)
        {
            _url = HttpContext.Current.Request.RawUrl;
        }
        public override void WriteAttribute(string name, string value, bool encode)
        {
            if (_url != null && string.Compare(name, "action", true) == 0)
            {
                value = _url;
            }
            base.WriteAttribute(name, value, encode);
        }
    }
