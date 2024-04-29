using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSRMS.Models.EventModel;

namespace CSRMS.Pages
{
    public partial class LandingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void getViewAllTaskView()
        {
            Response.Redirect("ViewAllTasksPage.aspx");
        }
        public void getAddTaskView()
        {
            Response.Redirect("AddTaskPage.aspx");
        }
        public void getEditProfileView()
        {
            Response.Redirect("EditProfileSettingsPage.aspx");
        }
        public List<Reminder> getTodaysReminders()
        {
            // Temp retrun value
            return new List<Reminder>();
        }
        //public void selectEventsView()
        //{ }
    }
}



