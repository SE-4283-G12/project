<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="CSRMS.Pages.LandingPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="UTF-8"/>
        <meta name="viewport"
        content="width=device-width, initial-scale=1.0"/>
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
		<div class="table-widget">
			<table>
				<caption>
					<h1><center>Today's Task</center></h1> 
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

	<script src="../Public/Scripts/dashboardtable.js"></script>


	</body>

	</html>
</asp:Content>


