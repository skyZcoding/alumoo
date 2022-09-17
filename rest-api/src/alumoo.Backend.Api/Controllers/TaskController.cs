using alumoo.Backend.Core.Database.Entities;
using alumoo.Backend.Core.Domain.Models.Project;
using alumoo.Backend.Core.Domain.Models.Task;
using alumoo.Backend.Core.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alumoo.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _repository;

        public TaskController(ITaskRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getTaskFromProject")]
        public async Task<ActionResult<List<TaskFromProjectModel>>> GetTasksFromProject(int projectId)
        {
            var tasks = await _repository.GetTasksFromProject(projectId);

            return Ok(tasks);
        }

        [HttpPost("createTasksForProject")]
        public async Task<ActionResult> CreateTasksForProjects(List<TaskForProjectModel> tasks, int projectId)
        {
            await _repository.AddTasksToRepository(tasks, projectId);

            return Ok();
        }

        [HttpPost("addApplication")]
        public async Task<ActionResult> AddApplication(int volunteerId, int taskId)
        {
            await _repository.AddApplication(volunteerId, taskId);

            return Ok();
        }

        [HttpDelete("denyApplication")]
        public async Task<ActionResult> DenyApplicaiton(int volunteerId, int taskId)
        {
            await _repository.RemoveApplication(volunteerId, taskId);

            return Ok();
        }

        [HttpPost("acceptApplication")]
        public async Task<ActionResult> AcceptApplication(int volunteerId, int taskId)
        {
            await _repository.AddApplicationToVolunteer(volunteerId, taskId);
            await _repository.RemoveApplication(volunteerId, taskId);

            return Ok();
        }

        [HttpPost("toggleStarTask")]
        public async Task<ActionResult> ToggleStarTask(int volunteerId, int taskId)
        {
            await _repository.ToggleStarTask(volunteerId, taskId);

            return Ok();
        }

        [HttpGet("getFavoritTasks")]
        public async Task<ActionResult<List<FavoritTaskModel>>> GetFavoritTasks(int volunteerId)
        {
            return Ok(await _repository.GetFavoritTasks(volunteerId));
        }

        [HttpGet("getApplicantsByTaskId")]
        public async Task<ActionResult<List<ApplicantsByTaskIdModel>>> GetApplicantsByTaskId(int taskId)
        {
            return Ok(await _repository.GetApplicatnsByTaskId(taskId));
        }

        [HttpGet("getDetailedTaskById")]
        public async Task<ActionResult<DetailedTaskByIdModel>> GetDetailedTaskById(int taskId)
        {
            return Ok(await _repository.GetDetailedTaskById(taskId));
        }

    }
}
