using alumoo.Backend.Core.Domain.Models.Project;
using alumoo.Backend.Core.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alumoo.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _repository;

        public ProjectController(IProjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getFavoritProjects")]
        public async Task<ActionResult<List<FavoritProjectModel>>> GetFavoritProjects(int volunteerId)
        {
            return Ok(await _repository.GetFavoritProjects(volunteerId));
        }

        [HttpPost("createProject")]
        public async Task<ActionResult<int>> CreateProject(CreateProjectModel project)
        {
            var projectId = await _repository.CreateProject(project);

            return Ok(projectId);
        }

        [HttpGet("getProjectById")]
        public async Task<ActionResult<ProjectById>> GetProjectById(int projectId)
        {
            var project = await _repository.GetProjectById(projectId);

            return Ok(project);
        }

        [HttpGet("getProjectsByOwnerId")]
        public async Task<ActionResult<ProjectsByOwnerIdModel>> GetProjectsByOwnerId(int ownerId)
        {
            return Ok(await _repository.GetProjectsByOwnerId(ownerId));
        }
    }
}
