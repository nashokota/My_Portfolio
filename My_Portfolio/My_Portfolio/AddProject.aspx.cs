using System;
using MySql.Data.MySqlClient;   // ✅ Use MySQL namespace

namespace My_Portfolio
{
    public partial class AddProject : System.Web.UI.Page
    {
        // ✅ Replace with your own MySQL connection string
        // Example for XAMPP (local MySQL, root user, no password, DB = PortfolioDB)
        private string connStr = System.Configuration.ConfigurationManager
                          .ConnectionStrings["PortfolioDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAdmin"] == null)
                Response.Redirect("AdminLogin.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            string sourceCode = txtSourceCode.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "INSERT INTO Projects (Title, Description, LiveDemo, SourceCode) " +
                               "VALUES (@Title, @Description, @LiveDemo, @SourceCode)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@SourceCode", sourceCode);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            Response.Write("<script>alert('Project added successfully!');window.location='Admin.aspx';</script>");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}
