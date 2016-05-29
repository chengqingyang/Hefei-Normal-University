<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>直达校园</title>
<style type="text/css">
<!--
.STYLE1 {
	font-size: 11pt;
	font-weight: bold;
}
.inputtext {border-left:1px solid balck;
border-right:1px solid balck;
border-top:1px solid balck;
border-bottom:1px solid balck;
}
body,td,th {
	font-size: 12px;
}
-->
</style>
</head>

<body style="background-image:url(images/admin_login_bg.gif); margin:0 auto; width:500px;">

    <form id="form1" runat="server">
    <div>
       
<table height="142" border="0" cellpadding="0" cellspacing="0" style="width: 59%" align="center" >
    <tr>
      <td width="42%" height="27">&nbsp;</td>
      <td width="58%">&nbsp;</td>
    </tr>
    <tr>
      <td height="115" colspan="2" valign="bottom"><div style="font-family:宋体; color:#FFFFFF; filter:Glow(Color=#000000,Strength=2); WIDTH: 100%; FONT-WEIGHT: bold; FONT-SIZE: 19pt; margin-top:5pt">
        <div align="center" class="STYLE5">直达校园-登录</div>
      </div></td>
    </tr>
  </table>
  <table height="195" border="0" cellpadding="0" cellspacing="0" background="images/s.gif" style="width: 500px" align="center" >
    <tr>
      <td width="42%" height="27">&nbsp;</td>
      <td width="58%">&nbsp;</td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td><table width="100%"  align="right" height="100%" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <td width="24%" height="30">用&nbsp;&nbsp;户:</td>
            <td width="76%" height="30"><span style="HEIGHT: 28px">&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="88px"></asp:TextBox></span></td>
          </tr>
          <tr>
            <td height="25">密&nbsp;&nbsp;码:</td>
            <td height="25"><span style="HEIGHT: 28px">&nbsp;<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"
                    Width="88px"></asp:TextBox></span></td>
          </tr>
          <tr>
            <td height="25">角&nbsp;&nbsp;色:</td>
            <td height="25"><span style="HEIGHT: 28px">&nbsp;<asp:DropDownList ID="cx" runat="server">
                </asp:DropDownList></span></td>
          </tr>
          <tr>
            <td height="25" colspan="2"><p align="center">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登陆" />
                &nbsp; &nbsp;
                <input id="Reset1" type="reset" value="重置" /></p></td>
          </tr>
        
      </table></td>
    </tr>
</table>

    
    </div>
    </form>
</body>
</html>
