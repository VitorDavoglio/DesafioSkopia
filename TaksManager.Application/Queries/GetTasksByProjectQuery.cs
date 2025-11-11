using MediatR;
using TaskManager.Application.Results;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Queries
{
    public class GetTasksByProjectQuery : IRequest<TaskQueryResult>
    {
        public GetTasksByProjectQuery(Guid projectId)
        {
            ProjectId = projectId;
        }

        public Guid ProjectId { get; set; }

        public static explicit operator Task(GetTasksByProjectQuery query) {
            return new Task()
            {
                ProjectId = query.ProjectId,
            };
        }
    }
}
