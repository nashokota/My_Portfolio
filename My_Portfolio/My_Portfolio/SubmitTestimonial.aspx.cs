using System;
using System.Data.SqlClient;
using System.IO;

namespace My_Portfolio
{
    public partial class SubmitTestimonial : System.Web.UI.Page
    {
        private string connStr = System.Configuration.ConfigurationManager
                          .ConnectionStrings["PortfolioDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string feedback = txtFeedback.Text.Trim();
            int stars = Convert.ToInt32(ddlStars.SelectedValue);
            string photoPath = null;

            // Handle file upload
            if (fuPhoto.HasFile)
            {
                string folder = Server.MapPath("~/image/testimonials/");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                string fileName = Path.GetFileName(fuPhoto.FileName);
                photoPath = "image/testimonials/" + fileName; // path to store in DB
                fuPhoto.SaveAs(Path.Combine(folder, fileName));
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = "INSERT INTO Testimonials (Name, Feedback, Stars, ImageUrl) " +
                                   "VALUES (@Name, @Feedback, @Stars, @ImageUrl)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Feedback", feedback);
                        cmd.Parameters.AddWithValue("@Stars", stars);
                        cmd.Parameters.AddWithValue("@ImageUrl", (object)photoPath ?? DBNull.Value);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                Response.Write("<script>alert('Thank you! Your testimonial has been submitted.'); window.location='WebForm1.aspx';</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }
    }
}
