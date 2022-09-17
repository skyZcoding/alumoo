using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Database.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {
            ImgUrl = string.Empty;
            Projects = new List<ProjectEntity>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ImgUrl { get; set; }
        public List<ProjectEntity> Projects { get; set; }
    }
}
