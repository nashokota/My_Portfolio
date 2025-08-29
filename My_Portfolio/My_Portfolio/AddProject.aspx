<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="My_Portfolio.AddProject" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Add New Project</title>
    <link href="css/addproject.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Add New Project</h1>

        <div>
            <label>Title:</label>
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Description:</label>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
        </div>
        <div>
            <label>Source Code URL:</label>
            <asp:TextBox ID="txtSourceCode" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnSave" runat="server" Text="Save Project" OnClick="btnSave_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
