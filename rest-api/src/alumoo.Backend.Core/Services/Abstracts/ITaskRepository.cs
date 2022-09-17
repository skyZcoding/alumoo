﻿using alumoo.Backend.Core.Domain.Models.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Services.Abstracts
{
    public interface ITaskRepository
    {
        Task AddTasksToRepository(List<TaskForProjectModel> tasks, int projectId);
        Task<List<TaskFromProjectModel>> GetTasksFromProject(int projectId);
    }
}
