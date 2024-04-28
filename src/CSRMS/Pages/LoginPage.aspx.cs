using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CSRMS.Models.AccountModel;
using CSRMS.Models.DatabaseInterface;


namespace CSRMS.Pages
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            sendCredentials(email.Text, password.Text);
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
                else
                {
                    ViewState["ErrorMessage"] = "Invalid Password"; 
                }
            }
            else
            {
                // Display Error Message
                ViewState["ErrorMessage"] = "Invalid Username or Password";

            }
        }

        protected void createUser_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("CreateUser.aspx");
        }


    }
}
