<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KaoShiEdit.aspx.cs" Inherits="BaseSystem.Teacher_KaoShiEdit" %>

<%@ Register src="../Ascx/pager.ascx" tagname="pager" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
    <link id="skinlink" href="../skin/blue.css" rel="stylesheet" type="text/css" />

    <script src="../JS/jquery-1.8.0.min.js" type="text/javascript"></script>

    <script src="../JS/zii.cookie.js" type="text/javascript"></script>

    <script src="../JS/zii.common.js" type="text/javascript"></script>

    <script src="../JS/calendar.js" type="text/javascript"></script>

    <script src="../JS/Teachers/KaoShiEdit.js" type="text/javascript"></script>

</head>
<body>
    <form id="form2" runat="server">
    <asp:HiddenField ID="hidschool" runat="server" />
    <asp:HiddenField ID="hidlsh" runat="server" />
    <input type="hidden" id="hidtgh" value="<%=Session["username"].ToString() %>">
    <div class="datadetail">
        <div class="datagrid-header">
            <table class="datagrid-control-table" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="title">
                    </td>
                    <td class="operating" style="width:90%;">
                        <div runat="Server" id="save">
                            <a href="#" onclick="KaoShiSave()" class="btn btn-toolbar"><span class="icon icon-save">
                            </span>保存</a> 
                        </div>
                    </td>
                    <td>
                        <div runat="Server" id="back">
                        <a href="#" class="btn btn-toolbar" onclick="GoList(<%=Request.QueryString["page"] %>)">
                            <span class="icon icon-print"></span>返回</a>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="datagrid-head-line">
            </div>
        </div>
        <div class="datadetail-view">
            <table class="datadetail-table" width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <th>
                        <b>*</b>学年：
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlXueNian" CssClass="ddt-input ddt-input-l" 
                                 Width="208px" runat="server" AutoPostBack="true" 
                                onselectedindexchanged="ddlXueNian_SelectedIndexChanged"> </asp:DropDownList>
                    </td>
                    <th>
                        <b>*</b>学期：
                    </th>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlXueQi" CssClass="ddt-input ddt-input-l" 
                                 Width="208px" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>*</b>考试班级：
                    </th>
                    <td width="200px">
                        <asp:DropDownList ID="ddlClass"  Width="208px" runat="server" 
                             CssClass="ddt-input ddt-input-l" 
                            AutoPostBack="True" onselectedindexchanged="ddlClass_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <th>
                        <b>*</b>考试日期：
                    </th>
                    <td width="200px">
                        <input id="txtdate" style="width:100%" class="ddt-input ddt-input-l" maxlength="50"
                            type="text" runat="server" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btn_addTime" runat="server" onclick="btn_addTime_Click"
                                ImageUrl="~/images/date.png" Width="30" Height="30" AlternateText="插入日期"/>
                    </td>
                </tr>
                <tr>
                    <th>
                        <b>*</b>课程名称：
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlCourse" runat="server"  Width="208px"
                             CssClass="ddt-input ddt-input-l" >
                        </asp:DropDownList>
                    </td>
                    <th>
                        <b>*</b>教室：
                    </th>
                    <td colspan="2">
                        <input type="text" id="txtjs" class="ddt-input ddt-input-l" style="width: 200px"
                            runat="server" />
                    </td>
                </tr>
                <tr>
                    <th>
                        是否可见：
                    </th>
                    <td>
                        <asp:DropDownList ID="ddlVisible" runat="server" Width="208px"
                             CssClass="ddt-input ddt-input-l" >
                            <asp:ListItem Value="0">可见</asp:ListItem>
                            <asp:ListItem Value="1">不可见</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <th>
                        <b>*</b>开始座位号：
                    </th>
                    <td colspan="2">
                        <input id="txtzwh" style="width: 200px" class="ddt-input ddt-input-l" maxlength="20"
                            type="text" runat="server" />
                    </td>
                </tr>
                <tr>
                    <th>
                        考试类型：
                    </th>
                    <td>
                        <asp:DropDownList ID="ddltype" runat="server" Width="208px" CssClass="ddt-input ddt-input-l" >
                            <asp:ListItem>期末 闭卷</asp:ListItem>
                            <asp:ListItem>期末 开卷</asp:ListItem>
                            <asp:ListItem>期中 闭卷</asp:ListItem>
                            <asp:ListItem>期中 开卷</asp:ListItem>
                            <asp:ListItem>一般测试</asp:ListItem>                                
                            <asp:ListItem>月考</asp:ListItem>
                            <asp:ListItem>其他</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <th>备注：</th>
                    <td colspan="2" >
                        <input id="txtremark" style="width: 200px" class="ddt-input ddt-input-l" maxlength="100"
                            type="text" runat="server" />
                    </td>
                </tr>
                <tr><th colspan="5" style="height:20px;"></th></tr>
                <tr>
                <td colspan="5" style=" padding:5px 0 5px 5px;">
                    <div class="clear"></div>
                    <div runat="Server" id="div_result" class="zwh_result">
                        <div class=""><%--datagrid-main--%><%--datagrid-main-table--%>
                        <table class="" width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <th width="10%" style="text-align:center;">学号</th>
                                <th width="20%" style="text-align:center;">教室</th>
                                <th width="10%" style="text-align:center;">座位号</th>
                                <th width="20%" style="text-align:center;">备注</th>
                            </tr>
                            <asp:Repeater ID="rpt_test" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td width="10%" style="text-align:center;"><%#Eval("SNO")%></td>
                                        <td width="20%" style="text-align:center;"><%#Eval("JS")%></td>
                                        <td width="10%" style="text-align:center;"><%#Eval("ZWNO")%></td>
                                        <td width="20%" style="text-align:center;"><%#Eval("BZ")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table> 
                        </div>
                        <div class="datagrid-footer">
                            <uc1:pager ID="Pager" runat="server" />
                        </div>                    
                    </div>                        
                </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>