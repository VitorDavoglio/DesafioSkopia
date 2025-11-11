using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands;
using TaskManager.Application.Queries;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ProjectController(IMediator mediatr) : BaseController(mediatr)
    {

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetProjectsByUser([FromRoute] Guid userId)
        {
            var query = new GetProjectsByUserQuery(userId);
            return await GenerateApiResponseAsync(async () => await _mediatr.Send(query));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] AddNewProject newProject)
        {
            return await GenerateApiResponseAsync(async () => await _mediatr.Send(newProject));
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject([FromBody] AddNewProject newProject)
        {
            return await GenerateApiResponseAsync(async () => await _mediatr.Send(newProject));
        }
    }
}
