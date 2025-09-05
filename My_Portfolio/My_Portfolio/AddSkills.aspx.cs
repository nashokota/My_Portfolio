using System;
using System.Data.SqlClient;

namespace My_Portfolio
{
    public partial class AddSkills : System.Web.UI.Page
    {
        // Connection string from Web.config
        private string connStr = System.Configuration.ConfigurationManager
                                  .ConnectionStrings["PortfolioDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // ✅ Check session and cookie to ensure only admin can access
            if ((Session["IsAdmin"] == null || !(bool)Session["IsAdmin"]) &&
                (Request.Cookies["IsAdmin"] == null || Request.Cookies["IsAdmin"].Value != "true"))
            {
                Response.Redirect("admin_login.aspx");
            }
        }

        protected void btnSaveSkill_Click(object sender, EventArgs e)
        {
            string skillName = txtSkillName.Text.Trim();
            string proficiencyStr = txtProficiency.Text.Trim();

            if (string.IsNullOrEmpty(skillName) || string.IsNullOrEmpty(proficiencyStr))
            {
                lblMessage.Text = "⚠ Please fill in all fields.";
                return;
            }

            if (!int.TryParse(proficiencyStr, out int proficiency) || proficiency < 0 || proficiency > 100)
            {
                lblMessage.Text = "⚠ Proficiency must be a number between 0 and 100.";
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Skills (SkillName, Proficiency) VALUES (@SkillName, @Proficiency)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SkillName", skillName);
                    cmd.Parameters.AddWithValue("@Proficiency", proficiency);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "✅ Skill added successfully!";

                        // Clear form
                        txtSkillName.Text = "";
                        txtProficiency.Text = "";
                    }
                    catch (Exception ex)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "❌ Error: " + ex.Message;
                    }
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}
