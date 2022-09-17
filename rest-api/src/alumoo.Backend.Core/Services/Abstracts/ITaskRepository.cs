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
        Task<List<FavoritTaskModel>> GetFavoritTasks(int volunteerId);
        Task<List<TaskFromProjectModel>> GetTasksFromProject(int projectId);
        Task RemoveApplication(int volunteerId, int taskId);
        Task StartTask(int volunteerId, int taskId);
    }
}
