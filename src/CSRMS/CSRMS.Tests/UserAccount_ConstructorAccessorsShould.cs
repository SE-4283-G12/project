using CSRMS.Models.AccountModel;

namespace CSRMS.Tests;

public class UserAccount_ConstructorAccessorsShould
{
    [Fact]
    public void UserAccount_GetEmailAddress_ReturnEmailAddressAsString()
    {
        //Arrange
        var actualUserAccountObject = new UserAccount("ahudson14@uco.edu", null, null, null);
        var expectedEmailAddress = "ahudson14@uco.edu";
        //Act
        var actualEmailAddress = actualUserAccountObject.getEmailAddress();
        //Assert
        Assert.Equal(expectedEmailAddress, actualEmailAddress);
    }

    [Fact]
    public void UserAccount_GetFirstName_ReturnFirstNameAsString()
    {
        //Arrange
        var actualUserAccountObject = new UserAccount(null, "Andrew", null, null);
        var expectedFirstName = "Andrew";
        //Act
        var actualFirstName = actualUserAccountObject.getFirstName();
        //Assert
        Assert.Equal(expectedFirstName, actualFirstName);
    }

    [Fact]
    public void UserAccount_GetLastName_ReturnLastNameAsString()
    {
        //Arrange
        var actualUserAccountObject = new UserAccount(null, null, "Hudson", null);
        var expectedLastName = "Hudson";
        //Act
        var actualLastName = actualUserAccountObject.getLastName();
        //Assert
        Assert.Equal(expectedLastName, actualLastName);
    }

    [Fact]
    public void UserAccount_GetPassword_ReturnPasswordAsString()
    {
        //Arrange
        var actualUserAccountObject = new UserAccount(null, null, null, "password");
        var expectedPassword = "password";
        //Act
        var actualPassword = actualUserAccountObject.getPassword();
        //Assert
        Assert.Equal(expectedPassword, actualPassword);
    }
}
