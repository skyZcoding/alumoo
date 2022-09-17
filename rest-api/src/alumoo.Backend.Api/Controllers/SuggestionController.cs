using alumoo.Backend.Core.Domain.Models.Suggestion;
using alumoo.Backend.Core.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alumoo.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        private readonly ISuggestionService _suggestionService;

        public SuggestionController(ISuggestionService suggestionService)
        {
            _suggestionService = suggestionService;
        }

        [HttpGet("getSuggestedTasks")]
        public async Task<ActionResult<List<SuggestedTaskModel>>> GetSuggestedTasks(int loadedTasks, int volunteerId)
        {
            return await _suggestionService.GetSuggestedTasks(loadedTasks, volunteerId);
        }
    }
}
