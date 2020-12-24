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
    public partial class Loan : System.Web.UI.Page
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Loan", sqlCon);
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
                        string query = "INSERT INTO Loan (Loan_number,Cust_id,Loan_amount,Loan_type,Loan_period,Loan_bal,Loan_status) VALUES (@Loan_number,@Cust_id,@Loan_amount,@Loan_type,@Loan_period,@Loan_bal,@Loan_status)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Loan_number", (gvPhoneBook.FooterRow.FindControl("txtLoan_numberFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Cust_id", (gvPhoneBook.FooterRow.FindControl("txtCust_idFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Loan_amount", (gvPhoneBook.FooterRow.FindControl("txtLoan_amountFooter") as TextBox).Text.Trim());

                        sqlCmd.Parameters.AddWithValue("@Loan_type", (gvPhoneBook.FooterRow.FindControl("txtLoan_typeFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Loan_period", (gvPhoneBook.FooterRow.FindControl("txtLoan_periodFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Loan_bal", (gvPhoneBook.FooterRow.FindControl("txtLoan_balFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Loan_status", (gvPhoneBook.FooterRow.FindControl("txtLoan_statusFooter") as TextBox).Text.Trim());

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
                    string query = "UPDATE Loan SET Loan_number=@Loan_number,Cust_id=@Cust_id,Loan_amount=@Loan_amount,Loan_type=@Loan_type,Loan_period=@Loan_period,Loan_bal=@Loan_bal,Loan_status=@Loan_status WHERE lid = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Loan_number", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtLoan_number") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Cust_id", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtCust_id") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Loan_amount", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtLoan_amount") as TextBox).Text.Trim());

                    sqlCmd.Parameters.AddWithValue("@Loan_type", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtLoan_type") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Loan_period", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtLoan_period") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Loan_bal", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtLoan_bal") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Loan_status", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtLoan_status") as TextBox).Text.Trim());

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
                    string query = "DELETE FROM Loan WHERE lid = @id";
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