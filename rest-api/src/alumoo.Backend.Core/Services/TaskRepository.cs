using alumoo.Backend.Core.Database;
using alumoo.Backend.Core.Database.Entities;
using alumoo.Backend.Core.Domain.Models.Project;
using alumoo.Backend.Core.Domain.Models.Task;
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
    public class TaskRepository : ITaskRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly IMapper _mapper;

        public TaskRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
        {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }

        public async Task AddApplication(int volunteerId, int taskId)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var volunteer = await context.Volunteers.FindAsync(volunteerId);
                var task = await context.Tasks.FindAsync(taskId);

                task.Applicants.Add(volunteer);

                context.Update(task);
                await context.SaveChangesAsync();
            };
        }

        public async Task AddApplicationToVolunteer(int volunteerId, int taskId)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var volunteer = await context.Volunteers.FindAsync(volunteerId);
                var task = await context.Tasks.FindAsync(taskId);

                task.Volunteers.Add(volunteer);

                context.Update(task);
                await context.SaveChangesAsync();
            }
        }

        public async Task AddTasksToRepository(List<TaskForProjectModel> tasks, int projectId)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var project = context.Projects.FirstOrDefault(p => p.ProjectId == projectId);
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

        public async Task<List<TaskFromProjectModel>> GetTasksFromProject(int projectId)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var entites = await context.Tasks
                    .Where(t => t.Project.ProjectId == projectId)
                    .ToListAsync();

                return _mapper.Map<List<TaskFromProjectModel>>(entites);
            }
        }

        public async Task RemoveApplication(int volunteerId, int taskId)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var volunteer = await context.Volunteers.FindAsync(volunteerId);
                var task = await context.Tasks.FindAsync(taskId);

                task.Applicants.Remove(volunteer);

                context.Update(task);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<FavoritTaskModel>> GetFavoritTasks(int volunteerId)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var entities = await context.Tasks
                    .Where(p => p.Followers.Any(f => f.VolunteerId == volunteerId))
                    .ToListAsync();

                return _mapper.Map<List<FavoritTaskModel>>(entities);
            }
        }

        public async Task StartTask(int volunteerId, int taskId)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var volunteer = await context.Volunteers.FindAsync(volunteerId);
                var task = await context.Tasks.FindAsync(taskId);

                task.Followers.Add(volunteer);
                context.Tasks.Update(task);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<ApplicantsByTaskIdModel>> GetApplicatnsByTaskId(int taskId)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var task = await context.Tasks
                    .Include(t => t.Applicants)
                    .ThenInclude(a => a.User)
                    .FirstOrDefaultAsync(t => t.TaskId == taskId);
                var applicants = task.Applicants;
                var applicantModels = new List<ApplicantsByTaskIdModel>();

                foreach (var applicant in applicants)
                {
                    applicantModels.Add(new ApplicantsByTaskIdModel
                    {
                        VolunteerId = applicant.VolunteerId,
                        FirstName = applicant.User.FirstName,
                        LastName = applicant.User.LastName
                    });
                }

                return applicantModels;
            }
        }
    }
}
