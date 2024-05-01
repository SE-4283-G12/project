<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategoryPage.aspx.cs" Inherits="CSRMS.Pages.EditCategoryPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8" />
        <meta name="viewport"
            content="width=device-width, initial-scale=1.0" />
        <title>DashBoard</title>
        <!-- styles -->
        <script src="https://kit.fontawesome.com/d30d7d19e7.js" crossorigin="anonymous"></script>
        <link rel="preconnect" href="https://fonts.googleapis.com">
        <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
        <link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap"
            rel="stylesheet">
        <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
        <link rel="stylesheet" href="../Public/Styles/table.css">
        <link rel="stylesheet" href="../Public/Styles/forms.css">
    </head>
    <body>

        <div class="container" style="width: 35%">
            <i class="fa-solid fa-arrow-left fa-2xl" style="cursor: pointer;" title="back to categories" onclick="CategoriesBack()"></i>
            <h2>Edit Category</h2>
                                                <asp:Label runat="server" ID="errorMessage" CssClass="error_message_label hidden" Text="Username or Password is incorrect"></asp:Label>

            <div class="input_wrapper">
                <asp:TextBox
                    ID="categoryname"
                    type="text"
                    name="text"
                    placeholder="Edit Cateogry"
                    CssClass="input_field"
                    runat="server" />
                <label for="categoryname" class="input_label">Edit Category</label>
            </div>
            <br />
            <asp:Button type="button" CssClass="create-button" Text="Edit Category" OnClick="EditCategoryBtn" runat="server" />
            <br />
            <br />
            <asp:Button type="button" CssClass="delete-button" Text="Delete Category" OnClick="DeleteCategoryBtn" runat="server" />
        </div>

        <script>
            function CategoriesBack() {
                window.history.back(); 
            }
        </script>
    </body>
    </html>
</asp:Content>
