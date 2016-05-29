<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeWorkList.aspx.cs" 
Inherits="BaseSystem.Student_HomeWorkList" %>

<%@ Register src="../Ascx/pager.ascx" tagname="pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/zhiri.css" rel="stylesheet" type="text/css" />    
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link id="skinlink" href="../skin/blue.css" rel="stylesheet" type="text/css" />
    
    <script src="../JS/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../JS/zii.cookie.js" type="text/javascript"></script>
    <script src="../JS/zii.common.js" type="text/javascript"></script>
    
    <script src="../JS/Teachers/TiaoKe.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div id="div_zhiri">
    <div id="div_top">
        <div class="top_left"><img src="../images/zhiri.png" alt="" width="30" height="30" /></div>
        <div class="top_right">家庭作业</div>
    </div>
    <div class="clear"></div>
    <div id="div_main">
        <asp:HiddenField ID="HidMenuName" Value="作业管理" runat="server" />
        <div class="datagrid">
            <div class="datagrid-header2">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="query">
        	            课程名：<input id="loginName" type="text" class="ddt-input ddt-input-l" style="width:150px" runat="server" />
                        <asp:Button ID="btnQuery" CssClass="form-btn" runat="server" Text="搜索" onclick="btnQuery_Click" />
                    </td>
                    <td class="operating">

                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line"></div>
            <table class="datagrid-head-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th width="5%"></th>
                    <th width="5%"><b>作业编号</b></th>
                    <th width="10%"><b>课程名称</b></th>
                    <th width="10%"><b>布置日期</b></th>
                    <th width="30%"><b>作业正文</b></th>
                    <th width="12%"><b>登记时间</b></th>
                </tr>
            </table>
             </div>
        
        <div class="datagrid-main">
            <table class="datagrid-main-table" width="100%" border="0" cellpadding="0" cellspacing="0">
              <asp:Repeater ID="rpt_stu" runat="server">
                <ItemTemplate>
                <tr>
                    <td width="5%"><%--<input type="checkbox" name="selectThis" value="<%#Eval("LSH") %>" />--%></td>
                    <td width="5%">
                        <a href="HomeWorkEdit.aspx?getid=<%#Eval("LSH") %>&page=<%=Pager.PageIndex.ToString() %>"
                           title="查看详情">
                            <%#Eval("ZYNO") %>&nbsp;
                        </a>
                    </td>
                    <td width="10%"><%#Eval("CID")%>&nbsp;</td>
                    <td width="10%">
                        <a href="HomeWorkEdit.aspx?getid=<%#Eval("LSH") %>&page=<%=Pager.PageIndex.ToString() %>"
                           title="查看详情">
                            <%#Eval("BZRQ")%>&nbsp;
                        </a>
                    </td>
                    <td width="30%"><%#Eval("ZYZW")%>&nbsp;</td>
                    <td width="12%"><%#Eval("DJSJ")%>&nbsp;</td>
                </tr>
                </ItemTemplate>
                </asp:Repeater>
            </table> 
        </div>
        
        <div class="datagrid-footer">
            <uc1:pager ID="Pager" runat="server" />
        </div>
    </div>
    </div>
</div>
</form>
</body>
</html>