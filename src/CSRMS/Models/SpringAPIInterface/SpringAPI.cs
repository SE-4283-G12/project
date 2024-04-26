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
		
		public void login(string accountId, string password)
		{
			
		}
		
		public void updateAccount(string session_sessionId, string account_accountId, string account_administrator, string account_firstName, string account_lastName, string account_emailAddress, string account_password)
		{
			
		}

        public void deleteAccount(string sessionId, string accountId)
        {
        }
		
		public void logoffAccount(string sessionId, string accountId)
		{
			
		}
		
		public void getAccountDetails(string sessionId, string accountId)
		{
			
		}
		
		public void createTask(string session_sessionId, string task_id, string task_title, string task_description, string task_priority, string task_location, string task_is_complete, string task_start_date_time, string task_due_date_time, string task_account_id, string task_category)
		{
			
		}
		
		public void updateTask(string session_sessionId, string task_id, string task_title, string task_description, string task_priority, string task_location, string task_is_complete, string task_start_date_time, string task_due_date_time, string task_account_id, string task_category[])
		{
			
		}
		
		public void deleteTask(string session_sessionId, string task_id)
		{
			
		}
		public void getTaskDetails(string session_sessionId, string task_id)
		{
			
		}
		public void getAllTasksOfAccount(string session_sessionId)
		{
			
		}
		
		public void createCategory(string session_sessionId, string category_id, string category_categoryName, string category_task[])
		{
			
		}
		
		public void updateCategory(string session_sessionId, string category_id, string category_categoryName, string category_task[])
		{
			
		}
		
		public void deleteCategory(string session_sessionId, string category_id)
		{
			
		}
		public void getCategoryDetails(string session_sessionId, string category_id)
		{
			
		}
		public void getAllCategoriesOfAccount(string session_sessionId)
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
