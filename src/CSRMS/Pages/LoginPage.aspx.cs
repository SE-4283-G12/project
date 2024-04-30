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

        public void sendCredentials(string email, string password)
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

        protected void createUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateUser.aspx");
        }
    }
}
