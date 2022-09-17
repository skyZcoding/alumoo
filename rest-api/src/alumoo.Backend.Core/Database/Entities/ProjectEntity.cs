using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Database.Entities
{
    public class ProjectEntity
    {
        public ProjectEntity()
        {
            ImgUrl = string.Empty;
            Tasks = new List<TaskEntity>();
            Followers = new List<VolunteerEntity>();
        }

        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public UserEntity Owner { get; set; }
        public List<TaskEntity> Tasks { get; set; }
        public List<VolunteerEntity> Followers { get; set; }
    }
}
