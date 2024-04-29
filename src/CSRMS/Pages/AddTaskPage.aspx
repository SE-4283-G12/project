<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddTaskPage.aspx.cs" Inherits="CSRMS.Pages.AddTaskPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8" />
        <meta name="viewport"
            content="width=device-width, initial-scale=1.0" />
        <title>Add Task</title>
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
            <div class="container" style="margin-top: 10px; width: 800px">
                <h2>
                    <center>
                        <i class="fa-solid fa-square-plus" style="color: #333333;"></i>
                        Add Task
                    </center>
                </h2>
                <h4>
                    <center>
                    </center>
                </h4>
                <div class="input_wrapper">
                    <asp:TextBox
                        ID="taskname"
                        type="text"
                        name="taskname"
                        placeholder="Task Name"
                        title="Input Task Name"
                        CssClass="input_field"
                        runat="server" />
                    <label for="taskname" class="input_label">Task Name<span style="color: red"> *</span></label>
                </div>
                <div class="input_wrapper">
                    <asp:TextBox
                        ID="location"
                        type="text"
                        name="location"
                        placeholder="Location"
                        title="Input Location Task is Completed"
                        CssClass="input_field"
                        runat="server" />
                    <label for="location" class="input_label">Location</label>
                </div>
                <div class="input_wrapper">
                    <asp:TextBox
                        ID="date"
                        type="date"
                        name="date"
                        placeholder="Date"
                        CssClass="input_field"
                        runat="server" />
                    <label for="date" class="input_label">Date<span style="color: red"> *</span></label>
                </div>
                <div class="input_wrapper">
                    <asp:TextBox
                        ID="time"
                        type="time"
                        name="time"
                        placeholder="Time"
                        title="The Time the task should be completed"
                        CssClass="input_field"
                        runat="server" />
                    <label for="time" class="input_label">Time</label>
                </div>
                <br />
                <div class="input-wrapper">

                    <asp:DropDownList ID="priorityDropDown" class="input_field" runat="server">
                        <asp:ListItem value="">Set priority...</asp:ListItem>
                        <asp:ListItem value="Urgent">Urgent</asp:ListItem>
                        <asp:ListItem value="High">High</asp:ListItem>
                        <asp:ListItem value="Medium">Medium</asp:ListItem>
                        <asp:ListItem value="Low">Low</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />
                <div class="input-wrapper">

                    <asp:DropDownList ID="categoryDropDown" class="input_field" runat="server"></asp:DropDownList>
                </div>
                <br>
                <br>
                <asp:Button type="button" CssClass="create-button" Text="Create Task" OnClick="createTask_Click" runat="server" />

            </div>
        </main>
    </body>
    </html>
</asp:Content>
