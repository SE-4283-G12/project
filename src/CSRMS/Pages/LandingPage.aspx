<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="CSRMS.Pages.LandingPage" %>

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
    </head>
    <body>
        <div class="container">
            <div class="table-widget" style="min-width: 500px">
                <table>
                    <caption>
                        <h1>
                            <center>Today's Task</center>
                        </h1>
                        <span runat="server" class="table-row-count" id="tableRowCount"></span>
                    </caption>
                    <thead>
                        <tr>
                            <th>Task Name</th>
                            <th>Priority</th>
                            <th>Due Date</th>
                            <th>End Time</th>
                            <th>Location</th>
                            <th>Category</th>
                            <th>Task Completed</th>
                        </tr>
                    </thead>
                    <tbody runat="server" title="Edit Task" id="taskRows">
                        <!--? rows are generated -->
                    </tbody>
                </table>
            </div>
            <br />
            <div class="table-widget" style="min-width: 500px">
                <table>
                    <caption>
                        <h1>
                            <center>Upcoming Task</center>
                        </h1>
                        <span runat="server" class="table-row-count" id="upcomingTableRowCount"></span>
                    </caption>
                    <thead>
                        <tr>
                            <th>Task Name</th>
                            <th>Priority</th>
                            <th>Due Date</th>
                            <th>End Time</th>
                            <th>Location</th>
                            <th>Category</th>
                            <th>Task Completed</th>
                        </tr>
                    </thead>
                    <tbody runat="server" title="Edit Task" id="upcomingTaskRows">
                        <!--? rows are generated -->
                    </tbody>
                </table>
            </div>
        </div>
        <script src="../Public/Scripts/dashboardtable.js"></script>


    </body>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            var rows = document.querySelectorAll("table tr[runat='server']");
            rows.forEach(function (row) {
                row.addEventListener("click", function () {
                    // Get the category name from the clicked row
                    var TaskName = row.cells[0].innerText.trim(); // Assuming the Task name is in the first column

                    // Redirect to the EditCategoryPage.aspx with the category name as a query parameter
                    window.location.href = "EditTaskPage.aspx?taskName=" + encodeURIComponent(TaskName);
                });
            });
        });
    </script>
    </html>
</asp:Content>


