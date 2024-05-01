using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSRMS.Models.AccountModel;
using CSRMS.Models.DatabaseInterface;
using CSRMS.Models.EventModel;

namespace CSRMS.Pages
{
    public partial class EditTaskPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // load in task
                string taskName = Request.QueryString["taskName"].ToString();
                Task userTask = new Task();
                foreach (Task task in (HttpContext.Current.Session["UserTasks"] as List<Task>))
                {
                    if (taskName == task.GetTitle())
                    {
                        userTask = task;
                        break;
                    }
                }


                completedTask.Checked = userTask.GetIsComplete();
                taskname.Text = userTask.GetTitle();
                //startdate.Text = userTask.GetStartDateTime().ToString("yyyy-MM-ddTHH:mm"); // Format the start date
                //enddate.Text = userTask.GetDueDateTime().ToString("yyyy-MM-ddTHH:mm"); // Format the due date
                location.Text = userTask.GetLocation();

                // Set the priorityDropDown to have the item UserTask.GetPriority() selected
                Priority priority = userTask.GetPriority();
                string priorityString = "";
                switch (priority)
                {
                    case Priority.Urgent: priorityString = "Urgent"; break;
                    case Priority.High: priorityString = "High"; break;
                    case Priority.Medium: priorityString = "Medium"; break;
                    case Priority.Low: priorityString = "Low"; break;
                    default: priorityString = "Low"; break;
                }

                foreach (ListItem item in priorityDropDown.Items)
                {
                    if (item.Text == priorityString)
                    {
                        item.Selected = true;
                        break;
                    }
                }

                //// Set the categories based on the categories
                //foreach (Category userCategory in HttpContext.Current.Session["UserCategories"] as List<Category>)
                //{
                //    categoryListbox.Items.Add(userCategory.getName());
                //    foreach (Category taskCategory in userTask.GetCategories())
                //    {
                //        if (userCategory.getName() == taskCategory.getName())
                //        {
                //            categoryListbox.Items.FindByText(taskCategory.getName()).Selected = true;
                //        }

                //    }
                //}

                description.Text = userTask.GetDescription();

                //if (userTask.GetReminders().Count == 0)
                //{
                //    reminderlistbox.Items.FindByText("Never").Selected = true;
                //}
                //else
                //{
                //    // Set the Reminders based on the Reminders
                //    foreach (Reminder reminder in userTask.GetReminders())
                //    {
                //        DateTime dueDate = userTask.GetDueDateTime();
                //        if (dueDate.AddHours(-1) == reminder.GetReminderDateTime())
                //        {
                //            // Select the item corresponding to "One Hour Prior"
                //            reminderlistbox.Items.FindByText("One Hour Prior").Selected = true;
                //        }
                //        else if (dueDate.AddDays(-1) == reminder.GetReminderDateTime())
                //        {
                //            // Select the item corresponding to "One Day Prior"
                //            reminderlistbox.Items.FindByText("One Day Prior").Selected = true;
                //        }
                //        else if (dueDate.AddDays(-7) == reminder.GetReminderDateTime())
                //        {
                //            // Select the item corresponding to "One Week Prior"
                //            reminderlistbox.Items.FindByText("One Week Prior").Selected = true;
                //        }
                //    }
                //}
            }
        }

        public void UpdateReminders()       // Update Reminders for given task based on any changes made by the user
        { }

        // Update any changes to selected task made by the user
        public void UpdateTaskDetails(string session_sessionId, string task_id, string task_title, string task_description, string task_priority, string task_location, string task_is_complete, string task_start_date_time, string task_due_date_time, string task_account_id, string task_category)
        {
           
        }

        protected void editTask_Click(object sender, EventArgs e)
        {
            bool allRequirementsProvided = true;
            string taskName = taskname.Text;
            foreach (Models.EventModel.Task task in (HttpContext.Current.Session["UserTasks"] as List<Models.EventModel.Task>))
            {
                if (task.GetTitle() == taskName && Request.QueryString["taskName"].ToString() != taskName)
                {
                    allRequirementsProvided = false;
                    break; // Exit loop since requirement not met
                }
            }
            if (allRequirementsProvided)
            {
                Priority priority;
                switch (priorityDropDown.SelectedItem.Text)
                {
                    case "Urgent": priority = Priority.Urgent; break;
                    case "High": priority = Priority.High; break;
                    case "Medium": priority = Priority.Medium; break;
                    case "Low": priority = Priority.Low; break;
                    default: priority = Priority.Low; break;
                }
                Task userTask = new Task();
                foreach (Task task in (HttpContext.Current.Session["UserTasks"] as List<Task>))
                {
                    if (Request.QueryString["taskName"].ToString() == task.GetTitle())
                    {
                        userTask = task;
                        break;
                    }
                }
                userTask.SetIsComplete(completedTask.Checked);
                userTask.SetTitle(taskname.Text);
                userTask.SetLocation(location.Text);
                userTask.SetPriority(priority);
                userTask.SetDescription(description.Text);
                ((UserAccount)HttpContext.Current.Session["UserAccount"]).updateTask(userTask);

                ViewState["ErrorMessage"] = "";
            }
            else
            {
                ViewState["ErrorMessage"] = "Required Feilds Missing";
            }
            errorCheck();
        }

        public void errorCheck()
        {
            if (ViewState["ErrorMessage"].ToString() == "Required Feilds Missing")
            {
                // Display Error Message

                errorMessage.CssClass = "error_message_label";
                errorMessage.Text = ViewState["ErrorMessage"].ToString();
            }
            else
            {
                errorMessage.CssClass = "hidden";
            }
        }
        protected void DeleteTaskBtn(object sender, EventArgs e)
        {

        }
    }
}
