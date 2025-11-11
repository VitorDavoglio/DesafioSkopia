using TaskManager.Application.Commands;
using Entities = TaskManager.Domain.Entities;
using MediatR;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.Services;

namespace TaskManager.Application.Handlers
{
    public class TaskCommandsHandler : IRequestHandler<AddNewTaskToProject, Unit>, IRequestHandler<UpdateTask, Entities.Task>, IRequestHandler<DeleteTask, Unit>, IRequestHandler<AddCommentToTask,Unit>
    {
        private readonly ICommandRepository<Entities.Task> _commandRepo;
        private readonly IQueryRepository<Entities.Task> _queryRepo;
        private readonly ITaskService _taskService;

        public TaskCommandsHandler(ICommandRepository<Entities.Task> commandRepo, IQueryRepository<Entities.Task> queryRepo, ITaskService updateTaskService)
        {
            _commandRepo = commandRepo;
            _queryRepo = queryRepo;
            _taskService = updateTaskService;
        }

        public async Task<Unit> Handle(AddNewTaskToProject request, CancellationToken cancellationToken)
        {
            await _taskService.AddTaskToProject((Entities.Task)request);
            return Unit.Value;
        }
        public async Task<Entities.Task> Handle(UpdateTask request, CancellationToken cancellationToken)
        {
            var newState = (Entities.Task)request;
            return await _taskService.UpdateTaskAndSaveHistory(newState, request.UpdaterId);
        }
        public async Task<Unit> Handle(DeleteTask request, CancellationToken cancellationToken)
        {
            var entityToDelete = _queryRepo.Find(new Entities.Task() { Id = request.Id });
            await _commandRepo.DeleteAsync(entityToDelete);
            return Unit.Value;
        }
        public async Task<Unit> Handle(AddCommentToTask request, CancellationToken cancellationToken)
        {
            await _taskService.AddCommentToTaskAndSaveHistory(new Entities.Task() { Id = request.TaskId }, request.CommenterId, request.Comment);
            return Unit.Value;
        }
    }
}
