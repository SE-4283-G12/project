﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CSRMS.Models.AccountModel;
using CSRMS.Models.DatabaseInterface;

namespace CSRMS.Pages
{
    public partial class EditProfileSettingsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState["ErrorMessage"] = "";
                displayProfileInformation();
            }
        }

        public void errorCheck()
        {
            if (ViewState["ErrorMessage"].ToString() == "Passwords do not match")
            {
                // Display Error Message
                errorMessage.CssClass = "error_message_label";
                errorMessage.Text = ViewState["ErrorMessage"].ToString();
            }
            else
            {
                errorMessage.CssClass = "hidden";
            }
        }

        public void displayProfileInformation()
        {
            UserAccount user = (UserAccount)Session["UserAccount"];
            firstname.Text = user.getFirstName();
            lastname.Text = user.getLastName();
        }

        public void changePassword(string newPassword)
        {
            ((UserAccount)Session["UserAccount"]).editAccount("", "", newPassword);
        }

        public void changeUsersName(string firstName, string lastName)
        {
            ((UserAccount)Session["UserAccount"]).editAccount(firstName, lastName, "");
        }

        protected void saveChangesBtn_Click(object sender, EventArgs e)
        {
            bool isChangeMade = false;
            if (firstname.Text.Length > 0 && lastname.Text.Length > 0)
            {
                changeUsersName(firstname.Text, lastname.Text);
                isChangeMade = true;
            }
            if (passwordNew.Text == passwordConfirm.Text && passwordNew.Text.Length > 0)
            {
                changePassword(passwordNew.Text);
                passwordNew.Text = "";
                passwordConfirm.Text = "";
                ViewState["ErrorMessage"] = "";
                isChangeMade = true;
            }
            else if (passwordNew.Text != passwordConfirm.Text && passwordNew.Text.Length > 0)
            {
                ViewState["ErrorMessage"] = "Passwords do not match";
            }
            displayProfileInformation();
            errorCheck();
        }

        protected void deleteAccount_Click(object sender, EventArgs e)
        {
            UserAccount user = ((UserAccount)Session["UserAccount"]);
            user.deleteAccount();
            UserAccount.signOut();
            Response.Redirect("LoginPage");
        }
    }
}
