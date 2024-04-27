using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSRMS.Models.AccountModel
{
    public class UserAccount
    {
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string emailAddress { get; set; }
        private string password { get; set; }

        public UserAccount(string fname, string lname, string email, string pass)
        {
            this.firstName = fname;
            this.lastName = lname;
            emailAddress = email;
            password = pass;
        }
        public string getFirstName()
        {
            return firstName;
        }
        public string getLastName()
        {
            return lastName;
        }
        public string getEmailAddress()
        {
            return emailAddress;
        }

        public void setFirstName(string fname)
        {
            firstName = fname;
        }

        public void setLastName(string lname)
        {
            lastName = lname;
        }

        public void setEmailAddress(string email)
        {
            emailAddress = email;
        }

        public bool validateCredentials()
        {
            // Temp return value
            return true;
        }

        public void storeCredentials()
        { }

        public void editAccount()
        { }

        public void deleteAccount()
        { }

    }
}
