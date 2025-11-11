using MediatR;
using TaskManager.Application.Resources;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Queries
{
    public class GetProjectsByUserQuery: IRequest<ProjectQueryResult>
    {
        public GetProjectsByUserQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }

        public static explicit operator Project(GetProjectsByUserQuery query) {
            return new Project()
            {
                Owner = new User()
                {
                    Id = query.UserId,
                }
            };
        }
    }

}
