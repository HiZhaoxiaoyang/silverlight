﻿<%@ Page Language="c#" AutoEventWireup="true" %>

<%@ Register Assembly="System.Web.Silverlight" Namespace="System.Web.UI.SilverlightControls"
    TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" style="height:100%;">
<head runat="server">
    <title>PublicCalendar</title>
</head>
<body style="height:100%;margin:0;" scroll="no">
    <form id="form1" runat="server" style="height:100%;">
        <asp:ScriptManager ID="ScriptManager" runat="server" />
        <div  style="height:100%;">
            <asp:Silverlight ID="Xaml1" runat="server" Source="~/ClientBin/PublicCalendar.xap" MinimumVersion="2.0.31005.0" Width="100%" Height="100%" />
        </div>
    </form>
</body>
</html>