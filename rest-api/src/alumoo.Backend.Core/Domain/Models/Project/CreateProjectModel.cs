using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Domain.Models.Project
{
    public class CreateProjectModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
