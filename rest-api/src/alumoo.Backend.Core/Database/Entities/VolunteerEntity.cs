using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Database.Entities
{
    public class VolunteerEntity
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Skills { get; set; }
        public UserEntity User { get; set; }
        public List<ImpressionEntity> Impressions { get; set; }
        public List<TaskEntity> Tasks { get; set; }
        public List<TaskEntity> Applications { get; set; }
    }
}
