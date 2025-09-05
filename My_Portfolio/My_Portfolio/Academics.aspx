<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Academics.aspx.cs" Inherits="My_Portfolio.Academics" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <title>My Academics & Skills</title>
    <link href="css/academics.css" rel="stylesheet" />
    <!-- Boxicons for skill icons -->
    <link href="https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <!-- Top navigation -->
        <div class="top-nav">
            <asp:Button ID="btnHome" runat="server" Text="← Back to Home" CssClass="btn-home" OnClick="btnHome_Click" />
        </div>

        <div class="academics-container">
            <h1>My Academics & Skills</h1>

            <!-- Academic Records -->
            <section class="academics">
                <h2>Academic Background</h2>
                <ul>
                    <li><strong>PEC:</strong> GPA 5.00</li>
                    <li><strong>JSC:</strong> GPA 5.00</li>
                    <li><strong>SSC:</strong> GPA 5.00 (Ideal School and College)</li>
                    <li><strong>HSC:</strong> GPA 5.00 (Notre Dame College)</li>
                    <li><strong>B.Sc:</strong> 3rd Year, 1st Semester in Computer Science & Engineering, KUET</li>
                </ul>
            </section>

            <!-- Skills -->
            <section class="skills">
                <h2>Skills</h2>

                <asp:Repeater ID="rptSkills" runat="server">
                    <ItemTemplate>
                        <div class="skill-category">
                            <h3><%# Eval("Category") %></h3>
                            <ul>
                                <asp:Repeater ID="rptCategorySkills" runat="server" DataSource='<%# Eval("Skills") %>'>
                                    <ItemTemplate>
                                        <li><i class='bx bx-code-alt'></i> <%# Container.DataItem %></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </section>
        </div>
    </form>
</body>
</html>
