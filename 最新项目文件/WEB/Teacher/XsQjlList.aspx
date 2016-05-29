<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XsQjlList.aspx.cs" Inherits="BaseSystem.Users_SchoolList" %>

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
    
    <script src="../JS/Students/Xsqjgl.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="HidMenuName" Value="学生请假管理" runat="server" />
    <div class="datagrid">
            <div class="datagrid-header">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="query">
        	            筛选条件：
                        <asp:DropDownList ID="ddlQuery" runat="server">
                            <asp:ListItem Value="">--请选择--</asp:ListItem>
                            <asp:ListItem Value="SNO">学号</asp:ListItem>
                            <asp:ListItem Value="SNAME">姓名</asp:ListItem>
                        </asp:DropDownList>
        	            <input id="txtQuery" type="text" class="ddt-input ddt-input-l" style="width:150px" runat="server" />
                        <asp:Button ID="btnQuery" CssClass="form-btn" runat="server" Text="搜索" onclick="btnQuery_Click" />
                    </td>
                    <td class="operating">
                        <a href="#" class="btn btn-toolbar" onclick="GoSpEdit(<%=Pager.PageIndex.ToString() %>)" id="btnEdit" ><i class="icon icon-edit"></i>审批请假条</a>
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line"></div>
            <table class="datagrid-head-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th width="5%"><input id="selectAll" type="checkbox" /></th>
                     <th width="10%"><b>姓名</b></th>
                    <th width="10%"><b>学号</b></th>
                    <th width="10%"><b>班级</b></th>
                    <th width="15%"><b>请假主题</b></th>
                    <th width="15%"><b>请假时间</b></th>
                    <th width="10%"><b>审批状态</b></th>
                    <th width="10%"><b>操作</b></th>
                </tr>
            </table>
             </div>
        
        <div class="datagrid-main">
            <table class="datagrid-main-table" width="100%" border="0" cellpadding="0" cellspacing="0">
              <asp:Repeater ID="rpt_user" runat="server">
                <ItemTemplate>
                <tr>
                    <td width="5%"><input type="checkbox" name="selectThis" value="<%#Eval("LSH") %>" /></td>
                    <td width="10%"><%#Eval("SNAME") %>&nbsp;</td>
                    <td width="10%"><%#Eval("SNO")%>&nbsp;</td>
                    <td width="10%"><%#Eval("CLASSNAME") %>&nbsp;</td>
                    <td width="15%"><%#Eval("QJZT")%>&nbsp;</td>
                    <td width="15%"><%#Eval("QJSJ")%>&nbsp;</td>
                    <td width="10%"><%#Eval("DQZT")%>&nbsp;</td>
                    <td width="10%">
                    <a href="XsQjEdit.aspx?getid=<%#Eval("LSH") %>&page=<%=Pager.PageIndex.ToString() %>"
                           title="查看详情">
                     <span style="color:Red;">查看请假条</span> </td>
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
