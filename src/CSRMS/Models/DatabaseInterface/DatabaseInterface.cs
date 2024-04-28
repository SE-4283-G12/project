﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using CSRMS.Models.AccountModel;
using CSRMS.Models.EventModel;

namespace CSRMS.Models.DatabaseInterface
{
    public static class DatabaseInterface
    {

        public static void testDatabaseConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
                {
                    connection.Open();

                    // Get the schema information for the database
                    DataTable schema = connection.GetSchema("Tables");

                    // Loop through the schema and print the table names
                    foreach (DataRow row in schema.Rows)
                    {
                        string tableName = row["TABLE_NAME"].ToString();
                        //Debug.WriteLine("Table Name: " + tableName);
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
        }

        //
        // Storage Procedures
        //

        // User Account Storage Procedures
        // Create User Account
        public static void CreateAccount(string email, string fname, string lname, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("CreateUserAccount", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
                    command.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
                    command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error creating account: " + ex.Message);
                        // Handle exception
                    }
                }
            }
        }

        // Get User Account
        public static UserAccount GetUserAccount(string email)
        {
            UserAccount user = null;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetUserAccount", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve user account details from the reader
                                string retrievedEmail = reader["email"].ToString();
                                string firstName = reader["fname"].ToString();
                                string lastName = reader["lname"].ToString();
                                string password = reader["password"].ToString();

                                // Create a UserAccount object
                                user = new UserAccount(firstName,lastName,retrievedEmail,password);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error retrieving user account: " + ex.Message);
                        // Handle exception
                    }
                }
            }

            return user;
        }

        // Update User Account
        public static void UpdateUserAccount(string email, string fname, string lname, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("UpdateUserAccount", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    command.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
                    command.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
                    command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error updating user account: " + ex.Message);
                        // Handle exception
                    }
                }
            }
        }

        // Delete User Account
        public static void DeleteUserAccount(string email)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("DeleteUserAccount", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error deleting user account: " + ex.Message);
                        // Handle exception
                    }
                }
            }
        }

        // Category Storage Procedures
        // CreateCategory
        public static void CreateCategory(string name)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("CreateCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error creating category: " + ex.Message);
                        // Handle exception
                    }
                }
            }
        }

        // GetCategory
        public static string GetCategory(int categoryId)
        {
            string categoryName = null;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@category_id", SqlDbType.Int).Value = categoryId;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve category name from the reader
                                categoryName = reader["name"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error retrieving category: " + ex.Message);
                        // Handle exception
                    }
                }
            }

            return categoryName;
        }

        // UpdateCategory
        public static void UpdateCategory(int categoryId, string newName)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("UpdateCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@category_id", SqlDbType.Int).Value = categoryId;
                    command.Parameters.Add("@name", SqlDbType.VarChar).Value = newName;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error updating category: " + ex.Message);
                        // Handle exception
                    }
                }
            }
        }

        // DeleteCategory

        public static void DeleteCategory(int categoryId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("DeleteCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@category_id", SqlDbType.Int).Value = categoryId;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error deleting category: " + ex.Message);
                        // Handle exception
                    }
                }
            }
        }

        // Task Storage Procedures
        // CreateTask
        public static void CreateTask(string title, bool isComplete, DateTime startDate, DateTime dueDate, string email, string location, string priority, string description)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("CreateTask", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@title", SqlDbType.VarChar).Value = title;
                    command.Parameters.Add("@is_complete", SqlDbType.Bit).Value = isComplete;
                    command.Parameters.Add("@start_date", SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@due_date", SqlDbType.DateTime).Value = dueDate;
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    command.Parameters.Add("@location", SqlDbType.VarChar).Value = location;
                    command.Parameters.Add("@priority", SqlDbType.Int).Value = priority;
                    command.Parameters.Add("@description", SqlDbType.Text).Value = description;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error creating task: " + ex.Message);
                        // Handle exception
                    }
                }
            }
        }

        // GetTask
        public static Task GetTask(int taskId)
        {
            Task task = null;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetTask", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@task_id", SqlDbType.Int).Value = taskId;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve task details from the reader
                                int retrievedTaskId = (int)reader["task_id"];
                                string title = reader["title"].ToString();
                                bool isComplete = (bool)reader["is_complete"];
                                DateTime startDate = (DateTime)reader["start_date"];
                                DateTime dueDate = (DateTime)reader["due_date"];
                                string location = reader["location"].ToString();
                                int priority = (int)reader["priority"];
                                string description = reader["description"].ToString();

                                // Create a new Task object
                                // add category and reminder later
                                task = new Task(Convert.ToString(retrievedTaskId), title, isComplete, dueDate, startDate, location, description, priority, null, null);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error retrieving task: " + ex.Message);
                        // Handle exception
                    }
                }
            }
            return task;
        }

        // UpdateTask
        public static void UpdateTask(int taskId, string title, bool isComplete, DateTime startDate, DateTime dueDate, string email, string location, int priority, string description)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("UpdateTask", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@task_id", SqlDbType.Int).Value = taskId;
                    command.Parameters.Add("@title", SqlDbType.VarChar).Value = title;
                    command.Parameters.Add("@is_complete", SqlDbType.Bit).Value = isComplete;
                    command.Parameters.Add("@start_date", SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@due_date", SqlDbType.DateTime).Value = dueDate;
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    command.Parameters.Add("@location", SqlDbType.VarChar).Value = location;
                    command.Parameters.Add("@priority", SqlDbType.Int).Value = priority;
                    command.Parameters.Add("@description", SqlDbType.Text).Value = description;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error updating task: " + ex.Message);
                        // Handle exception
                    }
                }
            }
        }

        // DeleteTask
        public static void DeleteTask(int taskId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("DeleteTask", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@task_id", SqlDbType.Int).Value = taskId;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error deleting task: " + ex.Message);
                        // Handle exception
                    }
                }
            }
        }

        // Task Categories Storage Procedures
        // CreateTaskCategory
        public static void CreateTaskCategory(int taskId, int categoryId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("CreateTaskCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@task_id", SqlDbType.Int).Value = taskId;
                    command.Parameters.Add("@category_id", SqlDbType.Int).Value = categoryId;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error creating task category: " + ex.Message);
                        // Handle exception
                    }
                }
            }
        }

        // GetTaskCategories
        public static List<int> GetTaskCategories(int taskId)
        {
            List<int> categoryIds = new List<int>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetTaskCategories", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@task_id", SqlDbType.Int).Value = taskId;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int categoryId = (int)reader["category_id"];
                                categoryIds.Add(categoryId);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error retrieving task categories: " + ex.Message);
                        // Handle exception
                    }
                }
            }

            return categoryIds;
        }

        // DeleteTaskCategory
        public static void DeleteTaskCategory(int taskId, int categoryId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("DeleteTaskCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@task_id", SqlDbType.Int).Value = taskId;
                    command.Parameters.Add("@category_id", SqlDbType.Int).Value = categoryId;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error deleting task category: " + ex.Message);
                        // Handle exception
                    }
                }
            }
        }

        // Reminder Storage Procedures
        // CreateReminder
        public static void CreateReminder(int taskId, string message, DateTime time)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("CreateReminder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@task_id", SqlDbType.Int).Value = taskId;
                    command.Parameters.Add("@message", SqlDbType.VarChar).Value = message;
                    command.Parameters.Add("@time", SqlDbType.DateTime).Value = time;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error creating reminder: " + ex.Message);
                        // Handle exception
                    }
                }
            }
        }

        // GetReminder
        public static Reminder GetReminder(int reminderId)
        {
            Reminder reminder = null;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("GetReminder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@reminder_id", SqlDbType.Int).Value = reminderId;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Retrieve reminder details from the reader
                                int retrievedReminderId = (int)reader["reminder_id"];
                                int taskId = (int)reader["task_id"];
                                string message = reader["message"].ToString();
                                DateTime time = (DateTime)reader["time"];

                                // Create a new Reminder object
                                reminder = new Reminder(retrievedReminderId, taskId, message, time);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error retrieving reminder: " + ex.Message);
                        // Handle exception
                    }
                }
            }

            return reminder;
        }

        // UpdateReminder
        public static void UpdateReminder(int reminderId, int taskId, string message, DateTime time)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("UpdateReminder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@reminder_id", SqlDbType.Int).Value = reminderId;
                    command.Parameters.Add("@task_id", SqlDbType.Int).Value = taskId;
                    command.Parameters.Add("@message", SqlDbType.VarChar).Value = message;
                    command.Parameters.Add("@time", SqlDbType.DateTime).Value = time;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error updating reminder: " + ex.Message);
                        // Handle exception
                    }
                }
            }
        }

        // Delete Reminder
        public static void DeleteReminder(int reminderId)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CSRMSConnectionString"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("DeleteReminder", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.Add("@reminder_id", SqlDbType.Int).Value = reminderId;

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error deleting reminder: " + ex.Message);
                        // Handle exception
                    }
                }
            }
        }
    }
}