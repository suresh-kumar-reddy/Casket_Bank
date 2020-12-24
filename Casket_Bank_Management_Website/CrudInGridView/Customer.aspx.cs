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
    public partial class Customer : System.Web.UI.Page
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Customer", sqlCon);
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
                        string query = "INSERT INTO Customer (Cust_id,Account_id,Cust_name,Cust_address,Phone_number,Email_id,Yearly_income) VALUES (@Cust_id,@Account_id,@Cust_name,@Cust_address,@Phone_number,@Email_id,@Yearly_income)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Cust_id", (gvPhoneBook.FooterRow.FindControl("txtCust_idFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Account_id", (gvPhoneBook.FooterRow.FindControl("txtAccount_idFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Cust_name", (gvPhoneBook.FooterRow.FindControl("txtCust_nameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Cust_address", (gvPhoneBook.FooterRow.FindControl("txtCust_addressFooter") as TextBox).Text.Trim());

                        sqlCmd.Parameters.AddWithValue("@Phone_number", (gvPhoneBook.FooterRow.FindControl("txtPhone_numberFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Email_id", (gvPhoneBook.FooterRow.FindControl("txtEmail_idFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Yearly_income", (gvPhoneBook.FooterRow.FindControl("txtYearly_incomeFooter") as TextBox).Text.Trim());

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
                    string query = "UPDATE Customer SET Cust_id=@Cust_id,Account_id=@Account_id,Cust_name=@Cust_name,Cust_address=@Cust_address,Phone_number=@Phone_number,Email_id=@Email_id,Yearly_income=@Yearly_income WHERE cid = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Cust_id", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtCust_id") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Account_id", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtAccount_id") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Cust_name", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtCust_name") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Cust_address", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtCust_address") as TextBox).Text.Trim());

                    sqlCmd.Parameters.AddWithValue("@Phone_number", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtPhone_number") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email_id", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtEmail_id") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Yearly_income", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtYearly_income") as TextBox).Text.Trim());

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
                    string query = "DELETE FROM Customer WHERE cid = @id";
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