<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddService.aspx.cs" Inherits="My_Portfolio.AddService" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Add New Service</title>
    <link href="css/addservice.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Add New Service</h1>

        <div>
            <label>Service Title:</label>
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        </div>

        <div>
            <label>Description:</label>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
        </div>

        <div>
            <label>Icon Class (for boxicons):</label>
            <asp:TextBox ID="txtIconClass" runat="server" Placeholder="bx bxl-html5"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="btnSave" runat="server" Text="Save Service" OnClick="btnSave_Click" />
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
