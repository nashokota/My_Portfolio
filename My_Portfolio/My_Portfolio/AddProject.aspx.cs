using System;
using System.Data.SqlClient;

namespace My_Portfolio
{
    public partial class AddProject : System.Web.UI.Page
    {
        // SQL Server connection string from Web.config
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

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
            {
                Response.Write("<script>alert('Title and Description cannot be empty.');</script>");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = "INSERT INTO Projects (Title, Description, SourceCode) " +
                                   "VALUES (@Title, @Description, @SourceCode)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@SourceCode", sourceCode);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                Response.Write("<script>alert('Project added successfully!'); window.location='Admin.aspx';</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}
