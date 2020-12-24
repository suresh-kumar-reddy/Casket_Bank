using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace CrudInGridView
{
    public partial class cust_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=HARI2908\SQLEXPRESS;Initial Catalog=bankdomain;Integrated Security=True;Pooling=False"))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM Customer WHERE Cust_id=@username AND Account_id=@password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@username", txtUserName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    Session["Cust_id"] = txtUserName.Text.Trim();
                    Response.Redirect("cust_home.aspx");
                }

            }
        }
    }
}