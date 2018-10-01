using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesToDoList.Models
{
    public class ToDoNote
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string TaskDescription { get; set; }
        public string DutyHolder { get; set; }
        public bool InProgress { get; set; }
        public bool Done { get; set; }
    }
}
