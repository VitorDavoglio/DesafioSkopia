using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Commands;
using TaskManager.Application.Queries;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class TaskController(IMediator mediatr) : BaseController(mediatr)
    {
        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetTasksByProject([FromRoute] Guid projectId)
        {
            var query = new GetTasksByProjectQuery(projectId);
            return await GenerateApiResponseAsync(async () => await _mediatr.Send(query));
        }

        [HttpPost("project/{projectId}")]
        public async Task<IActionResult> CreateTaskOnProject([FromRoute] Guid projectId, [FromBody] AddNewTaskToProject newTask)
        {
            newTask.ProjectId = projectId;
            return await GenerateApiResponseAsync(async () => await _mediatr.Send(newTask));
        }

        [HttpPut("{taskId}")]
        public async Task<IActionResult> CreateTask([FromRoute] Guid taskId, [FromBody] UpdateTask taskToUpdate)
        {
            taskToUpdate.Id = taskId;
            return await GenerateApiResponseAsync(async () => await _mediatr.Send(taskToUpdate));
        }
        [HttpPatch("{taskId}")]
        public async Task<IActionResult> AddCommentToTask([FromHeader] Guid updater, [FromRoute] Guid taskId, [FromBody] AddCommentToTask taskComment)
        {
            taskComment.TaskId = taskId;
            taskComment.CommenterId = updater;
            return await GenerateApiResponseAsync(async () => await _mediatr.Send(taskComment));
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> RemoveTask([FromRoute] Guid taskId)
        {
            return await GenerateApiResponseAsync(async () => await _mediatr.Send(new DeleteTask() { Id = taskId }));
        }
    }
}
