<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClassEdit.aspx.cs" Inherits="BaseSystem.Users_ClassEdit" %>

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
    
    <script src="../JS/Users/Class.js" type="text/javascript"></script>

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
                    <td class="operating">
                        <a href="#" onclick="ClassSave()" class="btn btn-toolbar"><span class="icon icon-save">
                        </span>保存</a> <a href="#" class="btn btn-toolbar" onclick="GoList2(<%=Request.QueryString["page"] %>)">
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
                        <b>*</b>所属学校：
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlSchool" runat="server" Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>  
                <tr>
                    <th>
                        <b>*</b>班级名称：
                    </th>
                    <td>
                        <input id="txtclassname" style="width: 200px" class="ddt-input ddt-input-l" maxlength="20"
                            type="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>*</b>班主任：
                    </th>
                    <td>
                        <input id="txtbzrname" style="width: 200px" class="ddt-input ddt-input-l" maxlength="20"
                            type="text" runat="server" />
                    </td>
                </tr>   
                <tr>
                    <th>
                        备注：
                    </th>
                    <td>
                        <input id="txtremark" style="width: 200px" maxlength="20" class="ddt-input ddt-input-l"
                            type="text" runat="server" />
                    </td>
                </tr>            
            </table>
        </div>
    </div>
    </form>
</body>
</html>