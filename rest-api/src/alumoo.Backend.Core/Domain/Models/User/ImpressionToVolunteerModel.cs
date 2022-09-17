using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Domain.Models.User
{
    public class ImpressionToVolunteerModel
    {
        public string Content { get; set; }
        public int VolunteerId { get; set; }
        public int TaskId { get; set; }
    }
}
