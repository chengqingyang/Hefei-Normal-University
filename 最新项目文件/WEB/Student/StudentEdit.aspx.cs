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
    public partial class Student_StudentEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.BindDropControl(ddlSchool, SchoolDAL.GetSchoolList(), "SCHOOLNAME", "SCHOOLNO", "请选择");
            }

            #region 学生信息
            if (Request.QueryString["getid"] != null)
            {
                try
                {
                    DataSet ds = StudentDAL.GetStudentList(Request.QueryString["getid"].ToString());
                    hidlsh.Value = ds.Tables[0].Rows[0]["LSH"].ToString();
                    txtstuname.Value = ds.Tables[0].Rows[0]["SNAME"].ToString();
                    txtstuid.Value = ds.Tables[0].Rows[0]["SNO"].ToString();
                    ddlsex.SelectedValue = ds.Tables[0].Rows[0]["XB"].ToString();
                    txtconnphone.Value = ds.Tables[0].Rows[0]["LXDH"].ToString();
                    txtcardid.Value = ds.Tables[0].Rows[0]["SFZH"].ToString();
                    txtaddress.Value = ds.Tables[0].Rows[0]["JTZZ"].ToString();
                    ddlSchool.SelectedValue = ds.Tables[0].Rows[0]["SCHOOLNO"].ToString();
                    CommonDAL.BindDropControl(ddlClass, ClassDAL.GetClassList("schoolno", ddlSchool.SelectedValue), "CLASSNAME", "CLASSNO", "请选择");

                    ddlClass.SelectedValue = ds.Tables[0].Rows[0]["BJ"].ToString();
                    txtremark.Value = ds.Tables[0].Rows[0]["BZ"].ToString();
                    pic.Src = ds.Tables[0].Rows[0]["ZPPATH"].ToString();
                    lab_picpath.Value = pic.Src;

                    if (Session["cx"].ToString() != "管理员" || Session["cx"].ToString() != "超级管理员")
                    {
                        txtstuid.Disabled = true;
                    }

                    if (Request.QueryString["page"] == null)
                    {
                        ddlClass.Enabled = false;
                        back.Visible = false;
                    }
                }
                catch
                { }
            }
            #endregion
        }
        protected void btn_upload_Click(object sender, EventArgs e)
        {
            bool fileOk = false;
            if (pic_upload.HasFile)//验证是否包含文件
            {
                //取得文件的扩展名,并转换成小写
                string fileExtension = Path.GetExtension(pic_upload.FileName).ToLower();
                //验证上传文件是否图片格式
                fileOk = IsImage(fileExtension);

                if (fileOk)
                {
                    //对上传文件的大小进行检测，限定文件最大不超过8M
                    if (pic_upload.PostedFile.ContentLength < 1024000)
                    {
                        string filepath = "../images/avatar/";
                        if (Directory.Exists(Server.MapPath(filepath)) == false)//如果不存在就创建file文件夹
                        {
                            Directory.CreateDirectory(Server.MapPath(filepath));
                        }
                        string virpath = filepath + DateTime.Now.ToString("yyyyMMddHHmmssfff") + fileExtension;//这是存到服务器上的虚拟路径
                        string mappath = Server.MapPath(virpath);//转换成服务器上的物理路径
                        pic_upload.PostedFile.SaveAs(mappath);//保存图片
                        //显示图片
                        //pic.ImageUrl = virpath;
                        pic.Src = virpath;
                        lab_picpath.Value = virpath;
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
        /// 验证是否指定的图片格式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsImage(string str)
        {
            bool isimage = false;
            string thestr = str.ToLower();
            //限定只能上传jpg和gif图片
            string[] allowExtension = { ".jpg", ".gif", ".bmp", ".png" };
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


        protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            string schoolno = ddlSchool.SelectedValue;
            if (schoolno == "")
                return;
            CommonDAL.BindDropControl(ddlClass, ClassDAL.GetClassList("schoolno", schoolno), "CLASSNAME", "CLASSNO", "请选择");
        }
    }
}