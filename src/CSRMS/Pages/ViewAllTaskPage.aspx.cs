using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSRMS.Pages
{
    public partial class ViewAllTaskPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void setEditTaskView()
        { }

        public void searchTasks()
        { }

        public void filterTasks()
        { }

        protected void filterTaskClick(object sender, EventArgs e)
        {
            string task = this.task.Text;
            string date = this.date.Text;
            string category = this.category.Text;
            string priority = this.priorityDropDown.SelectedValue; 

            System.Diagnostics.Debug.WriteLine("You\'re attempting to filter: " + task + " " + date + " " + category + " " +priority); 
        }
    }
}
