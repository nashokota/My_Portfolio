<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSkills.aspx.cs" Inherits="My_Portfolio.AddSkills" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Add New Skill</title>
    <link href="css/skills.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h1>Add New Skill</h1>
            <hr />

            <!-- Skill Name -->
            <label for="txtSkillName">Skill Name:</label>
            <asp:TextBox ID="txtSkillName" runat="server" CssClass="form-control" />

            <!-- Proficiency -->
            <label for="txtProficiency">Proficiency (%):</label>
            <asp:TextBox ID="txtProficiency" runat="server" CssClass="form-control" />

            <!-- Buttons -->
            <div class="button-group">
                <asp:Button ID="btnSaveSkill" runat="server" Text="Save Skill" OnClick="btnSaveSkill_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />
            </div>

            <!-- Message -->
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
