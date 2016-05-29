<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZdxlList.aspx.cs" Inherits="BaseSystem.Users_SchoolList" %>

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
    
    <script src="../JS/Users/Zdx.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="HidMenuName" Value="字典项管理" runat="server" />
    <div class="datagrid">
            <div class="datagrid-header">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="query">
        	            筛选条件：
                        <asp:DropDownList ID="ddlQuery" runat="server">
                            <asp:ListItem Value="DAZX">业务大项编号</asp:ListItem>
                            <asp:ListItem Value="WTBH">项目大项编号</asp:ListItem>
                            <asp:ListItem Value="WTNR">项目名称</asp:ListItem>
                        </asp:DropDownList>
        	            <input id="txtQuery" type="text" class="ddt-input ddt-input-l" style="width:150px" runat="server" />
                        <asp:Button ID="btnQuery" CssClass="form-btn" runat="server" Text="搜索" onclick="btnQuery_Click" />
                    </td>
                    <td class="operating">
                        <a href="#" class="btn btn-toolbar" onclick="GoAdd(<%=Pager.PageIndex.ToString() %>)" id="btnAdd" ><i class="icon icon-add"></i>添加</a>
                        <a href="#" class="btn btn-toolbar" onclick="GoEdit(<%=Pager.PageIndex.ToString() %>)" id="btnEdit" ><i class="icon icon-edit"></i>修改</a>
                        <a href="#" class="btn btn-toolbar" onclick="ZdxDel(<%=Pager.PageIndex.ToString() %>)" id="btnDel" ><i class="icon icon-delete"></i>删除</a>
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line"></div>
            <table class="datagrid-head-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th width="5%"><input id="selectAll" type="checkbox" /></th>
                    <th width="10%"><b>业务大项编号</b></th>
                    <th width="10%"><b>项目大项编号</b></th>
                    <th width="10%"><b>项目名称</b></th>
                    <th width="10%"><b>小项编号</b></th>
                    <th width="10%"><b>小项内容</b></th>
                    <th width="12%"><b>备注</b></th>
                </tr>
            </table>
             </div>
        
        <div class="datagrid-main">
            <table class="datagrid-main-table" width="100%" border="0" cellpadding="0" cellspacing="0">
              <asp:Repeater ID="rpt_user" runat="server">
                <ItemTemplate>
                <tr>
                    <td width="5%"><input type="checkbox" name="selectThis" value="<%#Eval("LSH") %>" /></td>
                    <td width="10%"><%#Eval("DAZX")%>&nbsp;</td>
                    <td width="10%"><%#Eval("WTBH")%>&nbsp;</td>
                    <td width="10%"><%#Eval("WTNR")%>&nbsp;</td>
                    <td width="10%"><%#Eval("DABH")%>&nbsp;</td>
                    <td width="10%"><%#Eval("DAXX")%>&nbsp;</td>
                    <td width="12%"><%#Eval("BZ")%>&nbsp;</td>
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
