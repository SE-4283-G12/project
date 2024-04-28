using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSRMS.Models.EventModel
{
    public class Task : TaskComponent
    {
        private string taskId { get; set; }
        private string title { get; set; }
        private bool isComplete { get; set; }
        private DateTime dueDateTime { get; set; }
        private DateTime startDateTime { get; set; }
        private string location { get; set; }
        private string description { get; set; }
        private int priority { get; set; }
        private Category category { get; set; }
        private Reminder reminder { get; set; }

        public Task(string taskId, string title, bool isComplete, DateTime dueDateTime, DateTime startDateTime, string email, string location, string description, int priority, Category category, Reminder reminder)
        {
            this.taskId = taskId;
            this.title = title;
            this.isComplete = isComplete;
            this.dueDateTime = dueDateTime;
            this.startDateTime = startDateTime;
            this.email = email;
            this.location = location;
            this.description = description;
            this.category = category;
            this.priority = priority;
            this.reminder = reminder;
        }

        public string getDetails()
        {
            // Temp return value
            return "Details";
        }
    }
}
