<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XueQiList.aspx.cs" Inherits="BaseSystem.Users_XueQiList" %>

<%@ Register src="../Ascx/pager.ascx" tagname="pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/zhiri.css" rel="stylesheet" type="text/css" />
    <link id="skinlink" href="../skin/blue.css" rel="stylesheet" type="text/css" />
    
    <script src="../JS/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../JS/zii.cookie.js" type="text/javascript"></script>
    <script src="../JS/zii.common.js" type="text/javascript"></script>
    
    <script src="../JS/Users/XueQi.js" type="text/javascript"></script>
    
</head>
<body>
<form id="form1" runat="server">
<div id="div_zhiri">
    <div id="div_top">
        <div class="top_left"><img src="../images/zhiri.png" alt="" width="30" height="30" /></div>
        <div class="top_right">学期信息维护</div>        
        <div class="top_right2"><a href="XueNianList.aspx?page=<%=Request.QueryString["page"] %>">学年信息</a></div>
        <div class="top_right2"><a href="XueQiList.aspx?page=<%=Request.QueryString["page"] %>">学期信息</a></div>
    </div>
    <div class="clear"></div>
    <div id="div_main">        
        <asp:HiddenField ID="HidMenuName" Value="学期管理" runat="server" />
        <div class="datagrid">
            <div class="datagrid-header2">
                <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="query">
        	                筛选条件：
                            <asp:DropDownList ID="ddlQuery" runat="server">
                                <asp:ListItem Value="C.SCHOOLNAME">所在学校</asp:ListItem>
                                <asp:ListItem Value="B.XNNAME">学年名称</asp:ListItem>
                                <asp:ListItem Value="A.XQNAME">学期名称</asp:ListItem>
                                <asp:ListItem Value="B.DJRYGH">登记人</asp:ListItem>
                            </asp:DropDownList>
        	                <input id="txtQuery" type="text" class="ddt-input ddt-input-l" style="width:150px" runat="server" />
                            <asp:Button ID="btnQuery" CssClass="form-btn" runat="server" Text="搜索" onclick="btnQuery_Click" />
                        </td>
                        <td class="operating">
                            <a href="#" class="btn btn-toolbar" onclick="GoAdd(<%=Pager.PageIndex.ToString() %>)" id="btnAdd" ><i class="icon icon-add"></i>添加</a>
                            <a href="#" class="btn btn-toolbar" onclick="GoEdit(<%=Pager.PageIndex.ToString() %>)" id="btnEdit" ><i class="icon icon-edit"></i>修改</a>
                            <a href="#" class="btn btn-toolbar" onclick="XueQiDel(<%=Pager.PageIndex.ToString() %>)" id="btnDel" ><i class="icon icon-delete"></i>删除</a>
                        </td>
                    </tr>
                </table>
                <div class="datagrid-head-line"></div>
                <table class="datagrid-head-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <th width="3%"><input id="selectAll" type="checkbox" /></th>
                        <th width="5%"><b>学期编号</b></th>
                        <th width="10%"><b>所在学校</b></th>
                        <th width="10%"><b>学年名称</b></th>
                        <th width="8%"><b>学期名称</b></th>
                        <th width="10%"><b>开始日期</b></th>
                        <th width="10%"><b>结束日期</b></th>
                        <th width="5%"><b>登记人</b></th>
                        <th width="5%"><b>是否可用</b></th>                     
                        <th width="5%"><b>排序</b></th>
                        <th width="12%"><b>修改时间</b></th>                    
                        <th width="12%"><b>登记时间</b></th>
                    </tr>
                </table>
            </div>
        
            <div class="datagrid-main">
                <table class="datagrid-main-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                  <asp:Repeater ID="rpt_xuenian" runat="server">
                    <ItemTemplate>
                    <tr>
                        <td width="3%"><input type="checkbox" name="selectThis" value="<%#Eval("LSH") %>" /></td>
                        <td width="5%"><%#Eval("XQNO") %>&nbsp;</td>
                        <td width="10%"><%#Eval("SCHOOLNAME") %>&nbsp;</td>
                        <td width="10%"><%#Eval("XNNAME")%>&nbsp;</td>
                        <td width="8%"><%#Eval("XQNAME")%>&nbsp;</td>
                        <td width="10%"><%#Eval("KSRQ").ToString().Split(' ')[0]%>&nbsp;</td>
                        <td width="10%"><%#Eval("JSRQ").ToString().Split(' ')[0]%>&nbsp;</td>
                        <td width="5%"><%#Eval("DJRYGH")%>&nbsp;</td>
                        <td width="5%">
                            <a href="XueQiList.aspx?st=<%#Eval("STATE")%>&lsh=<%#Eval("LSH") %>">
                                <%#Eval("STATE").ToString()=="0"?"可用":"不可用"%>&nbsp;
                            </a>
                        </td>
                        <td width="5%">
                            <a href="XueQiList.aspx?sort=<%#Eval("SORT")%>&lsh=<%#Eval("LSH")%>&sw=up">↑</a>
                            &nbsp;<%#Eval("SORT")%>&nbsp;
                            <a href="XueQiList.aspx?sort=<%#Eval("SORT")%>&lsh=<%#Eval("LSH")%>&sw=down">↓</a>
                        </td>
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
    </div>
</div>
</form>
</body>
</html>