using alumoo.Backend.Core.Database.Entities;
using alumoo.Backend.Core.Domain.Models.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Services.Abstracts
{
    public interface ITaskRepository
    {
        Task AddApplication(int volunteerId, int taskId);
        Task AddApplicationToVolunteer(int volunteerId, int taskId);
        Task AddTasksToRepository(List<TaskForProjectModel> tasks, int projectId);
        Task<List<ApplicantsByTaskIdModel>> GetApplicatnsByTaskId(int taskId);
        Task<DetailedTaskByIdModel> GetDetailedTaskById(int taskId);
        Task<List<FavoritTaskModel>> GetFavoritTasks(int volunteerId);
        Task<List<TaskFromProjectModel>> GetTasksFromProject(int projectId);
        Task RemoveApplication(int volunteerId, int taskId);
        Task ToggleStarTask(int volunteerId, int taskId);
    }
}
