using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Domain.Models.Project
{
    public class ProjectById
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public List<ProjectByIdTask> Tasks { get; set; }

    }
}
