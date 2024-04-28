<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="CSRMS.Pages.LoginPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8"/>
        <meta name="viewport"
        content="width=device-width, initial-scale=1.0"/>
        <title>Login Page</title>
        <!-- styles -->
        <script src="https://kit.fontawesome.com/d30d7d19e7.js" crossorigin="anonymous"></script>
        <link rel="preconnect" href="https://fonts.googleapis.com">
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
        <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" 
              rel="stylesheet">
              <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
        <link rel="stylesheet" href="../public/styles/styles.css">
    </head>
    <body>
        <main>
            <div class="container">
                <h2>
                    <center>
                    <i class="fa-solid fa-right-to-bracket" style="color: #333333;"></i>
                    CSRMS 
                    </center>
                </h2>

                <form name="login" method="POST" action = "login_action.aspx">
                    <asp:Label runat="server" ID="errorMessage" CssClass="error_message_label hidden" Text="Username or Password is incorrect"></asp:Label>
                    <div class="input_wrapper">
                        <asp:TextBox
                            runat="server"
                            ID="username"
                            type="text"
                            name="username"
                            placeholder="User Name"
                            title="Input User Name"
                            CssClass="input_field"
                        ></asp:TextBox>
                        <label for="username" class="input_label">User Name</label>
                    </div>
                    <div class="input_wrapper">
                        <asp:TextBox
                            runat="server"
                            ID="password"
                            type="password"
                            name="password"
                            placeholder="Your Password"
                            title="minimum 6 characters at least 1 Alphabet and 1 number"
                            class="input_field"
                        ></asp:TextBox>
                        <label for="password" class="input_label">Password</label>
                        <img
                            alt="Eye Icon" title="Eye Icon"
                            src="eye.svg" class="input_icon"
                        >
                    </div>
                    <br><br>

                    <asp:button runat="server" type="submit" class="login-button" name="submit" id="login" OnClick="loginBtnClicked" Text="Login" />
                </form>
            </div>
            <script src="loginInput.js"></script>
        </main>
    </body>
</html>
</asp:Content>
