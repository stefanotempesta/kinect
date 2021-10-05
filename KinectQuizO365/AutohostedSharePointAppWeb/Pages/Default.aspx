<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AutohostedSharePointAppWeb.Pages.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Open Quiz
        <asp:DropDownList ID="quizCollection" DataTextField="Title" DataValueField="Title" runat="server">
        </asp:DropDownList>
        <asp:Button ID="startQuiz" runat="server" Text="Open Quiz" PostBackUrl="~/Pages/Question.aspx" />
    </div>
    </form>
</body>
</html>
