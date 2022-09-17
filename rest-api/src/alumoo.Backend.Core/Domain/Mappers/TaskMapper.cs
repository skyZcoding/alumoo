using alumoo.Backend.Core.Database.Entities;
using alumoo.Backend.Core.Domain.Models.Suggestion;
using alumoo.Backend.Core.Domain.Models.Task;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Domain.Mappers
{
    public class TaskMapper : Profile
    {
        public TaskMapper()
        {
            CreateMap<TaskEntity, TaskFromProjectModel>();

            CreateMap<TaskEntity, SuggestedTaskModel>();
        }
    }
}
