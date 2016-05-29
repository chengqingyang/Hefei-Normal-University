<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XsCjlList.aspx.cs" Inherits="BaseSystem.Users_SchoolList" %>

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
    
    <script src="../JS/Users/School.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="HidMenuName" Value="学生成绩管理" runat="server" />
    <div class="datagrid">
            <div class="datagrid-header">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0" style="margin-top:10px;">
                <tr>
                    <td class="query">
        	            筛选条件：
                        <asp:DropDownList ID="ddlQuery" runat="server">
                            <asp:ListItem Value="SNO">学号</asp:ListItem>
                            <asp:ListItem Value="SNAME">姓名</asp:ListItem>
                            <asp:ListItem Value="COURSENAME">课程名</asp:ListItem>
                            <asp:ListItem Value="XQNAME">学期</asp:ListItem>
                        </asp:DropDownList>
        	            <input id="txtQuery" type="text" class="ddt-input ddt-input-l" style="width:150px" runat="server" />
                        <asp:Button ID="btnQuery" CssClass="form-btn" runat="server" Text="搜索" onclick="btnQuery_Click" />
                    </td>
                    <td class="operating">
                        <a href="#" class="btn btn-toolbar" onclick="GoAdd(<%=Pager.PageIndex.ToString() %>)" id="btnAdd" ><i class="icon icon-add"></i>添加</a>
                        <a href="#" class="btn btn-toolbar" onclick="GoEdit(<%=Pager.PageIndex.ToString() %>)" id="btnEdit" ><i class="icon icon-edit"></i>修改</a>
                        <a href="#" class="btn btn-toolbar" onclick="SchoolDel(<%=Pager.PageIndex.ToString() %>)" id="btnDel" ><i class="icon icon-delete"></i>删除</a>
                        <a href="../Teacher/ImPortEXCEL/ImportXscjEXCEL.aspx" class="btn btn-toolbar" id="A1" ><i class="icon icon-add"></i>成绩导入</a>
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line" style="margin-top:10px;"></div>
            <table class="datagrid-head-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th width="5%"><input id="selectAll" type="checkbox" /></th>
                    <th width="10%"><b>学号</b></th>
                    <th width="10%"><b>姓名</b></th>
                    <th width="10%"><b>班级</b></th>
                    <th width="10%"><b>课程名</b></th>
                    <th width="10%"><b>学年</b></th>
                    <th width="5%"><b>学期</b></th>
                    <th width="5%"><b>课程分数</b></th>
                    <th width="10%"><b>备注</b></th>
                    <th width="10%"><b>录入日期</b></th>
                    <th width="5%"><b>录入人员</b></th>
                    <th width="15%"><b>学校</b></th>
                </tr>
            </table>
             </div>
        
        <div class="datagrid-main">
            <table class="datagrid-main-table" width="100%" border="0" cellpadding="0" cellspacing="0">
              <asp:Repeater ID="rpt_user" runat="server">
                <ItemTemplate>
                <tr>
                    <td width="5%"><input type="checkbox" name="selectThis" value="<%#Eval("LSH") %>" /></td>
                    <td width="10%"><%#Eval("SNO") %>&nbsp;</td>
                    <td width="10%"><%#Eval("SNAME")%>&nbsp;</td>
                    <td width="10%"><%#Eval("CLASSNAME")%>&nbsp;</td>
                    <td width="10%"><%#Eval("COURSENAME")%>&nbsp;</td>
                    <td width="10%"><%#Eval("XNNAME")%>&nbsp;</td>
                    <td width="5%"><%#Eval("XQNAME")%>&nbsp;</td>
                    <td width="5%"><%#Eval("KCFS")%>&nbsp;</td>
                    <td width="10%"><%#Eval("BZ")%>&nbsp;</td>
                    <td width="10%"><%#Eval("LRRQ")%>&nbsp;</td>
                    <td width="5%"><%#Eval("DJRYXM")%>&nbsp;</td>
                    <td width="15%"><%#Eval("SCHOOLNAME")%>&nbsp;</td>
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
