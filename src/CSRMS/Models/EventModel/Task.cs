using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSRMS.Models.EventModel
{
    public class Task : TaskComponent
    {
        private int taskId { get; set; }
        private string title { get; set; }
        private bool isComplete { get; set; }
        private DateTime dueDateTime { get; set; }
        private DateTime startDateTime { get; set; }
        private string location { get; set; }
        private string description { get; set; }
        private Priority priority { get; set; }
        private List<Category> categories { get; set; }
        private List<Reminder> reminders { get; set; }

        public Task(int taskId, string title, bool isComplete, DateTime dueDateTime, DateTime startDateTime, string location, string description, Priority priority, List<Category> categories, List<Reminder> reminders)
        {
            this.taskId = taskId;
            this.title = title;
            this.isComplete = isComplete;
            this.dueDateTime = dueDateTime;
            this.startDateTime = startDateTime;
            this.location = location;
            this.description = description;
            this.categories = categories;
            this.priority = priority;
            this.reminders = reminders;
        }

        public string getDetails()
        {
            // Temp return value
            return "Details";
        }

        // Getter and setter functions for TaskId
        public int GetTaskId()
        {
            return taskId;
        }

        public void SetTaskId(int value)
        {
            taskId = value;
        }

        // Getter and setter functions for Title
        public string GetTitle()
        {
            return title;
        }

        public void SetTitle(string value)
        {
            title = value;
        }

        // Getter and setter functions for IsComplete
        public bool GetIsComplete()
        {
            return isComplete;
        }

        public void SetIsComplete(bool value)
        {
            isComplete = value;
        }

        // Getter and setter functions for DueDateTime
        public DateTime GetDueDateTime()
        {
            return dueDateTime;
        }

        public void SetDueDateTime(DateTime value)
        {
            dueDateTime = value;
        }

        // Getter and setter functions for StartDateTime
        public DateTime GetStartDateTime()
        {
            return startDateTime;
        }

        public void SetStartDateTime(DateTime value)
        {
            startDateTime = value;
        }

        // Getter and setter functions for Location
        public string GetLocation()
        {
            return location;
        }

        public void SetLocation(string value)
        {
            location = value;
        }

        // Getter and setter functions for Description
        public string GetDescription()
        {
            return description;
        }

        public void SetDescription(string value)
        {
            description = value;
        }

        // Getter and setter functions for Priority
        public Priority GetPriority()
        {
            return priority;
        }

        public void SetPriority(Priority value)
        {
            priority = value;
        }

        // Getter and setter functions for Categories
        public List<Category> GetCategories()
        {
            return categories;
        }

        public void SetCategories(List<Category> value)
        {
            categories = value;
        }

        // Getter and setter functions for Reminders
        public List<Reminder> GetReminders()
        {
            return reminders;
        }

        public void SetReminders(List<Reminder> value)
        {
            reminders = value;
        }

    }
}
