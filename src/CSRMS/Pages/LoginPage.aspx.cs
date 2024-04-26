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
            // Redirect to create_user.html
            Response.Redirect("create_user.html");
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string username = this.username.Text;
            string password = this.password.Text;
            // Handle login...
            System.Diagnostics.Debug.WriteLine(username);
            System.Diagnostics.Debug.WriteLine(password);

        }
    }
}
