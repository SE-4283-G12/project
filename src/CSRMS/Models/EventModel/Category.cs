using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CSRMS.Models.EventModel
{
    public class Category
    {
        private int id { get; set; }
        private string name { get; set; }

        public Category(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public string getName()
        { return name; }
        public void setName(string name)
        {
            this.name = name;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }
    }
}
