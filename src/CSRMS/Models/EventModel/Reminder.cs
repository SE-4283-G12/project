using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSRMS.Models.EventModel
{
    public class Reminder
    {
        private ReminderImplementation implementation { get; set; }
        private string message { get; set; }
        public void setImplementation(ReminderImplementation implementation)
        {
            this.implementation = implementation;
        }
        public void notify()
        {
        }
    }
}
