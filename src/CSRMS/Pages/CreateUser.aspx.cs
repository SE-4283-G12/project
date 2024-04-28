﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSRMS.Models.AccountModel;

namespace CSRMS.Pages
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["ErrorMessage"] = "";
            }
        }
        protected void createUser_Click(object sender, EventArgs e)
        {

            string firstname = this.firstname.Text;
            string lastname = this.lastname.Text;
            string password = this.password.Text;
            string email = this.email.Text;

            // check if any feilds are empty

            if(firstname == "" || lastname == "" || password == "" || email == "")
            {
                displayError("Please enter a value for all fields!");
                return;
            }

            // check if email is valid

            if (UserAccount.doesEmailExist(email) == true)
            {
                displayError("Invalid Email Address");
                return;
            }

            UserAccount.storeCredentials(email, firstname, lastname, password);
            Response.Redirect("LoginPage.aspx");

        }
        public void displayError(string msg)
        {
            ViewState["ErrorMessage"] = msg;
            errorMessage.CssClass = "error_message_label";
            errorMessage.Text = msg;
        }
    }
}
