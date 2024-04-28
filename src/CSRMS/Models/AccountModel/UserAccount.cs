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
