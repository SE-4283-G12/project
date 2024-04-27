using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSRMS.Models.EventModel
{
    public class Task : TaskComponent
    {
        private string id { get; set; }
        private string title { get; set; }
        private bool isComplete { get; set; }
        private DateTime dueDateTime { get; set; }
        private DateTime startDateTime { get; set; }
        private string email { get; set; }
        private string location { get; set; }
        private string description { get; set; }
        private int priority { get; set; }
        private List<Category> categories { get; set; }
        private Reminder reminder { get; set; }

        public Task(string id, string title, bool isComplete, DateTime dueDateTime, DateTime startDateTime, string email, string location, string description, int priority, List<Category> categories, Reminder reminder)
        {
            this.id = id;
            this.title = title;
            this.isComplete = isComplete;
            this.dueDateTime = dueDateTime;
            this.startDateTime = startDateTime;
            this.email = email;
            this.location = location;
            this.description = description;
            this.categories = categories;
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
