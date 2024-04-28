using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public void editAccount()
        { }

        public void deleteAccount()
        { }

    }
}
