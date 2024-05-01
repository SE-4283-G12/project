using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using CSRMS.Models.EventModel;
using CSRMS.Models.DatabaseInterface;
using Microsoft.Ajax.Utilities;

namespace CSRMS.Models.AccountModel
{
    public class UserAccount
    {
        private string emailAddress { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string password { get; set; }

        public UserAccount(string firstName, string lastName, string emailAddress, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.emailAddress = emailAddress;
            this.password = password;
        }

        public void setEmailAddress(string email)
        {
            emailAddress = email;
        }

        public string getEmailAddress()
        {
            return emailAddress;
        }

        public void setFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string getLastName()
        {
            return lastName;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public string getPassword()
        {
            return password;
        }

        public static bool validateCredentials(string email, string password)
        {
            UserAccount user = DatabaseInterface.DatabaseInterface.GetUserAccount(email);
            if (user != null && user.getPassword() == password)
            {
                // add account to session
                HttpContext.Current.Session["UserAccount"] = user;
                return true;
            }
            return false;
        }

        public static bool doesEmailExist(string email)
        {
            if (DatabaseInterface.DatabaseInterface.GetUserAccount(email) == null)
                return false;
            return true;
        }

        public static void createAccount(string emailAddress, string firstName, string lastName, string password)
        {
            DatabaseInterface.DatabaseInterface.CreateAccount(emailAddress, firstName, lastName, password);
        }

        public List<Task> getAllUserAccountTasks()
        {
           return DatabaseInterface.DatabaseInterface.GetAllUserAccountTasks(this.emailAddress);
        }

        public List<Category> getAllUserAccountCategories()
        {
            return DatabaseInterface.DatabaseInterface.GetAllUserAccountCategories(this.emailAddress);
        }

        public void updateTask(Task updatedTask)
        {
            DatabaseInterface.DatabaseInterface.UpdateTask(updatedTask.GetTaskId(), updatedTask.GetTitle(), updatedTask.GetIsComplete(), updatedTask.GetStartDateTime(), updatedTask.GetDueDateTime(), this.emailAddress, updatedTask.GetLocation(), (int)updatedTask.GetPriority(), updatedTask.GetDescription());
        }

        public static void login()
        {
            // set session values
            HttpContext.Current.Session["UserTasks"] = ((UserAccount)HttpContext.Current.Session["UserAccount"]).getAllUserAccountTasks();
            HttpContext.Current.Session["UserCategories"] = ((UserAccount)HttpContext.Current.Session["UserAccount"]).getAllUserAccountCategories();
        }

        public static void signOut()
        {
            // reset session values
            HttpContext.Current.Session["UserAccount"] = null;
            HttpContext.Current.Session["UserTasks"] = null;
        }

        public void editAccount(string firstName, string lastName, string password)
        {
            if (firstName == "") firstName = this.firstName;
            if(lastName == "") lastName = this.lastName;
            if (password == "") password = this.password;
            DatabaseInterface.DatabaseInterface.UpdateUserAccount(this.emailAddress, firstName, lastName, password);
        }

        public void createNewUserAccountCategory(string categoryName)
        {
            DatabaseInterface.DatabaseInterface.CreateCategory(categoryName, this.emailAddress);
        }

        public void createNewUserAccountTask(string title, DateTime startDate, DateTime dueDate, string location, int? priority, string description)
        {
            DatabaseInterface.DatabaseInterface.CreateTask(title, false, startDate, dueDate, this.emailAddress, location, priority, description);

        }

        public void addCategoriesToUserAccountTask(int task_id, List<Category> categories)
        {
            foreach (Category category in categories)
                DatabaseInterface.DatabaseInterface.CreateTaskCategory(task_id, category.getId());
        }

        public static void editUserAccountCateogry(string oldCategoryName, string newCategoryName)
        {

            foreach (Category category in HttpContext.Current.Session["UserCategories"] as List<Category>)
            {
                if (category.getName() == oldCategoryName)
                {
                    DatabaseInterface.DatabaseInterface.UpdateCategory(category.getId(), newCategoryName, ((UserAccount)HttpContext.Current.Session["UserAccount"]).getEmailAddress());
                    return;
                }
            }
        }

        public void addReminderToUserAccountTask(int task_id, string taskTitle, DateTime dueDate, DateTime time)
        {
            DatabaseInterface.DatabaseInterface.CreateReminder(task_id, taskTitle + " due " + dueDate.ToString(), time, "email");
        }

        public void resetUserCategoriesData()
        {
            HttpContext.Current.Session["UserCategories"] = DatabaseInterface.DatabaseInterface.GetAllUserAccountCategories(this.emailAddress);
        }

        public void resetUserAccountData()
        {
            HttpContext.Current.Session["UserAccount"] = DatabaseInterface.DatabaseInterface.GetUserAccount(this.emailAddress);
        }

        public void resetUserTasksData()
        {
            HttpContext.Current.Session["UserTasks"] = DatabaseInterface.DatabaseInterface.GetAllUserAccountTasks(this.emailAddress);
        }

        public void deleteAccount()
        {
            DatabaseInterface.DatabaseInterface.DeleteUserAccount(this.emailAddress);
        }



    }
}
