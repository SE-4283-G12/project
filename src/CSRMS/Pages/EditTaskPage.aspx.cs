using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSRMS.Models.DatabaseInterface;

namespace CSRMS.Pages
{
    public partial class EditTaskPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {}

        public void UpdateReminders()       // Update Reminders for given task based on any changes made by the user
        { }

        // Update any changes to selected task made by the user
        public void UpdateTaskDetails(string session_sessionId, string task_id, string task_title, string task_description, string task_priority, string task_location, string task_is_complete, string task_start_date_time, string task_due_date_time, string task_account_id, string task_category)
        {
           
        }
    }
}
