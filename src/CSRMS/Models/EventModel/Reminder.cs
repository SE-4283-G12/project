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
        private string reminderMethod { get; set; }

        public Reminder(int reminderId, int taskId, string message, DateTime reminderDateTime, string reminderMethod)
        {
            this.implementation = null;
            this.reminderId = reminderId;
            this.message = message;
            this.taskId = taskId;
            this.reminderDateTime = reminderDateTime;
            this.reminderMethod = reminderMethod;
        }

        public void setImplementation(ReminderImplementation implementation)
        {
            this.implementation = implementation;
        }
        public void notify()
        {
            implementation.remind();
        }

        // Getter and setter functions for ReminderId
        public int GetReminderId()
        {
            return reminderId;
        }

        public void SetReminderId(int value)
        {
            reminderId = value;
        }

        // Getter and setter functions for Message
        public string GetMessage()
        {
            return message;
        }

        public void SetMessage(string value)
        {
            message = value;
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

        // Getter and setter functions for ReminderDateTime
        public DateTime GetReminderDateTime()
        {
            return reminderDateTime;
        }

        public void SetReminderDateTime(DateTime value)
        {
            reminderDateTime = value;
        }

        // Getter and setter functions for ReminderMethod

        public string GetReminderMethod()
        {
            return reminderMethod;
        }

        public void SetReminderMethod(string value)
        {
            reminderMethod = value;
        }

    }
}
