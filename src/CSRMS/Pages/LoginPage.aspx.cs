using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CSRMS.Models.AccountModel;
using CSRMS.Models.DatabaseInterface;
using CSRMS.Models.EventModel;

namespace CSRMS.Pages
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["ErrorMessage"] = "";

                // clear old sessions
                UserAccount.signOut();

                //DatabaseInterface.CreateTask("Go To Wedding", false, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1), "test@gmail.com", "jail", (int)Priority.Urgent, "No Description");
                //DatabaseInterface.CreateTask("Go To Shop", false, DateTime.Now.AddDays(2), DateTime.Now.AddDays(2), "test@gmail.com", "School", (int)Priority.Urgent, "No Description");
                //DatabaseInterface.CreateTask("Go To Reststop", false, DateTime.Now.AddDays(2), DateTime.Now.AddDays(2), "test@gmail.com", "Hospital", (int)Priority.Urgent, "No Description");
                //DatabaseInterface.CreateTask("Go To Meal", false, DateTime.Now.AddDays(3), DateTime.Now.AddDays(3), "test@gmail.com", "Airport", (int)Priority.Urgent, "No Description");
                //DatabaseInterface.CreateTask("Go To Event", false, DateTime.Now.AddDays(3), DateTime.Now.AddDays(4), "test@gmail.com", "Walmart", (int)Priority.Urgent, "No Description");
                //DatabaseInterface.CreateTask("Go To Party", false, DateTime.Now.AddDays(4), DateTime.Now.AddDays(5), "test@gmail.com", "Tjmax", (int)Priority.Urgent, "No Description");
                //DatabaseInterface.CreateTask("Go To Birthday Bash", false, DateTime.Now.AddDays(8), DateTime.Now.AddDays(9), "test@gmail.com", "Some location", (int)Priority.Urgent, "No Description");
                //DatabaseInterface.CreateTask("Go To Okctechhelp.com", false, DateTime.Now.AddDays(8), DateTime.Now.AddDays(19), "test@gmail.com", "Another location", (int)Priority.Urgent, "No Description");
            }
        }

        public void errorCheck()
        {
            if (ViewState["ErrorMessage"].ToString() == "Invalid Username or Password")
            {
                // Display Error Message
                errorMessage.CssClass = "error_message_label";
            }
        }

        public void loginBtnClicked(object sender, EventArgs e)     // Confirm Login
        {
            sendCredentials(email.Text, password.Text);
            errorCheck();
        }

        public void sendCredentials(string email, string password)      //Verification of user credentials
        {
            if(UserAccount.validateCredentials(email, password)) loginUserAccount();
            else ViewState["ErrorMessage"] = "Invalid Username or Password";
        }

        public void loginUserAccount()
        {
            // Set the session variables
            UserAccount.login();
            Response.Redirect("LandingPage.aspx");
        }

        protected void createUser_Click(object sender, EventArgs e)     // Load to Create User Page
        {
            Response.Redirect("CreateUser.aspx");
        }
    }
}
