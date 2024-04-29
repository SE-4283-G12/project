using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CSRMS.Models.AccountModel;
using CSRMS.Models.DatabaseInterface;
using CSRMS.Models.EventModel;

namespace CSRMS.Pages
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["ErrorMessage"] = "";
                //DatabaseInterface.CreateTask("testTask5", true, DateTime.Now, DateTime.Now, "test@gmail.com", "testLocation5", 5, "testDescription5");
                //DatabaseInterface.CreateCategory("Test2", "test@gmail.com");
                //DatabaseInterface.CreateTaskCategory(2, 2);
                //DatabaseInterface.CreateReminder(2, "MSG2", DateTime.Now, "Email");
                //Debug.WriteLine(DateTime.Now);
                //List<Task> tasks = DatabaseInterface.GetAllUserAccountTasks("test@gmail.com");
                //foreach (Task task in tasks)
                //{
                //    // Print out all details of task
                //    Debug.WriteLine("TASK ID:" + task.GetTaskId());
                //    Debug.WriteLine("TITLE:" + task.GetTitle());
                //    Debug.WriteLine("ISCOMPLETE:" + task.GetIsComplete());
                //    Debug.WriteLine("DUEDATE:" + task.GetDueDateTime());
                //    Debug.WriteLine("STARTDATE:" + task.GetStartDateTime());
                //    Debug.WriteLine("LOCATION:" + task.GetLocation());
                //    Debug.WriteLine("DESCRIPTION:" + task.GetDescription());
                //    Debug.WriteLine("PRIORITY:" + task.GetPriority());
                //    foreach (Category category in task.GetCategories())
                //    {
                //        Debug.WriteLine("CATEGORY:" + category.getName());
                //    }
                //    foreach (Reminder reminder in task.GetReminders())
                //    {
                //        Debug.WriteLine("REMINDER ID:" + reminder.GetReminderId());
                //        Debug.WriteLine("MESSAGE:" + reminder.GetMessage());
                //        Debug.WriteLine("TASK ID:" + reminder.GetTaskId());
                //        Debug.WriteLine("REMINDER TIME:" + reminder.GetReminderDateTime());
                //    }

                //}
            }
        }

        public void errorCheck()
        {
            if (ViewState["ErrorMessage"].ToString() == "Invalid Username or Password")
            {
                // Display Error Message
                errorMessage.CssClass = "error_message_label";
            }
        }
        public void createAccountSelected()
        {
            Response.Redirect("CreateAccountPage.aspx");
        }

        public void loginBtnClicked(object sender, EventArgs e)
        {
            sendCredentials(email.Text, password.Text);
            errorCheck();
        }

        public void sendCredentials(string email, string password)
        {
            if(UserAccount.validateCredentials(email, password)) loginUserAccount();
            else ViewState["ErrorMessage"] = "Invalid Username or Password";
        }

        public void loginUserAccount()
        {
            // Set the session variables
            UserAccount.login();
            Response.Redirect("LandingPage.aspx");
        }

        protected void createUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateUser.aspx");
        }
    }
}
