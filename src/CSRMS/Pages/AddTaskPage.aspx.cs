using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSRMS.Models.DatabaseInterface;
using CSRMS.Models.EventModel;

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
                List<string> dbCategories = new List<string> { "Select a Category..."};

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

        protected void createTask_Click(object sender, EventArgs e)     //confirm task creation 
        {
            System.Diagnostics.Debug.WriteLine("Task button clicked"); 

        }
    }
}
