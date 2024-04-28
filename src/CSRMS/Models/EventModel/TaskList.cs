using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSRMS.Models.EventModel
{
    public class TaskList : TaskComponent
    {
        private List<TaskComponent> tasks;
        public new void add(TaskComponent task)
        {
            tasks.Add(task);
        }
        public new void remove(TaskComponent task)
        {
            tasks.Remove(task);
        }
        public new TaskComponent getChild(int i)
        {
            return tasks[i];
        }
        public void operation()
        {
           
        }
    }
}
