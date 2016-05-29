<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="mail"
    EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>我的邮箱</title>
    <link href="css/sitestyle.css" rel="stylesheet" type="text/css" />
</head>
<frameset rows="50,*" cols="*" frameborder="no" border="0" framespacing="0">
    <frame src="top.html" name="topFrame" scrolling="No" noresize="noresize" id="topFrame"
        title="topFrame" />
    <frameset cols="150,*" frameborder="no" border="0" framespacing="0">
        <frame src="left.html" name="leftFrame" scrolling="No" noresize="noresize" id="leftFrame"
            title="leftFrame" />
        <frame src="welcome.aspx" name="mainFrame" id="mainFrame" title="mainFrame" />
    </frameset>
    <noframes>
        <body>
        </body>
    </noframes>
</frameset>
</html>
