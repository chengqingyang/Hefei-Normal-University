﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourseFPList.aspx.cs" Inherits="BaseSystem.Users_CourseFPList" %>

<%@ Register src="../Ascx/pager.ascx" tagname="pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link id="skinlink" href="../skin/blue.css" rel="stylesheet" type="text/css" />
    
    <script src="../JS/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../JS/zii.cookie.js" type="text/javascript"></script>
    <script src="../JS/zii.common.js" type="text/javascript"></script>
    
    <script src="../JS/Users/CourseFP.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="HidMenuName" Value="课程分配管理" runat="server" />
    <div class="datagrid">
            <div class="datagrid-header">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="query">
        	            筛选条件：
                        <asp:DropDownList ID="ddlQuery" runat="server">
                            <asp:ListItem Value="B.SCHOOLNAME">所属学校</asp:ListItem>
                            <asp:ListItem Value="E.COURSENAME">课程名</asp:ListItem>
                            <asp:ListItem Value="C.TNAME">教师名</asp:ListItem>
                            <asp:ListItem Value="D.CLASSNAME">班级名</asp:ListItem>
                            <asp:ListItem Value="A.DJRYGH">登记人</asp:ListItem>
                        </asp:DropDownList>
        	            <input id="txtQuery" type="text" class="ddt-input ddt-input-l" style="width:150px" runat="server" />
                        <asp:Button ID="btnQuery" CssClass="form-btn" runat="server" Text="搜索" onclick="btnQuery_Click" />
                    </td>
                    <td class="operating">
                        <a href="#" class="btn btn-toolbar" onclick="GoAdd(<%=Pager.PageIndex.ToString() %>)" id="btnAdd" ><i class="icon icon-add"></i>添加</a>
                        <a href="#" class="btn btn-toolbar" onclick="GoEdit(<%=Pager.PageIndex.ToString() %>)" id="btnEdit" ><i class="icon icon-edit"></i>修改</a>
                        <a href="#" class="btn btn-toolbar" onclick="CourseFPDel(<%=Pager.PageIndex.ToString() %>)" id="btnDel" ><i class="icon icon-delete"></i>删除</a>
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line"></div>
            <table class="datagrid-head-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th width="5%"><input id="selectAll" type="checkbox" /></th>
                    <th width="10%"><b>所属学校</b></th>
                    <th width="10%"><b>授课教师</b></th>
                    <th width="10%"><b>授课班级</b></th>
                    <th width="10%"><b>课程名</b></th>
                    <th width="10%"><b>登记人</b></th>
                    <th width="10%"><b>是否可用</b></th>
                    <th width="12%"><b>修改时间</b></th>
                    <th width="12%"><b>登记时间</b></th>
                </tr>
            </table>
             </div>
        
        <div class="datagrid-main">
            <table class="datagrid-main-table" width="100%" border="0" cellpadding="0" cellspacing="0">
              <asp:Repeater ID="rpt_user" runat="server">
                <ItemTemplate>
                <tr>
                    <td width="5%"><input type="checkbox" name="selectThis" value="<%#Eval("LSH") %>" /></td>
                    <td width="10%"><%#Eval("SCHOOLNAME") %>&nbsp;</td>
                    <td width="10%"><%#Eval("TNAME")%>&nbsp;</td>
                    <td width="10%"><%#Eval("CLASSNAME")%>&nbsp;</td>
                    <td width="10%"><%#Eval("COURSENAME")%>&nbsp;</td>
                    <td width="10%"><%#Eval("DJRYGH")%>&nbsp;</td>
                    <td width="10%"><%#Eval("STATE").ToString().Trim() == "0" ? "可用" : "不可用"%>&nbsp;</td>
                    <td width="12%"><%#Eval("XGSJ")%>&nbsp;</td>
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
    </form>
</body>
</html>
