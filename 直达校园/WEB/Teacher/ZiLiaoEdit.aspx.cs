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

    public partial class Teacher_ZiLiaoEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 资料信息
            if (Request.QueryString["getid"] != null)
            {
                string getid = Request.QueryString["getid"].ToString();
                try
                {
                    DataSet ds = ZiLiaoDAL.GetZiLiaoList("lsh",getid);
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    ddlCourse.SelectedValue = ds.Tables[0].Rows[0]["CID"].ToString();
                    ddlVisibie.SelectedValue = ds.Tables[0].Rows[0]["STATE"].ToString();

                    lab_filename.Value = ds.Tables[0].Rows[0]["ZLNAME"].ToString();
                    lab_filepath.Value = ds.Tables[0].Rows[0]["ZLPATH"].ToString();
                    lbl_pic.Text = "原文件："+ds.Tables[0].Rows[0]["ZLNAME"].ToString();
                }
                catch(Exception exc)
                {
                    string msg = exc.Message;
                    string stack= exc.StackTrace;
                }
            }
            #endregion
        }


        protected void btn_upload_Click(object sender, EventArgs e)
        {
            bool fileOk = false;
            if (file_upload.HasFile)//验证是否包含文件
            {
                //取得文件的扩展名,并转换成小写
                string fileExtension = Path.GetExtension(file_upload.FileName).ToLower();
                //验证上传文件是否满足格式要求
                fileOk = IsFile(fileExtension);

                if (fileOk)
                {
                    //对上传文件的大小进行检测，限定文件最大不超过1M
                    if (file_upload.PostedFile.ContentLength < 1024000)
                    {
                        string filepath = "../files/";
                        string date = DateTime.Now.ToString("yyyyMMdd");
                        filepath += date+"/";
                        if (Directory.Exists(Server.MapPath(filepath)) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(Server.MapPath(filepath));
                        }
                        string filename = file_upload.FileName;
                        string virpath = filepath + DateTime.Now.ToString("yyyyMMddHHmmss")+"-"+filename;// +fileExtension;//这是存到服务器上的虚拟路径
                        
                        string mappath = Server.MapPath(virpath);//转换成服务器上的物理路径
                        file_upload.PostedFile.SaveAs(mappath);//保存图片
                        
                        lab_filepath.Value = virpath;
                        lab_filename.Value = filename;
                        //清空提示
                        lbl_pic.Text = "";
                    }
                    else
                    {
                        //pic.Src = "";
                        lbl_pic.Text = "文件大小超出1M！请重新选择！";
                    }
                }
                else
                {
                    //pic.Src = "";
                    lbl_pic.Text = "要上传的文件类型不对！请重新选择！";
                }
            }
            else
            {
                //pic.Src = "";
                lbl_pic.Text = "请选择要上传的图片！";
            }
        }

        /// <summary>
        /// 验证是否指定的文件格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsFile(string str)
        {
            bool isimage = false;
            string thestr = str.ToLower();
            //限定能上传文件的格式
            string[] allowExtension = { ".doc", ".docx", ".xls", ".xlsx",".rar",".zip",".gz" };
            //对上传的文件的类型进行一个个匹对
            for (int i = 0; i < allowExtension.Length; i++)
            {
                if (thestr == allowExtension[i])
                {
                    isimage = true;
                    break;
                }
            }
            return isimage;
        }
    }
}