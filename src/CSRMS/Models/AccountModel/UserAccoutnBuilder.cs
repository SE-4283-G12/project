using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSRMS.Models.AccountModel
{
    public class UserAccoutnBuilder : AccountBuilder
    {
        private UserAccount account { get; set; }

        public new void buildPrivileges()
        { }

        public new void buildUserSettings()
        { }

        public new UserAccount getAccount()
        {
            return account;
        }
    }
}
