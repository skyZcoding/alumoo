using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Domain.Models.Task
{
    public class FavoritTaskModel
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
    }
}
