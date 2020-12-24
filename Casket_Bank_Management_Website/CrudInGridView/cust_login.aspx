<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cust_login.aspx.cs" Inherits="CrudInGridView.cust_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Login</title>
          <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <style>
         a {
        text-decoration: none;
      }

 body
        {
            background-image:url('bg.jpg');
        }
       
.form {
  position: absolute;
  top: 50%;
  left: 50%;
  background: #fff;
  width: 285px;
  margin: -140px 0 0 -182px;
  padding: 40px;
  box-shadow: 0 0 3px rgba(0, 0, 0, 0.3);
  h2 {
    margin: 0 0 20px;
    line-height: 1;
    color: #44c4e7;
    font-size: 18px;
    font-weight: 400;
  }
  input {
    outline: none;
    display: block;
    width: 100%;
    margin: 0 0 20px;
    padding: 10px 15px;
    border: 1px solid #ccc;
    color: #ccc;
    font-family: "Roboto";
    box-sizing: border-box;
    font-size: 14px;
    font-wieght: 400;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    transition: 0.2s linear;
    &input:focus {
      color: #333;
      border: 1px solid #44c4e7;
    }
  }
  button {
    cursor: pointer;
    background: #44c4e7;
    width: 100%;
    padding: 10px 15px;
    border: 0;
    color: #fff;
    font-family: "Roboto";
    font-size: 14px;
    font-weight: 400;
    &:hover {
      background: #369cb8;
    }
  }
}

.error, .valid{display:none;}
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
<body>

    <form id="form1" runat="server">
                <br /><br /><br />        
        
           <h1 style="margin-left:510px;color:white;"> CASKET BANK </h1>
           <section class="form animated flipInX">          
               <h3>Customer Login</h3>
               <asp:p class="valid">Valid. Please wait a moment.</asp:p>
  <asp:p class="error">Error. Please enter correct Username &amp; password.</asp:p>
            
                <br /><div class="loginbox">
    <asp:TextBox placeholder="Customer ID" ID="txtUserName" runat="server" type="text" class="username" Text="Username"></asp:TextBox>
     <br /><br /><asp:TextBox placeholder="Account ID" runat="server" ID="txtPassword" TextMode="Password" type="password" class="password"></asp:TextBox>
                   <br /><br />
<asp:Button class="submit" ID="btnLogin" runat="server" Text="LOGIN" OnClick="btnLogin_Click" ></asp:Button>&nbsp;&nbsp;<a href="forgot.aspx" style="color:red;">Forgot Password?</a>
</div>
</section>
                           
        <script>
$(document).ready(function() {
    //$('#username').focus();

    $('#submit').click(function() {

        event.preventDefault(); // prevent PageReLoad

       var ValidEmail = $('#username').val() === 'invitado'; // User validate
var ValidPassword = $('#password').val() === 'hgm2015'; // Password validate

        if (ValidEmail === true && ValidPassword === true) { // if ValidEmail & ValidPassword
            $('.valid').css('display', 'block');
            window.location = "http://arkev.com"; // go to home.html
        }
        else {
            $('.error').css('display', 'block'); // show error msg
        }
    });
});</script>
    </form>
</body>
</html>

