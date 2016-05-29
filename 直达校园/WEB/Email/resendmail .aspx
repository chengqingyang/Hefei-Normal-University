<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resendmail .aspx.cs" Inherits="resendmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发送邮件</title>
    <link href="css/SiteStyle.css" type="text/css" rel="stylesheet">
    <style type="text/css">
        .auto-style1 {
            width: 679px;
        }
        .auto-style2 {
            height: 17px;
            width: 679px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%">
            <div>
                <asp:Button ID="btn_send" runat="server" Text="发  送" OnClick="btn_send_Click" />
                <asp:Button ID="btn_cancle" runat="server" Text="取  消" CausesValidation="False" OnClick="btn_cancle_Click" />
              
            </div>
            <br style="line-height: 10px" />
            <div>
                <table style="width: 100%; border: none">
                    <tr>
                        <td style="width: 55px; border: none">
                            发给</td>
                        <td style="border: none" class="auto-style1">
                            <asp:TextBox ID="tb_to" runat="server" Width="40%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 55px; border: none; height: 17px;">
                            主题</td>
                        <td style="border-style: none; border-color: inherit; border-width: medium;" class="auto-style2">
                            <asp:TextBox ID="tb_sub" runat="server" Width="50%"></asp:TextBox>
                    </td>
                    </tr>
                    <tr>
                        
                        <td style="width: 55px; border: none; height: 17px;">
                            附件：
                        </td>
                        <td style="border: none;color:red;" class="auto-style1">
                        邮件重新发送，请重新选择附件，原附件位置： <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank"  ForeColor="Blue">HyperLink</asp:HyperLink> 不加载，默认没有附件。
                            <br />
                        <asp:FileUpload ID="FileUpload1" runat="server" Width="355px" />
                            </td>
                    </tr>
                    <tr>
                        <td style="width: 55px; border: none">
                            邮件正文
                        </td>
                        <td style="border: none" class="auto-style1">

                            <asp:TextBox ID="tb_con" runat="server" Width="80%" Height="350px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td style="width:300px;border-color:green; background-image:url(images/txl.jpg)">
                            <div style="margin-left:10px;margin-top:-160px; position:absolute; ">
                                <image src="images/txltp.jpg" style="margin-left:20px;" ></image>
                                <input  id=Image1 type="image" src="images/newsnxr.jpg"  style="margin-left:50px;" name="ibtnAdd" onserverclick="ibtnAdd_ServerClick"   runat="server"  />
                            </div>
                            <div style="margin-left:10px;margin-top:-120px; position:absolute;">
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true"   Width="155px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AppendDataBoundItems="True" >
                            <asp:ListItem>请选择通讯录</asp:ListItem>
                        </asp:DropDownList>
                            </div>

                        </td>
                    </tr>
                </table>


            </div>
        </div>
    </form>
</body>
</html>
