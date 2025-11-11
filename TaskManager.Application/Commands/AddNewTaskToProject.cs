using MediatR;
using System.Text.Json.Serialization;
using Task = TaskManager.Domain.Entities.Task;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;
using TaskPriority = TaskManager.Domain.Enums.TaskPriority;


namespace TaskManager.Application.Commands
{
    public class AddNewTaskToProject : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatus CurrentStatus { get; set; }
        public TaskPriority Priority { get; set; }

        public static explicit operator Task(AddNewTaskToProject newTask)
        {
            return new Task()
            {
                CurrentStatus = newTask.CurrentStatus,
                Description = newTask.Description,
                DueDate = newTask.DueDate,
                Title = newTask.Title,
                ProjectId = newTask.ProjectId,
                Priority  = newTask.Priority,
            };
        }
    }
}
