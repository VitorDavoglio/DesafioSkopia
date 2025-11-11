using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Commands
{
    public class DeleteProject:IRequest<Unit>
    {
        public Guid ProjectId { get; set; }

        public static explicit operator Project(DeleteProject deleteProject) {
            return new Project()
            {
                Id = deleteProject.ProjectId,
            };
        }
    }
}
