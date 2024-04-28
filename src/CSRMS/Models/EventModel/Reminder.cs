using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSRMS.Models.EventModel
{
    public class Reminder
    {
        private ReminderImplementation implementation { get; set; }
        private int reminderId { get; set; }
        private string message { get; set; }
        private int taskId { get; set; }
        private DateTime reminderDateTime { get; set; }

        public Reminder(int reminderId, int taskId, string message, DateTime reminderDateTime)
        {
            this.implementation = null;
            this.reminderId = reminderId;
            this.message = message;
            this.taskId = taskId;
            this.reminderDateTime = reminderDateTime;
        }

        public void setImplementation(ReminderImplementation implementation)
        {
            this.implementation = implementation;
        }
        public void notify()
        {
            implementation.notify();
        }
    }
}
