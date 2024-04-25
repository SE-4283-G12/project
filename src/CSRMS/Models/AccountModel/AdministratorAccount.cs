using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSRMS.Models.AccountModel
{
    public class AdministratorAccount
    {
        private string accountIdentifier { get; set; }
        private bool isAdministrator { get; set; } = true;
        private string preferredName { get; set; }
        private string emailAddress { get; set; }
        private string password { get; set; }
        public string getAccountIdentifier()
        {
            return accountIdentifier;
        }
        public bool getAdministratorStatus()
        {
            return isAdministrator;
        }
        public string getPreferredName()
        {
            return preferredName;
        }

        public string getEmailAddress()
        {
            return emailAddress;
        }

        public void setPreferredName(string name)
        {
            preferredName = name;
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
