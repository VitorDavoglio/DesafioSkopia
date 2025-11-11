using System;
using Threading = System.Threading.Tasks;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Services;
using TaskManager.Domain.Interfaces.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace TaskManager.Domain.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ICommandRepository<Project> _commandRepo;
        private readonly IQueryRepository<Project> _queryRepo;
        private readonly IQueryRepository<Task> _taskRepo;

        public ProjectService(ICommandRepository<Project> commandRepo, IQueryRepository<Project> queryRepo, IQueryRepository<Task> taskRepo)
        {
            _commandRepo = commandRepo;
            _queryRepo = queryRepo;
            _taskRepo = taskRepo;
        }

        public async Threading.Task DeleteProject(Project project)
        {
            var tasks = _taskRepo.Where(new Task() { ProjectId = project.Id });
            project.Tasks = tasks;
            if (project.Tasks != null && project.Tasks.Any(x => x.CurrentStatus == Enums.TaskStatus.Pending))
            {
                throw new InvalidOperationException("Não é possível deletar um projeto com tasks pendentes.");
            }
            project = _queryRepo.Find(new Project() { Id = project.Id });
            if (project == null) { 
                throw new KeyNotFoundException("O projeto não existe no banco de dados.");
            }
            await _commandRepo.DeleteAsync(project);
        }
    }
}
