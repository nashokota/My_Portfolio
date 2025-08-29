<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="My_Portfolio.Admin" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Admin Panel</title>
    <link href="css/admin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Admin Panel</h1>

        <!-- LOGOUT BUTTON -->
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />

        <hr />

        <!-- PROJECTS SECTION -->
        <h2>Projects</h2>
        <asp:GridView ID="gvProjects" runat="server" AutoGenerateColumns="False" DataKeyNames="ProjectID"
            OnRowEditing="gvProjects_RowEditing"
            OnRowCancelingEdit="gvProjects_RowCancelingEdit"
            OnRowUpdating="gvProjects_RowUpdating"
            OnRowDeleting="gvProjects_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="LiveDemo" HeaderText="Live Demo URL" />
                <asp:BoundField DataField="SourceCode" HeaderText="Source Code URL" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnAddProject" runat="server" Text="Add New Project" OnClick="btnAddProject_Click" />

        <hr />

        <!-- SERVICES SECTION -->
        <h2>Services</h2>
        <asp:GridView ID="gvServices" runat="server" AutoGenerateColumns="False" DataKeyNames="ServiceID"
            OnRowEditing="gvProjects_RowEditing"
            OnRowCancelingEdit="gvProjects_RowCancelingEdit"
            OnRowUpdating="gvProjects_RowUpdating"
            OnRowDeleting="gvProjects_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Title" HeaderText="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="IconClass" HeaderText="Icon Class" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnAddService" runat="server" Text="Add New Service" OnClick="btnAddService_Click" />

        <hr />

        <!-- TESTIMONIALS SECTION -->
        <h2>Testimonials</h2>
        <asp:GridView ID="gvTestimonials" runat="server" AutoGenerateColumns="False" DataKeyNames="TestimonialID"
            OnRowEditing="gvProjects_RowEditing"
            OnRowCancelingEdit="gvProjects_RowCancelingEdit"
            OnRowUpdating="gvProjects_RowUpdating"
            OnRowDeleting="gvProjects_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Feedback" HeaderText="Feedback" />
                <asp:BoundField DataField="Stars" HeaderText="Stars" />
                <asp:BoundField DataField="ImageUrl" HeaderText="Image URL" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnAddTestimonial" runat="server" Text="Add New Testimonial" OnClick="btnAddTestimonial_Click" />
    </form>
</body>
</html>
