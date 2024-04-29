using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSRMS.Models.EventModel;

namespace CSRMS.Pages
{
    public partial class ViewAllTaskPage : System.Web.UI.Page
    {
        public Filter searchFilter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Empty Filter
                searchFilter = new Filter(true);
            }
            setAllTasksTable();
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
                    // TitleFilter
                    bool titleFilter = (searchFilter.titleIsEmpty)||(searchFilter.title == task.GetTitle());
                    // StartDateFilter
                    bool startDateFilter = (searchFilter.startDateIsEmpty)||(searchFilter.startDate == task.GetStartDateTime().Date);
                    // PriorityFilter
                    bool priorityFilter = (searchFilter.priorityIsEmpty)||(searchFilter.priority == task.GetPriority());
                    // CategoryFilter
                    bool categoryFilter = searchFilter.categoryIsEmpty;
                    if (categoryFilter == false)
                    {
                        foreach (Category c in task.GetCategories())
                        {
                            if (c.getName() == searchFilter.category)
                            {
                                categoryFilter = true;
                                break;
                            }
                        }
                    }
                    bool filtersAllPass = titleFilter && startDateFilter && categoryFilter && priorityFilter;
                    if (filtersAllPass)
                    {
                        // for each task that passes filtering we want to adjust the count of tasks for view
                        tableRowCount.InnerHtml = (++count).ToString();
                        // Generate HTML for each row
                        rowsHtml.Append("<tr>");
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

                tableRowCount.InnerHtml += " Tasks";

                // Set the generated HTML to the tbody element
                taskRows.InnerHtml = rowsHtml.ToString();
            }
        }

        public void setEditTaskView()
        { }

        public void searchTasks()
        {
            filterTasks();
        }

        public void filterTasks()
        {
            string title = Filter.getTitleFilter(task.Text);
            DateTime? sDate = Filter.getStartDateFilter(startDate.Text);
            string cateogry = Filter.getCategoryFilter(category.Text);
            Priority? priority = Filter.getPriorityFilter(priorityDropDown.Text);
            searchFilter = new Filter(title, sDate, cateogry, priority);
            setAllTasksTable();
        }

        protected void searchTaskClick(object sender, EventArgs e)
        {
            searchTasks();
        }
       
    }
}
