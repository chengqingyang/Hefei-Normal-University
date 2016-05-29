<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZiLiaoEdit.aspx.cs" Inherits="BaseSystem.Teacher_ZiLiaoEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/zhiri.css" rel="stylesheet" type="text/css" />  
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link id="skinlink" href="../skin/blue.css" rel="stylesheet" type="text/css" />

    <script src="../JS/jquery-1.8.0.min.js" type="text/javascript"></script>

    <script src="../JS/zii.cookie.js" type="text/javascript"></script>

    <script src="../JS/zii.common.js" type="text/javascript"></script>

    <script src="../JS/calendar.js" type="text/javascript"></script>

    <script src="../JS/Teachers/ZiLiaoEdit.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div id="div_zhiri">
    <div id="div_top">
        <div class="top_left"><img src="../images/zhiri.png" alt="" width="30" height="30" /></div>
        <div class="top_right">资料共享</div>
        <%--<div class="top_right2"><a href="PingJiaList.aspx">评价学生</a></div>
        <div class="top_right2"><a href="PingJiaShow.aspx">学生评价</a></div>--%>
    </div>
    <div class="clear"></div>
    <div id="div_main">
    <asp:HiddenField ID="hidlsh" runat="server" />
    <input type="hidden" id="hidtgh" value="<%=Session["username"].ToString() %>">
    <input type="hidden" id="hidflag" value="<%=Session["cx"].ToString() %>">
    <div class="datadetail">
        <div class="datagrid-header2">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="title">
                    </td>
                    <td class="operating">
                        <a href="#" onclick="ZiLiaoSave()" class="btn btn-toolbar"><span class="icon icon-save">
                        </span>保存</a> 
                        <a href="#" class="btn btn-toolbar" onclick="GoList(<%=Request.QueryString["page"] %>)">
                            <span class="icon icon-print"></span>返回</a>
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line">
            </div>
        </div>
        <div class="datadetail-view">
            <table class="datadetail-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th>
                        课程：
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlCourse" runat="server" Height="24px" Width="200px">
                            <asp:ListItem>语文</asp:ListItem>
                            <asp:ListItem>数学</asp:ListItem>
                            <asp:ListItem>英语</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td> </td>
                </tr>
                <tr>
                    <th>
                        是否可见：
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlVisibie" runat="server" Height="24px" Width="200px">
                            <asp:ListItem Value="0">可见</asp:ListItem>
                            <asp:ListItem Value="1">不可见</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td> </td>
                </tr>
                <tr>
                    <th>
                        资源：
                    </th>
                    <td>
                        <asp:FileUpload ID="file_upload" runat="server" CssClass="putfile" />
                        <asp:HiddenField ID="lab_filepath" Value="" runat="server" />
                        <asp:HiddenField ID="lab_filename" Value="" runat="server" />
                        <%--<asp:Label ID="Label1" runat="Server" class="pic_label">
                            建议图片大小：128px*128px<br/>
                            上传图片格式为.jpg, .gif, .bmp,.png,图片大小不得超过1M
                        </asp:Label>--%>
                        <asp:Button ID="btn_upload" runat="server"  Text="上传资源" onclick="btn_upload_Click"/>
                        <br/>                        
                        <asp:Label ID="lbl_pic" runat="server" class="pic_text"></asp:Label>
                    </td>
                    <td> </td>
                </tr>
            </table>
        </div>
    </div>
    </div>
</div>
</form>
</body>
</html>