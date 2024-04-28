using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CSRMS.Models.EventModel
{
    public class Category
    {
        private string name { get; set; }
        public string getName()
        { return name; }
        public void setName(string name)
        {
            this.name = name;
        }
    }
}
