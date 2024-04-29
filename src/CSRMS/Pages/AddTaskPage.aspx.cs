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
            if (!IsPostBack)
            {
                //TODO!!
                // We need to get the categories from the database and store them here.
                List<string> dbCategories = new List<string> {"Select a Category...", "Item 1", "Item 2", "Item 3" };

                // Assign the data source to the drop-down list
                categoryDropDown.DataSource = dbCategories; 
                // Bind the data to the drop-down list
                categoryDropDown.DataBind();
            }

        }
        //public void defineTaskParameters()
        //{ }

        //public void addReminder()
        //{ }

        public void saveTask()
        { }

        protected void createTask_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Task button clicked"); 

        }
    }
}
