using MediatR;
using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Application.Commands
{
    public class DeleteTask : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public static explicit operator Task(DeleteTask delete)
        {
            return new Task() { Id = delete.Id };
        }
    }
}
