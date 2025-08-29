using System;
using MySql.Data.MySqlClient;   // ✅ Use MySQL namespace

namespace My_Portfolio
{
    public partial class AddService : System.Web.UI.Page
    {
        // ✅ Use your MySQL connection string from Web.config
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
            string iconClass = txtIconClass.Text.Trim();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "INSERT INTO Services (Title, Description, IconClass) " +
                               "VALUES (@Title, @Description, @IconClass)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@IconClass", iconClass);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            Response.Write("<script>alert('Service added successfully!');window.location='Admin.aspx';</script>");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}
