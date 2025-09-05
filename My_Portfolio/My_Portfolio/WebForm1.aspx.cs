using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace My_Portfolio
{
    public partial class Default : System.Web.UI.Page
    {
        private string connStr = System.Configuration.ConfigurationManager
                          .ConnectionStrings["PortfolioDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadServices();
                LoadProjects();
                LoadTestimonials();
            }
        }

        private void LoadServices()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Services", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptServices.DataSource = dt;
                rptServices.DataBind();
            }
        }

        private void LoadProjects()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Projects", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptProjects.DataSource = dt;
                rptProjects.DataBind();
            }
        }

        protected void btnGiveFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubmitTestimonial.aspx");
        }

        private void LoadTestimonials()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Testimonials ORDER BY TestimonialID DESC"; 
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptTestimonials.DataSource = dt;
                rptTestimonials.DataBind();
            }
        }

        protected void btnDownloadCV_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath("~/files/CV.pdf"); 
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=CV.pdf");
            Response.TransmitFile(filePath);
            Response.End();
        }

        protected void btnReadMore_Click_about(object sender, EventArgs e)
        {
            Response.Redirect("academics.aspx");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string subject = txtSubject.Text.Trim();
            string message = txtMessage.Text.Trim();

            // Check if any field is empty
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(subject) ||
                string.IsNullOrEmpty(message))
            {
                Response.Write("<script>alert('Please fill in all the fields before submitting.');</script>");
                return; 
            }

            string connStr = System.Configuration.ConfigurationManager
                             .ConnectionStrings["PortfolioDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO ContactMessages (Name, Email, Phone, Subject, Message) " +
                               "VALUES (@Name, @Email, @Phone, @Subject, @Message)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Subject", subject);
                    cmd.Parameters.AddWithValue("@Message", message);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            Response.Write($"<script>alert('Thank you {name}, your message has been sent.');</script>");

            txtName.Text = txtEmail.Text = txtPhone.Text = txtSubject.Text = txtMessage.Text = "";
        }
    }
}
