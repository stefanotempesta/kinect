<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="AutohostedSharePointAppWeb.Pages.Question" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="quizTitle" runat="server" Text=""></asp:Label>
        <hr />
        <asp:Repeater ID="questionList" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr>
                        <td><b>Title</b></td>
                        <td><b>Answer</b></td>
                        <td><b>Option 1</b></td>
                        <td><b>Option 2</b></td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# DataBinder.Eval(Container.DataItem, "Title") %></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Answer") %></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Option1") %></td>
                    <td><%# DataBinder.Eval(Container.DataItem, "Option2") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
