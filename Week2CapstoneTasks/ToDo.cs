using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2CapstoneTasks
{
    public class ToDo
    {
        public string Asignee { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public bool Done { get; set; }
        public ToDo(string asignee, string description, string dueDate)
        {
            Asignee = asignee;
            Description = description;
            DueDate = dueDate;
        }

    }
}
