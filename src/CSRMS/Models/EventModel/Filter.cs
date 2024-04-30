using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CSRMS.Models.EventModel
{
    public struct Filter
    {
        public string title;
        public DateTime? startDate;
        public string category;
        public Priority? priority;
        public bool titleIsEmpty;
        public bool startDateIsEmpty;
        public bool categoryIsEmpty;
        public bool priorityIsEmpty;

        // empty filter
        public Filter(bool isEmpty)
        {
            isEmpty = true;
            // SetTitle
            titleIsEmpty = isEmpty;
            this.title = "";

            // SetDate
            startDateIsEmpty = isEmpty;
            this.startDate = null;

            // Set Category
            categoryIsEmpty = isEmpty;
            this.category = "";

            // Set Priority
            priorityIsEmpty = isEmpty;
            this.priority = null;
        }

        public Filter(string title, DateTime? startDate, string category, Priority? priority)
        {
            // SetTitle
            titleIsEmpty = (title == "" ? true : false);
            this.title = title;

            // SetDate
            startDateIsEmpty = (startDate == null ? true : false);
            this.startDate = startDate;

            // Set Category
            categoryIsEmpty = (category == "" ? true : false);
            this.category = category;

            // Set Priority
            priorityIsEmpty = (priority == null ? true : false);
            this.priority = priority;
        }

        public static string getTitleFilter(string title)
        {
            // Trip the title
            title = title.Trim();
            // return title or empty string
            return title;
        }
        public static DateTime? getStartDateFilter(string startDate)
        {
            // check to see if the startDate is empty
            if (string.IsNullOrEmpty(startDate)) return null;
            else
            {
                // Convert string to datetime
                DateTime startDateDateTime;
                if (DateTime.TryParseExact(startDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDateDateTime)) return startDateDateTime.Date;
                else return null;
            }
        }
        public static string getCategoryFilter(string category)
        {
            // Trip the category
            category = category.Trim();
            // return category or empty string
            return category;
        }
        public static Priority? getPriorityFilter(string priority)
        {
            switch (priority)
            {
                case "Urgent": return Priority.Urgent;
                case "High": return Priority.High;
                case "Medium": return Priority.Medium;
                case "Low": return Priority.Low;
                default: return null;
            }
        }
    }
}
