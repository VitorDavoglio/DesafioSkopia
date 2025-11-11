using MediatR;
using TaskManager.Application.Commands;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Domain.Interfaces.Services;

namespace TaskManager.Application.Handlers
{
    public class ProjectCommandsHandler : IRequestHandler<AddNewProject, Unit>, IRequestHandler<DeleteProject,Unit>
    {
        private readonly ICommandRepository<Project> _commandRepo;
        private readonly IQueryRepository<User> _userRepo;
        private readonly IProjectService _service;

        public ProjectCommandsHandler(ICommandRepository<Project> commandRepo, IQueryRepository<User> userRepo, IProjectService service)
        {
            _commandRepo = commandRepo;
            _userRepo = userRepo;
            _service = service;
        }

        public async Task<Unit> Handle(AddNewProject request, CancellationToken cancellationToken)
        {
            var user = _userRepo.Find(new User()
            {
                Id = request.OwnerId
            });

            var entity = (Project)request;
            await _commandRepo.AddAsync(entity);
            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteProject request, CancellationToken cancellationToken)
        {
            await _service.DeleteProject((Project)request);
            return Unit.Value;
        }
    }
}
