using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSRMS.Models.EventModel
{
    public class Reminder
    {
        private ReminderImplementation implementation { get; set; }
        private int id { get; set; }
        private int taskId { get; set; }
        private string message { get; set; }
        private DateTime time { get; set; }

        public Reminder(int id, int taskId, string message, DateTime time)
        {
            this.id = id;
            implementation = null;
            this.taskId = taskId;
            this.message = message;
            this.time = time;
        }

        public void setImplementation(ReminderImplementation implementation)
        {
            this.implementation = implementation;
        }
        public void notify()
        {
        }
    }
}
