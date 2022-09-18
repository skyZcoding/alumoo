using alumoo.Backend.Core.Database;
using alumoo.Backend.Core.Database.Entities;
using alumoo.Backend.Core.Domain.Models.Project;
using alumoo.Backend.Core.Services.Abstracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Services
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly IMapper _mapper;

        public ProjectRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
        {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }

        public async Task<int> CreateProject(CreateProjectModel project)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var user = await context.Users.FindAsync(project.UserId);

                var projectEntity = new ProjectEntity
                {
                    Title = project.Title,
                    Description = project.Description,
                    Owner = user
                };

                await context.Projects.AddAsync(projectEntity);
                await context.SaveChangesAsync();

                return context.Projects
                    .FirstOrDefault(p => p.Title == project.Title &&
                    p.Description == project.Description).ProjectId;
            }
        }

        public async Task<List<FavoritProjectModel>> GetFavoritProjects(int volunteerId)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var entities = await context.Projects
                    .Where(p => p.Followers.Any(f => f.VolunteerId == volunteerId))
                    .ToListAsync();

                return _mapper.Map<List<FavoritProjectModel>>(entities);
            }
        }

        public async Task<ProjectById> GetProjectById(int projectId)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var projectEntity = await context.Projects
                    .Include(p => p.Tasks)
                    .FirstOrDefaultAsync(p => p.ProjectId == projectId);
                var projectModel = new ProjectById
                {
                    Title = projectEntity.Title,
                    Description = projectEntity.Description,
                    ProjectId = projectId,
                    Tasks = new List<ProjectByIdTask>()
                };

                foreach (var task in projectEntity.Tasks)
                {
                    projectModel.Tasks.Add(new ProjectByIdTask
                    {
                        Title = task.Title,
                        Location = task.Location,
                        TaskId = task.TaskId
                    });
                }

                return projectModel;
            }
        }

        public async Task<ProjectsByOwnerIdModel> GetProjectsByOwnerId(int ownerId)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var ownerEntity = await context.Users.FindAsync(ownerId);
                var ownerModel = new ProjectsByOwnerIdModel
                {
                    OwnerId = ownerId,
                    OwnerName = ownerEntity.FirstName + " " + ownerEntity.LastName,
                    Projects = new List<ProjectsByOwnerIdProjectModel>()
                };

                foreach (var project in await context.Projects
                    .Where(p => p.Owner.UserId == ownerId)
                    .ToListAsync())
                {
                    ownerModel.Projects.Add(new ProjectsByOwnerIdProjectModel
                    {
                        Title = project.Title,
                        Description = project.Description,
                        ProjectId = project.ProjectId
                    });
                }

                return ownerModel;
            }
        }
    }
}
