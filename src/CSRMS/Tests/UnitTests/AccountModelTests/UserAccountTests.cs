using System;

/// <summary>
/// 
/// </summary>
namespace CSRMS.Models.AccountModel
{
    public class UserAccountTests
    {
        public static void UserAccount_Constructor_ReturnsUserAccount()
        {
            try
            {
                //Arrange
                var userAccount = new UserAccount("FirstName", "lastName", "email", "Password");
                //Act

                //Assert

            }
            catch (Exception exception)
            {

            }
        }
    }
}
