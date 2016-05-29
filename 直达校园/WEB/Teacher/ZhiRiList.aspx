<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZhiRiList.aspx.cs" Inherits="BaseSystem.Teacher_ZhiRiList" %>

<%@ Register src="../Ascx/pager.ascx" tagname="pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link id="skinlink" href="../skin/blue.css" rel="stylesheet" type="text/css" />
    
    <script src="../JS/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../JS/zii.cookie.js" type="text/javascript"></script>
    <script src="../JS/zii.common.js" type="text/javascript"></script>
    
    <script src="../JS/Teachers/ZhiRi.js" type="text/javascript"></script>
    
</head>
<body>
<form id="form2" runat="server">
    <asp:HiddenField ID="HidMenuName" Value="值日管理" runat="server" />
    <div class="datagrid">

    
            <div class="datagrid-header">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="query">
                        <asp:DropDownList ID="ddlXueNian" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlXueNian_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlXueQi" runat="server">
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlClass" runat="server">
                        </asp:DropDownList>
                    
        	            周次：<input id="loginName" type="text" class="ddt-input ddt-input-l" style="width:150px" runat="server" />
                        <asp:Button ID="btnQuery" CssClass="form-btn" runat="server" Text="搜索" onclick="btnQuery_Click" />
                    </td>
                    <td class="operating">
                        <a href="#" class="btn btn-toolbar" onclick="GoAdd(<%=Pager.PageIndex.ToString() %>)" id="btnAdd" ><i class="icon icon-add"></i>添加</a>
                        <a href="#" class="btn btn-toolbar" onclick="GoEdit(<%=Pager.PageIndex.ToString() %>)" id="btnEdit" ><i class="icon icon-edit"></i>修改</a>
                        <a href="#" class="btn btn-toolbar" onclick="ZhiRiDel(<%=Pager.PageIndex.ToString() %>)" id="btnDel" ><i class="icon icon-delete"></i>删除</a>
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line"></div>
            <table class="datagrid-head-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th width="3%"><input id="selectAll" type="checkbox" /></th>
                    <th width="10%"><b>班级</b></th>
                    <th width="3%"><b>周次</b></th>
                    <th width="10%"><b>星期一</b></th>
                    <th width="10%"><b>星期二</b></th>
                    <th width="10%"><b>星期三</b></th>
                    <th width="10%"><b>星期四</b></th>
                    <th width="10%"><b>星期五</b></th>
                    <th width="15%"><b>值日内容</b></th>                    
                    <th width="5%"><b>是否可见</b></th>
                    <th width="12%"><b>登记时间</b></th>
                </tr>
            </table>
             </div>
        
        <div class="datagrid-main">
            <table class="datagrid-main-table" width="100%" border="0" cellpadding="0" cellspacing="0">
              <asp:Repeater ID="rpt_stu" runat="server">
                <ItemTemplate>
                <tr>
                    <td width="3%"><input type="checkbox" name="selectThis" value="<%#Eval("LSH") %>" /></td>
                    <td width="10%"><%#Eval("CLASSNAME") %></td>
                    <td width="3%"><%#Eval("WNO") %></td>
                    <td width="10%"><%#Eval("MON") %>&nbsp;</td>
                    <td width="10%"><%#Eval("TUE")%>&nbsp;</td>
                    <td width="10%"><%#Eval("WED")%>&nbsp;</td>
                    <td width="10%"><%#Eval("THU")%>&nbsp;</td>
                    <td width="10%"><%#Eval("FRI")%>&nbsp;</td>
                    <td width="15%"><%#Eval("ZRNR")%>&nbsp;</td>                    
                    <td width="5%">
                        <a href="ZhiRiList.aspx?st=<%#Eval("STATE")%>&lsh=<%#Eval("LSH") %>">
                            <%#Eval("STATE").ToString()=="0"?"可见":"不可见"%>&nbsp;
                        </a>
                    </td>
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