using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace My_Portfolio
{
    public partial class Admin : System.Web.UI.Page
    {
        // SQL Server connection string from Web.config
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

        // ================== LOAD METHODS ==================
        private void LoadProjects()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT ProjectID, Title, Description, SourceCode FROM Projects";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
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
                string query = "SELECT ServiceID, Title, Description, IconClass FROM Services";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
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
                string query = "SELECT TestimonialID, Name, Feedback, Stars, ImageUrl FROM Testimonials";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvTestimonials.DataSource = dt;
                gvTestimonials.DataBind();
            }
        }

        // ================== LOGOUT ==================
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["IsAdmin"] = null;
            Response.Redirect("admin_login.aspx");
        }

        // ================== ADD NEW ==================
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

        // ================== GRIDVIEW EVENTS ==================
        // ---------- PROJECTS ----------
        protected void gvProjects_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProjects.EditIndex = e.NewEditIndex;
            LoadProjects();
        }

        protected void gvProjects_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProjects.EditIndex = -1;
            LoadProjects();
        }

        protected void gvProjects_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (gvProjects.DataKeys == null || gvProjects.DataKeys.Count == 0) return;
            if (e.RowIndex < 0 || e.RowIndex >= gvProjects.DataKeys.Count) return;

            int projectId = Convert.ToInt32(gvProjects.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvProjects.Rows[e.RowIndex];

            string title = ((TextBox)row.Cells[0].Controls[0]).Text;
            string description = ((TextBox)row.Cells[1].Controls[0]).Text;
            string sourceCode = ((TextBox)row.Cells[2].Controls[0]).Text;

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
                }
            }

            gvProjects.EditIndex = -1;
            LoadProjects();
        }

        protected void gvProjects_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (gvProjects.DataKeys == null || gvProjects.DataKeys.Count == 0) return;
            if (e.RowIndex < 0 || e.RowIndex >= gvProjects.DataKeys.Count) return;

            int projectId = Convert.ToInt32(gvProjects.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Projects WHERE ProjectID=@ProjectID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProjectID", projectId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            LoadProjects();
        }

        // ---------- SERVICES ----------
        protected void gvServices_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvServices.EditIndex = e.NewEditIndex;
            LoadServices();
        }

        protected void gvServices_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvServices.EditIndex = -1;
            LoadServices();
        }

        protected void gvServices_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (gvServices.DataKeys == null || gvServices.DataKeys.Count == 0) return;
            if (e.RowIndex < 0 || e.RowIndex >= gvServices.DataKeys.Count) return;

            int serviceId = Convert.ToInt32(gvServices.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvServices.Rows[e.RowIndex];

            string title = ((TextBox)row.Cells[0].Controls[0]).Text;
            string description = ((TextBox)row.Cells[1].Controls[0]).Text;
            string iconClass = ((TextBox)row.Cells[2].Controls[0]).Text;

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
                }
            }

            gvServices.EditIndex = -1;
            LoadServices();
        }

        protected void gvServices_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (gvServices.DataKeys == null || gvServices.DataKeys.Count == 0) return;
            if (e.RowIndex < 0 || e.RowIndex >= gvServices.DataKeys.Count) return;

            int serviceId = Convert.ToInt32(gvServices.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Services WHERE ServiceID=@ServiceID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ServiceID", serviceId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            LoadServices();
        }

        // ---------- TESTIMONIALS ----------
        protected void gvTestimonials_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTestimonials.EditIndex = e.NewEditIndex;
            LoadTestimonials();
        }

        protected void gvTestimonials_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTestimonials.EditIndex = -1;
            LoadTestimonials();
        }

        protected void gvTestimonials_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (gvTestimonials.DataKeys == null || gvTestimonials.DataKeys.Count == 0) return;
            if (e.RowIndex < 0 || e.RowIndex >= gvTestimonials.DataKeys.Count) return;

            int testimonialId = Convert.ToInt32(gvTestimonials.DataKeys[e.RowIndex].Value);
            GridViewRow row = gvTestimonials.Rows[e.RowIndex];

            string name = ((TextBox)row.Cells[0].Controls[0]).Text;
            string feedback = ((TextBox)row.Cells[1].Controls[0]).Text;
            int stars = Convert.ToInt32(((TextBox)row.Cells[2].Controls[0]).Text);
            string imageUrl = ((TextBox)row.Cells[3].Controls[0]).Text;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE Testimonials SET Name=@Name, Feedback=@Feedback, Stars=@Stars, ImageUrl=@ImageUrl WHERE TestimonialID=@TestimonialID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Feedback", feedback);
                    cmd.Parameters.AddWithValue("@Stars", stars);
                    cmd.Parameters.AddWithValue("@ImageUrl", imageUrl);
                    cmd.Parameters.AddWithValue("@TestimonialID", testimonialId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            gvTestimonials.EditIndex = -1;
            LoadTestimonials();
        }

        protected void gvTestimonials_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (gvTestimonials.DataKeys == null || gvTestimonials.DataKeys.Count == 0) return;
            if (e.RowIndex < 0 || e.RowIndex >= gvTestimonials.DataKeys.Count) return;

            int testimonialId = Convert.ToInt32(gvTestimonials.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Testimonials WHERE TestimonialID=@TestimonialID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TestimonialID", testimonialId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            LoadTestimonials();
        }
    }
}
