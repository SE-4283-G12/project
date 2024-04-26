using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSRMS.Models.AccountModel;

namespace CSRMS.Models.SpringAPIInterface
{
    public static class SpringAPI
    {
        // Account Methods
        public static void createAccount(string accountId, bool isAdministrator, string preferedName, string emailAddress, string password)
        {

        }
		
		public static void login(string accountId, string password)
		{
			
		}
		
		public static void updateAccount(string session_sessionId, string account_accountId, string account_administrator, string account_firstName, string account_lastName, string account_emailAddress, string account_password)
		{
			
		}

        public static void deleteAccount(string sessionId, string accountId)
        {
        }
		
		public static void logoffAccount(string sessionId, string accountId)
		{
			
		}
		
		public static void getAccountDetails(string sessionId, string accountId)
		{
			
		}
        // Task Methods
		
		public static void createTask(string session_sessionId, string task_id, string task_title, string task_description, string task_priority, string task_location, string task_is_complete, string task_start_date_time, string task_due_date_time, string task_account_id, string task_category)
		{
			
		}
		
		public static void updateTask(string session_sessionId, string task_id, string task_title, string task_description, string task_priority, string task_location, string task_is_complete, string task_start_date_time, string task_due_date_time, string task_account_id, string task_category[])
		{
			
		}
		
		public static void deleteTask(string session_sessionId, string task_id)
		{
			
		}
		public static void getTaskDetails(string session_sessionId, string task_id)
		{
			
		}
		public static void getAllTasksOfAccount(string session_sessionId)
		{
			
		}
		
        // Category Methods
		public static void createCategory(string session_sessionId, string category_id, string category_categoryName, string category_task[])
		{
			
		}
		
		public static void updateCategory(string session_sessionId, string category_id, string category_categoryName, string category_task[])
		{
			
		}
		
		public static void deleteCategory(string session_sessionId, string category_id)
		{
			
		}
		public static void getCategoryDetails(string session_sessionId, string category_id)
		{
			
		}
		public static void getAllCategoriesOfAccount(string session_sessionId)
		{
			
		}
		




        // Reminder Methods



    }

    public class SpringAPIReturnMessage
    {

    }
}
