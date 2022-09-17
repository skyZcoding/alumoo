using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Domain.Models.Task
{
    public class TaskForProjectModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Skills { get; set; }
        public int HoursPerWeek { get; set; }
        public string Location { get; set; }
        public int NoOfVolunteers { get; set; }
    }
}
