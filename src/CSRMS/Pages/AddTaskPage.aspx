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
                        ID="startdate"
                        type="datetime-local"
                        name="startdate"
                        placeholder="Date"
                        CssClass="input_field"
                        runat="server" />
                    <label for="date" class="input_label">Start Date<span style="color: red"> *</span></label>
                </div>
                <div class="input_wrapper">
                    <asp:TextBox
                        ID="enddate"
                        type="datetime-local"
                        name="enddate"
                        placeholder="End Date"
                        CssClass="input_field"
                        runat="server" />
                    <label for="date" class="input_label">End Date<span style="color: red"> *</span></label>
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
                <br />
                <div class="input-wrapper">
                    <asp:DropDownList ID="priorityDropDown" class="input_field" runat="server">
                        <asp:ListItem Value="">Set priority...</asp:ListItem>
                        <asp:ListItem Value="Urgent">Urgent</asp:ListItem>
                        <asp:ListItem Value="High">High</asp:ListItem>
                        <asp:ListItem Value="Medium">Medium</asp:ListItem>
                        <asp:ListItem Value="Low">Low</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />
                <div class="input-wrapper">
                    <asp:ListBox ID="categoryListbox" ToolTip="Shift click to select multiple categories, Control click to remove categories" class="input_field" SelectionMode="multiple" runat="server">
                        <asp:ListItem Value="">Select a Category...</asp:ListItem>
                        <asp:ListItem Value="A">A</asp:ListItem>
                        <asp:ListItem Value="B">B</asp:ListItem>
                    </asp:ListBox>
                </div>
                <div class="input_wrapper">
                    <asp:TextBox
                        ID="description"
                        type="text"
                        name="description"
                        placeholder="Task Description"
                        title="Input Task Descriptioni"
                        CssClass="input_field"
                        runat="server" />
                    <label for="taskname" class="input_label">Task Description</label>
                </div>
                <div class="input_wrapper">
                    <h4 style="text-align: left; color: var(--clr-header-1)">Enable Reminders</h4>
                    <input type="checkbox" ID="remindercheckbox" Style="transform: scale(1.5);" OnClick="toggleReminderField()" />
                </div>
                <br />
                <div class="input-wrapper" id="reminder" >
                    <asp:ListBox ID="reminderlistbox" ToolTip="Shift click to select multiple reminders, Control click to remove reminders" class="input_field" SelectionMode="multiple" runat="server">
                        <asp:ListItem Value="">Never</asp:ListItem>
                        <asp:ListItem Value="One Hour Prior">One Hour Prior</asp:ListItem>
                        <asp:ListItem Value="One Day Prior">One Day Prior</asp:ListItem>
                        <asp:ListItem Value="One Week Prior">One Week Prior</asp:ListItem>
                    </asp:ListBox>
                </div>
                <br />
                <asp:Button type="button" CssClass="create-button" Text="Create Task" OnClick="createTask_Click" runat="server" />

            </div>
        </main>
        <script src="../Public/Scripts/AddTaskPage.js"></script>
    </body>
    </html>
</asp:Content>
