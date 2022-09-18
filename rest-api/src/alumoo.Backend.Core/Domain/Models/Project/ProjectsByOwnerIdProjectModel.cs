using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Domain.Models.Project
{
    public class ProjectsByOwnerIdProjectModel
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
