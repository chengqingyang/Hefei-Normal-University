<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XueNianEdit.aspx.cs" Inherits="BaseSystem.Users_XueNianEdit" %>

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
    
    <script src="../JS/Users/XueNian.js" type="text/javascript"></script>

    <script src="../JS/calendar.js" type="text/javascript"></script>

</head>
<body>
<form id="form1" runat="server">
    <asp:HiddenField ID="hidlsh" runat="server" />
    <input id="hidusr" type="hidden" value="<%=Session["username"].ToString()%>" />
    <div class="datadetail">
        <div class="datagrid-header">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="title">
                    </td>
                    <td class="operating">
                        <a href="#" onclick="XueNianSave()" class="btn btn-toolbar">
                            <span class="icon icon-save"></span>保存
                        </a> 
                        <a href="#" class="btn btn-toolbar" onclick="GoList2(<%=Request.QueryString["page"] %>)">
                            <span class="icon icon-print"></span>返回
                        </a>
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line"> </div>
        </div>
        <div class="datadetail-view">
            <table class="datadetail-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th>
                        <b>*</b>所属学校：
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlSchool" runat="server" class="ddt-input ddt-input-l" 
                            Width="208px">
                        </asp:DropDownList>
                    </td>
                </tr>   
                <tr>
                    <th>
                        <b>*</b>是否可见：
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlState" runat="server" class="ddt-input ddt-input-l" Width="208px">
                            <asp:ListItem Value="0">可用</asp:ListItem>
                            <asp:ListItem Value="1">不可用</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>  
                <tr>
                    <th>
                        <b>*</b>学年名称：
                    </th>
                    <td>
                        <input id="txtxuenianname" style="width: 200px" class="ddt-input ddt-input-l" 
                            maxlength="20" type="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>*</b>开始日期：
                    </th>
                    <td>
                        <input id="txtdatestart" style="width: 200px" class="ddt-input ddt-input-l" maxlength="20"
                            type="text" runat="server" onclick="calendar(this)" onfocus="calendar(this)" />
                    </td>
                </tr> 
                <tr>
                    <th>
                        <b>*</b>结束日期：
                    </th>
                    <td>
                        <input id="txtdateend" style="width: 200px" class="ddt-input ddt-input-l" maxlength="20"
                            type="text" runat="server" onclick="calendar(this)" onfocus="calendar(this)" />
                    </td>
                </tr>            
            </table>
        </div>
    </div>
</form>
</body>
</html>