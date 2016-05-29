<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KaoShiList.aspx.cs" Inherits="BaseSystem.Teacher_KaoShiList" %>

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
    
    <script src="../JS/Teachers/KaoShi.js" type="text/javascript"></script>
</head>
<body>
<form id="form1" runat="server">
    <asp:HiddenField ID="HidMenuName" Value="考试管理" runat="server" />
    <div class="datagrid">
        <div class="datagrid-header2">
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
                    
        	            课程名：<input id="loginName" type="text" class="ddt-input ddt-input-l" style="width:150px" runat="server" />
                        <asp:Button ID="btnQuery" CssClass="form-btn" runat="server" Text="搜索" onclick="btnQuery_Click" />
                    </td>
                    <td class="operating">
                        <a href="#" class="btn btn-toolbar" onclick="GoAdd(<%=Pager.PageIndex.ToString() %>)" id="btnAdd" ><i class="icon icon-add"></i>添加</a>
                        <a href="#" class="btn btn-toolbar" onclick="GoEdit(<%=Pager.PageIndex.ToString() %>)" id="btnEdit" ><i class="icon icon-edit"></i>修改</a>
                        <a href="#" class="btn btn-toolbar" onclick="KaoShiDel(<%=Pager.PageIndex.ToString() %>)" id="btnDel" ><i class="icon icon-delete"></i>删除</a>
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line"></div>
            <table class="datagrid-head-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th width="3%"><input id="selectAll" type="checkbox" /></th>
                    <th width="5%"><b>考试编号</b></th>
                    <th width="10%"><b>学年</b></th>
                    <th width="8%"><b>学期</b></th>
                    <th width="10%"><b>考试班级</b></th>
                    <th width="8%"><b>考试类型</b></th>
                    <th width="5%"><b>课程名称</b></th>
                    <th width="20%"><b>考试时间</b></th>
                    <th width="5%"><b>是否可见</b></th>
                    <th width="8%"><b>详细安排</b></th>
                    <th width="12%"><b>登记时间</b></th>
                </tr>
            </table>
        </div>
        
        <div class="datagrid-main">
            <table class="datagrid-main-table" width="100%" border="0" cellpadding="0" cellspacing="0">
              <asp:Repeater ID="rpt_stu" runat="server">
                <ItemTemplate>
                <tr>
                    <td width="3%">
                        <input type="checkbox" name="selectThis" value="<%#Eval("LSH") %>" />
                        <input type="hidden" name="selectKSNO" value="<%#Eval("KSNO") %>" />
                    </td>
                    <td width="5%"><%#Eval("KSNO") %>&nbsp;</td>
                    <td width="10%"><%#Eval("XNNAME")%>&nbsp;</td>
                    <td width="8%"><%#Eval("XQNAME")%>&nbsp;</td>
                    <td width="10%"><%#Eval("CLASSNAME")%>&nbsp;</td>
                    <td width="8%"><%#Eval("KSLX")%>&nbsp;</td>
                    <td width="5%"><%#Eval("COURSENAME")%>&nbsp;</td>
                    <td width="20%"><%#Eval("KSSJ")%>&nbsp;</td>
                    <td width="5%">
                        <a href="KaoShiList.aspx?st=<%#Eval("STATE")%>&lsh=<%#Eval("LSH") %>">
                            <%#Eval("STATE").ToString()=="0"?"可见":"不可见"%>&nbsp;
                        </a>
                    </td>
                    <td width="8%">
                        <a href="KaoShiEdit.aspx?getid=<%#Eval("LSH")%>&did=<%#Eval("KSNO")%>" title="考试安排详情">
                            详细信息
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