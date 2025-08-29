using System;
using System.Data;
using System.Data.SqlClient;

namespace My_Portfolio
{
    public partial class Admin : System.Web.UI.Page
    {
        private string connStr = System.Configuration.ConfigurationManager
                          .ConnectionStrings["PortfolioDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAdmin"] == null)
                Response.Redirect("AdminLogin.aspx");

            if (!IsPostBack)
            {
                LoadProjects();
                LoadServices();
                LoadTestimonials();
            }
        }

        // --- LOAD METHODS ---
        private void LoadProjects()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Projects", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvProjects.DataSource = dt;
                gvProjects.DataBind();
            }
        }

        private void LoadServices()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Services", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvServices.DataSource = dt;
                gvServices.DataBind();
            }
        }

        private void LoadTestimonials()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Testimonials", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvTestimonials.DataSource = dt;
                gvTestimonials.DataBind();
            }
        }

        // --- LOGOUT ---
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["IsAdmin"] = null;
            Response.Redirect("AdminLogin.aspx");
        }

        // --- ADD NEW BUTTONS ---
        protected void btnAddProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProject.aspx");
        }

        protected void btnAddService_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddService.aspx");
        }

        protected void btnAddTestimonial_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTestimonial.aspx");
        }

        // --- PROJECTS GRIDVIEW EVENTS ---
        protected void gvProjects_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvProjects.EditIndex = e.NewEditIndex;
            LoadProjects();
        }

        protected void gvProjects_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvProjects.EditIndex = -1;
            LoadProjects();
        }

        protected void gvProjects_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            if (gvProjects.DataKeys.Count == 0) return;

            int projectId = Convert.ToInt32(gvProjects.DataKeys[e.RowIndex].Value);
            var row = gvProjects.Rows[e.RowIndex];

            string title = ((System.Web.UI.WebControls.TextBox)row.Cells[0].Controls[0]).Text;
            string description = ((System.Web.UI.WebControls.TextBox)row.Cells[1].Controls[0]).Text;
            string sourceCode = ((System.Web.UI.WebControls.TextBox)row.Cells[2].Controls[0]).Text;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE Projects SET Title=@Title, Description=@Description, SourceCode=@SourceCode WHERE ProjectID=@ProjectID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@SourceCode", sourceCode);
                    cmd.Parameters.AddWithValue("@ProjectID", projectId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            gvProjects.EditIndex = -1;
            LoadProjects();
        }

        protected void gvProjects_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            if (gvProjects.DataKeys.Count == 0) return;

            int projectId = Convert.ToInt32(gvProjects.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Projects WHERE ProjectID=@ProjectID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProjectID", projectId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            LoadProjects();
        }

        // --- SERVICES GRIDVIEW EVENTS ---
        protected void gvServices_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvServices.EditIndex = e.NewEditIndex;
            LoadServices();
        }

        protected void gvServices_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvServices.EditIndex = -1;
            LoadServices();
        }

        protected void gvServices_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            if (gvServices.DataKeys.Count == 0) return;

            int serviceId = Convert.ToInt32(gvServices.DataKeys[e.RowIndex].Value);
            var row = gvServices.Rows[e.RowIndex];

            string title = ((System.Web.UI.WebControls.TextBox)row.Cells[0].Controls[0]).Text;
            string description = ((System.Web.UI.WebControls.TextBox)row.Cells[1].Controls[0]).Text;
            string iconClass = ((System.Web.UI.WebControls.TextBox)row.Cells[2].Controls[0]).Text;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE Services SET Title=@Title, Description=@Description, IconClass=@IconClass WHERE ServiceID=@ServiceID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@IconClass", iconClass);
                    cmd.Parameters.AddWithValue("@ServiceID", serviceId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            gvServices.EditIndex = -1;
            LoadServices();
        }

        protected void gvServices_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            if (gvServices.DataKeys.Count == 0) return;

            int serviceId = Convert.ToInt32(gvServices.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Services WHERE ServiceID=@ServiceID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ServiceID", serviceId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            LoadServices();
        }

        // --- TESTIMONIALS GRIDVIEW EVENTS ---
        protected void gvTestimonials_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            gvTestimonials.EditIndex = e.NewEditIndex;
            LoadTestimonials();
        }

        protected void gvTestimonials_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            gvTestimonials.EditIndex = -1;
            LoadTestimonials();
        }

        protected void gvTestimonials_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            if (gvTestimonials.DataKeys.Count == 0) return;

            int testimonialId = Convert.ToInt32(gvTestimonials.DataKeys[e.RowIndex].Value);
            var row = gvTestimonials.Rows[e.RowIndex];

            string name = ((System.Web.UI.WebControls.TextBox)row.Cells[0].Controls[0]).Text;
            string feedback = ((System.Web.UI.WebControls.TextBox)row.Cells[1].Controls[0]).Text;
            int stars = Convert.ToInt32(((System.Web.UI.WebControls.TextBox)row.Cells[2].Controls[0]).Text);
            string imageUrl = ((System.Web.UI.WebControls.TextBox)row.Cells[3].Controls[0]).Text;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE Testimonials SET user_name=@Name, message=@Feedback, rating=@Stars, ImageUrl=@ImageUrl WHERE TestimonialID=@TestimonialID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Feedback", feedback);
                    cmd.Parameters.AddWithValue("@Stars", stars);
                    cmd.Parameters.AddWithValue("@ImageUrl", imageUrl);
                    cmd.Parameters.AddWithValue("@TestimonialID", testimonialId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            gvTestimonials.EditIndex = -1;
            LoadTestimonials();
        }

        protected void gvTestimonials_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            if (gvTestimonials.DataKeys.Count == 0) return;

            int testimonialId = Convert.ToInt32(gvTestimonials.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Testimonials WHERE TestimonialID=@TestimonialID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestimonialID", testimonialId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            LoadTestimonials();
        }
    }
}
