using alumoo.Backend.Core.Database;
using alumoo.Backend.Core.Database.Entities;
using alumoo.Backend.Core.Domain.Models.Suggestion;
using alumoo.Backend.Core.Services.Abstracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Services
{
    public class SuggestionService : ISuggestionService
    {
        private readonly HttpClient httpClient;
        private readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;
        private readonly IMapper mapper;

        public SuggestionService(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://20.250.66.50:5000");
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        public async Task<List<SuggestedTaskModel>> GetSuggestedTasks(int loadedTasks, int volunteerId)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"/{volunteerId}/{loadedTasks}");
            var taskIds = string.Empty;

            if (response.IsSuccessStatusCode)
            {
                taskIds = await response.Content.ReadAsStringAsync();
            }

            var tasksId = taskIds
                .Split(',')
                .Where(x => int.TryParse(x, out _))
                .Select(int.Parse)
                .ToList();

            using (var context = await dbContextFactory.CreateDbContextAsync())
            {
                var taskEntities = await context.Tasks
                    .Where(t => tasksId.Any(tId => tId == t.TaskId))
                    .ToListAsync();

                return mapper.Map<List<SuggestedTaskModel>>(taskEntities);
            }
        }
    }
}
