﻿using alumoo.Backend.Core.Database;
using alumoo.Backend.Core.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Services
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public ProjectRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


    }
}