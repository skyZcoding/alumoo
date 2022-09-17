using alumoo.Backend.Core.Database;
using alumoo.Backend.Core.Database.Entities;
using alumoo.Backend.Core.Domain.Models.Task;
using alumoo.Backend.Core.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Services
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public TaskRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task AddTasksToRepository(List<TaskForProjectModel> tasks, int projectId)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var project = await context.Projects.FindAsync(projectId);
                var taskEntities = new List<TaskEntity>();

                foreach (var task in tasks)
                {
                    taskEntities.Add(new TaskEntity
                    {
                        Title = task.Title,
                        Description = task.Description,
                        HoursPerWeek = task.HoursPerWeek,
                        NoOfVolunteers = task.NoOfVolunteers,
                        Location = task.Location,
                        Skills = task.Skills,
                        Project = project
                    });
                }

                await context.AddRangeAsync(taskEntities);
                await context.SaveChangesAsync();
            }
        }
    }
}
