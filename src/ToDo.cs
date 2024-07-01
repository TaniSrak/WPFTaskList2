using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTaskList2.src
{
    public class ToDo
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool Done { get; set; }

        public DateTime Date { get; set; }
        public ToDo(string title, string description, DateTime date) 
        { 
            Title = title;
            Description = description;
            Date = date;
        }
    }
}
