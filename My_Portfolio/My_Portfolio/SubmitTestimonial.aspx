<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitTestimonial.aspx.cs" Inherits="My_Portfolio.SubmitTestimonial" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>Submit Testimonial</title>
    <link href="css/testimonial.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>Submit Your Feedback</h2>

        <asp:TextBox ID="txtName" runat="server" CssClass="input" Placeholder="Your Name"></asp:TextBox>
        <asp:FileUpload ID="fuPhoto" runat="server" CssClass="input" />
        <asp:TextBox ID="txtFeedback" runat="server" CssClass="textarea" TextMode="MultiLine" Rows="5" Columns="30" Placeholder="Your Feedback"></asp:TextBox>
        <asp:DropDownList ID="ddlStars" runat="server" CssClass="input">
            <asp:ListItem Text="⭐" Value="1"></asp:ListItem>
            <asp:ListItem Text="⭐⭐" Value="2"></asp:ListItem>
            <asp:ListItem Text="⭐⭐⭐" Value="3"></asp:ListItem>
            <asp:ListItem Text="⭐⭐⭐⭐" Value="4"></asp:ListItem>
            <asp:ListItem Text="⭐⭐⭐⭐⭐" Value="5"></asp:ListItem>
        </asp:DropDownList>

        <asp:Button ID="btnSubmit" runat="server" Text="Submit Feedback" CssClass="btn" OnClick="btnSubmit_Click" />
    </form>
</body>
</html>
