<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeacherList.aspx.cs" Inherits="BaseSystem.Teacher_TeacherList" %>

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
    
    <script src="../JS/Teachers/Teacher.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="HidMenuName" Value="教师管理" runat="server" />
    <div class="datagrid">

    
            <div class="datagrid-header">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="query">
        	            教工号：<input id="loginName" type="text" class="ddt-input ddt-input-l" style="width:150px" runat="server" />
                        <asp:Button ID="btnQuery" CssClass="form-btn" runat="server" Text="搜索" onclick="btnQuery_Click" />
                    </td>
                    <td class="operating">
                        <a href="#" class="btn btn-toolbar" onclick="GoAdd(<%=Pager.PageIndex.ToString() %>)" id="btnAdd" ><i class="icon icon-add"></i>添加</a>
                        <a href="#" class="btn btn-toolbar" onclick="GoEdit(<%=Pager.PageIndex.ToString() %>)" id="btnEdit" ><i class="icon icon-edit"></i>修改</a>
                        <a href="#" class="btn btn-toolbar" onclick="TeacherDel(<%=Pager.PageIndex.ToString() %>)" id="btnDel" ><i class="icon icon-delete"></i>删除</a>
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line"></div>
            <table class="datagrid-head-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th width="5%"><input id="selectAll" type="checkbox" /></th>
                    <th width="10%"><b>照片</b></th>
                    <th width="15%"><b>所在学校</b></th>
                    <th width="10%"><b>教工号</b></th>
                    <th width="10%"><b>姓名</b></th>
                    <th width="5%"><b>性别</b></th>
                    <th width="10%"><b>职称</b></th>
                    <th width="10%"><b>主教课程</b></th>
                    <th width="10%"><b>联系电话</b></th>
                    <th width="12%"><b>登记时间</b></th>
                </tr>
            </table>
             </div>
        
        <div class="datagrid-main">
            <table class="datagrid-main-table" width="100%" border="0" cellpadding="0" cellspacing="0">
              <asp:Repeater ID="rpt_stu" runat="server">
                <ItemTemplate>
                <tr>
                    <td width="5%"><input type="checkbox" name="selectThis" value="<%#Eval("LSH") %>" /></td>
                    <td width="10%"><img src="<%#Eval("ZPPATH") %>" alt="" width="32" height="32" /></td>
                    <td width="15%"><%#Eval("SCHOOLNAME") %>&nbsp;</td>
                    <td width="10%"><%#Eval("TGH") %>&nbsp;</td>
                    <td width="10%"><%#Eval("TNAME")%>&nbsp;</td>
                    <td width="5%"><%#Eval("XB")%>&nbsp;</td>
                    <td width="10%"><%#Eval("ZC")%>&nbsp;</td>
                    <td width="10%"><%#Eval("COURSENAME")%>&nbsp;</td>
                    <td width="10%"><%#Eval("LXDH")%>&nbsp;</td>
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
