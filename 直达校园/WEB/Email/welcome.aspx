<%@ Page Language="C#" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>欢迎页面</title>
    <link href="css/SiteStyle.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            欢迎回来，<%=User.Identity.Name%><br />
            <br />
            <br />
            <br />
            您有<%=new comClass().getValWithSQL("mails","count(id)","toUser='"+User.Identity.Name+"' and state=1 and sfcg=0")%>封未读邮件
            <br />
            <br />
            <br />
            <br />
            <br />
            邮件管理系统
        </div>
    </form>
</body>
</html>
