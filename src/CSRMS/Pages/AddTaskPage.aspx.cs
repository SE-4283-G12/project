using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSRMS.Models.DatabaseInterface;

namespace CSRMS.Pages
{
    public partial class AddTaskPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string selectedValue = prioritySelector.Value; 
            }

        }
        //public void defineTaskParameters()
        //{ }

        //public void addReminder()
        //{ }

<<<<<<< HEAD
        public void saveTask(string session_sessionId, string task_id, string task_title, string task_description, string task_priority, string task_location, string task_is_complete, string task_start_date_time, string task_due_date_time, string task_account_id, string task_category)
        {

=======
        public void saveTask()
        { }

        protected void createTask_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Task button clicked"); 
>>>>>>> LoginPage
        }
    }
}
