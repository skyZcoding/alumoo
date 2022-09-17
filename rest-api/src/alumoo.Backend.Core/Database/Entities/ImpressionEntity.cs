using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Database.Entities
{
    public class ImpressionEntity
    {
        public ImpressionEntity()
        {
            ImgUrl = string.Empty;
        }

        public int ImpressionId { get; set; }
        public string Content { get; set; }
        public string ImgUrl { get; set; }
        public TaskEntity Task { get; set; }
        public VolunteerEntity Volunteer { get; set; }
    }
}
