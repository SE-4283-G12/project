using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSRMS.Pages
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void createUser_Click(object sender, EventArgs e)
        {
            string name = this.firstname.Text +" " + this.lastname.Text; 
            string password = this.password.Text;
            string email = this.email.Text;


            System.Diagnostics.Debug.WriteLine(name);
            System.Diagnostics.Debug.WriteLine(password);
            System.Diagnostics.Debug.WriteLine(email);
        }

    }
}
