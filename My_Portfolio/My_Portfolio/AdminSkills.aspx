<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminSkills.aspx.cs" Inherits="My_Portfolio.AdminSkills" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Manage Skills</title>
    <link href="css/adminskills.css" rel="stylesheet" />
    <link href="https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <h1>Manage Skills</h1>

        <asp:Button ID="btnBack" runat="server" Text="← Back to Admin Panel" CssClass="btn-home" OnClick="btnBack_Click" />

        <h2>Add New Skill</h2>
        <div class="form-group">
            <label>Category:</label>
            <asp:TextBox ID="txtCategory" runat="server" CssClass="input-field"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Skill Name:</label>
            <asp:TextBox ID="txtSkillName" runat="server" CssClass="input-field"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Icon Class:</label>
            <asp:TextBox ID="txtIcon" runat="server" CssClass="input-field" Placeholder="e.g., bx bx-code-alt"></asp:TextBox>
        </div>
        <asp:Button ID="btnAddSkill" runat="server" Text="Add Skill" CssClass="btn-save" OnClick="btnAddSkill_Click" />

        <h2>Existing Skills</h2>
        <asp:GridView ID="gvSkills" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvSkills_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Category" HeaderText="Category" />
                <asp:BoundField DataField="SkillName" HeaderText="Skill Name" />
                <asp:BoundField DataField="Icon" HeaderText="Icon Class" />
                <asp:CommandField ShowDeleteButton="True" DeleteText="Delete" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
