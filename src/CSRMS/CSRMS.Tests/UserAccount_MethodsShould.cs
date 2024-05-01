using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSRMS.Models.AccountModel;

namespace CSRMS.Tests;
public class UserAccount_MethodsShould
{
    [Fact]
    public void UserAccount_ValidateCredentials_ReturnTrue
        ()
    {
        //Arrange
        var actualUserAccountObject = new UserAccount("Andrew", null, null, null);
        var expectedFirstName = "Andrew";
        //Act
        var actualFirstName = actualUserAccountObject.getFirstName();
        //Assert
        Assert.Equal(expectedFirstName, actualFirstName);
    }
}
