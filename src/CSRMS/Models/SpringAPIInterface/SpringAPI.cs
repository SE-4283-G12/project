using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSRMS.Models.AccountModel;

namespace CSRMS.Models.SpringAPIInterface
{
    public class SpringAPI
    {
        // Account Methods
        public void createAccount(string accountId, bool isAdministrator, string preferedName, string emailAddress, string password)
        {

        }
		
		public void login(string accountId, string password)
		{
			
		}
		
		public void updateAccount(string session_sessionId, string account_accountId, string account_administrator, string account_firstName, string account_lastName, string account_emailAddress, string account_password)
		{
			
		}

        public void deleteAccount(string sessionId, string accountId)
        {
        }
		
		public void logoffAccount(string sessionId, string accountId)
		{
			
		}
		
		public void getAccountDetails(string sessionId, string accountId)
		{
			
		}
		
		


        // Task Methods

        // Category Methods

        // Reminder Methods



    }

    public class SpringAPIReturnMessage
    {

    }
}
