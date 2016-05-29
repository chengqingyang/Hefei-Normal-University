using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Threading;

public partial class ImportUsers : System.Web.UI.Page
{
    string connr = System.Configuration.ConfigurationManager.AppSettings["connstr"].ToString();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void FileUpload_Button_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.PostedFile.FileName == "")
            {
                this.Upload_info.Text = "请选择上传文件！";
            }
            else
            {
                string filepath = FileUpload1.PostedFile.FileName;  //得到的是文件的完整路径,包括文件名，如：C:\Documents and Settings\Administrator\My Documents\My Pictures\20022775_m.jpg 
                string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);//20022775_m.jpg 
                string serverpath = Server.MapPath("~/uploadfile/") + filename;//取得文件在服务器上保存的位置C:\Inetpub\wwwroot\WebSite1\images\20022775_m.jpg 
                FileUpload1.PostedFile.SaveAs(serverpath);//将上传的文件另存为 
                this.Upload_info.Text = "上传成功！";


                string connExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + serverpath + ";Extended Properties=Excel 8.0";

                try
                {
                    OleDbConnection oleDbConnection = new OleDbConnection(connExcel);
                    oleDbConnection.Open();

                    //获取excel表  
                    DataTable dataTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    //从excel文件获得数据后，插入记录到SQL Server的数据表,dataTable1用于存储从excel导入的数据
                    DataTable dataTable1 = new DataTable();


                    SqlDataAdapter sqlDA1 = new SqlDataAdapter();

                        //获取sheet名，其中[0][1]...[N]: 按名称排列的表单元素  
                        string tableName = dataTable.Rows[0][2].ToString().Trim();
                        tableName = "[" + tableName.Replace("'", "") + "]";

                        //利用SQL语句从Excel文件里获取数据  
                        string query = "SELECT 学号,姓名,性别,班级,联系电话,身份证号,居住地址,备注 FROM " + tableName;
                        DataSet dataSet = new DataSet();

                        OleDbDataAdapter oleAdapter = new OleDbDataAdapter(query, connExcel);
                        oleAdapter.Fill(dataSet, "test1");

                        sqlDA1 = new SqlDataAdapter(@"SELECT SNO,SNAME,XB,CLASSNAME,LXDH,SFZH,JTZZ,BZ,SCHOOLNO,SCHOOLNAME FROM YW_STUDENT", connr);

                        SqlCommandBuilder SCB = new SqlCommandBuilder(sqlDA1);


                        sqlDA1.Fill(dataTable1);

                        foreach (DataRow dataRow in dataSet.Tables["test1"].Rows)
                        {
                            DataRow dataRow1 = dataTable1.NewRow();

                            dataRow1["SNO"] = dataRow["学号"];
                            dataRow1["SNAME"] = dataRow["姓名"];
                            dataRow1["XB"] = dataRow["性别"];
                            dataRow1["CLASSNAME"] = dataRow["班级"];
                            dataRow1["LXDH"] = dataRow["联系电话"];
                            dataRow1["SFZH"] = dataRow["身份证号"];
                            dataRow1["JTZZ"] = dataRow["居住地址"];
                            dataRow1["BZ"] = dataRow["备注"];
                            dataRow1["SCHOOLNO"] = Session["schoolno"].ToString();
                            dataRow1["SCHOOLNAME"] = Session["schoolname"].ToString();

                            dataTable1.Rows.Add(dataRow1);
                        }

                    sqlDA1.Update(dataTable1);
                    Response.Write("<script>javascript:alert('新插入 " + dataTable1.Rows.Count.ToString() + " 条记录，插入成功！');</script>");
                    oleDbConnection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


            }
        }
        catch (Exception ex)
        {
            this.Upload_info.Text = "上传发生错误！原因是：" + ex.ToString();
        }
    }
}