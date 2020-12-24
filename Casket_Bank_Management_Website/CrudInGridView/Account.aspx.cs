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
    public partial class Account : System.Web.UI.Page
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Account", sqlCon);
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
                        string query = "INSERT INTO Account (Account_id,Balance,Acc_type,Branch_id,IFSC_code) VALUES (@Account_id,@Balance,@Acc_type,@Branch_id,@IFSC_code)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@Account_id", (gvPhoneBook.FooterRow.FindControl("txtAccount_idFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Balance", (gvPhoneBook.FooterRow.FindControl("txtBalanceFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Acc_type", (gvPhoneBook.FooterRow.FindControl("txtAcc_typeFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Branch_id", (gvPhoneBook.FooterRow.FindControl("txtBranch_idFooter") as TextBox).Text.Trim());

                        sqlCmd.Parameters.AddWithValue("@IFSC_code", (gvPhoneBook.FooterRow.FindControl("txtIFSC_codeFooter") as TextBox).Text.Trim());
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
                    string query = "UPDATE Account SET Account_id=@Account_id,Balance=@Balance,Acc_type=@Acc_type,Branch_id=@Branch_id,IFSC_code=@IFSC_code WHERE aid = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Account_id", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtAccount_id") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Balance", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtBalance") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Acc_type", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtAcc_type") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Branch_id", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtBranch_id") as TextBox).Text.Trim());

                    sqlCmd.Parameters.AddWithValue("@IFSC_code", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtIFSC_code") as TextBox).Text.Trim());

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
                    string query = "DELETE FROM Account WHERE aid = @id";
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