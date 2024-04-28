<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LoginPage.aspx.cs" Inherits="CSRMS.Pages.LoginPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" style="width: 0px" runat="server">
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8" />
        <meta name="viewport"
            content="width=device-width, initial-scale=1.0" />
        <title>Login Page</title>
        <!-- styles -->
        <script src="https://kit.fontawesome.com/d30d7d19e7.js" crossorigin="anonymous"></script>
        <link rel="preconnect" href="https://fonts.googleapis.com">
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
        <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap"
            rel="stylesheet">
        <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
        <link rel="stylesheet" href="../Public/Styles/forms.css">
    </head>
    <body>
        <main>
            <div class="container" style="width: 600px">
                <h2>
                    <center>
                        <i class="fa-solid fa-right-to-bracket" style="color: #333333;"></i>
                        CSRMS 
                    </center>
                </h2>
                <asp:Label runat="server" ID="errorMessage" CssClass="error_message_label hidden" Text="Username or Password is incorrect"></asp:Label>

                <div class="input_wrapper">
                    <asp:TextBox
                        ID="email"
                        type="email"
                        name="email"
                        placeholder="Email"
                        CssClass="input_field"
                        runat="server" />
                    <label for="email" class="input_label">Email</label>
                </div>
                <div class="input_wrapper">
                    <asp:TextBox
                        ID="password"
                        type="password"
                        name="password"
                        placeholder="Your Password"
                        title="minimum 6 characters at least 1 Alphabet and 1 number"
                        CssClass="input_field"
                        runat="server"></asp:TextBox>
                    <label for="password" class="input_label">Password</label>
                    <img
                        alt="Eye Icon" title="Eye Icon"
                        src="../Public/Images/eye.svg" class="input_icon" />
                </div>
                <br>
                <br>

                <asp:Button type="submit" CssClass="login-button" name="login" ID="login" Text="Login" OnClick="loginBtnClicked" runat="server" />

                <asp:Button type="button" CssClass="create-button" Text="Create Account" OnClick="createUser_Click" runat="server" />
            </div>
            <script src="../Public/Scripts/loginInput.js"></script>
        </main>
    </body>
    </html>
</asp:Content>
