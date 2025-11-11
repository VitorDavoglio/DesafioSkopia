using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Results
{
    public class TaskQueryResult
    {
        public Guid ProjectId { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}
