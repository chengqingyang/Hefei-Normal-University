<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addTxl.aspx.cs" Inherits="addTxl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新建联系人</title>
    <link href="css/sitestyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 167px;
            height: 40px;
        }
        .auto-style2 {
            width: 221px;
            height: 40px;
        }
        .auto-style3 {
            width: 190px;
            height: 40px;
        }
    </style>
</head>
<body >
    <center>
        <form id="form1" runat="server">
            <div >
                <h3>新建通讯录联系人</h3>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 634px;background-color:#42b6f1;">
                    <tr>
                        <td style="width: 167px; text-align: right">
                            用户名</td>
                        <td style="width: 221px; text-align: left">
                            <asp:TextBox ID="tb_user" runat="server" Width="100%"></asp:TextBox></td>
                        <td style="text-align: left; width: 190px;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                ControlToValidate="tb_user"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 167px; text-align: right">
                            密码</td>
                        <td style="width: 221px; text-align: left">
                            <asp:TextBox ID="tb_pw" runat="server" Width="100%" TextMode="Password"></asp:TextBox></td>
                        <td style="text-align: left; width: 190px;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                ControlToValidate="tb_pw"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="width: 167px; text-align: right">
                            再次输入密码</td>
                        <td style="width: 221px; text-align: left">
                            <asp:TextBox ID="tb_pw1" runat="server" Width="100%" TextMode="Password"></asp:TextBox></td>
                        <td style="text-align: left; width: 190px;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                ControlToValidate="tb_pw1"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td style="text-align: right" class="auto-style1">
                            性别</td>
                        <td style="text-align: left" class="auto-style2">
                            <asp:RadioButtonList ID="rbList_sex" runat="server" Height="3px" RepeatColumns="2"
                                RepeatLayout="Flow" Width="110px">
                                <asp:ListItem>男</asp:ListItem>
                                <asp:ListItem>女</asp:ListItem>
                            </asp:RadioButtonList></td>
                        <td style="text-align: left; " class="auto-style3">
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td style="width: 167px; text-align: right">
                            出生日期</td>
                        <td style="width: 221px; text-align: left">
                            <asp:TextBox ID="tb_age" runat="server" Width="100%"></asp:TextBox></td>
                        <td style="text-align: left; width: 190px;">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 167px; text-align: right">
                            手机</td>
                        <td style="width: 221px; text-align: left">
                            <asp:TextBox ID="tb_mp" runat="server" Width="100%"></asp:TextBox></td>
                        <td style="text-align: left; width: 190px;">
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td style="width: 167px; text-align: right">
                            邮箱</td>
                        <td style="width: 221px; text-align: left">
                            <asp:TextBox ID="tb_mail" runat="server" Width="100%"></asp:TextBox></td>
                        <td style="text-align: left; width: 190px;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ControlToValidate="tb_mail" Enabled="False"></asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                        <td colspan="3" width="100%">
                            <asp:Button ID="btn_submit" runat="server" Text="添 加" OnClick="btn_submit_Click" />
                            <input id="Reset1" type="reset" value="重  置" />
                        </td>
                      
                    </tr>
                    
                </table>
            </div>
        </form>
    </center>
</body>
</html>
