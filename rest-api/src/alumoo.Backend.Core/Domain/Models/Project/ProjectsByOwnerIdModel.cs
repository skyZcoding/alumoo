using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Domain.Models.Project
{
    public class ProjectsByOwnerIdModel
    {
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public List<ProjectsByOwnerIdProjectModel> Projects { get; set; }
    }
}
