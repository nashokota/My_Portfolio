using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace My_Portfolio
{
    public partial class Academics : System.Web.UI.Page
    {
        private string connStr = System.Configuration.ConfigurationManager
                                  .ConnectionStrings["PortfolioDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSkills();
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }

        private void LoadSkills()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT SkillName, Category FROM Skills ORDER BY Category, SkillName";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            // Group skills by category
            var groupedSkills = new List<dynamic>();
            foreach (DataRow row in dt.Rows)
            {
                string category = row["Category"].ToString();
                string skillName = row["SkillName"].ToString();

                // Check if category exists in the grouped list
                dynamic catGroup = groupedSkills.Find(x => x.Category == category);
                if (catGroup == null)
                {
                    groupedSkills.Add(new
                    {
                        Category = category,
                        Skills = new List<string> { skillName }
                    });
                }
                else
                {
                    catGroup.Skills.Add(skillName);
                }
            }

            rptSkills.DataSource = groupedSkills;
            rptSkills.DataBind();

            // Bind nested repeater for each category
            foreach (RepeaterItem item in rptSkills.Items)
            {
                Repeater rptCategorySkills = (Repeater)item.FindControl("rptCategorySkills");
                var dataItem = item.DataItem;
                if (dataItem != null)
                {
                    var skills = ((dynamic)dataItem).Skills;
                    rptCategorySkills.DataSource = skills;
                    rptCategorySkills.DataBind();
                }
            }
        }
    }
}
