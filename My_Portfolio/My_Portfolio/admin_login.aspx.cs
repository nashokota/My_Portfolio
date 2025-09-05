using System;

namespace My_Portfolio
{
    public partial class admin_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ✅ If already logged in via session or cookie, skip login page
            if ((Session["IsAdmin"] != null && (bool)Session["IsAdmin"]) ||
                (Request.Cookies["IsAdmin"] != null && Request.Cookies["IsAdmin"].Value == "true"))
            {
                Response.Redirect("Admin.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // ✅ Hardcoded login credentials
            if (username == "admin" && password == "12345")
            {
                // Save login in session
                Session["IsAdmin"] = true;

                // ✅ Session-based cookie (dies when browser closes)
                Response.Cookies["IsAdmin"].Value = "true";
                Response.Cookies["IsAdmin"].Expires = DateTime.MinValue; // no expiry → session cookie

                Response.Redirect("Admin.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid username or password!";
            }
        }

        protected void btnPortfolio_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx"); // redirect to portfolio page
        }
    }
}
