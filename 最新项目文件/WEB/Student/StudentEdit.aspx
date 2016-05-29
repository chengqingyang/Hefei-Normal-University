<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentEdit.aspx.cs" Inherits="BaseSystem.Student_StudentEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link id="skinlink" href="../skin/blue.css" rel="stylesheet" type="text/css" />

    <script src="../JS/jquery-1.8.0.min.js" type="text/javascript"></script>

    <script src="../JS/zii.cookie.js" type="text/javascript"></script>

    <script src="../JS/zii.common.js" type="text/javascript"></script>

    <script src="../JS/Students/StudentEdit.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hidlsh" runat="server" />
    <div class="datadetail">
        <div class="datagrid-header">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="title">
                    </td>
                    <td class="operating" style="width:90%">
                        <a href="#" onclick="StudentSave()" class="btn btn-toolbar"><span class="icon icon-save">
                        </span>保存</a> 
                    </td>
                    <td>
                        <div runat="server" id="back">
                        <a href="#" class="btn btn-toolbar" onclick="GoList(<%=Request.QueryString["page"] %>)">
                            <span class="icon icon-print"></span>返回</a>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line">
            </div>
        </div>
        <div class="datadetail-view">
            <div class="div_out">
                <div class="div_left">
                    <table class="datadetail-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            <b>*</b>学生学号：
                        </th>
                        <td>
                            <input id="txtstuid" style="width: 200px" class="ddt-input ddt-input-l" maxlength="20"
                                type="text" runat="server" />
                        </td>
                        <th>
                            <b>*</b>学生姓名：
                        </th>
                        <td>
                            <input id="txtstuname" style="width: 200px" class="ddt-input ddt-input-l" maxlength="20"
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <b>*</b>学生性别：
                        </th>
                        <td>
                            <asp:DropDownList ID="ddlsex" CssClass="ddt-input ddt-input-l" runat="server" 
                                Width="205px" >
                                <asp:ListItem>男</asp:ListItem>
                                <asp:ListItem>女</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <th>
                            <b>*</b>所在学校：
                        </th>
                        <td>
                            <asp:DropDownList ID="ddlSchool" runat="server" Width="200px" 
                                AutoPostBack="True" onselectedindexchanged="ddlSchool_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            联系电话：
                        </th>
                        <td>
                            <input id="txtconnphone" style="width: 200px" maxlength="20" class="ddt-input ddt-input-l"
                                type="text" runat="server" />
                        </td>
                        <th>
                            <b>*</b>所在班级：
                        </th>
                        <td>
                            <asp:DropDownList ID="ddlClass" runat="server" Width="200px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            联系地址：
                        </th>
                        <td>
                            <input id="txtaddress" style="width: 200px" class="ddt-input ddt-input-l" maxlength="60"
                                type="text" runat="server" />
                        </td>
                        <th>
                            身份证号：
                        </th>
                        <td>
                            <input id="txtcardid" style="width: 200px" class="ddt-input ddt-input-l" maxlength="20"
                                type="text" runat="server" />
                        </td>
                    </tr>
                    <tr>
                    <th>
                            备注：
                        </th>
                        <td>
                            <input id="txtremark" style="width: 200px" class="ddt-input ddt-input-l" maxlength="60"
                                type="text" runat="server" />
                        </td>
                        <th> </th>
                        <td> </td>                         
                    </tr>
                </table>
                </div>
                <div class="div_right">
                    <div class="div_out" style="width:95%">
                        <div class="div_left" style="width:43%">
                            <img src="../images/avatar/stu_default.png" runat="server" id="pic" alt=""
                             width="128" height="128"/>
                             <asp:HiddenField ID="lab_picpath" Value="../images/avatar/stu_default.png" runat="server" />
                        </div>
                        <div class="div_right" style="width:55%">
                            <asp:FileUpload ID="pic_upload" runat="server" />
                            <asp:Label ID="lbl_pic" runat="server" class="pic_text"></asp:Label>
                            <asp:Label runat="Server" class="pic_label">
                                建议图片大小：128px*128px<br/>
                                上传图片格式为.jpg, .gif, .bmp,.png,图片大小不得超过1M
                            </asp:Label>
                            <br />
                            <asp:Button ID="btn_upload" runat="server"  Text="上传照片" 
                                onclick="btn_upload_Click"/>
                            <%--<a href="#" onclick="UploadPic()" class="btn btn-toolbar">
                                    <span class="icon icon-uploadpic"></span>
                                    上传照片
                                </a>  --%>  
                        </div>
                    </div>
                </div>
                <div class="div_clear"></div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>