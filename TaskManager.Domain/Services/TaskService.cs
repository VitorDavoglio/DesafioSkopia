using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Domain.Aggregate;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.Services;
using TaskManager.Domain.ValueObjects;

namespace TaskManager.Domain.Services
{
    public class TaskService : ITaskService
    {
        private readonly ICommandRepository<Entities.Task> _commandRepository;
        private readonly ICommandRepository<TaskChangeLog> _historyRepository;
        private readonly ICommandRepository<TaskComment> _commentsRepository;

        private readonly IQueryRepository<Entities.Task> _queryRepository;
        private readonly IQueryRepository<Project> _projectRepository;

        public TaskService(ICommandRepository<Entities.Task> commandRepository, ICommandRepository<TaskChangeLog> historyRepository, ICommandRepository<TaskComment> commentsRepository, IQueryRepository<Entities.Task> queryRepository, IQueryRepository<Project> projectRepository)
        {
            _commandRepository = commandRepository;
            _historyRepository = historyRepository;
            _commentsRepository = commentsRepository;
            _queryRepository = queryRepository;
            _projectRepository = projectRepository;
        }

        public async Task<Entities.Task> AddTaskToProject(Entities.Task newTask)
        {

            var project = _projectRepository.Find(new Project() { Id = newTask.ProjectId });
            
            if (project is null)
            {
                throw new InvalidOperationException("Não é possível inserir Task , o projeto não existe.");
            }
            if (project.HasReachMaximumTaskLimit)
            {
                throw new InvalidOperationException("O projeto atingiu seu limite máximo de tarefas.");
            }
            else
            {
                await _commandRepository.AddAsync(newTask);
            }
            newTask.Project = project;
            return newTask;
        }
        public async Task<Entities.Task> UpdateTaskAndSaveHistory(Entities.Task newState, Guid updaterId)
        {
            var entityToUpdate = _queryRepository.Find(new Entities.Task() { Id = newState.Id });
            if (entityToUpdate == null)
            {
                throw new InvalidOperationException("Não foi possível atualizar a task porque a task não existe.");
            }

            var changes = entityToUpdate.PrepareUpdate(newState, updaterId);
            await _commandRepository.UpdateAsync(entityToUpdate);
            await _historyRepository.AddAsync(new TaskChangeLog()
            {
                Changes = changes,
                TaskId = entityToUpdate.Id
            });
            return entityToUpdate;
        }
        public async Task<Entities.Task> AddCommentToTaskAndSaveHistory(Entities.Task task, Guid commenterId, string comment)
        {
            var entityToUpdate = _queryRepository.Find(new Entities.Task() { Id = task.Id });
            if (entityToUpdate == null)
            {
                throw new InvalidOperationException("Não foi possível adicionar comentários a task porque a task não existe.");
            }

            var taskComment = new TaskComment()
            {
                TaskId = entityToUpdate.Id,
                Comment = comment,
                Created = DateTime.Now,
                Creator = commenterId
            };
            await _commentsRepository.AddAsync(taskComment);
            await _historyRepository.AddAsync(new TaskChangeLog()
            {
                Changes = new List<TaskChange>() { new TaskChange() {
                    Field = "Comment",
                    PreviousValue = string.Empty,
                    UpdatedValue = taskComment.Comment,
                    UpdateDate = taskComment.Created,
                    UpdaterId = commenterId
                }},
                TaskId = entityToUpdate.Id
            });

            entityToUpdate.Comments = new List<string>() { taskComment.Comment };
            return entityToUpdate;
        }
    }
}
