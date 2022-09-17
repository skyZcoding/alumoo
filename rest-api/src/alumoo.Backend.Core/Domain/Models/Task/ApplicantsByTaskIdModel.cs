using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Domain.Models.Task
{
    public class ApplicantsByTaskIdModel
    {
        public int VolunteerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
