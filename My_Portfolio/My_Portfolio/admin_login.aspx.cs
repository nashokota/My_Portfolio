using System;
using System.Web.UI.WebControls;

namespace My_Portfolio
{
    public partial class admin_login : System.Web.UI.Page
    {
        //protected Label lblMessage;
        //protected TextBox txtUsername;
        //protected TextBox txtPassword;

        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Hardcoded login credentials
            if (username == "admin" && password == "12345")
            {
                // Save login in session
                Session["IsAdmin"] = true;
                Response.Redirect("Admin.aspx"); // Redirect to your admin page
            }
            else
            {
                lblMessage.Text = "Invalid username or password!";
            }
        }
        protected void btnPortfolio_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx"); // Redirect to your portfolio page
        }
    }
}
