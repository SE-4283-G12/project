using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSRMS.Models.AccountModel;
using CSRMS.Models.DatabaseInterface;
using CSRMS.Models.EventModel;
using Task = CSRMS.Models.EventModel.Task;

namespace CSRMS.Pages
{
    public partial class AddTaskPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // We need to get the categories from the database and store them here.
                List<string> dbCategories = new List<string> { "Select Categories..."};

                // Get Categories from session data
                foreach (Category category in Session["UserCategories"] as List<Category>)
                {
                    dbCategories.Add(category.getName());
                }

                //// Assign the data source to the drop-down list
                categoryListbox.DataSource = dbCategories;
                //// Bind the data to the drop-down list
                categoryListbox.DataBind();
            }

        }
        //public void defineTaskParameters()
        //{ }

        //public void addReminder()     //take parameter string to create individual
                                        //reminders based on selection during task creation
        //{ }

        public void saveTask()
        { }

        protected void createTask_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Task button clicked");

            // Check if task name is filled in and passes requirement
            bool allRequirementsProvided = true;
            string taskName = taskname.Text;
            foreach (Models.EventModel.Task task in (HttpContext.Current.Session["UserTasks"] as List<Models.EventModel.Task>))
            {
                if (task.GetTitle() == taskName)
                {
                    allRequirementsProvided = false;
                    break; // Exit loop since requirement not met
                }
            }

            // Get start date and end date strings from TextBoxes
            string startDateString = startdate.Text;
            string dueDateString = enddate.Text;

            // Parse the start date and end date strings into DateTime objects with the specified format
            DateTime startDate;
            DateTime dueDate;

            // Specify the date format
            string dateFormat = "yyyy-MM-ddTHH:mm";

            // Parse the start date string
            if (!DateTime.TryParseExact(startDateString, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
            {
                // Start date parsing failed
                allRequirementsProvided = false;
            }

            // Parse the end date string
            if (!DateTime.TryParseExact(dueDateString, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDate))
            {
                // End date parsing failed
                allRequirementsProvided = false;
            }

            // Check if due date is after start date
            if (dueDate <= startDate)
            {
                // Due date is not after start date
                allRequirementsProvided = false;
            }

            bool areRemindersEnabledSelected = false;

            List<string> reminders = new List<string>();
            foreach (ListItem item in reminderlistbox.Items)
            {
                if (item.Selected && item.Text != "Never")
                {
                    areRemindersEnabledSelected = true;
                    reminders.Add(item.Text);
                }

            }

            // Check if any categories are selected
            bool areCategoriesSelected = false;
            List<Category> categoriesSelected = new List<Category>();
            foreach (ListItem item in categoryListbox.Items)
            {
                if (item.Selected && item.Text != "Select Categories...")
                {
                    areCategoriesSelected = true;
                    foreach (Category category in (HttpContext.Current.Session["UserCategories"] as List<Category>))
                    {
                        if (item.Text == category.getName())
                        {
                            categoriesSelected.Add(category);
                        }
                    }
                }

            }

            // Now allRequirementsProvided will be true if all requirements are met, otherwise, it will be false
            if (allRequirementsProvided)
            {
                // All requirements are met, proceed with task creation
                int priority;
                switch (priorityDropDown.SelectedItem.Text)
                {
                    case "Urgent": priority = (int)Priority.Urgent; break;
                    case "High": priority = (int)Priority.High; break;
                    case "Medium": priority = (int)Priority.Medium; break;
                    case "Low": priority = (int)Priority.Low; break;
                    default: priority = (int)Priority.Low; break;
                }
                ((UserAccount)HttpContext.Current.Session["UserAccount"]).createNewUserAccountTask(taskName, startDate, dueDate, location.Text, priority, description.Text);
                ((UserAccount)HttpContext.Current.Session["UserAccount"]).resetUserTasksData();
                if (areCategoriesSelected)
                {
                    foreach(Models.EventModel.Task task in (HttpContext.Current.Session["UserTasks"] as List<Models.EventModel.Task>))
                    {
                        if (taskName == task.GetTitle())
                        {
                            ((UserAccount)HttpContext.Current.Session["UserAccount"]).addCategoriesToUserAccountTask(task.GetTaskId(), categoriesSelected);
                            ((UserAccount)HttpContext.Current.Session["UserAccount"]).resetUserTasksData();
                            break;
                        }

                    }
                }
                if (areRemindersEnabledSelected)
                {
                    int taskId = -1;
                    Task userTask = new Task();
                    foreach (Models.EventModel.Task task in (HttpContext.Current.Session["UserTasks"] as List<Models.EventModel.Task>))
                    {
                        if (taskName == task.GetTitle())
                        {
                            userTask = task; break;
                        }

                    }
                    foreach (string r in reminders)
                    {
                        
                        DateTime timeOfReminder = userTask.GetDueDateTime();
                        switch (r)
                        {
                            case "One Hour Prior":
                                timeOfReminder = dueDate.AddHours(-1);
                                break;
                            case "One Day Prior":
                                timeOfReminder = dueDate.AddDays(-1);
                                break;
                            case "One Week Prior":
                                timeOfReminder = dueDate.AddDays(-7);
                                break;
                            default:
                                // Handle unrecognized reminder
                                break;
                        }
                        ((UserAccount)HttpContext.Current.Session["UserAccount"]).addReminderToUserAccountTask(taskId, taskname.Text, dueDate, timeOfReminder);
                        ((UserAccount)HttpContext.Current.Session["UserAccount"]).resetUserTasksData();
                    }
                }
                // redirect to view all task page
                Response.Redirect("ViewAllTaskPage.aspx");
            }
            else
            {
                // Display an error message or take appropriate action
                ViewState["ErrorMessage"] = "Missing Required Feilds";
                errorMessage.CssClass = "error_message_label";
                errorMessage.Text = ViewState["ErrorMessage"].ToString();
            }
        }
    }
}
