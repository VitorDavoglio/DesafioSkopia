using MediatR;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Commands
{
    public class AddNewProject : IRequest<Unit>
    {
        public Guid OwnerId { get; set; }

        public static explicit operator Project(AddNewProject newProject)
        {
            return new Project()
            {
                OwnerId = newProject.OwnerId,
            };
        }
    }
}
