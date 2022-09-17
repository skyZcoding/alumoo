using alumoo.Backend.Core.Domain.Models.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Services.Abstracts
{
    public interface IProjectRepository
    {
        Task<int> CreateProject(CreateProjectModel project);
        Task<List<FavoritProjectModel>> GetFavoritProjects(int volunteerId);
        Task<ProjectById> GetProjectById(int projectId);
    }
}
