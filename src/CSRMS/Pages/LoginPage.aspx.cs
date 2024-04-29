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
        protected void Page_Load(object sender, EventArgs e)    //Checking for page loading errors
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

        public void loginBtnClicked(object sender, EventArgs e)     //Attempt login
        {
            sendCredentials(email.Text, password.Text);
            errorCheck();
        }

        public void sendCredentials(string email, string password)      //Send login info for verification
        {
            if(UserAccount.validateCredentials(email, password)) Response.Redirect("LandingPage.aspx");
            else ViewState["ErrorMessage"] = "Invalid Username or Password";
        }

        protected void createUser_Click(object sender, EventArgs e)     //Create new user selection
        {
            Response.Redirect("CreateUser.aspx");
        }


    }
}
