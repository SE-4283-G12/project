using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSRMS.Models.AccountModel;
using CSRMS.Models.DatabaseInterface;
using Xunit;


namespace CSRMS.Tests
{
    public class UserAccount_EventMethodsShould
    {
        [Fact]
        public void UserAccount_ValidateCredentials_ReturnTrueBool()
        {
            //Arrange
            string emailAddress = "xunit@test.net";
            string firstName = "x";
            string lastName = "unit";
            string password = "xunit";
            UserAccount expectedUserAccount = new UserAccount(emailAddress, firstName, lastName, password);
            //Act
            UserAccount.createAccount(emailAddress, firstName, lastName, password);
            UserAccount actualUserAccount = DatabaseInterface.GetUserAccount(emailAddress);
            //Assert
            Assert.Equal(expectedUserAccount, actualUserAccount);

        }

        [Fact]
        public void UserAccount_DoesEmailExist_ReturnTrueBool()
        {
            //Arrange
            //Known existing account
            string knownValidEmailAddress = "test@gmail.com";
            //Act
            bool result = UserAccount.doesEmailExist(knownValidEmailAddress);
            //Assert
            Assert.True(result);

        }

        [Fact]
        public void UserAccount_DoesEmailExist_ReturnFalseBool()
        {
            //Arrange
            string nonexistentEmailAddress = "invalid@invalid.edu";
            //Act
            bool result = UserAccount.doesEmailExist(nonexistentEmailAddress);
            //Assert
            Assert.False(result);

        }
    }

}
