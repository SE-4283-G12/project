using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSRMS.Models.AccountModel;
using CSRMS.Models.EventModel;

namespace CSRMS
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserAccount"] == null)
                {
                    // check what page we are on
                    string path = HttpContext.Current.Request.Url.AbsolutePath;
                    bool pageWithoutAccount = path.Contains("Login") || path.Contains("Create");
                    Debug.WriteLine(path);
                    if (!pageWithoutAccount)
                        Response.Redirect("LoginPage.aspx");
                }
                else
                {
                    CheckReminders();
                }
            }
        }

        private void CheckReminders()
        {
            // Fetch reminders from session
            List<Task> tasks = (List<Task>)Session["UserTasks"];
            foreach (Task task in tasks)
            {
                foreach (Reminder reminder in task.GetReminders())
                {
                    if (DateTime.Now >= reminder.GetReminderDateTime())
                    {
                        reminder.notify(((UserAccount)Session["UserAccount"]).getEmailAddress());
                        ((UserAccount)Session["UserAccount"]).resetUserTasksData();
                        break;
                    }
                }
            }
        }

        protected void signOut_Click(object sender, EventArgs e)
        {
            UserAccount.signOut();
            Response.Redirect("LoginPage.aspx");
        }
    }
}
