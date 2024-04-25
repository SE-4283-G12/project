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

        public void deleteAccount(string sessionId, string accountId)
        {
        }

        public void deleteAccount(string sessionId, string accountId, string password)
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
