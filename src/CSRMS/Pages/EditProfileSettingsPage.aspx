<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfileSettingsPage.aspx.cs" Inherits="CSRMS.Pages.EditProfileSettingsPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8"/>
        <meta name="viewport"
        content="width=device-width, initial-scale=1.0"/>
        <title>Edit Profile</title>
        <!-- styles -->
        <script src="https://kit.fontawesome.com/d30d7d19e7.js" crossorigin="anonymous"></script>
        <link rel="preconnect" href="https://fonts.googleapis.com">
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
        <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" 
              rel="stylesheet">
              <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
        <link rel="stylesheet" href="../Public/Styles/forms.css">

        <script src="../Public/Scripts/EditProfileSettingsPage.js" defer></script>



    </head>
<body>
    
            <div class="container" style="width: 600px">
            <h2>
                <center>
                  <i class="fa-solid fa-user-plus"style="color: #333333;""></i>
                    Update Profile
                </center>
            </h2>
            <h4>
                <center>
                    * All Fields are required to create an account
                </center>
            </h4>
                    <asp:Label ID="errorMessage" runat="server" CssClass="error_message_label hidden"></asp:Label>
                <div class="input-container">
                    <div class="input_wrapper">
                        <asp:TextBox
                            id="firstname"
                            type="text"
                            name="firstname"
                            placeholder="First Name (required)"
                            title="Input First Name"
                            CssClass="input_field2"
                            runat="server"/>
                        <label for="firstname" class="input_label">First Name</label>
                    </div>
                    <div class="input_wrapper">
                        <asp:TextBox
                            id="lastname"
                            type="text"
                            name="lastname"
                            placeholder="Last Name (required)"
                            title="Input Last Name"
                            CssClass="input_field2"
                            style ="width: 100%"
                            runat="server"/>
                        <label for="lastname" class="input_label">Last Name</label>
                    </div>

                </div>
                <div class="input_wrapper">
                    <asp:TextBox
                        id="password"
                        type="text"
                        name="password"
                        placeholder="Password (required)"
                        title="minimum 6 characters at least 1 Alphabet and 1 number"
                        Cssclass="input_field"
                        runat="server"
                        />
                    <label for="password" class="input_label">Current Password</label>
                </div>
                <div class="input_wrapper">
                    <h3 style="text-align:left; color:red">Please click below check box to update password</h3>
                    <input type="checkbox" id="passwordCheckbox" onclick="togglePasswordFields()" style="transform: scale(1.5);" />
                </div>
                <div class="input_wrapper" id ="newpassword">
                    <asp:TextBox
                    id="TextBox1"
                    type="text"
                    name="lastname"
                    placeholder="Last Name (required)"
                    title="Input Last Name"
                    CssClass="input_field2"
                    style ="width: 100%"
                    runat="server"/>
                <label for="lastname" class="input_label" >New Password</label>
                </div>
                <div class="input_wrapper" id ="confirmnewpassword">
                    <asp:TextBox
                    id="TextBox2"
                    type="text"
                    name="lastname"
                    placeholder="Last Name (required)"
                    title="Input Last Name"
                    CssClass="input_field2"
                    style ="width: 100%"
                    runat="server"/>
                <label for="lastname" class="input_label" >Confirm New Password</label>
</div>
                <br>
                <br>
                <asp:Button type="button" Cssclass="create-button" Text="Update Profile" runat="server" />
</div>
</body>
</html>
</asp:Content>
