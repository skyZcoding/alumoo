using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Domain.Models.Task
{
    public class TaskFromProjectModel
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Database.Entities.Enums.TaskStatus Status { get; set; }
        public string Skills { get; set; }
        public int HoursPerWeek { get; set; }
        public string Location { get; set; }
        public int NoOfVolunteers { get; set; }
    }
}
