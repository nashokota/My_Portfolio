using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;

namespace My_Portfolio
{
    public partial class Default : System.Web.UI.Page
    {
        // Your database connection string (from Web.config)
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

        // Load services from database
        private void LoadServices()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM Services", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptServices.DataSource = dt;
                rptServices.DataBind();
            }
        }

        // Load projects from database
        private void LoadProjects()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Projects", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptProjects.DataSource = dt;
                rptProjects.DataBind();
            }
        }

        // Take viewer to a new page to give feedback
        protected void btnGiveFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubmitTestimonial.aspx");
        }

        // Load testimonials
        private void LoadTestimonials()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = "SELECT * FROM Testimonials ORDER BY TestimonialID DESC"; // latest first
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptTestimonials.DataSource = dt;
                rptTestimonials.DataBind();
            }
        }

        // CV download
        protected void btnDownloadCV_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath("~/files/CV.pdf"); // path to your CV file
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=CV.pdf");
            Response.TransmitFile(filePath);
            Response.End();
        }


        // About Read More
        protected void btnReadMore_Click_about(object sender, EventArgs e)
        {
            Response.Redirect("academics.aspx");
        }

        // Contact form submit
        protected void btnSend_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string subject = txtSubject.Text;
            string message = txtMessage.Text;

            // TODO: Save to DB or send email
            Response.Write($"<script>alert('Thank you {name}, your message has been sent.');</script>");
        }

        // Service read more
        protected void btnReadMoreService_Click(object sender, EventArgs e)
        {
            var btn = (System.Web.UI.WebControls.Button)sender;
            int serviceId = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect($"service-details.aspx?id={serviceId}");
        }
    }
}
