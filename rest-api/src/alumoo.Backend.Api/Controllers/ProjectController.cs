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

        //[HttpGet("getStaredProjects")]
        //public async Task<ActionResult> GetStaredProjects()
        //{

        //}

    }
}
