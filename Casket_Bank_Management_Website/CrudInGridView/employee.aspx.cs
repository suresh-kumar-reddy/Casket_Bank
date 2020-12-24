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
    public partial class employee : System.Web.UI.Page
    {
        string connectionString = @"Data Source=HARI2908\SQLEXPRESS;Initial Catalog=bankdomain;Integrated Security=True;Pooling=False";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("login.aspx");


            if (!IsPostBack)
            {
                PopulateGridview();
            }
        }

        void PopulateGridview()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Employee", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
                gvPhoneBook.Rows[0].Cells.Clear();
                gvPhoneBook.Rows[0].Cells.Add(new TableCell());
                gvPhoneBook.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvPhoneBook.Rows[0].Cells[0].Text = "No Data Found ..!";
                gvPhoneBook.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        protected void gvPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO Employee (Emp_id,Emp_name,Phone_no,Emp_exp,Branch_id,Salary,Designation) VALUES (@Emp_id,@Emp_name,@Phone_no,@Emp_exp,@Branch_id,@Salary,@Designation)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Emp_id", (gvPhoneBook.FooterRow.FindControl("txtEmp_idFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Emp_name", (gvPhoneBook.FooterRow.FindControl("txtEmp_nameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Phone_no", (gvPhoneBook.FooterRow.FindControl("txtPhone_noFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Emp_exp", (gvPhoneBook.FooterRow.FindControl("txtEmp_expFooter") as TextBox).Text.Trim());

                        sqlCmd.Parameters.AddWithValue("@Branch_id", (gvPhoneBook.FooterRow.FindControl("txtBranch_idFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Salary", (gvPhoneBook.FooterRow.FindControl("txtSalaryFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Designation", (gvPhoneBook.FooterRow.FindControl("txtDesignationFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        PopulateGridview();
                        lblSuccessMessage.Text = "New Record Added";
                        lblErrorMessage.Text = "";
                    }
                }
            }

            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPhoneBook.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void gvPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPhoneBook.EditIndex = -1;
            PopulateGridview();
        }

        protected void gvPhoneBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE Employee SET Emp_id=@Emp_id,Emp_name=@Emp_name,Phone_no=@Phone_no,Emp_exp=@Emp_exp,Branch_id=@Branch_id,Salary=@Salary,Designation=@Designation WHERE eid = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Emp_id", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtEmp_id") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Emp_name", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtEmp_name") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Phone_no", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtPhone_no") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Emp_exp", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtEmp_exp") as TextBox).Text.Trim());

                    sqlCmd.Parameters.AddWithValue("@Branch_id", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtBranch_id") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Salary", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtSalary") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Designation", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtDesignation") as TextBox).Text.Trim());

                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvPhoneBook.EditIndex = -1;
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Updated";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Employee WHERE eid = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";

                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");

        }
    }
}

