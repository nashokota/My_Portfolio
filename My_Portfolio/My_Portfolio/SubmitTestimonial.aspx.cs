using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace My_Portfolio
{
    public partial class SubmitTestimonial : System.Web.UI.Page
    {
        // MySQL database connection string from Web.config
        private string connStr = System.Configuration.ConfigurationManager
                          .ConnectionStrings["PortfolioDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string feedback = txtFeedback.Text;
            string stars = ddlStars.SelectedItem.Value;
            string photoPath = "";

            // Handle file upload
            if (fuPhoto.HasFile)
            {
                string fileName = Path.GetFileName(fuPhoto.FileName);
                photoPath = "images/testimonials/" + fileName; // save path in DB
                fuPhoto.SaveAs(Server.MapPath("~/image/testimonials/" + fileName));
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "INSERT INTO Testimonials (Name, Feedback, Stars, ImageUrl) VALUES (@Name, @Feedback, @Stars, @ImageUrl)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Feedback", feedback);
                cmd.Parameters.AddWithValue("@Stars", stars);
                cmd.Parameters.AddWithValue("@ImageUrl", photoPath);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            Response.Write("<script>alert('Thank you! Your testimonial has been submitted.'); window.location='Default.aspx';</script>");
            Response.Redirect("WebForm1.aspx");
        }
    }
}
