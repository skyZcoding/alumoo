﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Domain.Models.Suggestion
{
    public class SuggestedTaskModel
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
    }
}
