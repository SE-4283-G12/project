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
        private string location { get; set; }
        private string description { get; set; }
        private Category category { get; set; }
        private Reminder reminder { get; set; }
        public string getDetails()
        {
            // Temp return value
            return "Details";
        }
    }
}
