using alumoo.Backend.Core.Domain.Models.User;
using alumoo.Backend.Core.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alumoo.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("createUser")]
        public async Task<ActionResult<int>> CreateUser(CreateUserModel user)
        {
            var userId = await _repository.CreateUser(user);

            return Ok(userId);
        }

        [HttpPost("addUserToVolunteers")]
        public async Task<ActionResult<int>> AddUserToVolunteers(UserToVolunteerModel volunteer)
        {
            var volunteerId = await _repository.AddUserToVolunteers(volunteer);

            return Ok(volunteerId);
        }

        [HttpPost("addImpressionToVolunteer")]
        public async Task<ActionResult> AddImpressionToVolunteer(ImpressionToVolunteerModel impression)
        {
            await _repository.AddImpressionToVolunteer(impression);

            return Ok();
        }
    }
}
