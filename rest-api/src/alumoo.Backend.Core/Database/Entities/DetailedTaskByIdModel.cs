using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Database.Entities
{
    public class DetailedTaskByIdModel
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Skills { get; set; }
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
    }
}
