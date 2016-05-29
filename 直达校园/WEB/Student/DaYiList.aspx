<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DaYiList.aspx.cs" Inherits="BaseSystem.Student_DaYiList" %>

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
    
    <script src="../JS/Students/DaYi.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
<div id="div_zhiri">
    <div id="div_top">
        <div class="top_left"><img src="../images/zhiri.png" alt="" width="30" height="30" /></div>
        <div class="top_right">在线答疑</div>
        <%--<div class="top_right2"><a href="PingJiaList.aspx">评价学生</a></div>
        <div class="top_right2"><a href="PingJiaShow.aspx">学生评价</a></div>--%>
    </div>
    <div class="clear"></div>
    <div id="div_main">
    <asp:HiddenField ID="HidMenuName" Value="答疑管理" runat="server" />
    <div class="datagrid">
        <div class="datagrid-header2">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="query">
                        筛选条件：
                        <asp:DropDownList ID="ddlFilter" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlFilter_SelectedIndexChanged">
                            <asp:ListItem>全部</asp:ListItem>
                            <asp:ListItem>我的答疑</asp:ListItem>
                            <asp:ListItem>语文</asp:ListItem>
                            <asp:ListItem>数学</asp:ListItem>
                            <asp:ListItem>英语</asp:ListItem>
                        </asp:DropDownList>
                    
        	            <%--作业号：<input id="loginName" type="text" class="ddt-input ddt-input-l" style="width:150px" runat="server" />
                        <asp:Button ID="btnQuery" CssClass="form-btn" runat="server" Text="搜索" onclick="btnQuery_Click" />--%>
                    </td>
                    <td class="operating">
                        <a href="#" class="btn btn-toolbar" onclick="GoAdd(<%=Pager.PageIndex.ToString() %>)" id="btnAdd" ><i class="icon icon-add"></i>添加</a>
                        <a href="#" class="btn btn-toolbar" onclick="GoEdit(<%=Pager.PageIndex.ToString() %>)" id="btnEdit" ><i class="icon icon-edit"></i>修改</a>
                        <a href="#" class="btn btn-toolbar" onclick="DaYiDel(<%=Pager.PageIndex.ToString() %>)" id="btnDel" ><i class="icon icon-delete"></i>删除</a>
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line"></div>
            <table class="datagrid-head-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                     <% if (ddlFilter.SelectedValue=="我的答疑")
                     {
                     %>
                         <th width="5%"><input id="selectAll" type="checkbox" /></th>                    
                     <% 
                     }
                     %>
                    <th width="25%"><b>标题</b></th>
                    <th width="12%"><b>提问者</b></th>
                    <th width="12%"><b>提问日期</b></th>
                    <th width="5%"><b>浏览次数</b></th>
                    <th width="12%"><b>登记时间</b></th>
                </tr>
            </table>
        </div>
        
        <div class="datagrid-main">
            <table class="datagrid-main-table" width="100%" border="0" cellpadding="0" cellspacing="0">
              <asp:Repeater ID="rpt_stu" runat="server">
                <ItemTemplate>
                <tr>
                    <% if (ddlFilter.SelectedValue=="我的答疑")
                    {
                    %>
                        <td width="5%"><input type="checkbox" name="selectThis" value="<%#Eval("LSH") %>" /></td> 
                    <% 
                    }
                     %>
                    <td width="25%">
                        <a href="DaYiShow.aspx?getid=<%#Eval("LSH") %>&page=<%=Pager.PageIndex.ToString() %>">
                            <%#Eval("TITLE") %>
                        </a>
                    </td>
                    <td width="12%"><%#Eval("NAME")%></td>
                    <td width="12%"><%#Eval("TWSJ")%>&nbsp;</td>
                    <td width="5%"><%#Eval("CLICK")%>&nbsp;</td>
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
