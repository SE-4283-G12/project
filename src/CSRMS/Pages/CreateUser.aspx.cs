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
            string firstname = this.firstname.Text;
            string lastname = this.lastname.Text;
            string name = firstname + " " + lastname; 
            string password = this.password.Text;
            string email = this.email.Text;



            string[] fields = { firstname, lastname, password, email};
            List<string> missingFields = new List<string>();

            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] == "")
                {
                    switch (i)
                    {
                        case 0:
                            missingFields.Add("first name");
                            break;
                        case 1:
                            missingFields.Add("last name");
                            break; 
                        case 2:
                            missingFields.Add("password");
                            break;
                        case 3:
                            missingFields.Add("email");
                            break;
                    }
                }
            }

            if (missingFields.Count > 0)
            {
                string message = $"alert('Please enter a value for {string.Join(", ", missingFields)}!');";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", message, true);
                
            }
            else
            {


                this.email.Text = string.Empty;
                this.firstname.Text = string.Empty;
                this.lastname.Text = string.Empty;
                this.password.Text = string.Empty;

                Response.Redirect("LandingPage.aspx"); 
            }
        }

    }
}
