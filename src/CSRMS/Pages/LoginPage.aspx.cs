using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Diagnostics;
=======
>>>>>>> LoginPage
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
<<<<<<< HEAD
using CSRMS.Models.AccountModel;
using CSRMS.Models.DatabaseInterface;
=======
>>>>>>> LoginPage

namespace CSRMS.Pages
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (!Page.IsPostBack)
            {
                ViewState["ErrorMessage"] = "";
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
        public void createAccountSelected()
        {
            Response.Redirect("CreateAccountPage.aspx");
        }

        public void loginBtnClicked(object sender, EventArgs e)
        {
            sendCredentials(username.Text, password.Text);
            errorCheck();
        }

        public void sendCredentials(string username, string password)
        {
           UserAccount user = DatabaseInterface.GetUserAccount(username);
            if (user != null)
            {
               // Check if password is correct
                if (user.getPassword() == password)
                {
                    // Redirect to Home Page
                    // Add UserAccount to Session
                    Session["UserAccount"] = user;
                    Response.Redirect("LandingPage.aspx");
                }
            }
            else
            {
                // Display Error Message
                ViewState["ErrorMessage"] = "Invalid Username or Password";
=======

        }

        protected void createUser_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("CreateUser.aspx");
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string email = this.email.Text; 
            string password = this.password.Text;
            // Handle login...
            System.Diagnostics.Debug.WriteLine(email);
            System.Diagnostics.Debug.WriteLine(password);

            if(email == "" || password == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Please ensure both fields are filled out!')", true);
            }
            else
            {
                Response.Redirect("LandingPage.aspx"); 
>>>>>>> LoginPage
            }
        }
    }
}
