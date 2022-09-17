using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Database.Entities
{
    public class TaskEntity
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public string Skills { get; set; }
        public int HoursPerWeek { get; set; }
        public string Location { get; set; }
        public int NoOfVolunteers { get; set; }
        public ProjectEntity Project { get; set; }
        public List<VolunteerEntity> Volunteers { get; set; }
        public List<VolunteerEntity> Applicants { get; set; }
        public List<ImpressionEntity> Impressions { get; set; }
    }
}
