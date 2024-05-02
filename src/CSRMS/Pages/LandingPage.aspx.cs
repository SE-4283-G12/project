using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSRMS.Models.EventModel;

namespace CSRMS.Pages
{
    public partial class LandingPage : System.Web.UI.Page
    {
        public Filter searchFilter;
        public List<Filter> weeksearchFilter = new List<Filter>();


        protected void Page_Load(object sender, EventArgs e)
        {
            getTodaysTasks();       // Display all user's task for todays date
            getWeeksTasks();     // Display the rest of the weeks tasks
            foreach (Filter filter in weeksearchFilter)
            {
                System.Diagnostics.Debug.WriteLine(filter.ToString());
            };
            System.Diagnostics.Debug.WriteLine(searchFilter.ToString()); 
        }
        public void getViewAllTaskView()
        {
            Response.Redirect("ViewAllTasksPage.aspx");     // Load to View All Tasks Page
        }
        public void getAddTaskView()
        {
            Response.Redirect("AddTaskPage.aspx");      // Load to Add Task Page
        }
        public void getEditProfileView()
        {
            Response.Redirect("EditProfileSettingsPage.aspx");      // Load to Edit Profile Page
        }

        public void getTodaysTasks()        // Find and Display all todays tasks
        {
            filterTasks();
        }

        public void getWeeksTasks()         // Find and Display this weeks tasks
        {
            // new filter to be applied to filterTasks()
            filterweektasks();

        }


        public void setAllTasksTable()
        {
            List<Models.EventModel.Task> allTasks = Session["UserTasks"] as List<Models.EventModel.Task>;
            if (allTasks != null)
            {
                StringBuilder rowsHtml = new StringBuilder();

                // empty table
                rowsHtml.Clear();

                // track task count
                int count = 0;
                tableRowCount.InnerHtml = "";
                tableRowCount.InnerHtml = (count).ToString();

                foreach (Models.EventModel.Task task in allTasks)
                {
                    // Apply filtering
                    // We only want to generate a row if it passes the filters.
                    // StartDateFilter
                    bool startDateFilter = (searchFilter.startDateIsEmpty) || (searchFilter.startDate == task.GetStartDateTime().Date);

                    bool filtersAllPass = startDateFilter;
                    if (filtersAllPass)
                    {
                        // for each task that passes filtering we want to adjust the count of tasks for view
                        tableRowCount.InnerHtml = (++count).ToString();

                        // Generate HTML for each row
                        rowsHtml.Append("<tr OnClick=\"TableRowClicked()\" runat=\"server\">");
                        rowsHtml.Append("<td>").Append(task.GetTitle()).Append("</td>");
                        rowsHtml.Append("<td>").Append(task.GetPriority()).Append("</td>");
                        DateTime dateTime = task.GetDueDateTime();
                        rowsHtml.Append("<td>").Append(dateTime.ToString("yyyy-MM-dd")).Append("</td>");
                        rowsHtml.Append("<td>").Append((dateTime.Hour).ToString() + ":" + (dateTime.Minute.ToString())).Append("</td>");
                        rowsHtml.Append("<td>").Append(task.GetLocation()).Append("</td>");
                        rowsHtml.Append("<td>").Append(string.Join(", ", task.GetCategories().Select(c => c.getName()))).Append("</td>");
                        rowsHtml.Append("<td>").Append(task.GetIsComplete()).Append("</td>");
                        rowsHtml.Append("</tr>");
                    }
                }

                tableRowCount.InnerHtml+= " Tasks";

                // Set the generated HTML to the tbody element
                taskRows.InnerHtml = rowsHtml.ToString();
            }
        }

        public void setWeekTaskTable()
        {
            List<Models.EventModel.Task> allTasks = Session["UserTasks"] as List<Models.EventModel.Task>;
            StringBuilder rowsHtml = new StringBuilder();
            int count = 0;
            if (allTasks != null)
            {
               rowsHtml = new StringBuilder();

                // empty table
                rowsHtml.Clear();

                // track task count

                upcomingTableRowCount.InnerHtml = "";
                upcomingTableRowCount.InnerHtml = (count).ToString();
            }

            foreach (Models.EventModel.Task task in allTasks)
            {
                // Apply filtering
                // We only want to generate a row if it passes the filters.
                // StartDateFilter
                bool filtersAllPass = false;

                foreach (Filter weekFilter in weeksearchFilter)
                {
                    
                    bool startDateFilter = (weekFilter.startDateIsEmpty) || (weekFilter.startDate == task.GetStartDateTime().Date);

                    System.Diagnostics.Debug.WriteLine(task.GetStartDateTime()); 

                    if (startDateFilter)
                    {
                        filtersAllPass = true;
                        break; 
                    }

                }
                if (filtersAllPass)
                {

                    // for each task that passes filtering we want to adjust the count of tasks for view
                    upcomingTableRowCount.InnerHtml = (++count).ToString();

                    // Generate HTML for each row
                    rowsHtml.Append("<tr OnClick=\"TableRowClicked()\" runat=\"server\">");
                    rowsHtml.Append("<td>").Append(task.GetTitle()).Append("</td>");
                    rowsHtml.Append("<td>").Append(task.GetPriority()).Append("</td>");
                    DateTime dateTime = task.GetDueDateTime();
                    rowsHtml.Append("<td>").Append(dateTime.ToString("yyyy-MM-dd")).Append("</td>");
                    rowsHtml.Append("<td>").Append((dateTime.Hour).ToString() + ":" + (dateTime.Minute.ToString())).Append("</td>");
                    rowsHtml.Append("<td>").Append(task.GetLocation()).Append("</td>");
                    rowsHtml.Append("<td>").Append(string.Join(", ", task.GetCategories().Select(c => c.getName()))).Append("</td>");
                    rowsHtml.Append("</tr>");
                }
            }
            upcomingTableRowCount.InnerHtml += " Tasks";

            // Set the generated HTML to the tbody element
            upcomingTaskRows.InnerHtml = rowsHtml.ToString();
        }
            public void setEditTaskView()
        { }

        public void searchTasks()
        {
            filterTasks();
        }

        public void filterTasks()       // Filter Tasks to display with specific conditions
        {
            searchFilter = new Filter("", DateTime.Now.Date, "", null);     // May need to be updated to have the function for both Today and the Week
            setAllTasksTable();
        }

        public void filterweektasks()
        {
            System.Diagnostics.Debug.WriteLine("We are here"); 
            DateTime today = DateTime.Today;

            Filter filters = new Filter("", today, "", null);

            weeksearchFilter.Add(filters);
            
            for (int i = 1; i < 7; i++)
            {
                DateTime nextday = today.AddDays(i);
                nextday = nextday.Date; 
                
                System.Diagnostics.Debug.WriteLine("Next Day " + nextday); 
                filters = new Filter("", nextday, "", null);

                weeksearchFilter.Add(filters);

            }
            setWeekTaskTable(); 

        }
    }
}



