<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XskqList.aspx.cs" Inherits="BaseSystem.Users_UserList" %>

<%@ Register src="../Ascx/pager.ascx" tagname="pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link id="skinlink" href="../skin/blue.css" rel="stylesheet" type="text/css" />
     <script src="../JS/calendar.js" type="text/javascript"></script>
    <script src="../JS/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../JS/zii.cookie.js" type="text/javascript"></script>
    <script src="../JS/zii.common.js" type="text/javascript"></script>
    
    <script src="../JS/Users/User.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div class="datagrid">

    
            <div class="datagrid-header">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0" style="margin-top:20px;">
                <tr>
                    <td class="query">
        	            考勤日期：
                    <input id="BeginDate" type="text" style="width:100px" runat="server" onclick="calendar(this)"/>
                    至
                    <input id="EndDate" type="text" style="width:100px" runat="server" onclick="calendar(this)"/>
                        <asp:Button ID="btnQuery" CssClass="form-btn" runat="server" Text="搜索" onclick="btnQuery_Click" />
                    </td>
                    <td class="operating" style="display:none;">
                        <a href="#" class="btn btn-toolbar" onclick="GoAdd(<%=Pager.PageIndex.ToString() %>)" id="btnAdd" ><i class="icon icon-add"></i>添加</a>
                        <a href="#" class="btn btn-toolbar" onclick="GoEdit(<%=Pager.PageIndex.ToString() %>)" id="btnEdit" ><i class="icon icon-edit"></i>修改</a>
                        <a href="#" class="btn btn-toolbar" onclick="UserDel(<%=Pager.PageIndex.ToString() %>)" id="btnDel" ><i class="icon icon-delete"></i>删除</a>
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line" style="margin-top:20px;"></div>
            <table class="datagrid-head-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th width="5%"><input id="selectAll" type="checkbox" /></th>
                    <th width="10%"><b>学号</b></th>
                    <th width="10%"><b>姓名</b></th>
                     <th width="10%"><b>学校</b></th>
                    <th width="10%"><b>班级</b></th>
                    <th width="15%"><b>考勤日期</b></th>
                    <th width="10%"><b>考勤状态</b></th>
                    <th width="20%"><b>事由</b></th>
                    <th width="10%"><b>考勤教师</b></th>

                </tr>
            </table>
             </div>
        
        <div class="datagrid-main">
            <table class="datagrid-main-table" width="100%" border="0" cellpadding="0" cellspacing="0">
              <asp:Repeater ID="rpt_user" runat="server">
                <ItemTemplate>
                <tr>
                    <td width="5%"><input type="checkbox" name="selectThis" value="<%#Eval("LSH") %>" /></td>
                     <td width="10%"><%#Eval("SNO")%>&nbsp;</td>
                    <td width="10%"><%#Eval("SNAME")%>&nbsp;</td>
                    <td width="10%"><%#Eval("SCHOOLNAME")%>&nbsp;</td>
                    <td width="10%"><%#Eval("CLASSNAME")%>&nbsp;</td>
                    <td width="15%"><%#Eval("DJRQ")%>&nbsp;</td>
                    <td width="10%"><%#Eval("KQZT")%>&nbsp;</td>
                    <td width="20%"><%#Eval("BZ")%>&nbsp;</td>
                     <td width="10%"><%#Eval("DJRYXM")%>&nbsp;</td>
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
