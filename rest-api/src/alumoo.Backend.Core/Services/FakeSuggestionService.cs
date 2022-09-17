using alumoo.Backend.Core.Domain.Models.Suggestion;
using alumoo.Backend.Core.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using alumoo.Backend.Core.Database;
using AutoMapper;

namespace alumoo.Backend.Core.Services
{
    public class FakeSuggestionService : ISuggestionService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly IMapper _mapper;

        public FakeSuggestionService(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
        {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }

        public async Task<List<SuggestedTaskModel>> GetSuggestedTasks(int loadedTasks, int volunteerId)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var taskEntities = await context.Tasks.ToListAsync();
                
                return _mapper.Map<List<SuggestedTaskModel>>(taskEntities);
            }
        }
    }
}
