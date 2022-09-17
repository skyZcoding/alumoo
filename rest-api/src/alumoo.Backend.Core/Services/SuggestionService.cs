using alumoo.Backend.Core.Domain.Models.Suggestion;
using alumoo.Backend.Core.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Services
{
    public class SuggestionService : ISuggestionService
    {
        public Task<List<SuggestedTaskModel>> GetSuggestedTasks(int loadedTasks, int volunteerId)
        {
            throw new NotImplementedException();
        }
    }
}
