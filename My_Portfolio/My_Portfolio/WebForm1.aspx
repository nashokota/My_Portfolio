<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="My_Portfolio.Default" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Portfolio</title>
    <link href="css/style.css" rel="stylesheet" />
    <link href="https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css" rel="stylesheet" />
</head>
<body>
    <!-- ASP.NET requires server-side form -->
    <form id="form1" runat="server">

        <!-- ✅ HEADER -->
        <header class="header">
            <a href="#home" class="logo">AL - Mubtasim Preom</a>
            <i class='bx bx-menu' id="menu-icon"></i>
            <nav class="navbar">
                <a href="#home">Home</a>
                <a href="#about">About</a>
                <a href="#services">Services</a>
                <a href="#projects">Projects</a>
                <a href="#testimonial">Testimonial</a>
                <a href="#contact">Contact</a>
            </nav>
        </header>

        <!-- ✅ HOME SECTION -->
        <section class="home" id="home">
            <div class="home-img">
                <img src="image/Al_Mubtasim_Preom-removebg-preview.png" alt="Home Image" />
            </div>
            <div class="home-content">
                <h3>Hello , Myself</h3>
                <h1>AL - Mubtasim Preom</h1>
                <h3>And I'm a <span class="multiple-text"></span></h3>
                <div class="social-media">
                    <a href="https://www.facebook.com/preom27" target="_blank"><i class='bx bxl-facebook'></i></a>
                    <a href="https://www.instagram.com/oxy_cod_one/" target="_blank"><i class='bx bxl-instagram'></i></a>
                    <a href="https://www.linkedin.com/in/mubtasim-preom-220273315/" target="_blank"><i class='bx bxl-linkedin'></i></a>
                    <a href="https://github.com/nashokota" target="_blank"><i class='bx bxl-github'></i></a>
                </div>
                <asp:Button ID="btnDownloadCV" runat="server" Text="Download CV" CssClass="btn" OnClick="btnDownloadCV_Click" />
            </div>
        </section>

        <!-- ✅ ABOUT SECTION -->
        <section class="about" id="about">
            <div class="about-content">
                <h2 class="heading">About <span>Me</span></h2>
                <p>I am a 3rd-year Computer Science and Engineering student at Khulna University of Engineering & Technology (KUET), passionate about problem-solving, software development, and emerging technologies. My academic journey has strengthened my foundation in algorithms, data structures, database systems, and software engineering, while also giving me hands-on experience with programming in C, C++, Java, and Python.</p>
                <asp:Button ID="btnReadMore" runat="server" Text="Read More" CssClass="btn" OnClick="btnReadMore_Click_about" />
            </div>
            <div class="about-img">
                <img src="image/aboutsection.jpeg" alt="About Image" />
            </div>
        </section>

        <!-- ✅ SERVICES SECTION -->
        <section class="services" id="services">
            <h2 class="heading">My <span>Services</span></h2>
            <div class="service-container">
                <asp:Repeater ID="rptServices" runat="server">
                    <ItemTemplate>
                        <div class="service-box">
                            <i class='bx <%# Eval("IconClass") %>'></i>
                            <h3><%# Eval("Title") %></h3>
                            <p><%# Eval("Description") %></p>
                            <asp:Button ID="btnReadMoreService" runat="server" 
                                Text="Read More" CssClass="btn"
                                CommandArgument='<%# Eval("ServiceID") %>'
                                OnClick="btnReadMoreService_Click" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>


      <!-- PROJECTS SECTION -->
        <section class="projects" id="projects">
            <h2 class="heading">My <span>Projects</span></h2><br />
            <div class="projects-container">
                <asp:Repeater ID="rptProjects" runat="server">
                    <ItemTemplate>
                        <div class="project-card">
                            <h3 class="project-title"><%# Eval("Title") %></h3>
                            <p class="project-desc"><%# Eval("Description") %></p>
                            <div class="project-links">
                                <a href='<%# Eval("SourceCode") %>' target="_blank">Source Code</a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>


        <!-- ✅ TESTIMONIAL -->
        <section class="testimonial" id="testimonial">
            <div class="testimonial-container">
                <h2 class="heading">What <span>People Say</span></h2>
                <div class="wrapper">
                    <asp:Repeater ID="rptTestimonials" runat="server">
                        <ItemTemplate>
                            <div class="testimonial-item">
                                <img src='<%# Eval("ImageUrl") %>' alt="" />
                                <h2><%# Eval("Name") %></h2>
                                <div class="rating">
                                    <%#  new string('⭐', Convert.ToInt32(Eval("Stars"))) %>
                                </div>
                                <p><%# Eval("Feedback") %></p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <asp:Button ID="btnGiveFeedback" runat="server" CssClass="btn" Text="Give Feedback" OnClick="btnGiveFeedback_Click" />
            </div>
        </section>

        <!-- ✅ CONTACT FORM -->
        <section class="contact" id="contact">
    <h2 class="heading">Contact <span>Me</span></h2>

    <div class="input-box">
        <asp:TextBox ID="txtName" runat="server" CssClass="input" Placeholder="Full Name"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
            ErrorMessage="* Name is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

        <asp:TextBox ID="txtEmail" runat="server" CssClass="input" TextMode="Email" Placeholder="Your Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="* Email is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>

    <div class="input-box">
        <asp:TextBox ID="txtPhone" runat="server" CssClass="input" Placeholder="Phone Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
            ErrorMessage="* Phone is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

        <asp:TextBox ID="txtSubject" runat="server" CssClass="input" Placeholder="Subject"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject"
            ErrorMessage="* Subject is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
    </div>

    <asp:TextBox ID="txtMessage" runat="server" CssClass="textarea" TextMode="MultiLine" Rows="6" Columns="30" Placeholder="Your Message"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtMessage"
        ErrorMessage="* Message is required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>

    <asp:Button ID="btnSend" runat="server" Text="Send Message" CssClass="btn" OnClick="btnSend_Click" />
</section>


        <!-- ✅ FOOTER -->
        <footer class="footer">
            <div class="social">
                <a href="#"><i class='bx bxl-facebook'></i></a>
                <a href="#"><i class='bx bxl-instagram'></i></a>
                <a href="#"><i class='bx bxl-linkedin'></i></a>
                <a href="#"><i class="bx bxl-github"></i></a>
            </div>
            <p class="copyright">
                &copy; 2023 All Rights Reserved.<br />
                Designed by - <a href="#">AL - Mubtasim Preom</a>
            </p>
        </footer>

        <!-- JS -->
        <script src="https://unpkg.com/typed.js@2.1.0/dist/typed.umd.js"></script>
        <script src="js/main.js"></script>
        <script src="js/script.js"></script>
        <script src="js/contact.js"></script>
        </form>
</body>
</html>
