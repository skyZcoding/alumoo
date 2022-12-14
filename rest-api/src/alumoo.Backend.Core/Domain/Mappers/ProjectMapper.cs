using alumoo.Backend.Core.Database.Entities;
using alumoo.Backend.Core.Domain.Models.Project;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Domain.Mappers
{
    public class ProjectMapper : Profile
    {
        public ProjectMapper()
        {
            CreateMap<ProjectEntity, FavoritProjectModel>();
        }
    }
}
