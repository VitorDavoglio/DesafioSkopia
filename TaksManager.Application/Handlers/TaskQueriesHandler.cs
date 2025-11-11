using MediatR;
using TaskManager.Application.Queries;
using TaskManager.Application.Results;
using TaskManager.Domain.Interfaces.Repositories;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Handlers
{
    public class TaskQueriesHandler : IRequestHandler<GetTasksByProjectQuery, TaskQueryResult>
    {
        private readonly IQueryRepository<Task> _queryRepository;

        public TaskQueriesHandler(IQueryRepository<Task> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<TaskQueryResult> Handle(GetTasksByProjectQuery request, CancellationToken cancellationToken)
        {
            var results = _queryRepository.Where((Task)request);
            return new TaskQueryResult()
            {
                ProjectId = request.ProjectId,
                Tasks = results.ToList()
            };
        }
    }
}
