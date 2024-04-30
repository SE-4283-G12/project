using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSRMS.Models.EventModel;
using Microsoft.Ajax.Utilities;

namespace CSRMS.Models.AccountModel
{
    public class UserAccount
    {
        private string emailAddress { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string password { get; set; }

        public UserAccount(string firstName, string lastName, string emailAddress, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.emailAddress = emailAddress;
            this.password = password;
        }

        public void setEmailAddress(string email)
        {
            emailAddress = email;
        }

        public string getEmailAddress()
        {
            return emailAddress;
        }

        public void setFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string getLastName()
        {
            return lastName;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public string getPassword()
        {
            return password;
        }

        public static bool validateCredentials(string email, string password)
        {
            UserAccount user = DatabaseInterface.DatabaseInterface.GetUserAccount(email);
            if (user != null && user.getPassword() == password)
            {
                // add account to session
                HttpContext.Current.Session["UserAccount"] = user;
                return true;
            }
            return false;
        }

        public static bool doesEmailExist(string email)
        {
            if (DatabaseInterface.DatabaseInterface.GetUserAccount(email) == null)
                return false;
            return true;
        }

        // using as create new account
        public static void storeCredentials(string email, string firstName, string lastName, string password)
        {
            DatabaseInterface.DatabaseInterface.CreateAccount(email, firstName, lastName, password);
        }

        public List<Task> getAllUserAccountTasks()
        {
           return DatabaseInterface.DatabaseInterface.GetAllUserAccountTasks(this.emailAddress);
        }

        public List<Category> getAllUserAccountCategories()
        {
            return DatabaseInterface.DatabaseInterface.GetAllUserAccountCategories(this.emailAddress);
        }

        public static void login()
        {
            // set session values
            HttpContext.Current.Session["UserTasks"] = ((UserAccount)HttpContext.Current.Session["UserAccount"]).getAllUserAccountTasks();
            HttpContext.Current.Session["UserCategories"] = ((UserAccount)HttpContext.Current.Session["UserAccount"]).getAllUserAccountCategories();
        }

        public static void signOut()
        {
            // reset session values
            HttpContext.Current.Session["UserAccount"] = null;
            HttpContext.Current.Session["UserTasks"] = null;
        }

        public void editAccount(string firstName, string lastName, string password)
        {
            if (firstName == "") firstName = this.firstName;
            if(lastName == "") lastName = this.lastName;
            if (password == "") password = this.password;
            DatabaseInterface.DatabaseInterface.UpdateUserAccount(this.emailAddress, firstName, lastName, password);
            resetUserAccountSessionData();
        }

        public void resetUserAccountSessionData()
        {
            HttpContext.Current.Session["UserAccount"] = DatabaseInterface.DatabaseInterface.GetUserAccount(this.emailAddress);
        }

        public void deleteAccount()
        {
            DatabaseInterface.DatabaseInterface.DeleteUserAccount(this.emailAddress);
        }

    }
}
