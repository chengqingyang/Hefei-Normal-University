<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>邮件管理系统系统登录</title>
    <STYLE type=text/css>BODY {
	PADDING-RIGHT: 0px; PADDING-LEFT: 0px; FONT-SIZE: 14px; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-TOP: 0px; FONT-FAMILY: Arial, Helvetica, sans-serif; BACKGROUND-COLOR: #7893ae
}
.bg {
	BACKGROUND: url(Images/login_bg.jpg) #7893ae repeat-x left top; OVERFLOW: hidden; HEIGHT: 600px
}
#ckbAuCode {
	BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none
}
#lbtnAuCode {
	TEXT-DECORATION: none
}
.mid_bg {
	BACKGROUND: url(Images/midd_bg.gif) no-repeat; MARGIN:50px auto 0px; WIDTH: 541px; POSITION: relative; HEIGHT: 535px
}
.login {
	LEFT: 150px; POSITION: absolute; TOP: 100px
}
.login INPUT {
	BORDER-RIGHT: #000 1px solid; BORDER-TOP: #000 1px solid; BORDER-LEFT: #000 1px solid; COLOR: #888; BORDER-BOTTOM: #000 1px solid; FONT-FAMILY: Verdana
}
.login_btn {
	BACKGROUND: url(Images/login_btn.gif) no-repeat; MARGIN: 8px 0px 0px 50px; WIDTH: 94px; CURSOR: pointer; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 29px; BORDER-BOTTOM-STYLE: none
}
#lbtnDesktop {
	FLOAT: left; COLOR: white; HEIGHT: 12px
}
        .auto-style1 {
            width: 53px;
        }
        .auto-style2 {
            height: 62px;
            width: 53px;
        }
        .auto-style3 {
            width: 53px;
            height: 26px;
        }
        .auto-style4 {
            height: 26px;
        }
        .auto-style5 {
            height: 34px;
            width: 85px;
        }
    </STYLE>
</head>
<body>
    <form id="form1" runat="server">
<DIV class=bg>
<DIV class=mid_bg style="left: 0px; top: 0px">
<DIV class=login>
<TABLE cellSpacing=0 cellPadding=3 width=270 border=0 style="height: 115px; margin-top:0px;">
  <TBODY>
  <TR id=userTR>
    <TD style="TEXT-ALIGN: right" class="auto-style1">用户名:</TD>
    <TD>
        <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox></TD></TR>

  <TR id=pwdTR >
    <TD style="TEXT-ALIGN: right" class="auto-style3">密&nbsp;&nbsp;&nbsp;&nbsp;码:</TD>
    <TD class="auto-style4">
        <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox></TD></TR>
        
  
  <TR>
    <TD class="auto-style2"  >
      <TABLE>
        <TBODY>
        <TR>
          <TD class="auto-style5">
              <INPUT id=ibtnLogin 
            style="border-width: 0px; width: 85px;" 
           type=image 
            src="Images/login_btn.gif" name=ibtnLogin onserverclick="ibtnLogin_ServerClick" runat="server">

          </TD>
        </TR>

        </TBODY></TABLE></TD>

      <td>
              <INPUT id=Image1 
            style="border-width: 0px; margin-left: 40px;" 
           type=image 
            src="Images/chongzhi.gif" name=ibtnCancel onserverclick="ibtnCancel_ServerClick" runat="server">
      </td>
  </TR></TBODY>
</TABLE>
        <div><a href="userReg.aspx">用户注册</a></div>
</DIV>

</DIV></DIV>

</FORM>
</body>
</html>

