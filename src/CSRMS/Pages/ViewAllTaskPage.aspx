<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAllTaskPage.aspx.cs" Inherits="CSRMS.Pages.ViewAllTaskPage" %>


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
        <div class="table-widget">
            <div class="filter-container" style="margin-bottom: 5em; width: 95%">
                <div class="input_wrapper">
                    <asp:TextBox
                        ID="task"
                        type="text"
                        name="text"
                        placeholder="Search Task"
                        CssClass="input_field2"
                        runat="server" />
                    <label for="email" class="input_label">Search Task</label>
                </div>
                <div class="input_wrapper">
                    <asp:TextBox
                        ID="date"
                        type="date"
                        name="date"
                        placeholder="Date"
                        CssClass="input_field2"
                        runat="server" />
                    <label for="date" class="input_label">Date</label>
                </div>
                <div class="input_wrapper">
                    <asp:TextBox
                        ID="category"
                        type="text"
                        name="category"
                        placeholder="Search Categories"
                        CssClass="input_field2"
                        runat="server" />
                    <label for="taskname" class="input_label">Category Name</label>
                </div>

                <div class="input-wrapper">

                    <asp:DropDownList ID="priorityDropDown" class="input_field2" runat="server">
                        <asp:ListItem value="">Filter by Priority...</asp:ListItem>
                        <asp:ListItem value="High">High Priority</asp:ListItem>
                        <asp:ListItem value="Medium">Medium Priority</asp:ListItem>
                        <asp:ListItem value="Low">Low Priority</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Button type="button" CssClass="filter-button" Text="Filter Task" OnClick="filterTaskClick" runat="server" />
            </div>
            <table>
                <caption>
                    <h1>
                        <center>View All Task</center>
                    </h1>
                    <span class="table-row-count" id="table-row-count"></span>
                </caption>
                <thead>
                    <tr>
                        <th>Task Name</th>
                        <th>Priority</th>
                        <th>Location</th>
                        <th>Category</th>
                    </tr>
                </thead>
                <tbody id="task-rows">
                    <!--? rows are generated -->
                </tbody>
            </table>
        </div>
        <%-- </div> --%>
        <script src="../Public/Scripts/ViewAllTaskTable.js"></script>
    </body>
    </html>
</asp:Content>
