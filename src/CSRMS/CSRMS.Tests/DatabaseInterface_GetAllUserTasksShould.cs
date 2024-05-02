using System;
using Xunit;

using System.Data.SqlClient;
using CSRMS.Models.DatabaseInterface;
using CSRMS.Models.EventModel;
using System.Diagnostics;
using Task = CSRMS.Models.EventModel.Task;

namespace CSRMS.Tests
{

    public class DatabaseInterface_GetAllUserTasksShould
    {
        [Fact]
        public void DatabaseInterface_GetAllUserAccountTasks_ReturnListOfTypeTask()
        {
            //Arrange
            //Known Test Account//
            string emailAddress = "test@gmail.com";
            //Act
            List<Task> tasks = DatabaseInterface.GetAllUserAccountTasks(emailAddress);
            //Assert
            Assert.True(tasks is List<Task>);
        }
    }
}
