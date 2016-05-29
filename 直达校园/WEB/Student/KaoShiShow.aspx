<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KaoShiShow.aspx.cs" Inherits="BaseSystem.Student_KaoShiShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/zhiri.css" rel="stylesheet" type="text/css" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link id="skinlink" href="../skin/blue.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="form1" runat="server">
<div id="div_zhiri" runat="Server">
    <div id="div_top">
        <div class="top_left"><img src="../images/zhiri.png" alt="" width="30" height="30" /></div>
        <div class="top_right">考试安排</div>
    </div>
    <div class="clear"></div>
    <div id="div_main">
    <table style="width: 100%;">
        <tr><td colspan="7" style="height:20px;"></td></tr>
        <tr>
            <td style=" width:60px;"></td>
            <td colspan="6"><%--<div class="tdzhiri">值日安排</div>--%></td>
        </tr>
        <%--<tr><td colspan="7" style="height:20px;"></td></tr>--%>
        <tr>
            <td></td>
            <td colspan="6">
                <div class="testinfo">
                    <div class="datagrid-header2">
                    <div class="datagrid-head-line"></div>
                    <table class="head_table" width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th width="10%"><b>考试科目</b></th>
                            <th width="20%"><b>考试时间</b></th>
                            <th width="20%"><b>考试地点</b></th>
                            <th width="10%"><b>座位号</b></th>
                            <th width="20%"><b>备注</b></th>
                        </tr>
                    </table>
                    </div>
                    <div class="datagrid-main">
                        <table class="head_table" width="100%" border="0" cellpadding="0" cellspacing="0">
                          <asp:Repeater ID="rpt_test" runat="server">
                            <ItemTemplate>
                            <tr>
                                <%--<td width="10%"><%#Eval("CID")%></td>--%>
                                <%--<td width="10%"><%#Eval("KSSJ")%></td>--%>
                                <td width="10%"><div runat="Server" id="div_km"></div></td>
                                <td width="20%"><div runat="Server" id="div_time"></div></td>
                                <td width="20%"><%#Eval("JS")%></td>
                                <td width="10%"><%#Eval("ZWNO")%></td>
                                <td width="20%"><%#Eval("BZ")%></td>
                                <%--<td width="10%"><div runat="Server" id="div_km"></div></td>
                                <td width="10%"><div runat="Server" id="div_time"></div></td>
                                <td width="10%"><div runat="Server" id="div_js"></div></td>
                                <td width="10%"><div runat="Server" id="div_zwh"></div></td>
                                <td width="20%"><div runat="Server" id="div_remark"></div></td>--%>
                            </tr>
                            </ItemTemplate>
                            </asp:Repeater>
                        </table> 
                    </div>
                </div>
            </td>
        </tr>
    </table>
    </div>
</div>
</form>
</body>
</html>
