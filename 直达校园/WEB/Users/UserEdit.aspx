<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserEdit.aspx.cs" Inherits="BaseSystem.Users_UserEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link id="skinlink" href="../skin/blue.css" rel="stylesheet" type="text/css" />

    <script src="../JS/jquery-1.8.0.min.js" type="text/javascript"></script>

    <script src="../JS/zii.cookie.js" type="text/javascript"></script>

    <script src="../JS/zii.common.js" type="text/javascript"></script>
    
    <script src="../JS/Users/UserEdit.js" type="text/javascript"></script>

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
                        <a href="#" onclick="UserSave()" class="btn btn-toolbar"><span class="icon icon-save">
                        </span>保存</a> <a href="#" class="btn btn-toolbar" onclick="GoList(<%=Request.QueryString["page"] %>)">
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
                        <b>*</b>用户口令：
                    </th>
                    <td>
                        <input id="txtusername" style="width: 200px" class="ddt-input ddt-input-l" maxlength="20"
                            type="text" runat="server" />
                    </td>
                    <th>
                        <b>*</b>用户密码：
                    </th>
                    <td>
                        <input id="txtuserpwd" style="width: 200px" class="ddt-input ddt-input-l" maxlength="20"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>*</b>用户角色：
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlrole" CssClass="ddt-input ddt-input-l" runat="server" Width="205px" />
                    </td>
                    <th>
                        <b>*</b>用户姓名：
                    </th>
                    <td>
                        <input type="text" id="txtTrueName" class="ddt-input ddt-input-l" style="width: 200px"
                            runat="server" />
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
                        身份证号：
                    </th>
                    <td>
                        <input id="txtcardid" style="width: 200px" class="ddt-input ddt-input-l" maxlength="20"
                            type="text" runat="server" />
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
                        用户状态：
                    </th>
                    <td>
                        <select id="ddlstate" class="ddt-input ddt-input-l" style="width: 205px" runat="server">
                            <option value="1">正常</option>
                            <option value="2">锁定</option>
                        </select>
                    </td>
                </tr>
                <tr>
                      <th>
                          <b>*</b>所在学校：
                        </th>
                        <td>
                            <asp:DropDownList ID="ddlSchool" runat="server" Width="200px"  >
                            </asp:DropDownList>
                        </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
