/*
 for services
using System;
using System.Data;
using System.Data.SqlClient;

protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        BindServices();
    }
}

private void BindServices()
{
    string connStr = @"Server=YOUR_SERVER;Database=PortfolioDB;Trusted_Connection=True;";
    using (SqlConnection conn = new SqlConnection(connStr))
    {
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Services", conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        rptServices.DataSource = dt;
        rptServices.DataBind();
    }
}


for projects 
using System;
using System.Data;
using System.Data.SqlClient;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindProjects();
        }
    }

    private void BindProjects()
    {
        string connStr = @"Server=YOUR_SERVER;Database=PortfolioDB;Trusted_Connection=True;";
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
}


*/