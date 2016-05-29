<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XskqList.aspx.cs" Inherits="BaseSystem.Users_UserList" %>

<%@ Register src="../Ascx/pager.ascx" tagname="pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>学生考勤管理</title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link id="skinlink" href="../skin/blue.css" rel="stylesheet" type="text/css" />
     <script src="../JS/calendar.js" type="text/javascript"></script>
    <script src="../JS/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../JS/zii.cookie.js" type="text/javascript"></script>
    <script src="../JS/zii.common.js" type="text/javascript"></script>
    
    <script src="../JS/Users/User.js" type="text/javascript"></script>
    <!-- 设置控件不可编辑-->
    <script type="text/javascript">
            $(document).ready( function(){
            
                 $(".SFBJ").attr("disabled",'false');//实现展示不可编辑
                 $('input:checkbox').live('click',function(){
                 $('input:checkbox').not(this).attr('checked',!$(this).attr('checked'));
                 });
            
            });


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="datagrid">

    
            <div class="datagrid-header">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="query">
        	            学生姓名：<input id="sname" type="text" class="ddt-input ddt-input-l" style="width:100px" runat="server" />
        	            学生学号：<input id="sno" type="text" class="ddt-input ddt-input-l" style="width:100px" runat="server" />
        	            考勤日期：
                    <input id="BeginDate" type="text" style="width:100px" runat="server" onclick="calendar(this)"/>
                    至
                    <input id="EndDate" type="text" style="width:100px" runat="server" onclick="calendar(this)"/>
                        <asp:Button ID="btnQuery" CssClass="form-btn" runat="server" Text="搜索" onclick="btnQuery_Click" />
                    </td>
                    <td class="operating">
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line"></div>
            <table class="datagrid-head-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th width="5%"><input id="selectAll" type="checkbox" /></th>
                    <th width="10%"><b>学号</b></th>
                    <th width="10%"><b>姓名</b></th>
                    <th width="10%"><b>出勤</b></th>
                    <th width="10%"><b>旷课</b></th>
                    <th width="10%"><b>事假</b></th>
                    <th width="10%"><b>病假</b></th>
                    <th width="10%"><b>登记人员</b></th>
                    <th width="12%"><b>登记日期</b></th>
                    <th width="15%"><b>操作</b></th>
                </tr>
            </table>
             </div>
        
        <div class="datagrid-main">
            <table class="datagrid-main-table" width="100%" border="0" cellpadding="0" cellspacing="0">
              <asp:Repeater ID="rpt_user" runat="server"  onitemcommand="rptUser_ItemCommand" 
        onitemdatabound="rptUser_ItemDataBound">
                <ItemTemplate>
                <asp:Panel ID="plItem" runat="server">
                <tr>
                    <td width="5%"><input type="checkbox" name="selectThis" value="<%#Eval("LSH") %>" /></td>
                    <td width="10%"><%#Eval("SNO")%>&nbsp;</td>
                    <td width="10%"><%#Eval("SNAME")%>&nbsp;</td>
                    <td width="10%" class="SFBJ"><asp:CheckBox  runat="server" Checked=<%#Eval("CQ").ToString().Trim() == "1" ? true : false %> />&nbsp;</td>
                    <td width="10%" class="SFBJ"><asp:CheckBox  runat="server" Checked=<%#Eval("KK").ToString().Trim() == "1" ? true : false %>/>&nbsp;</td>
                    <td width="10%" class="SFBJ"><asp:CheckBox  runat="server" Checked=<%#Eval("SJ").ToString().Trim() == "1" ? true : false %>/>&nbsp;</td>
                    <td width="10%" class="SFBJ"><asp:CheckBox  runat="server" Checked=<%#Eval("BJ").ToString().Trim() == "1" ? true : false %>/>&nbsp;</td>
                    <td width="10%"><%#Eval("DJRYXM")%>&nbsp;</td>
                    <td width="12%"><%#Eval("DJRQ")%>&nbsp;</td>
                    <td width="15%"> <asp:LinkButton runat="server" ID="lbtEdit"  CommandArgument='<%#Eval("LSH") %>'
                     CommandName="Edit" Text="考勤"></asp:LinkButton>&nbsp;&nbsp;
                       <asp:LinkButton runat="server" ID="lbtdel" CommandArgument='<%#Eval("LSH") %>'
                     CommandName="Delete" Text="删除" OnClientClick="return confirm('确定删除吗？')"></asp:LinkButton>
                    </td>
                </tr>
                </asp:Panel>
                <asp:Panel ID="plEdit" runat="server">
                <tr >
                    <td width="5%"><input type="checkbox" name="selectThis" value="<%#Eval("LSH") %>" /></td>
                    <td width="10%"><%#Eval("SNO")%>&nbsp;</td>
                    <td width="10%"><%#Eval("SNAME")%>&nbsp;</td>
                    <td width="10%"><asp:CheckBox ID="CheckBox1"  runat="server" Checked=<%#Eval("CQ").ToString().Trim() == "1" ? true : false %>/>&nbsp;</td>
                    <td width="10%"><asp:CheckBox ID="CheckBox2"  runat="server" Checked=<%#Eval("KK").ToString().Trim() == "1" ? true : false %>/>&nbsp;</td>
                    <td width="10%"><asp:CheckBox ID="CheckBox3"  runat="server" Checked=<%#Eval("SJ").ToString().Trim() == "1" ? true : false %>/>&nbsp;</td>
                    <td width="10%"><asp:CheckBox ID="CheckBox4"  runat="server" Checked=<%#Eval("BJ").ToString().Trim() == "1" ? true : false %>/>&nbsp;</td>
                    <td width="10%"><%#Eval("DJRYXM")%>&nbsp;</td>
                    <td width="12%"> <%#Eval("DJRQ") %></td>
                    <td width="15%">
                      <asp:LinkButton runat="server" ID="lbtUpdate" CommandArgument='<%#Eval("LSH") %>'
                     CommandName="Update" Text="保存"></asp:LinkButton>&nbsp;&nbsp;
                    <asp:LinkButton runat="server" ID="lbtCancel" CommandArgument='<%#Eval("LSH") %>'
                     CommandName="Cancel" Text="取消"></asp:LinkButton>
                    </td>
                </tr>
            </asp:Panel>
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
