<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editArc.aspx.cs" Inherits="editArc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人资料</title>
    <link href="css/SiteStyle.css" type="text/css" rel="stylesheet">
</head>
<body style="text-align: center">
    <center>
        <form id="form1" runat="server">
            <table style="width: 100%" runat="server" enableviewstate="true">
                <tr style="background-color: #40984C">
                    <td style="width: 20%; height: 29px;">
                        个人资料</td>
                    <td align="right">
                        <input name="goback" onclick='javascript:history.back()' type="button" value="返 回" /></td>
                </tr>
                <tr>
                    <td style="width: 20%">
                        用户名</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" Width="90%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        性别</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TextBox2" runat="server" Width="90%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        手机</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TextBox4" runat="server" Width="90%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        备用邮箱</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TextBox5" runat="server" Width="90%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        住址</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TextBox6" runat="server" Width="90%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        QQ</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TextBox7" runat="server" Width="90%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        个人主页</td>
                    <td style="text-align: left">
                        <asp:TextBox ID="TextBox8" runat="server" Width="90%"></asp:TextBox></td>
                </tr>
            </table>
            <asp:Button ID="Button1" runat="server" Text="确  定" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="取  消" OnClick="Button2_Click" />
        </form>
    </center>
</body>
</html>
