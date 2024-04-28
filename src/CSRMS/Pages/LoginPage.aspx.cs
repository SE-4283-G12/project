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
            Debug.WriteLine("LoginPage Loaded");
            DatabaseInterface.testDatabaseConnection();
        }
        public void createAccountSelected()
        {
            Response.Redirect("CreateAccountPage.aspx");
        }

        public void sendCredentials(string username, string password)
        {
           
        }
    }
}
