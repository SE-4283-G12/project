<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCategoryPage.aspx.cs" Inherits="CSRMS.Pages.ViewCategoryPage" %>

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

        <div class="table-widget" style="width: 50%; min-width: 500px">
            <div class="table-container">
                <div style="border-right: 2px solid var(--clr-border-1); padding-right: 20px">
                    <h2 style="margin-top: 22px; padding-bottom: 15px; border-block-end: 2px solid var(--clr-border-1);">Add Category</h2>
                                    <asp:Label runat="server" ID="errorMessage" CssClass="error_message_label hidden" Text="Username or Password is incorrect"></asp:Label>

                    <div class="input_wrapper">
                        <asp:TextBox
                            ID="categoryname"
                            type="text"
                            name="text"
                            placeholder="Add Cateogry"
                            CssClass="input_field2"
                            runat="server" />
                        <label for="categoryname" class="input_label">Add Category</label>
                    </div>
                    <br />
                    <asp:Button type="button" CssClass="create-button" Text="Create Category" Style="width: 95%; margin-left: 5px" OnClick="creatcategory_Click" runat="server" />
                </div>
                <table style="margin-left: 2em;">
                    <caption>
                        <h2>Categories
                        </h2>
                        <span runat="server" class="table-row-count" id="tablerowcontent"></span>
                    </caption>
                    <thead>
                        <tr>
                            <th>Category Name</th>
                            <%--<th>Completion Percentage</th>--%>
                        </tr>
                    </thead>
                    <tbody runat="server" title="Edit Category" id="categoryRows">
                        <!--? rows are generated -->
                    </tbody>
                </table>
            </div>
        </div>

        <script src="../Public/Scripts/categoryTable.js"></script>
        <script>
            document.addEventListener("DOMContentLoaded", function () {
                var rows = document.querySelectorAll("table tr[runat='server']");
                rows.forEach(function (row) {
                    row.addEventListener("click", function () {
                        // Get the category name from the clicked row
                        var categoryName = row.cells[0].innerText.trim(); // Assuming the category name is in the first column

                        // Redirect to the EditCategoryPage.aspx with the category name as a query parameter
                        window.location.href = "EditCategoryPage.aspx?categoryName=" + encodeURIComponent(categoryName);
                    });
                });
            });
        </script>

    </body>

    </html>
</asp:Content>
