<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="emp_home.aspx.cs" Inherits="CrudInGridView.emp_home" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <title>Employee Home</title>
    <style>
        body
        {
            background-image:url('bg.jpg');
        }
        a {
        text-decoration: none;
      /*}*/
      div{
          position:relative;
      }
      a{
        text-decoration:none;
        color:white;
      }

      a:hover {
        color: white;
        border-bottom: 1px solid #000099;
      }
    </style>
</head> 
<body style="border:2px solid white;">
        <form id="form1" runat="server">
      
        <div class="container-fluid" style="border:2px solid white; "><br />
        <center><h2 style="color:white;">CASKET BANK</h2>
                  <br /><hr color="white"/><asp:Label style="color:white"  ID="lblUserDetails" runat="server" Text=""></asp:Label>
        <br /></center>
            <div align="right"><asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" Height="37px" Width="97px" />
            </div>
            <hr color="white"/>
            <div style="border:3px solid white;  padding:6px;border-collapse: separate; width:20%; color:white;">
            <h4 style="color:white;"><u>Dashboard</u></h4>

            <br />

            <a href="cust_home.aspx" style="color:white;">Home</a><br />
            <a href="Loan_details.aspx"  style="color:white;">Profile</a><br />
            <a href="Payloan.aspx"  style="color:white;">Search Customer</a><br />
            <a href="Loanhis.aspx"  style="color:white;">Settings</a><br />
            <a href="Help.aspx"  style="color:white;">Help</a><br /><br />
            <a href="reports.aspx" style="color:red;"  style="color:white;">Reports</a><br /><br />              
        </div><br /><br /><br /><br /><br /><br />
        </form>
</body>
</html>

