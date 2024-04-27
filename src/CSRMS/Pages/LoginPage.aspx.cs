using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSRMS.Pages
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            }
        }
    }
}
