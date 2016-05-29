﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeWorkEdit.aspx.cs" 
Inherits="BaseSystem.Teacher_HomeWorkEdit" %>

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

    <script src="../JS/Teachers/HomeWorkEdit.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            width: 445px;
        }
        .style2
        {
            width: 386px;
        }
    </style>

</head>
<body>
    <form id="form2" runat="server">
    <asp:HiddenField ID="hidschool" runat="server" />
    <asp:HiddenField ID="hidlsh" runat="server" />
    <input type="hidden" id="hidtgh" value="<%=Session["username"].ToString() %>">
    <div class="datadetail">
        <div class="datagrid-header">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="title">
                    </td>
                    <td class="operating">
                        <a href="#" onclick="HomeWorkSave()" class="btn btn-toolbar"><span class="icon icon-save">
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
                            <b>*</b>日期：
                        </th>
                        <td class="style2">
                            <input id="txtdate" style="width: 433px" class="ddt-input ddt-input-l" maxlength="50"
                                type="text" runat="server" />
                        </td>
                        <td>
                            <asp:ImageButton ID="btn_addTime" runat="server" onclick="btn_addTime_Click"
                             ImageUrl="~/images/date.png" Width="30" Height="30" AlternateText="插入日期"/>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <th>
                            <b>*</b>学年：
                        </th>
                        <td colspan="2" class="style1">
                            <asp:DropDownList ID="ddlXueNian" CssClass="ddt-input ddt-input-l" 
                                 Width="208px" runat="server" AutoPostBack="true" 
                                onselectedindexchanged="ddlXueNian_SelectedIndexChanged"> </asp:DropDownList>
                        </td>
                        <td> </td>
                    </tr>
                    <tr>
                        <th>
                            <b>*</b>学期：
                        </th>
                        <td colspan="2" class="style1">
                            <asp:DropDownList ID="ddlXueQi" CssClass="ddt-input ddt-input-l" 
                                 Width="208px" runat="server"> </asp:DropDownList>
                        </td>
                        <td> </td>
                    </tr>
                    <tr>
                        <th>
                            <b>*</b>班级：
                        </th>
                        <td colspan="2" class="style1">
                            <asp:DropDownList ID="ddlClass" CssClass="ddt-input ddt-input-l" 
                                 Width="208px" runat="server"> </asp:DropDownList>
                        </td>
                        <td> </td>
                    </tr>
                    <tr>
                        <th>
                            课程名称：
                        </th>
                        <td colspan="2" class="style1">
                            <asp:DropDownList ID="ddlCourse" runat="server" Width="208px"
                                CssClass="ddt-input ddt-input-l" >
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <th>
                            是否可见：
                        </th>
                        <td colspan="2" class="style1">
                            <asp:DropDownList ID="ddlVisible" runat="server" Width="208px"
                                CssClass="ddt-input ddt-input-l">
                                <asp:ListItem Value="0">可见</asp:ListItem>
                                <asp:ListItem Value="1">不可见</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <th>
                            正文：
                        </th>
                        <td colspan="2" class="style1">
                            <%--<input id="txtbody"  maxlength="100"  style="width: 500px; height: 220px;" 
                            class="ddt-input ddt-input-l" type="text" runat="server"/>--%>
                            <textarea id="txtbody" cols="20" rows="2" style="width: 500px; height: 180px;" 
                                runat="Server"></textarea>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    </table>
        </div>
    </div>
    </form>
</body>
</html>