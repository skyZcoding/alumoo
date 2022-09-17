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
    }
}
