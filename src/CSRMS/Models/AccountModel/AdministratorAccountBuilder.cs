using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSRMS.Models.AccountModel
{
    public class AdministratorAccountBuilder : AccountBuilder
    {
        private AdministratorAccount account { get; set; }

        public new void buildPrivileges()
        { }

        public new void buildUserSettings()
        { }

        public new AdministratorAccount getAccount()
        {
            return account;
        }
    }
}
