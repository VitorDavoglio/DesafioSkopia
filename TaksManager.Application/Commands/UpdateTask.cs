using MediatR;
using System.Text.Json.Serialization;
using Task = TaskManager.Domain.Entities.Task;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Application.Commands
{
    public class UpdateTask : IRequest<Task>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public Guid UpdaterId { get; set; }
        public string Details { get; set; }
        public TaskStatus Status { get; set; }

        public static explicit operator Task(UpdateTask update) {
            return new Task()
            {
                Id = update.Id,
                CurrentStatus = update.Status,
                Description = update.Details,
            };
        }
    }
}
