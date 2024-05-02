<%@ Page Title="Edit Profile Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfileSettingsPage.aspx.cs" Inherits="CSRMS.Pages.EditProfileSettingsPage" %>

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
                    <i class="fa-solid fa-user-pen" style="color: #333333;"></i>
                    Edit Profile
                </center>
            </h2>
            <h4>
                <center>
                    To Save Changes Please Press Save Changes
                </center>
            </h4>
                    <asp:Label ID="errorMessage" runat="server" CssClass="error_message_label hidden"></asp:Label>
                <div class="">
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
                    </div>
                    <div class="input_wrapper">
                        <asp:TextBox
                            id="lastname"
                            type="text"
                            name="lastname"
                            placeholder="Last Name (required)"
                            title="Input Last Name"
                            CssClass="input_field2"
                            runat="server"/>
                        <label for="lastname" class="input_label">Last Name</label>
                    </div>

                <div class="input_wrapper">
                    <h4 style="text-align:left; color:var(--clr-header-1)">Please click below check box to update password</h4>
                    <input type="checkbox" id="passwordCheckbox" onclick="togglePasswordFields()" style="transform: scale(1.5);" />
                </div>
                <div class="input_wrapper" id ="newpassword">
                    <asp:TextBox
                    id="passwordNew"
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
                    id="passwordConfirm"
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
                <asp:Button type="button" Cssclass="create-button" Text="Save Changes" ID="saveChangesBtn" OnClick="saveChangesBtn_Click" runat="server" />
                <br />
                <br />
                <asp:Button type="button" Cssclass="create-button" Text="Delete Account" ID="deleteAccount" OnClick="deleteAccount_Click" runat="server" style="background-color:red"/>
</div>
</body>
</html>
</asp:Content>
