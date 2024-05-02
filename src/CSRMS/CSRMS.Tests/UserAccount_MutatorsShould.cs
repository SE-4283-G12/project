using CSRMS.Models.AccountModel;

namespace CSRMS.Tests;
public class UserAccount_MutatorsShould
{
    [Fact]
    public void UserAccount_SetEmailAddress_SetString()
    {
        //Arrange
        string contructedEmailAddress = "constructed@test.com";
        string setEmailAddress = "set@test.com";
        var actualUserAccount = new UserAccount(contructedEmailAddress, null, null, null);
        var expectedUserAccount = new UserAccount(setEmailAddress, null, null, null);
        //Act
        actualUserAccount.setEmailAddress(setEmailAddress);
        //Assert
        Assert.Equal(expectedUserAccount.getEmailAddress(), actualUserAccount.getEmailAddress());
    }

    [Fact]
    public void UserAccount_SetFirstName_SetString()
    {
        //Arrange
        string contructedFirstName = "constructed";
        string setFirstName = "set";
        var actualUserAccount = new UserAccount(null, contructedFirstName, null, null);
        var expectedUserAccount = new UserAccount(null, setFirstName, null, null);
        //Act
        actualUserAccount.setFirstName(setFirstName);
        //Assert
        Assert.Equal(expectedUserAccount.getFirstName(), actualUserAccount.getFirstName());
    }

    [Fact]
    public void UserAccount_SetLastName_SetString()
    {
        //Arrange
        string contructedLastName = "constructed";
        string setLastName = "set";
        var actualUserAccount = new UserAccount(null, null, contructedLastName, null);
        var expectedUserAccount = new UserAccount(null, null, setLastName, null);
        //Act
        actualUserAccount.setLastName(setLastName);
        //Assert
        Assert.Equal(expectedUserAccount.getLastName(), actualUserAccount.getLastName());
    }

    [Fact]
    public void UserAccount_SetPassword_SetString()
    {
        //Arrange
        string contructedPassword = "constructed";
        string setPassword = "set";
        var actualUserAccount = new UserAccount(null, null, null, contructedPassword);
        var expectedUserAccount = new UserAccount(null, null, null, setPassword);
        //Act
        actualUserAccount.setPassword(setPassword);
        //Assert
        Assert.Equal(expectedUserAccount.getPassword(), actualUserAccount.getPassword());
    }

    /*[Fact]
    public void UserAccount_ValidateCredentials_ReturnTrue()
    {
        //Arrange
        var actualUserAccountObject = new UserAccount(null, null, null, null);
        actualUserAccountObject.setEmailAddress("ahudson14@uco.edu");
        actualUserAccountObject.setFirstName("Andrew");
        actualUserAccountObject.setLastName("Hudson");
        actualUserAccountObject.setPassword("password");
        string emailAccount = actualUserAccountObject.getEmailAddress();
        string password = actualUserAccountObject.getPassword();
        //Act
        bool response = UserAccount.validateCredentials(emailAccount, password);
        //Assert
        Assert.True(response);
    }*/
}
