<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PingJiaEdit.aspx.cs" Inherits="BaseSystem.Teacher_PingJiaEdit" %>

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

    <script src="../JS/calendar.js" type="text/javascript"></script>

    <script src="../JS/Teachers/PingJiaEdit.js" type="text/javascript"></script>

</head>
<body>
    <form id="form2" runat="server">
    <asp:HiddenField ID="hidlsh" runat="server" />
    <input type="hidden" id="hidtgh" value="<%=Session["username"].ToString() %>">
    <div class="datadetail">
        <div class="datagrid-header">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="title">
                    </td>
                    <td class="operating">
                        <a href="#" onclick="PingJiaSave()" class="btn btn-toolbar"><span class="icon icon-save">
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
                    <th>描述：</th>
                    <td><div runat="Server" id="info" class="info"></div></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <th></th>
                    <td>
                        <input id="txtbody"  maxlength="100"  style="width: 500px; height: 220px;" 
                        class="ddt-input ddt-input-l" type="text" runat="server"/>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>