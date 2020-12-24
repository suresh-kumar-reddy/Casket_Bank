<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loan.aspx.cs" Inherits="CrudInGridView.Loan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

       <style>
                a {
        text-decoration: none;
      }

      a{
        text-decoration:none;
        color:white;
      }

      a:hover {
        color: white;
        border-bottom: 1px solid #000099;
      }
            body
        {
            background-image:url('bg.jpg');
        }</style>


</head>
<body style="border:2px solid white;"> 
    <form id="form1" runat="server">
      <div class="container-fluid" style="border:2px solid white; padding:5px;"><br />
     <center><h2 style="color:white;">CASKET BANK</h2>
            </center> <div align="right"><a href="home.aspx">Back</a>&nbsp;&nbsp;<asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" Height="37px" Width="97px" />
            </div>
            <hr color="white"/>
          <center>
            <h2 style="color:white;">Loan Details</h2>
            
            <asp:GridView ID="gvPhoneBook" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="lid"
                ShowHeaderWhenEmpty="true"

                OnRowCommand="gvPhoneBook_RowCommand" OnRowEditing="gvPhoneBook_RowEditing" OnRowCancelingEdit="gvPhoneBook_RowCancelingEdit"
                OnRowUpdating="gvPhoneBook_RowUpdating" OnRowDeleting="gvPhoneBook_RowDeleting"

                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <%-- Theme Properties --%>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                
                <Columns>
                    <asp:TemplateField HeaderText="Loan ID">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Loan_number") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLoan_number" Text='<%# Eval("Loan_number") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtLoan_numberFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer ID">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Cust_id") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCust_id" Text='<%# Eval("Cust_id") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCust_idFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Loan Amount">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Loan_amount") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLoan_amount" Text='<%# Eval("Loan_amount") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtLoan_amountFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Loan Type">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Loan_type") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLoan_type" Text='<%# Eval("Loan_type") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtLoan_typeFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Loan Period">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Loan_Period") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLoan_period" Text='<%# Eval("Loan_period") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtLoan_periodFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Balance">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Loan_bal") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLoan_bal" Text='<%# Eval("Loan_bal") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtLoan_balFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Loan_status") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLoan_status" Text='<%# Eval("Loan_status") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtLoan_statusFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>




                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/Images/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="White" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />    
                </center>
        </div>
    </form>
</body>
</html>
