using MediatR;
using TaskManager.Application.Queries;
using TaskManager.Application.Resources;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces.Repositories;

namespace TaskManager.Application.Handlers
{
    public class ProjectQueriesHandler : IRequestHandler<GetProjectsByUserQuery, ProjectQueryResult>
    {
        private readonly IQueryRepository<Project> _queryRepo;

        public ProjectQueriesHandler(IQueryRepository<Project> queryRepo)
        {
            _queryRepo = queryRepo;
        }

        public async Task<ProjectQueryResult> Handle(GetProjectsByUserQuery request, CancellationToken cancellationToken)
        {
            var results = _queryRepo.Where((Project)request);
            return new ProjectQueryResult()
            {
                Projects = results,
                User = request.UserId.ToString(),
            };
        }
    }
}
