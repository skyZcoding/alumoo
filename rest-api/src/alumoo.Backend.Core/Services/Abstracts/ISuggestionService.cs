using alumoo.Backend.Core.Domain.Models.Suggestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Services.Abstracts
{
    public interface ISuggestionService
    {
        public Task<List<SuggestedTaskModel>> GetSuggestedTasks(int loadedTasks, int volunteerId);
    }
}
