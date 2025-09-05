using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace My_Portfolio
{
    public partial class AdminSkills : System.Web.UI.Page
    {
        private string connStr = System.Configuration.ConfigurationManager
                          .ConnectionStrings["PortfolioDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsAdmin"] == null)
                Response.Redirect("AdminLogin.aspx");

            if (!IsPostBack)
                LoadSkills();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        private void LoadSkills()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = "SELECT * FROM Skills ORDER BY Category, SkillName";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvSkills.DataSource = dt;
                    gvSkills.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error loading skills: {ex.Message}');</script>");
            }
        }

        protected void btnAddSkill_Click(object sender, EventArgs e)
        {
            string category = txtCategory.Text.Trim();
            string skillName = txtSkillName.Text.Trim();
            string icon = txtIcon.Text.Trim();

            if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(skillName) || string.IsNullOrEmpty(icon))
            {
                Response.Write("<script>alert('All fields are required.');</script>");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = "INSERT INTO Skills (Category, SkillName, Icon) VALUES (@Category, @SkillName, @Icon)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Category", category);
                        cmd.Parameters.AddWithValue("@SkillName", skillName);
                        cmd.Parameters.AddWithValue("@Icon", icon);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                Response.Write("<script>alert('Skill added successfully!');</script>");
                txtCategory.Text = txtSkillName.Text = txtIcon.Text = "";
                LoadSkills();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

        protected void gvSkills_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int skillId = Convert.ToInt32(gvSkills.DataKeys[e.RowIndex].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = "DELETE FROM Skills WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", skillId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                Response.Write("<script>alert('Skill deleted successfully!');</script>");
                LoadSkills();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }
    }
}
