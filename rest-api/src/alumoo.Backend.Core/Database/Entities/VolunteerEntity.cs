using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Database.Entities
{
    public class VolunteerEntity
    {
        public VolunteerEntity()
        {
            Skills = string.Empty;
            Impressions = new List<ImpressionEntity>();
            Tasks = new List<TaskEntity>();
            Applications = new List<TaskEntity>();
            FavoritProjects = new List<ProjectEntity>();
        }

        public int VolunteerId { get; set; }
        public string Location { get; set; }
        public string Skills { get; set; }
        public UserEntity User { get; set; }
        public List<ImpressionEntity> Impressions { get; set; }
        public List<TaskEntity> Tasks { get; set; }
        public List<TaskEntity> Applications { get; set; }
        public List<ProjectEntity> FavoritProjects { get; set; }
    }
}
