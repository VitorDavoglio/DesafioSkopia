using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Queries;
using TaskManager.Domain.Enums;
using TaskManager.Filter;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ReportController(IMediator mediatr) : BaseController(mediatr)
    {

        [RoleFilterAttribute(AllowedRoles = [UserRole.Manager])]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetPerformanceReports([FromHeader(Name = "logged-user-id")] Guid loggedUserId, [FromRoute] Guid userId)
        {
            var query = new GetProjectsByUserQuery(userId);
            return await GenerateApiResponseAsync(async () => await _mediatr.Send(query));
        }
    }
}
