<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BeiWangList.aspx.cs" Inherits="BaseSystem.Teacher_BeiWangList" %>

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
    <script src="../JS/calendar.js" type="text/javascript"></script>
    
    <script src="../JS/Teachers/BeiWang.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
    <asp:HiddenField ID="HidMenuName" Value="作业管理" runat="server" />
    <div class="datagrid">
        <div class="datagrid-header2">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="query">
        	            筛选条件：
        	            <asp:DropDownList ID="ddlFilter" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlFilter_SelectedIndexChanged">
                            <asp:ListItem>全部</asp:ListItem>
                            <asp:ListItem>最近一周</asp:ListItem>
                            <asp:ListItem>最近一月</asp:ListItem>
                            <asp:ListItem>自定义范围</asp:ListItem>
                        </asp:DropDownList>
        	            <input id="txtdate1" type="text" class="ddt-input ddt-input-l" 
        	                style="width:150px;" runat="server" onclick="calendar(this)"  />
        	            <input id="txtdate2" type="text" class="ddt-input ddt-input-l" 
        	                style="width:150px;" runat="server" onclick="calendar(this)"  />
                        <asp:Button ID="btnQuery" CssClass="form-btn" runat="server" Text="搜索" 
                            onclick="btnQuery_Click" />
                    </td>
                    <td class="operating">
                        <a href="#" class="btn btn-toolbar" onclick="GoAdd(<%=Pager.PageIndex.ToString() %>)" id="btnAdd" ><i class="icon icon-add"></i>添加</a>
                        <a href="#" class="btn btn-toolbar" onclick="GoEdit(<%=Pager.PageIndex.ToString() %>)" id="btnEdit" ><i class="icon icon-edit"></i>修改</a>
                        <a href="#" class="btn btn-toolbar" onclick="BeiWangDel(<%=Pager.PageIndex.ToString() %>)" id="btnDel" ><i class="icon icon-delete"></i>删除</a>
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line"></div>
            <table class="datagrid-head-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th width="5%"><input id="selectAll" type="checkbox" /></th>
                    <%--<th width="5%"><b>编号</b></th>--%>
                    <th width="15%"><b>标题</b></th>
                    <th width="30%"><b>备忘内容</b></th>
                    <th width="12%"><b>备忘时间</b></th>
                    <th width="12%"><b>登记时间</b></th>
                </tr>
            </table>
        </div>
        <%int num = 1; %>
        <div class="datagrid-main">
            <table class="datagrid-main-table" width="100%" border="0" cellpadding="0" cellspacing="0">
              <asp:Repeater ID="rpt_stu" runat="server">
                <ItemTemplate>
                <tr>
                    <td width="5%"><input type="checkbox" name="selectThis" value="<%#Eval("LSH") %>" /></td>
                    <%--<td width="5%"><%#Eval("BWNO") %>&nbsp;</td>--%>
                    <td width="15%"><%#Eval("TITLE")%>&nbsp;</td>
                    <td width="30%"><%#Eval("BWZW")%>&nbsp;</td>
                    <td width="12%"><%#Eval("BWSJ")%>&nbsp;</td>
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