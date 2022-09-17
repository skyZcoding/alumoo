using alumoo.Backend.Core.Database;
using alumoo.Backend.Core.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Services
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public TaskRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
    }
}
